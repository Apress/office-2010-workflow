using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

using Microsoft.SharePoint.Administration;

namespace WF_Chapter17.Features.Feature2
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("b7339f9e-1e7d-4086-a6e3-f845c3e5cdbf")]
    public class Feature2EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            // Create a configuration object
            SPWebConfigModification config = new SPWebConfigModification();
            config.Type =
                SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            config.Owner = "WF_Chapter17";
            config.Name = "WorkflowService[Class='FileService.CustomService']";
            config.Path = "configuration/SharePoint/WorkflowServices";
            config.Value = @"<WorkflowService Assembly=""FileService, Version=1.0.0.0, " +
                @"Culture=neutral, PublicKeyToken=75da00303dcde51d"" " +
                @"Class=""FileService.CustomService"" />";

            // Get the web applications for this feature
            SPWebApplication app = (SPWebApplication)properties.Feature.Parent;

            // Apply the configuration changes
            app.WebConfigModifications.Add(config);
            app.WebService.ApplyWebConfigModifications();
            app.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


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
