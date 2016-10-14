using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

using Microsoft.SharePoint.Administration;

namespace WF_Chapter16.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("d82d6801-9e35-4796-9578-b0bc7fd76521")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            // Create a configuration object
            SPWebConfigModification config = new SPWebConfigModification();
            config.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            config.Owner = "ActivityLibrary";
            config.Name = "authorizedType[@Assembly='ActivityLibrary'][@Namespace='ActivityLibrary'][@TypeName='*'][@Authorized='True']";
            config.Path = "configuration/System.Workflow.ComponentModel.WorkflowCompiler/authorizedTypes";
            config.Value = @"<authorizedType Assembly=""ActivityLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d6384a93fc3e8f6"" Namespace=""ActivityLibrary"" TypeName=""*"" Authorized=""True"" />";

            // Get the web application for this feature
            SPWebApplication app = (SPWebApplication)properties.Feature.Parent;

            // Apply the configuration changes
            app.WebConfigModifications.Add(config);
            app.WebService.ApplyWebConfigModifications();
        }

       
        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            // Create a configuration object
            SPWebConfigModification config = new SPWebConfigModification();
            config.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            config.Owner = "ActivityLibrary";
            config.Name = "authorizedType[@Assembly='ActivityLibrary'][@Namespace='ActivityLibrary'][@TypeName='*'][@Authorized='True']";
            config.Path = "configuration/System.Workflow.ComponentModel.WorkflowCompiler/authorizedTypes";
            config.Value = @"<authorizedType Assembly=""ActivityLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9d6384a93fc3e8f6"" Namespace=""ActivityLibrary"" TypeName=""*"" Authorized=""True"" />";

            // Get the web application for this feature
            SPWebApplication app = (SPWebApplication)properties.Feature.Parent;

            // Apply the configuration changes
            app.WebConfigModifications.Remove(config);
            app.WebService.ApplyWebConfigModifications();
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
