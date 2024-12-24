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
    public class HardCodedPayrollEmployeeTest:BaseTest
    {

        [Test]
        [Ignore("Ignored due to hard coded data")]
        public void VerifyPayrollEmployeeCreation()
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
                HardCodedPayrollEmployeePage pe=new HardCodedPayrollEmployeePage(_driver);
                pe.ClickNewBtn();
                pe.ProvideWorkEmail();
                pe.SetName();
                pe.ClickMgrDropdown();
                pe.SelectMgr();
                pe.SetMobileNumber();
                pe.SetDOJ();
                pe.ClickDept();
                pe.SelectDept();
                pe.ClickDesig();
                pe.SelectDesig();
                pe.ClickCalendar();
                pe.SelectCalendar();
                pe.ClickGrade();
                pe.SetGrade();
                pe.ClickGender();
                pe.SetGender();
                pe.ClickReligion();
                pe.SetReligion();
                pe.ClickMaritalStatus();
                pe.SetMaritalStatus();
                pe.ClickSave();
                
                ClassicAssert.IsTrue(pe.IsEmployeeCreated());

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
    }
}
