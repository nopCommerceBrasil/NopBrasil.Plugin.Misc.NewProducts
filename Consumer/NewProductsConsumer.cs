using Nop.Services.Events;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Mvc.Models;
using Nop.Web.Areas.Admin.Models.Catalog;
using NopBrasil.Plugin.Misc.NewProducts.Services;

namespace NopBrasil.Plugin.Misc.NewProducts.Consumer
{
    public class NewProductsConsumer : IConsumer<ModelPrepared<BaseNopModel>>
    {
        private readonly INewProductsService _newProductsService;

        public NewProductsConsumer(INewProductsService newProductsService)
        {
            this._newProductsService = newProductsService;
        }

        public void HandleEvent(ModelPrepared<BaseNopModel> eventMessage)
        {
            if (eventMessage.Model is ProductModel)
                _newProductsService.UpdateProductModel((ProductModel)eventMessage.Model);
        }
    }
}