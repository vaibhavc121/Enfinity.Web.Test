using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class PriceListModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public string Markup { get; set; }
        public string Markdown { get; set; }
        public string Percentage { get; set; }         
        public string MinUnitPricePercent { get; set; }
        public string MaxUnitPricePercent { get; set; }           
        public string DefaultDiscountPercent { get; set; }
        public string MaxDiscountPrecent { get; set; }
        public string ItemGroup { get; set; }
        public string ItemCategory { get; set; }
        public string ItemBrand { get; set; }
    }
}
