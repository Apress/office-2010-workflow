using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
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

namespace ActivityLibrary
{
    public partial class CreateEvent : Activity
    {
        public CreateEvent()
        {
            InitializeComponent();
        }

        // Add properties here...
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(CreateEvent));

        [Description("Title")]
        [Category("Title Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get
            {
                return ((string)(base.GetValue(CreateEvent.TitleProperty)));
            }
            set
            {
                base.SetValue(CreateEvent.TitleProperty, value);
            }
        }

        public static DependencyProperty StartTimeProperty = DependencyProperty.Register("StartTime", typeof(DateTime), typeof(CreateEvent));

        [Description("StartTime")]
        [Category("StartTime Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public DateTime StartTime
        {
            get
            {
                return ((DateTime)(base.GetValue(CreateEvent.StartTimeProperty)));
            }
            set
            {
                base.SetValue(CreateEvent.StartTimeProperty, value);
            }
        }

        public static DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(int), typeof(CreateEvent));

        [Description("Duration")]
        [Category("Duration Category")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Duration
        {
            get
            {
                return ((int)(base.GetValue(CreateEvent.DurationProperty)));
            }
            set
            {
                base.SetValue(CreateEvent.DurationProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                SPList calendar = web.Lists["Calendar"];
                SPListItemCollection events = calendar.Items;
                SPListItem item = events.Add();

                item[SPBuiltInFieldId.Title] = Title;
                item[SPBuiltInFieldId.StartDate] = StartTime.ToUniversalTime();
                item[SPBuiltInFieldId.Duration] = Duration;
                item[SPBuiltInFieldId.EndDate] = StartTime.ToUniversalTime() + TimeSpan.FromSeconds(Duration);

                item.Update();
            }

            return ActivityExecutionStatus.Closed;
        }
    }
}
