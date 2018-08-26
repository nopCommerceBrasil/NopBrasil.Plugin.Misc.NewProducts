using Nop.Services.Events;
using Nop.Web.Framework.Events;
using Nop.Web.Areas.Admin.Models.Catalog;
using NopBrasil.Plugin.Misc.NewProducts.Services;
using Nop.Web.Framework.Models;

namespace NopBrasil.Plugin.Misc.NewProducts.Consumer
{
    public class NewProductsConsumer : IConsumer<ModelPreparedEvent<BaseNopModel>>
    {
        private readonly INewProductsService _newProductsService;

        public NewProductsConsumer(INewProductsService newProductsService)
        {
            this._newProductsService = newProductsService;
        }

        public void HandleEvent(ModelPreparedEvent<BaseNopModel> eventMessage)
        {
            if (eventMessage.Model is ProductModel)
                _newProductsService.UpdateProductModel((ProductModel)eventMessage.Model);
        }
    }
}