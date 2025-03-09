using Enfinity.Common.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class PaymentTermTest:BaseTest
    {
        //private string Product = "Erp";

        #region Constructor
        public PaymentTermTest()
        { }
        #endregion

        #region Create new payment term
        [Test, Category("Inventory"), Order(1)]
        public async Task CreatePaymentTerm()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var paymentTermFile = FileHelper.GetDataFile("Erp", "Purchase", "PaymentTerm", "PaymentTermData");
            var paymentTerm = JsonHelper.ConvertJsonListDataModel<WarehouseModel>(paymentTermFile, "new");

            var psp = new PurchaseSetupPage(_driver);
            var ptp = new PaymentTermPage(_driver);

            foreach (var paymentterm in paymentTerm)
            {
                CommonPageActions.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnPaymentTerm();
                CommonPageActions.ClickOnNew();
                await WaitHelper.WaitForSeconds(1);

                CommonPageActions.ProvideCode(paymentterm.Code);
                CommonPageActions.ProvideName(paymentterm.Name);
                CommonPageActions.ProvideArabicName(paymentterm.ArabicName);
                
                ptp.ProvideDescription(paymentterm.Description);
                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate
                CommonPageActions.ValidateMessage("");
                #endregion

                ptp.ClickOnPaymentTerm();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

    }
}
