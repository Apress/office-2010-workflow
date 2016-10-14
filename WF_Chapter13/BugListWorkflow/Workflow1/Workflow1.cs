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

namespace BugListWorkflow.Workflow1
{
    public sealed partial class Workflow1 : StateMachineWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private string _admin = "internal\\test1";
        private string _test = "internal\\test2";
        private string _itemTitle;
        private string _itemDescription;

        private string _priority = "Normal";
        private string _assign = "";
        private string _resolution;
        private string _feedback;
        private bool _wad = false;
        private bool _waiting = false;
        private bool _started = false;
        private bool _fixed = false;
        private bool _closed = false;
        private bool _reSubmit = false;
        private bool _tested = false;
        private bool _notFixed = false;

        private Guid _taskId = Guid.Empty;
        private Guid _workTaskId = Guid.Empty;

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            // Get the details from the BugList item that we’ll need later
            _itemTitle = workflowProperties.Item.Title;
            _itemDescription = workflowProperties.Item["Description"].ToString();

            // Make sure the Tasks lists supports all of our content types
            List<SPContentTypeId> types = new List<SPContentTypeId>();

            // BugActive
            types.Add(new SPContentTypeId("0x010801006F51849CF46B42939046CFD9CF6D3E0B"));

            // BugAssigned
            types.Add(new SPContentTypeId("0x010801004A00B43FE6164C9CBF293387CEA8620B"));

            // BugFixed
            types.Add(new SPContentTypeId("0x01080100B9F327A7AA4F4D1BA315ACDC30608AE4"));

            // BugPending
            types.Add(new SPContentTypeId("0x0108010035C58D2F345347AAAF424215A9CDC37D"));

            // BugWAD
            types.Add(new SPContentTypeId("0x010801002BB2E8C199C54880B6F7495585C1E967"));

            // BugWaiting
            types.Add(new SPContentTypeId("0x01080100BFFDDAD4FDE84D1CB164F744FA4EE57E"));

            foreach (SPContentTypeId type in types)
            {
                workflowProperties.TaskList.ContentTypesEnabled = true;
                SPContentTypeId matchContentTypeId
                    = workflowProperties.TaskList.ContentTypes.BestMatch(type);
                if (matchContentTypeId.Parent.CompareTo(type) != 0)
                {
                    SPContentType ct
                       = workflowProperties.TaskList.ParentWeb.AvailableContentTypes[type];
                    workflowProperties.TaskList.ContentTypes.Add(ct);
                    workflowProperties.TaskList.Update();
                }
            }

            // Get the association data
            if (workflowProperties.AssociationData != null)
            {
                XElement data = XElement.Parse(workflowProperties.AssociationData);

                foreach (XElement x in data.Element("AdminUsers").Elements())
                {
                    _admin = x.Value;
                    break;  // just get the first one
                }
                foreach (XElement x in data.Element("TestUsers").Elements())
                {
                    _test = x.Value;
                    break;  // just get the first one
                }
            }

