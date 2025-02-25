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

namespace Enfinity.Hrms.Test.UI
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

                //HR asset request page                
                HRAssetRequestPage ar = new HRAssetRequestPage(_driver);

                foreach(var HRAssetRequest in HRAssetRequestData)
                {
                    ar.ClickHRAssetRequest();
                    ar.ClickNew();
                    ar.ProvideTxnDate(HRAssetRequest.txnDate);
                    ar.ProvideEffectiveDate(HRAssetRequest.effectiveDate);
                    ar.ClickSave();
                    ar.ClickNewLine();
                    ar.ClickHRAssetDD();
                    ar.SelectHRAsset(HRAssetRequest.HRAsset);
                    //ar.ProvideExpReturnDate(HRAssetRequest.expReturnDate);
                    ar.ClickView();
                    ar.ClickApprove();

                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
