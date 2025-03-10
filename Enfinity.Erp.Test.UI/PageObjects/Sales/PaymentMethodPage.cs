using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class PaymentMethodPage
    {
        private readonly IWebDriver _driver;
        public PaymentMethodPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Payment Method Page
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Payment Method']");
        private By type = By.XPath("//input[contains(@id, '.Type_I')]");
        private By bankAccount = By.XPath("//td[contains(@id, '.BankAccountIdLookup_B-1')]");
        #endregion

        #region Payment Method Context Menu
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        #endregion

        #endregion

        #region Action Methods

        #region Payment Method Page
        public void ClickOnPaymentMethod()
        {
            _driver.FindElement(link).Click();
        }
        public void ClickOnType()
        {
            _driver.FindElement(type).Click();
        }
        public void ClickOnBankAccount()
        {
            _driver.FindElement(bankAccount).Click();
        }
        #endregion

        #region Payment Method Context Menu
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #endregion
    }
}
