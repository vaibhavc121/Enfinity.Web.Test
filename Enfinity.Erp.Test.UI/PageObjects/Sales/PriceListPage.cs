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
    public class PriceListPage
    {
        private readonly IWebDriver _driver;
        public PriceListPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Price List Page
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Price List']");
        private By percentageType = By.XPath("//input[contains(@id, 'PercentageType')]");
        private By percentage = By.XPath("(//input[contains(@id, 'Percentage')])[2]");
        #endregion

        #region Price List Context Menu
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        #endregion

        #endregion

        #region Action Methods

        #region Price List Page
        public void ClickOnPriceList()
        {
            _driver.FindElement(link).Click();
        }
        public void ClickOnPercentageType()
        {
            _driver.FindElement(percentageType).Click();
        }
        public void ProvidePercentage(string data)
        {
            //_driver.FindElement(percentage).SendKeys(data);
            CommonPageActions.ClearAndProvideValue(percentage, data);
        }
        #endregion

        #region Price List Context Menu
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #endregion
    }
}
