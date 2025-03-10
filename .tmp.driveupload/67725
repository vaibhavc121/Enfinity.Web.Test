using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SalesmanPage
    {
        private readonly IWebDriver _driver;
        public SalesmanPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Salesman Page
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Salesman']");
        #endregion

        #region Salesman Context Menu
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        #endregion

        #region Salesman Page Gird - Other
        private By otherGrid = By.Id("Other_CB");
        private By type = By.XPath("//input[contains(@id, '.Type_I')]");
        private By commission = By.XPath("//input[contains(@id, '.SalesCommissionInPercent_I')]");
        private By title = By.XPath("//input[contains(@id, '.Title_I')]");
        private By email = By.XPath("//input[contains(@id, '.Email_I')]");
        private By extension = By.XPath("//input[contains(@id, '.ExtensionNumber_I')]");
        private By mobile = By.XPath("//input[contains(@id, '.MobileNumber_I')]");
        #endregion

        #endregion

        #region Action Methods

        #region Salesman page
        public void ClickOnSalesman()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #region Salesman Context Menu
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #region Salesman Page Gird - Other
        public void ClickOnSalesmanType()
        {
            _driver.FindElement(type).Click();
        }
        public void ClickOnOtherGrid()
        {
            _driver.FindElement(otherGrid).Click();
        }
        public void ProvideCommission(string data)
        {
            CommonPageActions.ClearAndProvideValue(commission, data);
        }
        public void ProvideTitle(string data)
        {
            CommonPageActions.ClearAndProvideValue(title, data);
        }
        public void ProvideEmail(string data)
        {
            CommonPageActions.ClearAndProvideValue(email, data);
        }
        public void ProvideExtension(string data)
        {
            CommonPageActions.ClearAndProvideValue(extension, data);
        }
        public void ProvideMobile(string data)
        {
            CommonPageActions.ClearAndProvideValue(mobile, data);
        }
        #endregion

        #endregion
    }
}
