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
    public class DD_PayrollEmployeeTest : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.PayrollEmployee))]
        public void VerifyPayrollEmployeeCreation(string email, string name, string mbl, string doj, string dept, string desg, string payrollset, string calendar,string indemnity, string grade, string gender, string religion, string martitalStatus)
        {
            try
            {
                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                DD_PayrollEmployeePage pe = new DD_PayrollEmployeePage(_driver);
                pe.ClickNewBtn();
                pe.SetWorkEmail(email);
                pe.SetName(name);
                pe.ClickMgrDropdown();
                pe.SelectMgr();
                pe.SetMobileNumber(mbl);
                pe.SetDOJ(doj);
                pe.ClickDept();
                pe.SelectDept(dept);
                pe.ClickDesig();
                pe.SelectDesig(desg);
                //pe.ClearPayrollSet();
                pe.ClickPayrollSet();
                pe.SelectPayrollSet(payrollset);
                pe.ClickCalendar();
                pe.SelectCalendar(calendar);
                pe.ClickIndemnity();
                pe.SelectIndemnity(indemnity);
                pe.ClickGrade();
                pe.SetGrade(grade);
                pe.ClickGender();
                pe.SetGender(gender);
                pe.ClickReligion();
                pe.SetReligion(religion);
                pe.ClickMaritalStatus();
                pe.SetMaritalStatus(martitalStatus);                
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
