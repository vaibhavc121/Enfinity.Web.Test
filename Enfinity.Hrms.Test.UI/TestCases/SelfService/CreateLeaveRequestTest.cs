using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest;
using Enfinity.Hrms.Test.UI;
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
    public class CreateLeaveRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        [Ignore("issue in create new btn")]
        public void VerifyLeaveRequestCreation()
        {
            try
            {
                Login(Product);

                var LeaveRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonHelper.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Leave Request page                
                LeaveRequestPage lr = new LeaveRequestPage(_driver);

                foreach (var leaveRequest in LeaveRequestData)
                {
                    lr.ClickLeaveRequest();
                    lr.ClickNew();
                    lr.HoverAndClick();
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    lr.ClickSaveSubmit();

                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
