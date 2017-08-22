using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using System.Web.Mvc;
using NopBrasil.Plugin.Misc.NewProducts.Controllers;
using NopBrasil.Plugin.Misc.NewProducts.Filter;
using NopBrasil.Plugin.Misc.NewProducts.Services;

namespace NopBrasil.Plugin.Misc.NewProducts.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<MiscNewProductsController>().AsSelf();
            builder.RegisterType<NewProductsService>().As<INewProductsService>().InstancePerDependency();
            builder.RegisterType<ProductAdminFilter>().As<IFilterProvider>();
        }

        public int Order => 2;
    }
}
