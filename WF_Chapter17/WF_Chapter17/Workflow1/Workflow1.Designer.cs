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

namespace WF_Chapter17.Workflow1
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            this.sendEmail1 = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // sendEmail1
            // 
            this.sendEmail1.BCC = null;
            this.sendEmail1.Body = null;
            this.sendEmail1.CC = null;
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "Workflow1";
            this.sendEmail1.CorrelationToken = correlationtoken1;
            this.sendEmail1.From = "sharepoint@thecreativepeople.local";
            this.sendEmail1.Headers = null;
            this.sendEmail1.IncludeStatus = false;
            this.sendEmail1.Name = "sendEmail1";
            this.sendEmail1.Subject = "Folder Contents";
            this.sendEmail1.To = "mark@thecreativepeople.local";
            this.sendEmail1.MethodInvoking += new System.EventHandler(this.sendEmail1_MethodInvoking);
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "DataOutput";
            this.handleExternalEventActivity1.InterfaceType = typeof(FileService.ICustomService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "eventArgs";
            workflowparameterbinding1.ParameterName = "e";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.handleExternalEventActivity1.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(FileService.ICustomService);
            this.callExternalMethodActivity1.MethodName = "GetFolderContent";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            workflowparameterbinding2.ParameterName = "path";
            workflowparameterbinding2.Value = "C:\\Books\\OfficeWorkflow\\Code";
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding2);
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.callExternalMethodActivity1);
            this.Activities.Add(this.handleExternalEventActivity1);
            this.Activities.Add(this.sendEmail1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmail1;

        private CallExternalMethodActivity callExternalMethodActivity1;

        private HandleExternalEventActivity handleExternalEventActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;



    }
}
