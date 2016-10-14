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

namespace WF_Chapter09.CheckTasksWorkflow
{
    public sealed partial class CheckTasksWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            this.checkTasks = new System.Workflow.Activities.CodeActivity();
            this.logDetails = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.getDetails = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // checkTasks
            // 
            this.checkTasks.Name = "checkTasks";
            this.checkTasks.ExecuteCode += new System.EventHandler(this.checkTasks_ExecuteCode);
            // 
            // logDetails
            // 
            this.logDetails.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logDetails.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind1.Name = "CheckTasksWorkflow";
            activitybind1.Path = "Details";
            this.logDetails.HistoryOutcome = "OK";
            this.logDetails.Name = "logDetails";
            this.logDetails.OtherData = "";
            this.logDetails.UserId = -1;
            this.logDetails.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // getDetails
            // 
            this.getDetails.Name = "getDetails";
            this.getDetails.ExecuteCode += new System.EventHandler(this.getDetails_ExecuteCode);
            activitybind3.Name = "CheckTasksWorkflow";
            activitybind3.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "CheckTasksWorkflow";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind2.Name = "CheckTasksWorkflow";
            activitybind2.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // CheckTasksWorkflow
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.getDetails);
            this.Activities.Add(this.logDetails);
            this.Activities.Add(this.checkTasks);
            this.Name = "CheckTasksWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity checkTasks;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logDetails;
        private CodeActivity getDetails;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;



    }
}
