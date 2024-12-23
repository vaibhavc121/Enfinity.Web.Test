using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string UOM { get; set; }
        public string Type { get; set; }
        public string TrackingMode { get; set; }
        public string CostingMethod { get; set; }
        public string ExpectedName {get; set;}
        public List<SubItemModel> SubItems { get; set; }

    }   
    public class SubItemModel
    {
        public string SubItem { get; set; }
        public string Qty { get; set; }
        public string ExpectedName { get; set; }
    }
}
