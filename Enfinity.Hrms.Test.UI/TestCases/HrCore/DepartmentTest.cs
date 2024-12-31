using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class DepartmentTest : BaseTest
    {
        public string Product = "Hrms";
        [Test]
        [Ignore("")]
        public void VerifyDepartmentCreation()
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

                ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
