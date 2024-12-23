using NUnit.Framework;
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
    public class NonPayrollEmployeeTest:BaseTest
    {
        [Test]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.NonPayrollEmployee))]
        public void VerifyNonPayrollEmployeeCreation(string email, string name, string mbl, string doj, string grade, string gender, string religion, string martitalStatus)
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
                pe.ClickNonPayrollBtn();    
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
