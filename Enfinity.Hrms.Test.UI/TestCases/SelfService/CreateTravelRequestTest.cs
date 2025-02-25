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
    public class CreateTravelRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyTravelRequestCreation()
        {
            try
            {
                Login(Product);

                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var travelRequestData = JsonHelper.ConvertJsonListDataModel<TravelRequestModel>(selfServiceFile, "createTravelRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //travel Request page                
                TravelRequestPage tr = new TravelRequestPage(_driver);

                foreach(var travelRequest in travelRequestData)
                {
                    tr.ScrollDownWebpage();
                    tr.ClickTravelRequest();
                    tr.ClickNew();
                    tr.ProvideFromDate(travelRequest.fromDate);
                    tr.ProvideUptoDate(travelRequest.uptoDate);
                    //tr.ClickCategoryDD();
                    //tr.SelectCategory(travelRequest.category);
                    tr.ProvideCategory(travelRequest.category);
                    tr.ProvideToCountry(travelRequest.country);
                    tr.ProvideCity(travelRequest.city);
                    tr.ClickHotelBookedByEmpBtn();
                    tr.ProvideTicketDestination(travelRequest.ticketDestination);
                    //tr.ProvideTicketAmt(travelRequest.ticketAmt);
                    tr.ProvidePurpose(travelRequest.purpose);
                    tr.ProvidePaymentType(travelRequest.paymentType);
                    tr.ProvideRemarks(travelRequest.remarks);
                    tr.ClickSave();

                    ClassicAssert.IsTrue(tr.IsTxnCreated(travelRequest.empName, travelRequest.country));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
