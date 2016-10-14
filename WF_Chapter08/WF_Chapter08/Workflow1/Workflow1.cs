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

namespace WF_Chapter08.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public static DependencyProperty taskIDProperty = DependencyProperty.Register("taskID", typeof(System.Guid), typeof(WF_Chapter08.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public Guid taskID
        {
            get
            {
                return ((System.Guid)(base.GetValue(WF_Chapter08.Workflow1.Workflow1.taskIDProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter08.Workflow1.Workflow1.taskIDProperty, value);
            }
        }

        public static DependencyProperty taskPropertiesProperty = DependencyProperty.Register("taskProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(WF_Chapter08.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Misc")]
        public SPWorkflowTaskProperties taskProperties
        {
            get
            {
                return ((Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)(base.GetValue(WF_Chapter08.Workflow1.Workflow1.taskPropertiesProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter08.Workflow1.Workflow1.taskPropertiesProperty, value);
            }
        }

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            taskID = Guid.NewGuid();

            taskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
            taskProperties.PercentComplete = (float)0.0;
            taskProperties.AssignedTo = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            taskProperties.DueDate = DateTime.Now.AddDays(1);
            taskProperties.Title = "Submit Status Report";
            taskProperties.Description = "Please submit your status report ASAP";
        }
    }
}
