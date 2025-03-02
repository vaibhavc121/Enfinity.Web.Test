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
    public class CreateOvertimeRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyOvertimeCreation()
        {
            try
            {
                Login(Product);

                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var overtimeRequestData = JsonHelper.ConvertJsonListDataModel<OvertimeRequestModel>(selfServiceFile, "createOvertimeRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Overtime Request page                
                OvertimeRequestPage or = new OvertimeRequestPage(_driver);

                foreach(var overtimeRequest in overtimeRequestData)
                {
                    or.ScrollDownWebpage();
                    or.ClickOvertimeRequest();
                    or.ClickNew();
                    or.ProvideOvertimeDate(overtimeRequest.overtimeDate);
                    or.ProvideOvertimeType(overtimeRequest.overtimeType);
                    or.ProvideHrs(overtimeRequest.hrs);
                    or.ProvideRemarks(overtimeRequest.remarks);
                    or.ClickSave();

                    #region additional code
                    CommonPageActions.ClickSave();
                    if (CommonPageActions.IsTxnCreated())
                    {
                        or.ClickSave();
                    }
                    else
                    {
                        ClassicAssert.Fail("Test case failed" + or.DisplayErrorMsg());
                    }
                    #endregion

                    ClassicAssert.IsTrue(or.IsTxnCreated(overtimeRequest.overtimeType, overtimeRequest.hrs));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
