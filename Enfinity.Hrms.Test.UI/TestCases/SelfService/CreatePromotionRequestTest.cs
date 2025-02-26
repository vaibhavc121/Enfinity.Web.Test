using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class CreatePromotionRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyPromotionRequestCreation()
        {
            try
            {
                Login(Product);

                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var promotionRequestData = JsonHelper.ConvertJsonListDataModel<PromotionRequestModel>(selfServiceFile, "createPromotionRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Promotion Request page                
                PromotionRequestPage pr = new PromotionRequestPage(_driver);
                pr.ScrollDownWebpage();
                pr.ClickPromotionRequest();
                pr.ClickNew();

                foreach (var promotionRequest in promotionRequestData)
                {
                    
                    pr.ProvideTxnDate(promotionRequest.txnDate);
                    pr.ProvideEffectiveDate(promotionRequest.effectiveDate);
                    pr.ProvideType(promotionRequest.type);
                    pr.ProvideNewDepartment(promotionRequest.newDepartment);
                    pr.ProvideNewDesignation(promotionRequest.newDesignation);
                    pr.ProvideNewWorkLocation(promotionRequest.newWorkLocation);
                    pr.ProvideNewProject(promotionRequest.newProject);
                    pr.ProvideDescription(promotionRequest.description);

                    pr.ClickSave();
                    #region salaries section
                    //pr.ClickSalariesSection();
                    //pr.ClickPlusBtn();
                    //pr.ProvideSalaryComponent(promotionRequest.salaryComponent);
                    //pr.ProvideIncrementAmount(promotionRequest.incrementAmount);
                    //pr.ProvideEffectiveFromDate(promotionRequest.effectiveFromDate);
                    //pr.ProvideEffectiveToDate(promotionRequest.effectiveToDate);
                    #endregion



                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
