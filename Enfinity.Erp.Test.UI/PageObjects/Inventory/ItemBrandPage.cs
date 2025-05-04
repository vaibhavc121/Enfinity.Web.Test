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
    public class ItemBrandPage
    {
        private readonly IWebDriver _driver;
        public ItemBrandPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Item Brand Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI13_P");
        #endregion

        #endregion

        #region Action Methods        

        #region Item Brand Context Menu Action Methods
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #endregion
    }
}
