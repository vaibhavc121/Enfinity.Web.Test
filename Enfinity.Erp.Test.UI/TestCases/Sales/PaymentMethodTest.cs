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
    public class PaymentMethodTest : BaseTest
    {
        #region Constructor
        public PaymentMethodTest()
        { }
        #endregion

        #region Create New Payment Method
        [Test, Category("Sales"), Order(1)]
        public async Task CreatePaymentMethod()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var paymentMethodFile = FileHelper.GetDataFile("Erp", "Sales", "PaymentMethod", "PaymentMethodData");
            var paymentMethod = JsonHelper.ConvertJsonListDataModel<PaymentMethodModel>(paymentMethodFile, "new");

            var ssp = new SalesSetupPage(_driver);
            var pmp = new PaymentMethodPage(_driver);

            foreach (var paymentmethod in paymentMethod)
            {
                CommonPageActions.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnPaymentMethod();
                CommonPageActions.ClickOnNew();
                await WaitHelper.WaitForSeconds(1);

                CommonPageActions.ProvideCode(paymentmethod.Code);
                CommonPageActions.ProvideName(paymentmethod.Name);
                CommonPageActions.ProvideArabicName(paymentmethod.ArabicName);
                CommonPageActions.ProvideDescription(paymentmethod.Description);

                pmp.ClickOnType();                 
                CommonPageActions.SelectDropDownValue(paymentmethod.Type);
                pmp.ClickOnBankAccount();
                CommonPageActions.SelectDropDownOptionValue(paymentmethod.BankAccount);
                await WaitHelper.WaitForSeconds(1);

                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the created message
                CommonPageActions.ValidateMessage("Payment Method created successfully!");
                #endregion

                pmp.ClickOnPaymentMethod();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion
    }
}
