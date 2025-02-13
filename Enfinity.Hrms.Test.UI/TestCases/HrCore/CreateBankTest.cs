using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore;
using Enfinity.Hrms.Test.UI.Models.HRCore.Bank;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
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
    public class CreateBankTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyBankCreation()
        {
            try
            {
                Login(Product);

                var bankFile = FileHelper.GetDataFile("Hrms", "HRCore", "Bank", "BankData");
                var bankData = JsonHelper.ConvertJsonListDataModel<BankModel>(bankFile, "createBank");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickBank();
                Thread.Sleep(2000);

                //bank page                
                BankPage bp = new BankPage(_driver);

                foreach(var bank in bankData)
                {
                    bp.ClickNew();
                    //bp.provideBankName(bank.bankName);
                    bp.provideBankName();
                    bp.clickSave();                      
                }
                ClassicAssert.IsTrue(bp.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
