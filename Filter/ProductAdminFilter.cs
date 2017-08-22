using Nop.Admin.Controllers;
using Nop.Admin.Models.Catalog;
using Nop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NopBrasil.Plugin.Misc.NewProducts.Services;

namespace NopBrasil.Plugin.Misc.NewProducts.Filter
{
    public class ProductAdminFilter : ActionFilterAttribute, IFilterProvider
    {
        public IEnumerable<System.Web.Mvc.Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if ((controllerContext.Controller is ProductController) &&
                ((ValidateActionName("Create", 0, actionDescriptor)) || (ValidateActionName("CopyProduct", 1, actionDescriptor))))
            {
                return new List<System.Web.Mvc.Filter>() { new System.Web.Mvc.Filter(this, FilterScope.Action, 0) };
            }
            return new List<System.Web.Mvc.Filter>();
        }

        private bool ValidateActionName(string actionName, int qtdParameters, ActionDescriptor actionDescriptor)
        {
            return (actionDescriptor.ActionName.Equals(actionName, StringComparison.InvariantCultureIgnoreCase)) &&
                    (actionDescriptor.GetParameters().Count() == qtdParameters);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                INewProductsService newProductsService = EngineContext.Current.Resolve<INewProductsService>();
                if (filterContext.Controller.ViewData.Model is ProductModel)
                    newProductsService.UpdateProductModel((ProductModel)filterContext.Controller.ViewData.Model);
            }
            catch
            {
            }
        }
    }
}
