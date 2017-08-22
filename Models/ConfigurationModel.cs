using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace NopBrasil.Plugin.Misc.NewProducts.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Misc.NewProducts.Fields.Disable")]
        [AllowHtml]
        public bool Disable { get; set; }

        [NopResourceDisplayName("Plugins.Misc.NewProducts.Fields.NumberOfDaysAsNew")]
        [AllowHtml]
        public int NumberOfDaysAsNew { get; set; }

        public ConfigurationModel()
        {
        }
    }
}