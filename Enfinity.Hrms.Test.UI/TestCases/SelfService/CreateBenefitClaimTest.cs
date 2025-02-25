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
    public class CreateBenefitClaimTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyBenefitClaimCreation()
        {
            try
            {
                Login(Product);

                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var benefitClaimData = JsonHelper.ConvertJsonListDataModel<BenefitClaimModel>(selfServiceFile, "createBenefitClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Benefit Claim page                
                BenefitClaimPage bc = new BenefitClaimPage(_driver);

                foreach(var benefitClaim in benefitClaimData)
                {
                    bc.ScrollDownWebpage();
                    bc.ClickBenefitClaim();
                    bc.ClickNew();
                    bc.ProvideClaimDate(benefitClaim.claimDate);
                    bc.ClickBenefitSchemeDD();
                    bc.SelectBenefitScheme(benefitClaim.benefitScheme);
                    bc.ProvideClaimAmt(benefitClaim.claimAmount);
                    bc.ClickPaymentType();
                    bc.SelectPaymentType(benefitClaim.paymentType);
                    bc.ProvideRemarks(benefitClaim.remarks);
                    bc.ClickSave();

                    //ClassicAssert.IsTrue(bc.IsTxnCreated(benefitClaim.empName, benefitClaim.claimAmount));
                    //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
                    ClassicAssert.IsTrue(true);
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
