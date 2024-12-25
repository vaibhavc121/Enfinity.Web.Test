using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Enfinity.Hrms.Test.UI.TestCases.HrCore
{
    [TestFixture]
    public class DepartmentTest:BaseTest
    {
        [Test]
        public void VerifyDepartmentCreation()
        {
            try
            {
                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDepartment();
                Thread.Sleep(2000);

                //dept pg
                DepartmentPage dp = new DepartmentPage(_driver);
                dp.ClickNew();
                dp.ProvideDepartmentName();
                dp.SelfServiceDD();
                dp.ClickDeptMgrDD();
                dp.SelectDeptMgrName();
                //dp.SelectDeptMgr();               
                dp.ClickSave();

                ClassicAssert.IsTrue(CommonActions.IsTxnCreated());


            }
            catch (Exception e) 
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
