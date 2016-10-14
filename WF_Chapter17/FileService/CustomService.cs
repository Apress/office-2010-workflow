using System;
using System.Collections.Generic;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using System.Threading;
using System.IO;
using System.Workflow.Runtime;

namespace FileService
{
    //-----------------------------------------------------
    // This class is used to pass the SharePoint and 
    // workflow data between threads
    //-----------------------------------------------------
    internal class ServiceState
    {
        internal SPWeb _web;
        internal Guid _instanceID;
        internal string _path;

        public ServiceState(SPWeb web, Guid instanceID, string path)
        {
            _web = web;
            _instanceID = instanceID;
            _path = path;
        }
    }


    //-----------------------------------------------------
    // This class implements the ICustomService interface
    //-----------------------------------------------------
    public class CustomService : SPWorkflowExternalDataExchangeService,
                                 ICustomService
    {
        //-------------------------------------------------
        // Implement the ICustomService interface
        //-------------------------------------------------
        public event EventHandler<CustomEventArgs> DataOutput;

        public void GetFolderContent(string path)
        {
            // Schedule the work on a different thread
            ThreadPool.QueueUserWorkItem
                (GetFolderContent,
                 new ServiceState(CurrentWorkflow.ParentWeb,
                                  WorkflowEnvironment.WorkflowInstanceId,
                                  path));

            // This method returns as soon as the work is scheduled
        }

        //-------------------------------------------------
        // This method performs the work on a different thread
        //-------------------------------------------------
        private void GetFolderContent(object state)
        {
            ServiceState s = state as ServiceState;

            // Get the folders
            List<string> contents =
                new List<string>((System.IO.Directory.GetDirectories(s._path)));

            // Add the files
            contents.AddRange(System.IO.Directory.GetFiles(s._path));

            // Return the results
            RaiseEvent(s._web,
                       s._instanceID,
                       typeof(ICustomService),
                       "DataOutput",
                       new object[] { contents });
        }

        //-------------------------------------------------
        // This method responds to the RaiseEvent call to
        // format and send the event
        //-------------------------------------------------
        public override void CallEventHandler
            (Type eventType,
             string eventName,
             object[] eventData,
             SPWorkflow workflow,
             string identity,
             IPendingWork workHandler,
             object workItem)
        {

            switch (eventName)
            {
                case "DataOutput":
                    CustomEventArgs e = new CustomEventArgs(workflow.InstanceId);
                    e.Identity = identity;
                    e.WorkHandler = workHandler;
                    e.WorkItem = workItem;
                    e.contents = (List<string>)eventData[0];

                    // Raise the event
                    DataOutput(null, e);
                    break;
            }
        }

        //-------------------------------------------------
        // Provide an implementation for the remaining
        // SPWorkflowExternalDataExchangeService methods
        //-------------------------------------------------
        public override void CreateSubscription
            (System.Workflow.Activities.MessageEventSubscription subscription)
        {
            throw new NotImplementedException();
        }

        public override void DeleteSubscription(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}
