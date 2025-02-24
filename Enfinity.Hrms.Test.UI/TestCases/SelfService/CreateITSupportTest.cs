using Enfinity.Common.Test;
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
    public class CreateITSupportTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyITSupportCreation()
        {
            try
            {
                Login(Product);

                var ITSupportFile = FileHelper.GetDataFile("Hrms", "SelfService", "ITSupport", "ITSupportData");
                var ITSupportData = JsonHelper.ConvertJsonListDataModel<ITSupportModel>(ITSupportFile, "createITSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ITSupport page                
                ITSupportPage it = new ITSupportPage(_driver);

                foreach(var ITSupport in ITSupportData)
                {
                    it.ClickITSupport();
                    it.ClickNew();
                    it.ClickSupportRequestCategoryDD();
                    it.SelectSupportRequestCategory(ITSupport.supportRequestCategory);
                    it.ClickPriorityDD();
                    it.SelectPriority(ITSupport.priority);
                    it.ProvideRemarks(ITSupport.remarks);
                    it.ClickSave();
                    ClassicAssert.IsTrue(it.IsTxnCreated(ITSupport.supportRequestCategory));
                }
                
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
