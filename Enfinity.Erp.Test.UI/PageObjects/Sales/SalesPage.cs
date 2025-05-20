using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SalesPage
    {
        private readonly IWebDriver _driver;
        public SalesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Sales Module Locators
        private By moduleName = By.XPath("//span[normalize-space()='Sales']");
        private By priceList = By.CssSelector("li[title='Price List']");
        #endregion

        #region Transactions Locators
        private By quotation = By.XPath("//span[normalize-space()='Quotation']");
        private By order = By.XPath("//span[normalize-space()='Order']");
        private By deliveryNote = By.XPath("//span[normalize-space()='Delivery Note']");
        private By invoice = By.XPath("//span[normalize-space()='Invoice']");
        private By salesReturn = By.XPath("//span[normalize-space()='Return']");
        #endregion

        #endregion

        #region Action Methods

        #region Sales Module Action Methods        
        public void ClickOnSalesModule()
        {
            _driver.FindElement(moduleName).Click();
        }
        public void ClickOnPriceList()
        {
            _driver.FindElement(priceList).Click();
        }
        #endregion

        #region Transactions Action Methods
        public void ClickOnQuotation()
        {
            _driver.FindElement(quotation).Click();
        }
        public void ClickOnOrder()
        {
            _driver.FindElement(order).Click();
        }
        public void ClickOnDeliveryNote()
        {
            _driver.FindElement(deliveryNote).Click();
        }
        public void ClickOnInvoice()
        {
            _driver.FindElement(invoice).Click();
        }
        public void ClickOnReturn()
        {
            _driver.FindElement(salesReturn).Click();
        }
        #endregion

        #endregion
    }
}
