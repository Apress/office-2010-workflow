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

namespace WF_Chapter11.Workflow1
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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.createTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.createTask1 = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            this.createTasks = new System.Workflow.Activities.ReplicatorActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // onTaskChanged1
            // 
            this.onTaskChanged1.AfterProperties = null;
            this.onTaskChanged1.BeforeProperties = null;
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "sequenceActivity1";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            this.onTaskChanged1.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.onTaskChanged1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.notCompleted);
            this.whileActivity1.Condition = codecondition1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // createTask
            // 
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "contentTypeIdString";
            this.createTask.CorrelationToken = correlationtoken1;
            this.createTask.ListItemId = -1;
            this.createTask.Name = "createTask";
            this.createTask.SpecialPermissions = null;
            this.createTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createTask.TaskProperties = null;
            this.createTask.MethodInvoking += new System.EventHandler(this.createTask_MethodInvoking);
            this.createTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.createTask);
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // createTask1
            // 
            correlationtoken2.Name = "finalTaskToken";
            correlationtoken2.OwnerActivityName = "Workflow1";
            this.createTask1.CorrelationToken = correlationtoken2;
            this.createTask1.ListItemId = -1;
            this.createTask1.Name = "createTask1";
            this.createTask1.SpecialPermissions = null;
            this.createTask1.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createTask1.TaskProperties = null;
            this.createTask1.MethodInvoking += new System.EventHandler(this.createTask1_MethodInvoking);
            activitybind2.Name = "Workflow1";
            activitybind2.Path = "ChildData";
            // 
            // createTasks
            // 
            this.createTasks.Activities.Add(this.sequenceActivity1);
            this.createTasks.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel;
            this.createTasks.Name = "createTasks";
            this.createTasks.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            activitybind4.Name = "Workflow1";
            activitybind4.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken3.Name = "workflowToken";
            correlationtoken3.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken3;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind3.Name = "Workflow1";
            activitybind3.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.createTasks);
            this.Activities.Add(this.createTask1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.CreateTask createTask1;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;
        private WhileActivity whileActivity1;
        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createTask;
        private SequenceActivity sequenceActivity1;
        private ReplicatorActivity createTasks;
        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;












    }
}