            // Set the Date Created
            SPListItem item = workflowProperties.Item;
            item["_DCDateCreated"] = DateTime.Now;
            item.Update();
        }

        private void createPendingTask_MethodInvoking(object sender, EventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            task.TaskId = Guid.NewGuid();

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = _admin;
            wtp.TaskType = 0;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Pending: " + _itemTitle;
            wtp.Description = _itemDescription;

            task.TaskProperties = wtp;
        }

        private void codeInitPending_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Pending";
            item.Update();
        }

        private void onPendingChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                _priority = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugPriority")
                    .Id].ToString();
                _assign = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugAssign")
                    .Id].ToString();
                _wad = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugWAD")
                    .Id].ToString());

                // Store the item's priority
                if (_priority.Length > 0)
                {
                    SPListItem item = workflowProperties.Item;

                    if (_priority.Length > 0)
                        item["Priority"] = _priority;

                    item.Update();
                }
            }
        }

        private void completeTask_MethodInvoking(object sender, EventArgs e)
        {
            CompleteTask ct = (CompleteTask)sender;
            ct.TaskId = _taskId;
        }

        private void codeInitActive_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Active";
            item.Update();
        }

        private void createAssignedTask_MethodInvoking(object sender, EventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            task.TaskId = Guid.NewGuid();
            _workTaskId = task.TaskId;

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = _assign;
            wtp.TaskType = 1;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Bug: " + _itemTitle;
            wtp.Description = _itemDescription;

            task.TaskProperties = wtp;

            // Update the item to show the assignee
            SPUser u = workflowProperties.Web.SiteUsers[_assign];
            SPListItem item = workflowProperties.Item;
            item["AssignedTo"] = u;
            item.Update();
        }

        private void codeInitAssigned_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Assigned";
            item.Update();
        }

        private void createWadTask_MethodInvoking(object sender, EventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            task.TaskId = Guid.NewGuid();

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = _test;
            wtp.TaskType = 2;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Working As Designed: " + _itemTitle;
            wtp.Description = _itemDescription;

            task.TaskProperties = wtp;
        }

        private void createWaitingTask_MethodInvoking(object sender, EventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            task.TaskId = Guid.NewGuid();

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = _admin;
            wtp.TaskType = 4;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Waiting: " + _itemTitle;
            wtp.Description = _itemDescription;

            task.TaskProperties = wtp;
        }

        private void createFixedTask_MethodInvoking(object sender, EventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            task.TaskId = Guid.NewGuid();

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = _test;
            wtp.TaskType = 3;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Resolved: " + _itemTitle;
            wtp.Description = _itemDescription;

            task.TaskProperties = wtp;
        }

        private void codeInitWad_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Working As Designed";
            item.Update();
        }

        private void codeInitWaiting_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Waiting";
            item.Update();
        }

        private void codeInitFixed_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            item["BugStatus"] = "Fixed";
            item.Update();
        }

        private void onAssignedChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                if (after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("Resolution")
                    .Id] != null)
                {
                    _resolution = after.ExtendedProperties[
                        workflowProperties.TaskList.Fields.GetFieldByInternalName("Resolution")
                        .Id].ToString();
                    _wad = bool.Parse(after.ExtendedProperties[
                        workflowProperties.TaskList.Fields.GetFieldByInternalName("BugWAD")
                        .Id].ToString());
                    _waiting = bool.Parse(after.ExtendedProperties[
                        workflowProperties.TaskList.Fields.GetFieldByInternalName("BugWaiting")
                        .Id].ToString());
                    _started = bool.Parse(after.ExtendedProperties[
                        workflowProperties.TaskList.Fields.GetFieldByInternalName("BugStarted")
                        .Id].ToString());
                    _fixed = bool.Parse(after.ExtendedProperties[
                        workflowProperties.TaskList.Fields.GetFieldByInternalName("BugFixed")
                        .Id].ToString());

                    if (_resolution.Length > 0)
                    {
                        SPListItem item = workflowProperties.Item;
                        item["Resolution"] = _resolution;
                        item.Update();
                    }
                }
                else
                    _fixed = false;
            }
        }

        private void onActiveChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                _resolution = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("Resolution")
                    .Id].ToString();
                _wad = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugWAD")
                    .Id].ToString());
                _waiting = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugWaiting")
                    .Id].ToString());
                _started = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugStarted")
                    .Id].ToString());
                _fixed = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugFixed")
                    .Id].ToString());

                if (_resolution.Length > 0)
                {
                    SPListItem item = workflowProperties.Item;
                    item["Resolution"] = _resolution;
                    item.Update();
                }
            }
        }

        private void onWadChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                _feedback = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("Feedback")
                    .Id].ToString();
                _closed = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugClosed")
                    .Id].ToString());
                _reSubmit = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugReSubmit")
                    .Id].ToString());

                if (_feedback.Length > 0)
                {
                    SPListItem item = workflowProperties.Item;
                    if (item["Feedback"] != null)
                        item["Feedback"] += "\r\n";
                    item["Feedback"] += _feedback;
                    item.Update();
                }
            }
        }

        private void completeWorkTask_MethodInvoking(object sender, EventArgs e)
        {
            CompleteTask ct = (CompleteTask)sender;
            ct.TaskId = _workTaskId;
        }

        private void codeSetClosed_ExecuteCode(object sender, EventArgs e)
        {
            // Now set the BugStatus and the completed date
            SPListItem item = workflowProperties.Item;
            item["DateCompleted"] = DateTime.Now;
            item["BugStatus"] = "Closed";
            item.Update();
        }

        private void onWaitingChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                _feedback = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("Feedback")
                    .Id].ToString();
                _closed = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugClosed")
                    .Id].ToString());
                _reSubmit = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugReSubmit")
                    .Id].ToString());

                if (_feedback.Length > 0)
                {
                    SPListItem item = workflowProperties.Item;
                    if (item["Feedback"] != null)
                        item["Feedback"] += "\r\n";
                    item["Feedback"] += _feedback;
                    item.Update();
                }
            }
        }

        private void onFixedChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            _taskId = args.taskId;

            SPWorkflowTaskProperties after = args.afterProperties;
            if (after != null)
            {
                _feedback = after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("Feedback")
                    .Id].ToString();
                _tested = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugTested")
                    .Id].ToString());
                _notFixed = bool.Parse(after.ExtendedProperties[
                    workflowProperties.TaskList.Fields.GetFieldByInternalName("BugNotFixed")
                    .Id].ToString());

                if (_feedback.Length > 0)
                {
                    SPListItem item = workflowProperties.Item;
                    if (item["Feedback"] != null)
                        item["Feedback"] += "\r\n";
                    item["Feedback"] += _feedback;
                    item.Update();
                }
            }
        }

        private void codeFixedNotFixed_ExecuteCode(object sender, EventArgs e)
        {
            SPListItem task = null;
            foreach (SPWorkflowTask t in workflowProperties.Item.Tasks)
            {
                if (t.DisplayName.Substring(0, 4) == "Bug:")
                {
                    task = (SPListItem)t;
                    break;
                }
            }

            if (task != null)
            {
                Hashtable ht = new Hashtable();
                ht["BugFixed"] = 0;
                SPWorkflowTask.AlterTask(task, ht, false);
            }
        }

    }
}
