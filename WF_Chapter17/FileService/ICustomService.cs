using System;
using System.Collections.Generic;
using System.Workflow.Activities;

namespace FileService
{
    [Serializable]
    public class CustomEventArgs : ExternalDataEventArgs
    {
        public CustomEventArgs(Guid id)
            : base(id)
        {
        }

        public List<string> contents;
    }

    [ExternalDataExchange]
    public interface ICustomService
    {
        event EventHandler<CustomEventArgs> DataOutput;
        void GetFolderContent(string path);
    }
}
