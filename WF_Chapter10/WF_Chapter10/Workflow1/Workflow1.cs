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
using System.Xml.Linq;

namespace WF_Chapter10.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private string _eventName;
        private string _menuUrl;
        private List<string> _invitees;

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            XElement data = XElement.Parse(workflowProperties.InitiationData);

            _eventName = data.Elements().Single(x => x.Name == "EventName").Value;
            _menuUrl = data.Elements().Single(x => x.Name == "MenuUrl").Value;

            _invitees = new List<string>();
            ChildData = new ArrayList();

            foreach (XElement x in data.Element("Invitees").Elements())
            {
                _invitees.Add(x.Value);
                ChildData.Add(x.Value);
            }

            // Get the content type ID
            try
            {
                SPContentTypeId contentTypeId =
                    new SPContentTypeId("0x010801000da2ad56f41a465bbaa3311519728c2c");
                workflowProperties.TaskList.ContentTypesEnabled = true;
                SPContentTypeId matchContentTypeId =
                    workflowProperties.TaskList.ContentTypes.BestMatch(contentTypeId);
                if (matchContentTypeId.Parent.CompareTo(contentTypeId) != 0)
                {
                    SPContentType ct = workflowProperties.TaskList.ParentWeb
                        .AvailableContentTypes[contentTypeId];
                    workflowProperties.TaskList.ContentTypes.Add(ct);
                    workflowProperties.TaskList.Update();
                }

                ContentTypeId = contentTypeId.ToString();
            }
            catch (Exception ex)
            {
                string sz1 = ex.Message;
            }
        }

        public static DependencyProperty ChildDataProperty = DependencyProperty.Register("ChildData", typeof(System.Collections.IList), typeof(WF_Chapter10.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Properties")]
        public IList ChildData
        {
            get
            {
                return ((System.Collections.IList)(base.GetValue(WF_Chapter10.Workflow1.Workflow1.ChildDataProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter10.Workflow1.Workflow1.ChildDataProperty, value);
            }
        }

        private void createTasks_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            TaskId = Guid.NewGuid();

            TaskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
            TaskProperties.PercentComplete = (float)0.0;
            TaskProperties.AssignedTo = e.InstanceData.ToString();
            TaskProperties.DueDate = DateTime.Now.AddDays(1);
            TaskProperties.Title = "Enter your lunch order";
            TaskProperties.Description = _eventName;
            TaskProperties.ExtendedProperties["MenuUrl"] = _menuUrl;
        }

        private void createTasks_ChildCompleted(object sender, ReplicatorChildEventArgs e)
        {

        }

        private void createTasks_Completed(object sender, EventArgs e)
        {

        }

        private void createTasks_Initialized(object sender, EventArgs e)
        {

        }

        public static DependencyProperty TaskIdProperty = DependencyProperty.Register("TaskId", typeof(System.Guid), typeof(WF_Chapter10.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid TaskId
        {
            get
            {
                return ((System.Guid)(base.GetValue(WF_Chapter10.Workflow1.Workflow1.TaskIdProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter10.Workflow1.Workflow1.TaskIdProperty, value);
            }
        }

        public static DependencyProperty TaskPropertiesProperty = DependencyProperty.Register("TaskProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(WF_Chapter10.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties TaskProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(WF_Chapter10.Workflow1.Workflow1.TaskPropertiesProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter10.Workflow1.Workflow1.TaskPropertiesProperty, value);
            }
        }

        public static DependencyProperty ContentTypeIdProperty = DependencyProperty.Register("ContentTypeId", typeof(System.String), typeof(WF_Chapter10.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public String ContentTypeId
        {
            get
            {
                return ((string)(base.GetValue(WF_Chapter10.Workflow1.Workflow1.ContentTypeIdProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter10.Workflow1.Workflow1.ContentTypeIdProperty, value);
            }
        }

    }
}
