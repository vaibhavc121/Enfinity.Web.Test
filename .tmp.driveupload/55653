using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class HRCoreDataProvider
    {
        public static IEnumerable<TestCaseData> PayrollEmployee()
        {
            yield return new TestCaseData("abc121@gmail.com", "Mohan", "7769765434", "01-Jan-2024", "prod", "Systems Analyst", "Test", "for flipkart", "Indemnity2", "Contributor", "Male", "Muslim", "Married");
            //yield return new TestCaseData("abc121@gmail.com", "Manoj", "7769765434", "01-Jan-2024", "prod", "Systems Analyst", "for flipkart", "Contributor", "Male", "Hindu", "Married");
        }

        public static IEnumerable<TestCaseData> NonPayrollEmployee()
        {
            yield return new TestCaseData("abc121@gmail.com", "Mohan", "7769765434", "01-Jan-2024", "Contributor", "Male", "Hindu", "Married");
            
        }

        public static IEnumerable<TestCaseData> EmployeeWithSystemAccess()
        {
            yield return new TestCaseData("abc121@gmail.com", "Mohan", "7769765434", "01-Jan-2024", "Finance", "SR Accountant", "PS0- Calendar days", "Default Calendar", "Indemnity", "Contributor", "Male", "Hindu", "Married", "mohan@test.com", "VRC");
            //yield return new TestCaseData("abc121@gmail.com", "Manoj", "7769765434", "01-Jan-2024", "prod", "Systems Analyst", "for flipkart", "Contributor", "Male", "Hindu", "Married");
        }
    }
}
