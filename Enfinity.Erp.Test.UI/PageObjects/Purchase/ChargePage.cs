using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class ChargePage
    {
        private readonly IWebDriver _driver;
        public ChargePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Charge Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI11_P");
        #endregion

        #region Charge Page Locators
        private By defaultValue = By.XPath("//input[contains(@id, 'DefaultValue_I')]");
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Charge']");
        #endregion

        #endregion

        #region Action Methods

        #region Charge Contextmenu Action Methods
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #region Charge Action Methods
        public void ProvideDefaultValue(string data)
        {
            _driver.FindElement(defaultValue).SendKeys(data);
        }
        public void ClickOnCharge()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #endregion
    }
}
