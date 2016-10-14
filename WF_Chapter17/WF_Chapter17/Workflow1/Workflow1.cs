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

namespace WF_Chapter17.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        public static DependencyProperty eventArgsProperty = DependencyProperty.Register("eventArgs", typeof(FileService.CustomEventArgs), typeof(WF_Chapter17.Workflow1.Workflow1));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public FileService.CustomEventArgs eventArgs
        {
            get
            {
                return ((FileService.CustomEventArgs)(base.GetValue(WF_Chapter17.Workflow1.Workflow1.eventArgsProperty)));
            }
            set
            {
                base.SetValue(WF_Chapter17.Workflow1.Workflow1.eventArgsProperty, value);
            }
        }

        private void sendEmail1_MethodInvoking(object sender, EventArgs e)
        {
            SendEmail email = sender as SendEmail;
            if (email != null)
            {
                email.Body = "The content of this directory are: <br><br>";
                foreach (string s in eventArgs.contents)
                {
                    email.Body += " - " + s + "<br>";
                }
            }
        }
    }
}
