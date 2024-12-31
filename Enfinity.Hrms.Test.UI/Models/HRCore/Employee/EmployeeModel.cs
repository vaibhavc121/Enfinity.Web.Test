using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.Employee
{
    public class EmployeeModel
    {

    }

    public class PersonalTabModel
    {
        public string nameL2 { get; set; }
        public string displayName { get; set; }
        public string displayNameL2 { get; set; }
        public string DOB { get; set; }
        public string nationality { get; set; }
        public string bloodGroup { get; set; }
        public string photoVisibility { get; set; }
        public string mobileNumberVisibility { get; set; }
        public string emailVisibility { get; set; }
    }

    public class JobTabModel
    {
        public string manager { get; set; }
        public string substituteEmployee { get; set; }
        public string category { get; set; }
        public string workLocation { get; set; }
        public string employmentType { get; set; }
        public string probationPeriod { get; set; }
        public string noticePeriod { get; set; }
        public string priorCompany { get; set; }
        public string startDate { get; set; }
        public string qualification { get; set; }
        public string university { get; set; }
        public string YearOfPassing { get; set; }
    }

    public class PayrollTabModel
    {
        public string payrollset { get; set; }
        public string paymentMode { get; set; }
        public string employeebank { get; set; }
        public string bankAccountType { get; set; }
        public string govtRecruitmentContractLicense { get; set; }
        public string salaryComponent { get; set; }
        public string amount { get; set; }
        public string effectiveFromDate { get; set; }
        public string overtimeType { get; set; }
        public string relationshipType { get; set; }
        public string description { get; set; }
        public string ticketAccrual { get; set; }
        public string ticketDestination { get; set; }
        public string ticketEffectiveFromDate { get; set; }
        public string accrualType { get; set; }
        public string accrualAmount { get; set; }
        public string resetAvailedDaysMethod { get; set; }
        public string BSrelationshipType { get; set; }
        public string benefitScheme { get; set; }
        public string BSeffectiveFromDate { get; set; }
        public string BSeffectiveToDate { get; set; }
       
    }


}
