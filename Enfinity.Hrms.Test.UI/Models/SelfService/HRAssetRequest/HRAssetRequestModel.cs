using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest
{
    public class HRAssetRequestModel
    {
        public string txnDate { get; set; }
        public string txnDate1 { get; set; }
        public string effectiveDate { get; set; }
        public string HRAsset { get; set; }
        public string expReturnDate { get; set; }
        public string status { get; set; }
        public string emp { get; set; }
    }
    public class HRAssetReturnModel
    {
        public string txnDate { get; set; }
        public string effectiveDate { get; set; }
        public string HRAsset { get; set; }
        public string expReturnDate { get; set; }
        public string status { get; set; }
        public string emp { get; set; }
    }
}
