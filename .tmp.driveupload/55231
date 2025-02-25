using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SalesSetupPage
    {
        private readonly IWebDriver _driver;
        public SalesSetupPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Setups - Common Page Objects
        private By customer = By.Id("NavViewCommon_I0i0_T");
        private By paymentTerm = By.Id("NavViewCommon_I0i1_T");
        private By salesman = By.Id("NavViewCommon_I0i2_T");
        private By priceList = By.Id("NavViewCommon_I0i3_T");
        private By paymentMethod = By.Id("NavViewCommon_I0i4_T");
        #endregion

        #region Setups - Settings Page Objects
        private By item = By.XPath("//*[contains(@id, 'NavViewSettings_I0i0_') and contains(., 'Item')]");
        private By invoice = By.XPath("//*[contains(@id, 'NavViewSettings_I0i1_') and contains(., 'Invoice')]");
        private By recurringInvoice = By.XPath("//*[contains(@id, 'NavViewSettings_I0i2_') and contains(., 'Recurring Invoice')]");
        private By salesReturn = By.XPath("//*[contains(@id, 'NavViewSettings_I0i2_') and contains(., 'Sales Return')]");
        #endregion

        #region Setups - Commom Action Methods
        public void ClickOnCustomer()
        {
            _driver.FindElement(customer).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(paymentTerm).Click();
        }
        public void ClickOnSalesman()
        {
            _driver.FindElement(salesman).Click();
        }
        public void ClickOnPriceList()
        {
            _driver.FindElement(priceList).Click();
        }
        public void ClickOnPaymentMethod()
        {
            _driver.FindElement(paymentMethod).Click();
        }
        #endregion

        #region Setups - Settings Action Methods
        public void ClickOnItem()
        {
            _driver.FindElement(item).Click();
        }
        public void ClickOnInvoice()
        {
            _driver.FindElement(invoice).Click();
        }
        public void ClickOnRecurringInvoice()
        {
            _driver.FindElement(recurringInvoice).Click();
        }
        public void ClickOnSalesReturn()
        {
            _driver.FindElement(salesReturn).Click();
        }
        #endregion
    }
}
