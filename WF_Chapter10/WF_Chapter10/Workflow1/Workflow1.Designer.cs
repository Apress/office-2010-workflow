using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WF_Chapter10.Workflow1
{
    public sealed partial class Workflow1
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            this.lunchOrder = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.createTask = new System.Workflow.Activities.SequenceActivity();
            this.createTasks = new System.Workflow.Activities.ReplicatorActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // lunchOrder
            // 
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "ContentTypeId";
            correlationtoken1.Name = "TaskToken";
            correlationtoken1.OwnerActivityName = "createTask";
            this.lunchOrder.CorrelationToken = correlationtoken1;
            this.lunchOrder.ListItemId = -1;
            this.lunchOrder.Name = "lunchOrder";
            this.lunchOrder.SpecialPermissions = null;
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "TaskId";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "TaskProperties";
            this.lunchOrder.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.lunchOrder.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.lunchOrder.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // createTask
            // 
            this.createTask.Activities.Add(this.lunchOrder);
            this.createTask.Name = "createTask";
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "ChildData";
            // 
            // createTasks
            // 
            this.createTasks.Activities.Add(this.createTask);
            this.createTasks.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            this.createTasks.Name = "createTasks";
            this.createTasks.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.createTasks_ChildInitialized);
            this.createTasks.ChildCompleted += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.createTasks_ChildCompleted);
            this.createTasks.Completed += new System.EventHandler(this.createTasks_Completed);
            this.createTasks.Initialized += new System.EventHandler(this.createTasks_Initialized);
            this.createTasks.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            activitybind6.Name = "Workflow1";
            activitybind6.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind5.Name = "Workflow1";
            activitybind5.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.createTasks);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType lunchOrder;
        private SequenceActivity createTask;
        private ReplicatorActivity createTasks;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;
















    }
}
