using Nop.Core.Configuration;

namespace NopBrasil.Plugin.Misc.NewProducts
{
    public class NewProductsSettings : ISettings
    {
        public bool Disable { get; set; }

        public int NumberOfDaysAsNew { get; set; }
    }
}