using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim
{
    public class ExpenseClaimModel
    {
        public string expenseDate { get; set; }
        public string remarks { get; set; }
        public string claimCategory { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
    }
}
