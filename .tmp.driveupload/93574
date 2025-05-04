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
    public class ItemCategoryPage
    {
        private readonly IWebDriver _driver;
        public ItemCategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Item Category Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI16_P");
        #endregion

        #endregion

        #region Action Methods

        #region Item Category Listing Page Action Methods
        public void ProvideNameOnListing(string name)
        {
            BaseTest._driver.FindElement(By.XPath("//input[@aria-describedby='dx-col-4']")).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickOnSelectedName()
        { 
            IWebElement linkElement = BaseTest._driver.FindElement(By.XPath("(//td[@aria-describedby='dx-col-4' and @role='gridcell' and @aria-colindex='2'])[2]"));
            linkElement.Click();
            Thread.Sleep(1000);
        }
        #endregion

        #region Item Category Contextmenu Action Methods
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #endregion
    }
}
