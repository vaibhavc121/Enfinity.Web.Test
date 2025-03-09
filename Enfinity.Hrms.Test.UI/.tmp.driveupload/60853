using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class PurchaseSetupPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public PurchaseSetupPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Setups - Common Page Objects
        private By supplier = By.XPath("//*[contains(@id, 'NavViewCommon_I0i0_') and contains(., 'Supplier')]");
        private By paymentTerm = By.Id("NavViewCommon_I0i1_T");
        private By charge = By.Id("NavViewCommon_I0i2_T");
        #endregion

        #region Setups - Settings Page Objects
        private By item = By.XPath("//*[contains(@id, 'NavViewSettings_I0i0_') and contains(., 'Item')]");
        private By purchaseOrder = By.XPath("//*[contains(@id, 'NavViewSettings_I0i1_') and contains(., 'Purchase Order')]");
        private By goodsReceipt = By.XPath("//*[contains(@id, 'NavViewSettings_I0i2_') and contains(., 'Goods Receipt')]");
        private By supplierReturn = By.XPath("//*[contains(@id, 'NavViewSettings_I0i2_') and contains(., 'Supplier Return')]");
        #endregion

        #region Setups - Commom Action Methods
        public void ClickOnSupplier()
        {
            _driver.FindElement(supplier).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(paymentTerm).Click();
        }
        public void ClickOnCharge()
        {
            _driver.FindElement(charge).Click();
        }
        #endregion

        #region Setups - Settings Action Methods
        public void ClickOnItem()
        {
            _driver.FindElement(item).Click();
        }
        public void ClickOnPurchaseOrder()
        {
            _driver.FindElement(purchaseOrder).Click();
        }
        public void ClickOnGoodsReceipt()
        {
            _driver.FindElement(goodsReceipt).Click();
        }
        public void ClickOnSupplierReturn()
        {
            _driver.FindElement(supplierReturn).Click();
        }
        #endregion
    }
}
