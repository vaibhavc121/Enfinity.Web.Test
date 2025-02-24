using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService.AdminSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.ITSupport;
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
    public class CreateAdminSupportTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyAdminSupportCreation()
        {
            try
            {
                Login(Product);

                var adminSupportFile = FileHelper.GetDataFile("Hrms", "SelfService", "AdminSupport", "AdminSupportData");
                var adminSupportData = JsonHelper.ConvertJsonListDataModel<AdminSupportModel>(adminSupportFile, "createAdminSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Admin Support page                
                AdminSupportPage ap = new AdminSupportPage(_driver);

                foreach(var adminSupport in adminSupportData)
                {
                    ap.ClickAdminSupport();
                    ap.ClickNew();
                    ap.ClickSupportRequestCategory();
                    ap.ProvideSupportRequestCat(adminSupport.supportRequestCategory);
                    ap.ClickPriorityDD();
                    ap.SelectPriority(adminSupport.priority);
                    ap.ProvideRemarks(adminSupport.remarks);
                    ap.ClickSave();
                    ClassicAssert.IsTrue(ap.IsTxnCreated(adminSupport.supportRequestCategory));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
