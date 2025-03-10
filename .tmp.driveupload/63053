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
        #region Constructor
        public PaymentTermTest()
        { }
        #endregion

        #region Create new payment term
        [Test, Category("Purchase"), Order(1)]
        public async Task CreatePaymentTerm()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var paymentTermFile = FileHelper.GetDataFile("Erp", "Purchase", "PaymentTerm", "PaymentTermData");
            var paymentTerm = JsonHelper.ConvertJsonListDataModel<PaymentTermModel>(paymentTermFile, "new");

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
                ptp.ProvideDueDays(paymentterm.DueDays);
                ptp.ClickOnAutoInsertCustomer();
                ptp.ClickOnAutoInsertSupplier();
                CommonPageActions.ProvideDescription(paymentterm.Description);
                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the payment term created message
                CommonPageActions.ValidateMessage("Payment Term (Payable) created successfully!");
                #endregion

                ptp.ClickOnPaymentTerm();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Delete payment term
        [Test, Category("Purchase"), Order(2)]
        public async Task DeletePaymentTerm()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var paymentTermFile = FileHelper.GetDataFile("Erp", "Purchase", "PaymentTerm", "PaymentTermData");
            var paymentTerm = JsonHelper.ConvertJsonListDataModel<PaymentTermModel>(paymentTermFile, "delete");

            var psp = new PurchaseSetupPage(_driver);
            var ptp = new PaymentTermPage(_driver);

            foreach (var paymentterm in paymentTerm)
            {
                CommonPageActions.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnPaymentTerm();

                CommonPageActions.ProvideNameOnListing(paymentterm.Name);
                CommonPageActions.ClickOnSelectedName();
                ptp.clickOnContextMenu();
                CommonPageActions.ClickOnDelete();
                CommonPageActions.ClickOnOk();

                #region Validate payment term deleted message
                CommonPageActions.ValidateMessage("Record deleted successfully!");
                #endregion                 
            }
        }
        #endregion

    }
}
