using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace NopBrasil.Plugin.Misc.NewProducts.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Misc.NewProducts.Fields.Disable")]
        public bool Disable { get; set; }

        [NopResourceDisplayName("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew")]
        public int NumberOfDaysAsNew { get; set; }
    }
}