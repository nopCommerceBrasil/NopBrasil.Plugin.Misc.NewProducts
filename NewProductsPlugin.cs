using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Common;

namespace NopBrasil.Plugin.Misc.NewProducts
{
    public class NewProductsPlugin : BasePlugin, IMiscPlugin
    {
        private readonly ISettingService _settingService;
        private readonly NewProductsSettings _newProductsSettings;
        private readonly IWebHelper _webHelper;

        public NewProductsPlugin(ISettingService settingService, NewProductsSettings newProductsSettings, IWebHelper webHelper)
        {
            this._settingService = settingService;
            this._newProductsSettings = newProductsSettings;
            this._webHelper = webHelper;
        }

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/MiscNewProducts/Configure";

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
