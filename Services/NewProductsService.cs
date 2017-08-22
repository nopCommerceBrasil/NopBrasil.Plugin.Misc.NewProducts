using Nop.Admin.Models.Catalog;
using System;

namespace NopBrasil.Plugin.Misc.NewProducts.Services
{
    public class NewProductsService : INewProductsService
    {
        private readonly NewProductsSettings _newProductsSettings;

        public NewProductsService(NewProductsSettings newProductsSettings)
        {
            this._newProductsSettings = newProductsSettings;
        }

        public void UpdateProductModel(ProductModel model)
        {
            bool recentlyCreated = (!model.CreatedOn.HasValue) || (model.CreatedOn.Value.AddMinutes(1).ToUniversalTime() >= DateTime.UtcNow);
            if ((!_newProductsSettings.Disable) && (_newProductsSettings.NumberOfDaysAsNew > 0) && (!model.MarkAsNew) && (recentlyCreated))
            {
                model.MarkAsNew = true;
                model.MarkAsNewStartDateTimeUtc = DateTime.UtcNow;
                model.MarkAsNewEndDateTimeUtc = DateTime.UtcNow.AddDays(_newProductsSettings.NumberOfDaysAsNew);
            }
        }
    }
}