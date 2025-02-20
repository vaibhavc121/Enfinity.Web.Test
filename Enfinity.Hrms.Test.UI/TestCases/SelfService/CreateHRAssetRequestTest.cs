using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.TestCases.SelfService
{
    [TestFixture]
    public class CreateHRAssetRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyHRAssetRequestCreation()
        {
            try
            {
                Login(Product);

                var HRAssetRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
                var HRAssetRequestData = JsonHelper.ConvertJsonListDataModel<HRAssetRequestModel>(HRAssetRequestFile, "createHRAssetRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                ExpenseClaimPage ec = new ExpenseClaimPage(_driver);
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
