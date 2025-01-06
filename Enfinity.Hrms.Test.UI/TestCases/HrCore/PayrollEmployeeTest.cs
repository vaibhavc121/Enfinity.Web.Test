using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class PayrollEmployeeTest : BaseTest
    {
        public string Product = "Hrms";
        [Test]
        [Ignore("")]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.PayrollEmployee))]
        public void VerifyPayrollEmployeeCreation(string email, string name, string mbl, string doj, string dept, string desg, string payrollset, string calendar,string indemnity, string grade, string gender, string religion, string martitalStatus)
        {
            try
            {
                Login(Product);

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage pe = new EmployeePage(_driver);
                pe.ClickNewBtn();
                pe.ProvideWorkEmail(email);
                pe.ProvideName();
                pe.ClickMgrDropdown();
                pe.SelectMgr();
                pe.ProvideMobileNumber(mbl);
                pe.ProvideDOJ(doj);
                pe.ClickDepartment();
                pe.SelectDepartment(dept);
                pe.ClickDesignation();
                pe.SelectDesignation(desg);
                //pe.ClearPayrollSet();
                pe.ClickPayrollSet();
                pe.SelectPayrollSet(payrollset);
                pe.ClickCalendar();
                pe.SelectCalendar(calendar);
                pe.ClickIndemnity();
                pe.SelectIndemnity(indemnity);
                pe.ClickGrade();
                pe.SelectGrade(grade);
                pe.ClickGender();
                pe.SelectGender(gender);
                pe.ClickReligion();
                pe.SelectReligion(religion);
                pe.ClickMaritalStatus();
                pe.SelectMaritalStatus(martitalStatus);                
                pe.ClickSave();

                ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
    }
}
