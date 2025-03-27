using Enfinity.Common.Test;
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
    public class HardCodedPayrollEmployeeTest : BaseTest
    {

        //[Test]
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
                HardCodedPayrollEmployeePage ep = new HardCodedPayrollEmployeePage(_driver);
                ep.ClickNewBtn();
                ep.ProvideWorkEmail();
                ep.SetName();
                ep.ClickMgrDropdown();
                ep.SelectMgr();
                ep.SetMobileNumber();
                ep.SetDOJ();
                ep.ClickDept();
                ep.SelectDept();
                ep.ClickDesig();
                ep.SelectDesig();
                ep.ClickCalendar();
                ep.SelectCalendar();
                ep.ClickGrade();
                ep.SetGrade();
                ep.ClickGender();
                ep.SetGender();
                ep.ClickReligion();
                ep.SetReligion();
                ep.ClickMaritalStatus();
                ep.SetMaritalStatus();
                ep.ClickSave();

                ClassicAssert.IsTrue(ep.IsEmployeeCreated());

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
    }
}
