using System.Web.Routing;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Common;

namespace NopBrasil.Plugin.Misc.NewProducts
{
    public class NewProductsPlugin : BasePlugin, IMiscPlugin
    {
        private readonly ISettingService _settingService;
        private readonly NewProductsSettings _newProductsSettings;

        public NewProductsPlugin(ISettingService settingService, NewProductsSettings newProductsSettings)
        {
            this._settingService = settingService;
            this._newProductsSettings = newProductsSettings;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "MiscNewProducts";
            routeValues = new RouteValueDictionary { { "Namespaces", "NopBrasil.Plugin.Misc.NewProducts.Controllers" }, { "area", null } };
        }

        public override void Install()
        {
            var settings = new NewProductsSettings
            {
                NumberOfDaysAsNew = 30,
                Disable = false
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew", "Number Of Days As New");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew.Hint", "Number of days the product is set up as new");
            
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable", "Disable");
            this.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable.Hint", "Disable plugin");

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<NewProductsSettings>();

            this.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew");
            this.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew.Hint");

            this.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable");
            this.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable.Hint");

            base.Uninstall();
        }
    }
}
