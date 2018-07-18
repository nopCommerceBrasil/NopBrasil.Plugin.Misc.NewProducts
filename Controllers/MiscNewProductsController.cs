using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using NopBrasil.Plugin.Misc.NewProducts.Models;

namespace NopBrasil.Plugin.Misc.NewProducts.Controllers
{
    [Area(AreaNames.Admin)]
    public class MiscNewProductsController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly NewProductsSettings _newProductsSettings;

        public MiscNewProductsController(NewProductsSettings newProductsSettings, ISettingService settingService, ILocalizationService localizationService)
        {
            this._newProductsSettings = newProductsSettings;
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                Disable = _newProductsSettings.Disable,
                NumberOfDaysAsNew = _newProductsSettings.NumberOfDaysAsNew
            };
            return View("~/Plugins/Misc.NewProducts/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }

            _newProductsSettings.NumberOfDaysAsNew = model.NumberOfDaysAsNew;
            _newProductsSettings.Disable = model.Disable;
            _settingService.SaveSetting(_newProductsSettings);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}