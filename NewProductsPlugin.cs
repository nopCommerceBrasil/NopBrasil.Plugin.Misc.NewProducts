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
        private readonly ILocalizationService _localizationService;

        public NewProductsPlugin(ISettingService settingService, NewProductsSettings newProductsSettings, IWebHelper webHelper, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._newProductsSettings = newProductsSettings;
            this._webHelper = webHelper;
            this._localizationService = localizationService;
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

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew", "Number Of Days As New");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew.Hint", "Number of days the product is set up as new");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable", "Disable");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable.Hint", "Disable plugin");

            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<NewProductsSettings>();

            _localizationService.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable");
            _localizationService.DeletePluginLocaleResource("Plugins.Misc.NewProducts.Fields.Disable.Hint");

            base.Uninstall();
        }
    }
}
