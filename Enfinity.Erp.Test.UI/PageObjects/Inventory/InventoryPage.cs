using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class InventoryPage
    {
        private readonly IWebDriver _driver;
        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Inventory Module Page Objects
        private By moduleName = By.XPath("//span[normalize-space()='Inventory']");
        private By home = By.CssSelector("li[title='Home']");
        private By item = By.CssSelector("li[title='Item']");
        private By storeTransfer = By.CssSelector("li[title='Store Transfer']");
        private By stockAdjustment = By.CssSelector("li[title='Stock Adjustment']");
        private By reports = By.CssSelector("li[title='Reports']");
        private By analytics = By.CssSelector("li[title='Analytics']");
        private By periodicProcess = By.CssSelector("li[title='Periodic Process']");
        private By setups = By.CssSelector("li[title='Setups']");
        #endregion

        #region Action Methods
        public void ClickOnInventoryModule()
        {
            _driver.FindElement(moduleName).Click();
        }
        public void ClickOnHome()
        {
            _driver.FindElement(home).Click();
        }
        public void ClickOnItem()
        {
            _driver.FindElement(item).Click();
        }
        public void ClickOnStoreTransfer()
        {
            _driver.FindElement(storeTransfer).Click();
        }
        public void ClickOnStockAdjustment()
        {
            _driver.FindElement(stockAdjustment).Click();
        }
        public void ClickOnReports()
        {
            _driver.FindElement(reports).Click();
        }
        public void ClickOnAnalytics()
        {
            _driver.FindElement(analytics).Click();
        }
        public void ClickOnPeriodicProcess()
        {
            _driver.FindElement(periodicProcess).Click();
        }
        public void ClickOnSetups()
        {
            _driver.FindElement(setups).Click();
        }
        #endregion
    }
}
