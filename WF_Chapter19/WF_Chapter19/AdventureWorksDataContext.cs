using System;

namespace WF_Chapter19
{
    public partial class AdventureWorksDataContext
    {

        public AdventureWorksDataContext() :
            base(global::WF_Chapter19.Settings.Default.AdventureWorksConnectionString,
                 mappingSource)
        {
            OnCreated();
        }
    }
}
