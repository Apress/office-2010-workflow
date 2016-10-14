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

namespace BugListWorkflow.Workflow1
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken3 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken4 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken5 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken6 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference5 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference6 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference7 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference8 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference9 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference10 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference11 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference12 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference13 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference14 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference15 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference16 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference17 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference18 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference19 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Runtime.CorrelationToken correlationtoken7 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.Runtime.CorrelationToken correlationtoken8 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.setWaitingPending = new System.Workflow.Activities.SetStateActivity();
            this.setWaitingAssigned = new System.Workflow.Activities.SetStateActivity();
            this.setWadPending = new System.Workflow.Activities.SetStateActivity();
            this.setWadAssigned = new System.Workflow.Activities.SetStateActivity();
            this.ifWaitingNotAssigned = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWaitingAssigned = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWadNotAssigned = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWadAssigned = new System.Workflow.Activities.IfElseBranchActivity();
            this.setPendingAssigned = new System.Workflow.Activities.SetStateActivity();
            this.completePendingAssigned = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setPendingWad = new System.Workflow.Activities.SetStateActivity();
            this.completePendingWad = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setFixedAsigned = new System.Workflow.Activities.SetStateActivity();
            this.codeFixedNotFixed = new System.Workflow.Activities.CodeActivity();
            this.completeFixedAssigned = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setFixedClosed = new System.Workflow.Activities.SetStateActivity();
            this.codeFixedClosed = new System.Workflow.Activities.CodeActivity();
            this.completeFixedWork = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.completeFixed = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.ifElseActivity8 = new System.Workflow.Activities.IfElseActivity();
            this.completeWaitingResubmit = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setWaitingClosed = new System.Workflow.Activities.SetStateActivity();
            this.codeWaitingClosed = new System.Workflow.Activities.CodeActivity();
            this.completeWaitingWork = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.completeWaiting = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setActiveAssigned = new System.Workflow.Activities.SetStateActivity();
            this.setActiveWaiting = new System.Workflow.Activities.SetStateActivity();
            this.setActiveWad = new System.Workflow.Activities.SetStateActivity();
            this.setActiveFixed = new System.Workflow.Activities.SetStateActivity();
            this.ifElseActivity6 = new System.Workflow.Activities.IfElseActivity();
            this.completeWadResubmit = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setWadClosed = new System.Workflow.Activities.SetStateActivity();
            this.codeWadClosed = new System.Workflow.Activities.CodeActivity();
            this.completeWadWork = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.completeWad = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.setAssignedActive = new System.Workflow.Activities.SetStateActivity();
            this.setAssignedWaiting = new System.Workflow.Activities.SetStateActivity();
            this.setAssignedWad = new System.Workflow.Activities.SetStateActivity();
            this.setAssignedFixed = new System.Workflow.Activities.SetStateActivity();
            this.createAssignedTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.ifPendingAssigned = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifPendingWad = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifNotFixed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifFixed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWaitingResubmit = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWaitingClosed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifActiveNotStarted = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifActiveWaiting = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifActiveWad = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifActiveFixed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWadResubmit = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifWadClosed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAssignedStated = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAssignedWaiting = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAssignedWad = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifAssignedFixed = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifNotCreated = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.onPendingChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitPending = new System.Workflow.Activities.CodeActivity();
            this.createPendingTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.ifElseActivity9 = new System.Workflow.Activities.IfElseActivity();
            this.onFixedChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitFixed = new System.Workflow.Activities.CodeActivity();
            this.createFixedTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.ifElseActivity7 = new System.Workflow.Activities.IfElseActivity();
            this.onWaitingChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitWaiting = new System.Workflow.Activities.CodeActivity();
            this.createWaitingTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.ifElseActivity4 = new System.Workflow.Activities.IfElseActivity();
            this.onActiveChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitActive = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity5 = new System.Workflow.Activities.IfElseActivity();
            this.onWadChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitWad = new System.Workflow.Activities.CodeActivity();
            this.createWadTask = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.ifElseActivity3 = new System.Workflow.Activities.IfElseActivity();
            this.onAssignedChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.codeInitAssigned = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.setInitialPending = new System.Workflow.Activities.SetStateActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            this.eventPending = new System.Workflow.Activities.EventDrivenActivity();
            this.initPending = new System.Workflow.Activities.StateInitializationActivity();
            this.eventFixed = new System.Workflow.Activities.EventDrivenActivity();
            this.initFixed = new System.Workflow.Activities.StateInitializationActivity();
            this.eventWaiting = new System.Workflow.Activities.EventDrivenActivity();
            this.initWaiting = new System.Workflow.Activities.StateInitializationActivity();
            this.eventActive = new System.Workflow.Activities.EventDrivenActivity();
            this.initActive = new System.Workflow.Activities.StateInitializationActivity();
            this.eventWad = new System.Workflow.Activities.EventDrivenActivity();
            this.initWad = new System.Workflow.Activities.StateInitializationActivity();
            this.eventAssigned = new System.Workflow.Activities.EventDrivenActivity();
            this.initAssigned = new System.Workflow.Activities.StateInitializationActivity();
            this.eventInitial = new System.Workflow.Activities.EventDrivenActivity();
            this.statePending = new System.Workflow.Activities.StateActivity();
            this.stateFinal = new System.Workflow.Activities.StateActivity();
            this.stateFixed = new System.Workflow.Activities.StateActivity();
            this.stateWaiting = new System.Workflow.Activities.StateActivity();
            this.stateActive = new System.Workflow.Activities.StateActivity();
            this.stateWad = new System.Workflow.Activities.StateActivity();
            this.stateAssigned = new System.Workflow.Activities.StateActivity();
            this.stateInitial = new System.Workflow.Activities.StateActivity();
            // 
            // setWaitingPending
            // 
            this.setWaitingPending.Name = "setWaitingPending";
            this.setWaitingPending.TargetStateName = "statePending";
            // 
            // setWaitingAssigned
            // 
            this.setWaitingAssigned.Name = "setWaitingAssigned";
            this.setWaitingAssigned.TargetStateName = "stateAssigned";
            // 
            // setWadPending
            // 
            this.setWadPending.Name = "setWadPending";
            this.setWadPending.TargetStateName = "statePending";
            // 
            // setWadAssigned
            // 
            this.setWadAssigned.Name = "setWadAssigned";
            this.setWadAssigned.TargetStateName = "stateAssigned";
            // 
            // ifWaitingNotAssigned
            // 
            this.ifWaitingNotAssigned.Activities.Add(this.setWaitingPending);
            this.ifWaitingNotAssigned.Name = "ifWaitingNotAssigned";
            // 
            // ifWaitingAssigned
            // 
            this.ifWaitingAssigned.Activities.Add(this.setWaitingAssigned);
            ruleconditionreference1.ConditionName = "Assigned";
            this.ifWaitingAssigned.Condition = ruleconditionreference1;
            this.ifWaitingAssigned.Name = "ifWaitingAssigned";
            // 
            // ifWadNotAssigned
            // 
            this.ifWadNotAssigned.Activities.Add(this.setWadPending);
            this.ifWadNotAssigned.Name = "ifWadNotAssigned";
            // 
            // ifWadAssigned
            // 
            this.ifWadAssigned.Activities.Add(this.setWadAssigned);
            ruleconditionreference2.ConditionName = "Assigned";
            this.ifWadAssigned.Condition = ruleconditionreference2;
            this.ifWadAssigned.Name = "ifWadAssigned";
            // 
            // setPendingAssigned
            // 
            this.setPendingAssigned.Name = "setPendingAssigned";
            this.setPendingAssigned.TargetStateName = "stateAssigned";
            // 
            // completePendingAssigned
            // 
            correlationtoken1.Name = "pendingToken";
            correlationtoken1.OwnerActivityName = "statePending";
            this.completePendingAssigned.CorrelationToken = correlationtoken1;
            this.completePendingAssigned.Name = "completePendingAssigned";
            this.completePendingAssigned.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completePendingAssigned.TaskOutcome = null;
            this.completePendingAssigned.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setPendingWad
            // 
            this.setPendingWad.Name = "setPendingWad";
            this.setPendingWad.TargetStateName = "stateWad";
            // 
            // completePendingWad
            // 
            this.completePendingWad.CorrelationToken = correlationtoken1;
            this.completePendingWad.Name = "completePendingWad";
            this.completePendingWad.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completePendingWad.TaskOutcome = null;
            this.completePendingWad.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setFixedAsigned
            // 
            this.setFixedAsigned.Name = "setFixedAsigned";
            this.setFixedAsigned.TargetStateName = "stateAssigned";
            // 
            // codeFixedNotFixed
            // 
            this.codeFixedNotFixed.Name = "codeFixedNotFixed";
            this.codeFixedNotFixed.ExecuteCode += new System.EventHandler(this.codeFixedNotFixed_ExecuteCode);
            // 
            // completeFixedAssigned
            // 
            correlationtoken2.Name = "fixedToken";
            correlationtoken2.OwnerActivityName = "stateFixed";
            this.completeFixedAssigned.CorrelationToken = correlationtoken2;
            this.completeFixedAssigned.Name = "completeFixedAssigned";
            this.completeFixedAssigned.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeFixedAssigned.TaskOutcome = null;
            this.completeFixedAssigned.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setFixedClosed
            // 
            this.setFixedClosed.Name = "setFixedClosed";
            this.setFixedClosed.TargetStateName = "stateFinal";
            // 
            // codeFixedClosed
            // 
            this.codeFixedClosed.Name = "codeFixedClosed";
            this.codeFixedClosed.ExecuteCode += new System.EventHandler(this.codeSetClosed_ExecuteCode);
            // 
            // completeFixedWork
            // 
            correlationtoken3.Name = "taskToken";
            correlationtoken3.OwnerActivityName = "Workflow1";
            this.completeFixedWork.CorrelationToken = correlationtoken3;
            this.completeFixedWork.Name = "completeFixedWork";
            this.completeFixedWork.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeFixedWork.TaskOutcome = null;
            this.completeFixedWork.MethodInvoking += new System.EventHandler(this.completeWorkTask_MethodInvoking);
            // 
            // completeFixed
            // 
            this.completeFixed.CorrelationToken = correlationtoken2;
            this.completeFixed.Name = "completeFixed";
            this.completeFixed.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeFixed.TaskOutcome = null;
            this.completeFixed.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // ifElseActivity8
            // 
            this.ifElseActivity8.Activities.Add(this.ifWaitingAssigned);
            this.ifElseActivity8.Activities.Add(this.ifWaitingNotAssigned);
            this.ifElseActivity8.Name = "ifElseActivity8";
            // 
            // completeWaitingResubmit
            // 
            correlationtoken4.Name = "waitingToken";
            correlationtoken4.OwnerActivityName = "stateWaiting";
            this.completeWaitingResubmit.CorrelationToken = correlationtoken4;
            this.completeWaitingResubmit.Name = "completeWaitingResubmit";
            this.completeWaitingResubmit.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWaitingResubmit.TaskOutcome = null;
            this.completeWaitingResubmit.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setWaitingClosed
            // 
            this.setWaitingClosed.Name = "setWaitingClosed";
            this.setWaitingClosed.TargetStateName = "stateFinal";
            // 
            // codeWaitingClosed
            // 
            this.codeWaitingClosed.Name = "codeWaitingClosed";
            this.codeWaitingClosed.ExecuteCode += new System.EventHandler(this.codeSetClosed_ExecuteCode);
            // 
            // completeWaitingWork
            // 
            correlationtoken5.Name = "taskToken";
            correlationtoken5.OwnerActivityName = "Workflow1";
            this.completeWaitingWork.CorrelationToken = correlationtoken5;
            this.completeWaitingWork.Name = "completeWaitingWork";
            this.completeWaitingWork.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWaitingWork.TaskOutcome = null;
            this.completeWaitingWork.MethodInvoking += new System.EventHandler(this.completeWorkTask_MethodInvoking);
            // 
            // completeWaiting
            // 
            this.completeWaiting.CorrelationToken = correlationtoken4;
            this.completeWaiting.Name = "completeWaiting";
            this.completeWaiting.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWaiting.TaskOutcome = null;
            this.completeWaiting.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setActiveAssigned
            // 
            this.setActiveAssigned.Name = "setActiveAssigned";
            this.setActiveAssigned.TargetStateName = "stateActive";
            // 
            // setActiveWaiting
            // 
            this.setActiveWaiting.Name = "setActiveWaiting";
            this.setActiveWaiting.TargetStateName = "stateWaiting";
            // 
            // setActiveWad
            // 
            this.setActiveWad.Name = "setActiveWad";
            this.setActiveWad.TargetStateName = "stateWad";
            // 
            // setActiveFixed
            // 
            this.setActiveFixed.Name = "setActiveFixed";
            this.setActiveFixed.TargetStateName = "stateFixed";
            // 
            // ifElseActivity6
            // 
            this.ifElseActivity6.Activities.Add(this.ifWadAssigned);
            this.ifElseActivity6.Activities.Add(this.ifWadNotAssigned);
            this.ifElseActivity6.Name = "ifElseActivity6";
            // 
            // completeWadResubmit
            // 
            correlationtoken6.Name = "wadToken";
            correlationtoken6.OwnerActivityName = "stateWad";
            this.completeWadResubmit.CorrelationToken = correlationtoken6;
            this.completeWadResubmit.Name = "completeWadResubmit";
            this.completeWadResubmit.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWadResubmit.TaskOutcome = null;
            this.completeWadResubmit.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setWadClosed
            // 
            this.setWadClosed.Name = "setWadClosed";
            this.setWadClosed.TargetStateName = "stateFinal";
            // 
            // codeWadClosed
            // 
            this.codeWadClosed.Name = "codeWadClosed";
            this.codeWadClosed.ExecuteCode += new System.EventHandler(this.codeSetClosed_ExecuteCode);
            // 
            // completeWadWork
            // 
            this.completeWadWork.CorrelationToken = correlationtoken3;
            this.completeWadWork.Name = "completeWadWork";
            this.completeWadWork.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWadWork.TaskOutcome = null;
            this.completeWadWork.MethodInvoking += new System.EventHandler(this.completeWorkTask_MethodInvoking);
            // 
            // completeWad
            // 
            this.completeWad.CorrelationToken = correlationtoken6;
            this.completeWad.Name = "completeWad";
            this.completeWad.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.completeWad.TaskOutcome = null;
            this.completeWad.MethodInvoking += new System.EventHandler(this.completeTask_MethodInvoking);
            // 
            // setAssignedActive
            // 
            this.setAssignedActive.Name = "setAssignedActive";
            this.setAssignedActive.TargetStateName = "stateActive";
            // 
            // setAssignedWaiting
            // 
            this.setAssignedWaiting.Name = "setAssignedWaiting";
            this.setAssignedWaiting.TargetStateName = "stateWaiting";
            // 
            // setAssignedWad
            // 
            this.setAssignedWad.Name = "setAssignedWad";
            this.setAssignedWad.TargetStateName = "stateWad";
            // 
            // setAssignedFixed
            // 
            this.setAssignedFixed.Name = "setAssignedFixed";
            this.setAssignedFixed.TargetStateName = "stateFixed";
            // 
            // createAssignedTask
            // 
            this.createAssignedTask.ContentTypeId = "0x010801004A00B43FE6164C9CBF293387CEA8620B";
            this.createAssignedTask.CorrelationToken = correlationtoken3;
            this.createAssignedTask.ListItemId = -1;
            this.createAssignedTask.Name = "createAssignedTask";
            this.createAssignedTask.SpecialPermissions = null;
            this.createAssignedTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createAssignedTask.TaskProperties = null;
            this.createAssignedTask.MethodInvoking += new System.EventHandler(this.createAssignedTask_MethodInvoking);
            // 
            // ifPendingAssigned
            // 
            this.ifPendingAssigned.Activities.Add(this.completePendingAssigned);
            this.ifPendingAssigned.Activities.Add(this.setPendingAssigned);
            ruleconditionreference3.ConditionName = "Assigned";
            this.ifPendingAssigned.Condition = ruleconditionreference3;
            this.ifPendingAssigned.Name = "ifPendingAssigned";
            // 
            // ifPendingWad
            // 
            this.ifPendingWad.Activities.Add(this.completePendingWad);
            this.ifPendingWad.Activities.Add(this.setPendingWad);
            ruleconditionreference4.ConditionName = "Working as Designed";
            this.ifPendingWad.Condition = ruleconditionreference4;
            this.ifPendingWad.Name = "ifPendingWad";
            // 
            // ifNotFixed
            // 
            this.ifNotFixed.Activities.Add(this.completeFixedAssigned);
            this.ifNotFixed.Activities.Add(this.codeFixedNotFixed);
            this.ifNotFixed.Activities.Add(this.setFixedAsigned);
            ruleconditionreference5.ConditionName = "NotFixed";
            this.ifNotFixed.Condition = ruleconditionreference5;
            this.ifNotFixed.Name = "ifNotFixed";
            // 
            // ifFixed
            // 
            this.ifFixed.Activities.Add(this.completeFixed);
            this.ifFixed.Activities.Add(this.completeFixedWork);
            this.ifFixed.Activities.Add(this.codeFixedClosed);
            this.ifFixed.Activities.Add(this.setFixedClosed);
            ruleconditionreference6.ConditionName = "Fixed";
            this.ifFixed.Condition = ruleconditionreference6;
            this.ifFixed.Name = "ifFixed";
            // 
            // ifWaitingResubmit
            // 
            this.ifWaitingResubmit.Activities.Add(this.completeWaitingResubmit);
            this.ifWaitingResubmit.Activities.Add(this.ifElseActivity8);
            ruleconditionreference7.ConditionName = "ReSubmit";
            this.ifWaitingResubmit.Condition = ruleconditionreference7;
            this.ifWaitingResubmit.Name = "ifWaitingResubmit";
            // 
            // ifWaitingClosed
            // 
            this.ifWaitingClosed.Activities.Add(this.completeWaiting);
            this.ifWaitingClosed.Activities.Add(this.completeWaitingWork);
            this.ifWaitingClosed.Activities.Add(this.codeWaitingClosed);
            this.ifWaitingClosed.Activities.Add(this.setWaitingClosed);
            ruleconditionreference8.ConditionName = "Closed";
            this.ifWaitingClosed.Condition = ruleconditionreference8;
            this.ifWaitingClosed.Name = "ifWaitingClosed";
            // 
            // ifActiveNotStarted
            // 
            this.ifActiveNotStarted.Activities.Add(this.setActiveAssigned);
            ruleconditionreference9.ConditionName = "NotStarted";
            this.ifActiveNotStarted.Condition = ruleconditionreference9;
            this.ifActiveNotStarted.Name = "ifActiveNotStarted";
            // 
            // ifActiveWaiting
            // 
            this.ifActiveWaiting.Activities.Add(this.setActiveWaiting);
            ruleconditionreference10.ConditionName = "Waiting";
            this.ifActiveWaiting.Condition = ruleconditionreference10;
            this.ifActiveWaiting.Name = "ifActiveWaiting";
            // 
            // ifActiveWad
            // 
            this.ifActiveWad.Activities.Add(this.setActiveWad);
            ruleconditionreference11.ConditionName = "Wad";
            this.ifActiveWad.Condition = ruleconditionreference11;
            this.ifActiveWad.Name = "ifActiveWad";
            // 
            // ifActiveFixed
            // 
            this.ifActiveFixed.Activities.Add(this.setActiveFixed);
            ruleconditionreference12.ConditionName = "Fixed";
            this.ifActiveFixed.Condition = ruleconditionreference12;
            this.ifActiveFixed.Name = "ifActiveFixed";
            // 
            // ifWadResubmit
            // 
            this.ifWadResubmit.Activities.Add(this.completeWadResubmit);
            this.ifWadResubmit.Activities.Add(this.ifElseActivity6);
            ruleconditionreference13.ConditionName = "ReSubmit";
            this.ifWadResubmit.Condition = ruleconditionreference13;
            this.ifWadResubmit.Name = "ifWadResubmit";
            // 
            // ifWadClosed
            // 
            this.ifWadClosed.Activities.Add(this.completeWad);
            this.ifWadClosed.Activities.Add(this.completeWadWork);
            this.ifWadClosed.Activities.Add(this.codeWadClosed);
            this.ifWadClosed.Activities.Add(this.setWadClosed);
            ruleconditionreference14.ConditionName = "Closed";
            this.ifWadClosed.Condition = ruleconditionreference14;
            this.ifWadClosed.Name = "ifWadClosed";
            // 
            // ifAssignedStated
            // 
            this.ifAssignedStated.Activities.Add(this.setAssignedActive);
            ruleconditionreference15.ConditionName = "Started";
            this.ifAssignedStated.Condition = ruleconditionreference15;
            this.ifAssignedStated.Name = "ifAssignedStated";
            // 
            // ifAssignedWaiting
            // 
            this.ifAssignedWaiting.Activities.Add(this.setAssignedWaiting);
            ruleconditionreference16.ConditionName = "Waiting";
            this.ifAssignedWaiting.Condition = ruleconditionreference16;
            this.ifAssignedWaiting.Name = "ifAssignedWaiting";
            // 
            // ifAssignedWad
            // 
            this.ifAssignedWad.Activities.Add(this.setAssignedWad);
            ruleconditionreference17.ConditionName = "Wad";
            this.ifAssignedWad.Condition = ruleconditionreference17;
            this.ifAssignedWad.Name = "ifAssignedWad";
            // 
            // ifAssignedFixed
            // 
            this.ifAssignedFixed.Activities.Add(this.setAssignedFixed);
            ruleconditionreference18.ConditionName = "Fixed";
            this.ifAssignedFixed.Condition = ruleconditionreference18;
            this.ifAssignedFixed.Name = "ifAssignedFixed";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifNotCreated
            // 
            this.ifNotCreated.Activities.Add(this.createAssignedTask);
            ruleconditionreference19.ConditionName = "NotCreated";
            this.ifNotCreated.Condition = ruleconditionreference19;
            this.ifNotCreated.Name = "ifNotCreated";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifPendingWad);
            this.ifElseActivity1.Activities.Add(this.ifPendingAssigned);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // onPendingChanged
            // 
            this.onPendingChanged.AfterProperties = null;
            this.onPendingChanged.BeforeProperties = null;
            this.onPendingChanged.CorrelationToken = correlationtoken1;
            this.onPendingChanged.Executor = null;
            this.onPendingChanged.Name = "onPendingChanged";
            this.onPendingChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onPendingChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onPendingChanged_Invoked);
            // 
            // codeInitPending
            // 
            this.codeInitPending.Name = "codeInitPending";
            this.codeInitPending.ExecuteCode += new System.EventHandler(this.codeInitPending_ExecuteCode);
            // 
            // createPendingTask
            // 
            this.createPendingTask.ContentTypeId = "0x0108010035C58D2F345347AAAF424215A9CDC37D";
            this.createPendingTask.CorrelationToken = correlationtoken1;
            this.createPendingTask.ListItemId = -1;
            this.createPendingTask.Name = "createPendingTask";
            this.createPendingTask.SpecialPermissions = null;
            this.createPendingTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createPendingTask.TaskProperties = null;
            this.createPendingTask.MethodInvoking += new System.EventHandler(this.createPendingTask_MethodInvoking);
            // 
            // ifElseActivity9
            // 
            this.ifElseActivity9.Activities.Add(this.ifFixed);
            this.ifElseActivity9.Activities.Add(this.ifNotFixed);
            this.ifElseActivity9.Name = "ifElseActivity9";
            // 
            // onFixedChanged
            // 
            this.onFixedChanged.AfterProperties = null;
            this.onFixedChanged.BeforeProperties = null;
            this.onFixedChanged.CorrelationToken = correlationtoken2;
            this.onFixedChanged.Executor = null;
            this.onFixedChanged.Name = "onFixedChanged";
            this.onFixedChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onFixedChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onFixedChanged_Invoked);
            // 
            // codeInitFixed
            // 
            this.codeInitFixed.Name = "codeInitFixed";
            this.codeInitFixed.ExecuteCode += new System.EventHandler(this.codeInitFixed_ExecuteCode);
            // 
            // createFixedTask
            // 
            this.createFixedTask.ContentTypeId = "0x01080100B9F327A7AA4F4D1BA315ACDC30608AE4";
            this.createFixedTask.CorrelationToken = correlationtoken2;
            this.createFixedTask.ListItemId = -1;
            this.createFixedTask.Name = "createFixedTask";
            this.createFixedTask.SpecialPermissions = null;
            this.createFixedTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createFixedTask.TaskProperties = null;
            this.createFixedTask.MethodInvoking += new System.EventHandler(this.createFixedTask_MethodInvoking);
            // 
            // ifElseActivity7
            // 
            this.ifElseActivity7.Activities.Add(this.ifWaitingClosed);
            this.ifElseActivity7.Activities.Add(this.ifWaitingResubmit);
            this.ifElseActivity7.Name = "ifElseActivity7";
            // 
            // onWaitingChanged
            // 
            this.onWaitingChanged.AfterProperties = null;
            this.onWaitingChanged.BeforeProperties = null;
            this.onWaitingChanged.CorrelationToken = correlationtoken4;
            this.onWaitingChanged.Executor = null;
            this.onWaitingChanged.Name = "onWaitingChanged";
            this.onWaitingChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onWaitingChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWaitingChanged_Invoked);
            // 
            // codeInitWaiting
            // 
            this.codeInitWaiting.Name = "codeInitWaiting";
            this.codeInitWaiting.ExecuteCode += new System.EventHandler(this.codeInitWaiting_ExecuteCode);
            // 
            // createWaitingTask
            // 
            this.createWaitingTask.ContentTypeId = "0x01080100BFFDDAD4FDE84D1CB164F744FA4EE57E";
            this.createWaitingTask.CorrelationToken = correlationtoken4;
            this.createWaitingTask.ListItemId = -1;
            this.createWaitingTask.Name = "createWaitingTask";
            this.createWaitingTask.SpecialPermissions = null;
            this.createWaitingTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createWaitingTask.TaskProperties = null;
            this.createWaitingTask.MethodInvoking += new System.EventHandler(this.createWaitingTask_MethodInvoking);
            // 
            // ifElseActivity4
            // 
            this.ifElseActivity4.Activities.Add(this.ifActiveFixed);
            this.ifElseActivity4.Activities.Add(this.ifActiveWad);
            this.ifElseActivity4.Activities.Add(this.ifActiveWaiting);
            this.ifElseActivity4.Activities.Add(this.ifActiveNotStarted);
            this.ifElseActivity4.Name = "ifElseActivity4";
            // 
            // onActiveChanged
            // 
            this.onActiveChanged.AfterProperties = null;
            this.onActiveChanged.BeforeProperties = null;
            correlationtoken7.Name = "taskToken";
            correlationtoken7.OwnerActivityName = "Workflow1";
            this.onActiveChanged.CorrelationToken = correlationtoken7;
            this.onActiveChanged.Executor = null;
            this.onActiveChanged.Name = "onActiveChanged";
            this.onActiveChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onActiveChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onActiveChanged_Invoked);
            // 
            // codeInitActive
            // 
            this.codeInitActive.Name = "codeInitActive";
            this.codeInitActive.ExecuteCode += new System.EventHandler(this.codeInitActive_ExecuteCode);
            // 
            // ifElseActivity5
            // 
            this.ifElseActivity5.Activities.Add(this.ifWadClosed);
            this.ifElseActivity5.Activities.Add(this.ifWadResubmit);
            this.ifElseActivity5.Name = "ifElseActivity5";
            // 
            // onWadChanged
            // 
            this.onWadChanged.AfterProperties = null;
            this.onWadChanged.BeforeProperties = null;
            this.onWadChanged.CorrelationToken = correlationtoken6;
            this.onWadChanged.Executor = null;
            this.onWadChanged.Name = "onWadChanged";
            this.onWadChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onWadChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWadChanged_Invoked);
            // 
            // codeInitWad
            // 
            this.codeInitWad.Name = "codeInitWad";
            this.codeInitWad.ExecuteCode += new System.EventHandler(this.codeInitWad_ExecuteCode);
            // 
            // createWadTask
            // 
            this.createWadTask.ContentTypeId = "0x010801002BB2E8C199C54880B6F7495585C1E967";
            this.createWadTask.CorrelationToken = correlationtoken6;
            this.createWadTask.ListItemId = -1;
            this.createWadTask.Name = "createWadTask";
            this.createWadTask.SpecialPermissions = null;
            this.createWadTask.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.createWadTask.TaskProperties = null;
            this.createWadTask.MethodInvoking += new System.EventHandler(this.createWadTask_MethodInvoking);
            // 
            // ifElseActivity3
            // 
            this.ifElseActivity3.Activities.Add(this.ifAssignedFixed);
            this.ifElseActivity3.Activities.Add(this.ifAssignedWad);
            this.ifElseActivity3.Activities.Add(this.ifAssignedWaiting);
            this.ifElseActivity3.Activities.Add(this.ifAssignedStated);
            this.ifElseActivity3.Name = "ifElseActivity3";
            // 
            // onAssignedChanged
            // 
            this.onAssignedChanged.AfterProperties = null;
            this.onAssignedChanged.BeforeProperties = null;
            this.onAssignedChanged.CorrelationToken = correlationtoken3;
            this.onAssignedChanged.Executor = null;
            this.onAssignedChanged.Name = "onAssignedChanged";
            this.onAssignedChanged.TaskId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.onAssignedChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onAssignedChanged_Invoked);
            // 
            // codeInitAssigned
            // 
            this.codeInitAssigned.Name = "codeInitAssigned";
            this.codeInitAssigned.ExecuteCode += new System.EventHandler(this.codeInitAssigned_ExecuteCode);
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ifNotCreated);
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // setInitialPending
            // 
            this.setInitialPending.Name = "setInitialPending";
            this.setInitialPending.TargetStateName = "statePending";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken8.Name = "workflowToken";
            correlationtoken8.OwnerActivityName = "Workflow1";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken8;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // eventPending
            // 
            this.eventPending.Activities.Add(this.onPendingChanged);
            this.eventPending.Activities.Add(this.ifElseActivity1);
            this.eventPending.Name = "eventPending";
            // 
            // initPending
            // 
            this.initPending.Activities.Add(this.createPendingTask);
            this.initPending.Activities.Add(this.codeInitPending);
            this.initPending.Name = "initPending";
            // 
            // eventFixed
            // 
            this.eventFixed.Activities.Add(this.onFixedChanged);
            this.eventFixed.Activities.Add(this.ifElseActivity9);
            this.eventFixed.Name = "eventFixed";
            // 
            // initFixed
            // 
            this.initFixed.Activities.Add(this.createFixedTask);
            this.initFixed.Activities.Add(this.codeInitFixed);
            this.initFixed.Name = "initFixed";
            // 
            // eventWaiting
            // 
            this.eventWaiting.Activities.Add(this.onWaitingChanged);
            this.eventWaiting.Activities.Add(this.ifElseActivity7);
            this.eventWaiting.Name = "eventWaiting";
            // 
            // initWaiting
            // 
            this.initWaiting.Activities.Add(this.createWaitingTask);
            this.initWaiting.Activities.Add(this.codeInitWaiting);
            this.initWaiting.Name = "initWaiting";
            // 
            // eventActive
            // 
            this.eventActive.Activities.Add(this.onActiveChanged);
            this.eventActive.Activities.Add(this.ifElseActivity4);
            this.eventActive.Name = "eventActive";
            // 
            // initActive
            // 
            this.initActive.Activities.Add(this.codeInitActive);
            this.initActive.Name = "initActive";
            // 
            // eventWad
            // 
            this.eventWad.Activities.Add(this.onWadChanged);
            this.eventWad.Activities.Add(this.ifElseActivity5);
            this.eventWad.Name = "eventWad";
            // 
            // initWad
            // 
            this.initWad.Activities.Add(this.createWadTask);
            this.initWad.Activities.Add(this.codeInitWad);
            this.initWad.Name = "initWad";
            // 
            // eventAssigned
            // 
            this.eventAssigned.Activities.Add(this.onAssignedChanged);
            this.eventAssigned.Activities.Add(this.ifElseActivity3);
            this.eventAssigned.Name = "eventAssigned";
            // 
            // initAssigned
            // 
            this.initAssigned.Activities.Add(this.ifElseActivity2);
            this.initAssigned.Activities.Add(this.codeInitAssigned);
            this.initAssigned.Name = "initAssigned";
            // 
            // eventInitial
            // 
            this.eventInitial.Activities.Add(this.onWorkflowActivated1);
            this.eventInitial.Activities.Add(this.setInitialPending);
            this.eventInitial.Name = "eventInitial";
            // 
            // statePending
            // 
            this.statePending.Activities.Add(this.initPending);
            this.statePending.Activities.Add(this.eventPending);
            this.statePending.Name = "statePending";
            // 
            // stateFinal
            // 
            this.stateFinal.Name = "stateFinal";
            // 
            // stateFixed
            // 
            this.stateFixed.Activities.Add(this.initFixed);
            this.stateFixed.Activities.Add(this.eventFixed);
            this.stateFixed.Name = "stateFixed";
            // 
            // stateWaiting
            // 
            this.stateWaiting.Activities.Add(this.initWaiting);
            this.stateWaiting.Activities.Add(this.eventWaiting);
            this.stateWaiting.Name = "stateWaiting";
            // 
            // stateActive
            // 
            this.stateActive.Activities.Add(this.initActive);
            this.stateActive.Activities.Add(this.eventActive);
            this.stateActive.Name = "stateActive";
            // 
            // stateWad
            // 
            this.stateWad.Activities.Add(this.initWad);
            this.stateWad.Activities.Add(this.eventWad);
            this.stateWad.Name = "stateWad";
            // 
            // stateAssigned
            // 
            this.stateAssigned.Activities.Add(this.initAssigned);
            this.stateAssigned.Activities.Add(this.eventAssigned);
            this.stateAssigned.Name = "stateAssigned";
            // 
            // stateInitial
            // 
            this.stateInitial.Activities.Add(this.eventInitial);
            this.stateInitial.Name = "stateInitial";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.stateInitial);
            this.Activities.Add(this.stateAssigned);
            this.Activities.Add(this.stateWad);
            this.Activities.Add(this.stateActive);
            this.Activities.Add(this.stateWaiting);
            this.Activities.Add(this.stateFixed);
            this.Activities.Add(this.stateFinal);
            this.Activities.Add(this.statePending);
            this.CompletedStateName = "stateFinal";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "stateInitial";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private SetStateActivity setInitialPending;

        private IfElseBranchActivity ifNotFixed;

        private IfElseBranchActivity ifFixed;

        private IfElseActivity ifElseActivity9;

        private SetStateActivity setFixedClosed;

        private CodeActivity codeFixedClosed;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeFixedWork;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeFixed;

        private SetStateActivity setFixedAsigned;

        private CodeActivity codeFixedNotFixed;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeFixedAssigned;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onFixedChanged;

        private EventDrivenActivity eventFixed;

        private SetStateActivity setWadPending;

        private SetStateActivity setWadAssigned;

        private IfElseBranchActivity ifWadNotAssigned;

        private IfElseBranchActivity ifWadAssigned;

        private IfElseActivity ifElseActivity6;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWadResubmit;

        private SetStateActivity setWadClosed;

        private SetStateActivity setWaitingPending;

        private SetStateActivity setWaitingAssigned;

        private IfElseBranchActivity ifWaitingNotAssigned;

        private IfElseBranchActivity ifWaitingAssigned;

        private IfElseActivity ifElseActivity8;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWaitingResubmit;

        private SetStateActivity setWaitingClosed;

        private CodeActivity codeWaitingClosed;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWaitingWork;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWaiting;

        private IfElseBranchActivity ifWaitingResubmit;

        private IfElseBranchActivity ifWaitingClosed;

        private IfElseActivity ifElseActivity7;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onWaitingChanged;

        private EventDrivenActivity eventWaiting;

        private IfElseBranchActivity ifWadResubmit;

        private IfElseBranchActivity ifWadClosed;

        private IfElseActivity ifElseActivity5;

        private CodeActivity codeWadClosed;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWadWork;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeWad;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onWadChanged;

        private EventDrivenActivity eventWad;

        private IfElseBranchActivity ifAssignedStated;

        private IfElseBranchActivity ifAssignedWaiting;

        private IfElseBranchActivity ifAssignedFixed;

        private IfElseBranchActivity ifAssignedWad;

        private IfElseActivity ifElseActivity3;

        private SetStateActivity setAssignedActive;

        private SetStateActivity setAssignedWaiting;

        private SetStateActivity setAssignedWad;

        private SetStateActivity setAssignedFixed;

        private SetStateActivity setActiveAssigned;

        private SetStateActivity setActiveWaiting;

        private SetStateActivity setActiveWad;

        private SetStateActivity setActiveFixed;

        private IfElseBranchActivity ifActiveNotStarted;

        private IfElseBranchActivity ifActiveWaiting;

        private IfElseBranchActivity ifActiveWad;

        private IfElseBranchActivity ifActiveFixed;

        private IfElseActivity ifElseActivity4;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onActiveChanged;

        private EventDrivenActivity eventActive;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onAssignedChanged;

        private EventDrivenActivity eventAssigned;

        private CodeActivity codeInitWad;

        private CodeActivity codeInitWaiting;

        private CodeActivity codeInitFixed;

        private IfElseBranchActivity ifElseBranchActivity2;

        private IfElseBranchActivity ifNotCreated;

        private IfElseActivity ifElseActivity2;

        private CodeActivity codeInitAssigned;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createAssignedTask;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createWadTask;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createWaitingTask;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createFixedTask;

        private SetStateActivity setPendingAssigned;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completePendingAssigned;

        private SetStateActivity setPendingWad;

        private CodeActivity codeInitActive;

        private IfElseBranchActivity ifPendingAssigned;

        private IfElseBranchActivity ifPendingWad;

        private IfElseActivity ifElseActivity1;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completePendingWad;

        private EventDrivenActivity eventPending;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onPendingChanged;

        private CodeActivity codeInitPending;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createPendingTask;

        private StateInitializationActivity initPending;

        private StateInitializationActivity initFixed;

        private StateInitializationActivity initWaiting;

        private StateInitializationActivity initActive;

        private StateInitializationActivity initWad;

        private StateInitializationActivity initAssigned;

        private StateActivity statePending;

        private StateActivity stateFinal;

        private StateActivity stateFixed;

        private StateActivity stateWaiting;

        private StateActivity stateActive;

        private StateActivity stateWad;

        private StateActivity stateAssigned;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;

        private EventDrivenActivity eventInitial;

        private StateActivity stateInitial;



































































    }
}
