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
using System.Threading;

using WF_Chapter12.Workflow1.SPPart3;

namespace WF_Chapter11.Workflow1
{
    [Serializable]
    public class Invitee
    {
        public string AssignedTo { get; set; }
        public Guid TaskId { get; set; }
        public bool Complete { get; set; }

        public Invitee(string assignedTo)
        {
            AssignedTo = assignedTo;
            Complete = false;
        }
    }

    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties =
            new SPWorkflowActivationProperties();

        public SPContentTypeId contentTypeId =
            new SPContentTypeId("0x010801000da2ad56f41a465bbaa3311519728c2c");
        //("0x01080100211c4a0fc8144c7eb270141b81e38a8a");
        public string contentTypeIdString = "";

        private string _eventName;
        private string _menuUrl;
        public List<Invitee> ChildData = new List<Invitee>();
        private int _task = 0;
        private string _relatedItem = "";
        private string _orders = "";

        private void onWorkflowActivated1_Invoked(object sender,
            ExternalDataEventArgs e)
        {
            SPListItem item = workflowProperties.Item;
            _eventName = item.Title;
            _menuUrl = item["MenuUrl"].ToString();
            _relatedItem = string.Format("ID={0},", item.ID);

            List<SPFieldUserValue> l = (List<SPFieldUserValue>)item["Attendees"];
            foreach (SPFieldUserValue u in l)
            {
                ChildData.Add(new Invitee(u.User.LoginName));
            }

            try
            {
                workflowProperties.TaskList.ContentTypesEnabled = true;
                SPContentTypeId matchContentTypeId = workflowProperties.TaskList
                    .ContentTypes.BestMatch(contentTypeId);
                if (matchContentTypeId.Parent.CompareTo(contentTypeId) != 0)
                {
                    SPContentType ct = workflowProperties.TaskList.ParentWeb
                        .AvailableContentTypes[contentTypeId];
                    workflowProperties.TaskList.ContentTypes.Add(ct);
                    workflowProperties.TaskList.Update();
                }

                contentTypeIdString = contentTypeId.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void createTask_MethodInvoking(object sender, EventArgs e)
        {
            // Get the task object from the sender parameter
            CreateTaskWithContentType task = sender as CreateTaskWithContentType;

            // Assign a new TaskId
            task.TaskId = Guid.NewGuid();

            // Safely get the next Invitee
            Mutex m = new Mutex(false);
            Invitee i = (Invitee)ChildData[_task++];
            m.Close();

            // Setup the task properties
            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.AssignedTo = i.AssignedTo;
            wtp.TaskType = 0;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Enter your lunch order";
            wtp.Description = _eventName;
            wtp.ExtendedProperties["MenuUrl"] = _menuUrl;

            task.TaskProperties = wtp;

            // Store the taskID in the Invitee object
            i.TaskId = task.TaskId;

            // Store the taskID on the OnTaskChanged activity
            Activity seq = task.Parent;
            if (seq != null)
            {
                Activity w = seq.GetActivityByName("whileActivity1");
                if (w != null)
                {
                    OnTaskChanged tc = (OnTaskChanged)w.GetActivityByName("onTaskChanged1");
                    if (tc != null)
                        tc.TaskId = task.TaskId;
                }
            }
        }

        private void notCompleted(object sender, ConditionalEventArgs e)
        {
            WhileActivity w = sender as WhileActivity;
            OnTaskChanged tc = (OnTaskChanged)w.GetActivityByName("onTaskChanged1");

            e.Result = true;

            foreach (Invitee i in ChildData)
            {
                if (i.TaskId == tc.TaskId)
                {
                    e.Result = !i.Complete;
                    break;
                }
            }
        }

        private void onTaskChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            SPTaskServiceEventArgs args = (SPTaskServiceEventArgs)e;

            // Find this Invitee and mark it complete
            foreach (Invitee i in ChildData)
            {
                if (i.TaskId == args.taskId)
                {
                    i.Complete = true;
                    break;
                }
            }
        }

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            CreateTask task = sender as CreateTask;
            task.TaskId = Guid.NewGuid();

            SPWorkflowTaskProperties wtp = new SPWorkflowTaskProperties();
            wtp.PercentComplete = (float)0.0;
            wtp.TaskType = 0;
            wtp.DueDate = DateTime.Now.AddDays(1);
            wtp.Title = "Lunch orders are complete";
            wtp.Description = _orders;

            task.TaskProperties = wtp;
        }

        private void collectOrders_ExecuteCode(object sender, EventArgs e)
        {
            SPPart3DataContext dc = new SPPart3DataContext("http://omega5/part3");

            IQueryable<LunchOrderTask> q 
                = dc.Tasks.OfType<LunchOrderTask>() 
                    .Where(x => x.RelatedContent.Contains(_relatedItem));

            _orders = "The lunch orders are as follows:\r\n";

            foreach (LunchOrderTask i in q)
            {
                _orders += i.AssignedTo;

                if (i.NoThanks.HasValue && i.NoThanks.Value)
                {
                    _orders += " - not eating";
                }
                else
                {
                    _orders += string.Format("\r\nEntree: {0}\r\nSides: {1}\r\nInstructions: {2}",
                        i.Entree, i.Sides, i.SpecialInstructions);
                }
                _orders += "\r\n\r\n";
            }
        }
    }
}
