using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.SelfService
{
    public class LoanRequestModel 
    {
        public string repaymentStartPeriod { get;set; }
        public string loanType { get; set; }
        public string loanAmt { get; set; }
        public string numberOfInstallments { get; set; }
        public string remarks { get; set; }
        public string empName { get; set; }
        
    }
    public class BenefitClaimModel
    {
        public string claimDate { get; set; }
        public string benefitScheme { get; set; }
        public string claimAmount { get; set; }
        public string paymentType { get; set; }
        public string remarks { get; set; }
        public string empName { get; set; }

    }
    public class TravelRequestModel
    {
        public string fromDate { get; set; }
        public string uptoDate { get; set; }
        public string category { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string ticketDestination { get; set; }
        public string ticketAmt { get; set; }
        public string purpose { get; set; }
        public string paymentType { get; set; }
        public string remarks { get; set; }
        public string empName { get; set; }

    }

}
