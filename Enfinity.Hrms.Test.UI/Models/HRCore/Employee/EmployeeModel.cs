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

    public class TimeOffTabModel
    {
        public string leaveType { get; set; }
        public string LTeffectiveFromDate { get; set; }
       
    }

    public class AttendanceTabModel
    {
        public string calendar { get; set; }
        public string checkInType { get; set; }
        public string defaultShift { get; set; }
        public string policy { get; set; }
        public string shiftPreference { get; set; }
       
    }

    public class DocumentsTabModel
    {
        public string documentType { get; set; }
        public string dateOfExpiry { get; set; }
        public string placeOfDocument { get; set; }        

    }

    public class PerformanceTabModel
    {
        public string KeyResultAreaName { get; set; }
        public string weightage { get; set; }
        public string competencyName { get; set; }
        public string competenciesWeightage { get; set; }
        public string skillSetName { get; set; }
        public string level { get; set; }
        public string skillSetWeightage { get; set; }
        public string goalName { get; set; }
        public string startDate { get; set; }
        public string dueDate { get; set; }
        public string priority { get; set; }
        public string goalsWeightage { get; set; }
    }


}
