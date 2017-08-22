using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using System.Web.Mvc;
using NopBrasil.Plugin.Misc.NewProducts.Models;

namespace NopBrasil.Plugin.Misc.NewProducts.Controllers
{
    public class MiscNewProductsController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly NewProductsSettings _newProductsSettings;

        public MiscNewProductsController(NewProductsSettings newProductsSettings, ISettingService settingService)
        {
            this._newProductsSettings = newProductsSettings;
            this._settingService = settingService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                Disable = _newProductsSettings.Disable,
                NumberOfDaysAsNew = _newProductsSettings.NumberOfDaysAsNew
            };

            return View("~/Plugins/Misc.NewProducts/Views/MiscNewProducts/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }

            _newProductsSettings.NumberOfDaysAsNew = model.NumberOfDaysAsNew;
            _newProductsSettings.Disable = model.Disable;

            _settingService.SaveSetting(_newProductsSettings);

            return Configure();
        }
    }
}