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
    public class PromotionRequestModel
    {
        public string txnDate { get; set; }
        public string effectiveDate { get; set; }
        public string effectiveDate1 { get; set; }
        public string type { get; set; }
        public string newDepartment { get; set; }
        public string newDesignation { get; set; }
        public string newWorkLocation { get; set; }
        public string newProject { get; set; }
        public string description { get; set; }
        public string salaryComponent { get; set; }
        public string incrementAmount { get; set; }
        public string effectiveFromDate { get; set; }
        public string effectiveToDate { get; set; }

    }

    public class OvertimeRequestModel
    {
        public string overtimeDate { get; set; }
        public string overtimeType { get; set; }
        public string hrs { get; set; }
        public string remarks { get; set; }

    }

    public class ResignationModel
    {
        public string submittedDate { get; set; }             
        public string remarks { get; set; }

    }
    public class SupportRequestCategoryModel
    {
        public string categoryName { get; set; }
        public string requestedTo { get; set; }
        public string priority { get; set; }
        public string workflow { get; set; }
        public string attachment { get; set; }
        public string desc { get; set; }

    }
    public class DeleteSupportRequestCategoryModel
    {
        public string categoryName { get; set; }
       
    }


}
