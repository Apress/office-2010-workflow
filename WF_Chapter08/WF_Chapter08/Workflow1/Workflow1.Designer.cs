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

namespace WF_Chapter08.Workflow1
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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.createTask1 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.logStarted = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // createTask1
            // 
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.createTask1.CorrelationToken = correlationtoken1;
            this.createTask1.ListItemId = -1;
            this.createTask1.Name = "createTask1";
            this.createTask1.SpecialPermissions = null;
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "taskID";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "taskProperties";
            this.createTask1.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.createTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // logStarted
            // 
            this.logStarted.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logStarted.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            this.logStarted.HistoryDescription = "The workflow has started";
            this.logStarted.HistoryOutcome = "OK";
            this.logStarted.Name = "logStarted";
            this.logStarted.OtherData = "";
            this.logStarted.UserId = -1;
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.logStarted);
            this.Activities.Add(this.createTask1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask1;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logStarted;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;



    }
}
