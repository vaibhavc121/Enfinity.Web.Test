using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Legacy;
using Enfinity.Common.Test;
using System.Drawing;
using System.Xml.Linq;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class SupplierTest: BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public SupplierTest()
        { }
        #endregion

        #region Create new customer
        [Test, Category("Purchase"), Order(1)]
        public async Task CreateNewSupplier()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "new");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();
                
                sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the customer created name
                IWebElement customerName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string actualName = customerName.GetDomProperty("value");
                ClassicAssert.AreEqual(supplier.Name, actualName);
                #endregion

                sp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion
    }
}
