using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

using System.Collections.Generic;

namespace WF_Chapter09.CheckTasksWorkflow
{
    public sealed partial class CheckTasksWorkflow : SequentialWorkflowActivity
    {
        public CheckTasksWorkflow()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public static DependencyProperty DetailsProperty = DependencyProperty.Register("Details", typeof(System.String), typeof(WF_Chapter09.CheckTasksWorkflow.CheckTasksWorkflow));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String Details
        {
            get
            {
                return ((string)(base.GetValue(WF_Chapter09.CheckTasksWorkflow.CheckTasksWorkflow.DetailsProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter09.CheckTasksWorkflow.CheckTasksWorkflow.DetailsProperty, value);
            }
        }

        private void getDetails_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                Details = "";

                try
                {
                    // SPWeb
                    Details += string.Format("URL: {0} \r\n", web.Url);

                    // SPList
                    SPList list = web.Lists["Tasks"];
                    Details += string.Format("The task list has {0} views \r\n",
                        list.Views.Count);

                    // SPListItem
                    if (list.ItemCount > 0)
                    {
                        SPListItem item = list.Items[0];
                        Details += string.Format("The title of first task is {0} \r\n",
                            item.Title);

                        // SPField
                        SPField field = item.Fields["Created"];
                        Details += string.Format("The field name is {0} \r\n",
                            field.StaticName);
                    }
                    else
                        Details += "The Tasks list is empty\r\n";

                    // SPDocumentLibrary
                    list = web.Lists["Shared Documents"];
                    if (list.BaseType == SPBaseType.DocumentLibrary)
                    {
                        SPDocumentLibrary lib = (SPDocumentLibrary)list;
                        Details += string.Format("The template is {0}\r\n",
                            lib.DocumentTemplateUrl);
                        Details += string.Format("The library contains {0} documents \r\n",
                            lib.ItemCount);

                        // SPContentType
                        SPContentType type = lib.ContentTypes[0];
                        Details += string.Format("The library supports the {0} content type \r\n",
                            type.Name);
                    }

                    // SPGroup 
                    SPGroup group = web.Groups[0];
                    Details += string.Format("The {0} group has {1} users \r\n",
                        group.Name, group.Users.Count);

                    // SPUser
                    SPUser user = group.Users[0];
                    Details += string.Format("The first user's email is {0} \r\n",
                        user.Email);

                }
                catch (Exception ex)
                {
                    Details += "Exception occurred: " + ex.Message;
                }
            }
        }

        private void checkTasks_ExecuteCode(object sender, EventArgs e)
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                SPList tasks = web.Lists["Tasks"];
                foreach (SPListItem i in tasks.Items)
                {
                    bool bSend = false;
                    string szMessage = "";

                    // Get the field values that we'll need
                    DateTime dtDueDate;
                    try
                    {
                        dtDueDate = DateTime.Parse(i["DueDate"].ToString());
                    }
                    catch (Exception)
                    {
                        dtDueDate = DateTime.MinValue;
                    }

                    string szAssigned = "";
                    string szTitle = "";
                    string szDesc = "";
                    string szStatus = "";

                    try
                    {
                        szStatus = i["Status"].ToString();
                        szTitle = i.Title;
                        szDesc = i["Description"].ToString();
                        szAssigned = i["AssignedTo"].ToString();
                    }
                    catch (Exception)
                    {
                    }

                    if (szStatus == "Active" || szStatus == "Not Started")
                    {
                        if (szAssigned == "")
                        {
                            bSend = true;
                            szMessage = "Task is not assigned";
                        }

                        if (!bSend && dtDueDate == DateTime.MinValue)
                        {
                            bSend = true;
                            szMessage = "No due date set";
                        }

                        if (!bSend && dtDueDate < DateTime.Now)
                        {
                            bSend = true;
                            szMessage = "Task is overdue";
                        }

                        if (bSend)
                        {
                            try
                            {
                                // Create a new task
                                SPListItem newTask = workflowProperties.TaskList.AddItem();

                                string szName =
                                    System.Threading.Thread.CurrentPrincipal.Identity.Name;
                                SPUser u = web.SiteUsers[szName];

                                newTask["Title"] = szMessage + " - " + szTitle;
                                newTask["Created"] = DateTime.Now;
                                newTask["PercentComplete"] = (float)0.0;
                                newTask["AssignedTo"] = u.ID;
                                newTask["DueDate"] = DateTime.Now.AddDays(1);
                                newTask["Description"] = szDesc;

                                // Set the Content Type
                                SPContentType wfType = tasks.ContentTypes["Workflow Task"];
                                newTask["ContentTypeId"] = wfType.Id;
                                newTask["Workflow Name"] = workflowProperties.TemplateName;

                                // Complete the updates in the database
                                newTask.Update();

                            }
                            catch (Exception ex)
                            {
                                string sz = ex.Message;
                            }
                        }
                    }
                }
            }
        }
    }
}
