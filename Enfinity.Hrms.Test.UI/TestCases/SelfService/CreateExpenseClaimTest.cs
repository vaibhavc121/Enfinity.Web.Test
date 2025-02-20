using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.TimeOff;
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
    public class CreateExpenseClaimTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        [Ignore("locator issue")]
        public void VerifyExpenseClaimCreation()
        {
            try
            {
                Login(Product);

                var ExpenseClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
                var ExpenseClaimData = JsonHelper.ConvertJsonListDataModel<ExpenseClaimModel>(ExpenseClaimFile, "createExpenseClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                ExpenseClaimPage ec = new ExpenseClaimPage(_driver);

                foreach(var ExpenseClaim in ExpenseClaimData)
                {
                    ec.ClickExpenseClaim();
                    ec.ClickNew();
                    ec.ClickSave();
                    ec.ScrollDownWebPage();
                    ec.ClickNewLine();
                    //ec.ProvideExpenseDate(ExpenseClaim.expenseDate);
                    ec.ProvideRemarks(ExpenseClaim.remarks);
                    ec.ClickExpenseClaimCategoryDD();
                    ec.SelectExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideCurrency(ExpenseClaim.currency);
                    ec.ProvideAmount(ExpenseClaim.amount);
                }

                ClassicAssert.IsTrue(ec.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
