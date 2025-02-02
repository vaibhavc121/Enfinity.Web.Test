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
        private By remindLater = By.Id("remindButton");
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
        public void clickOnInventoryModule()
        {
            _driver.FindElement(moduleName).Click();
        }
        public void clickOnRemindLater()
        {
            _driver.FindElement(remindLater).Click();
        }
        public void clickOnHome()
        {
            _driver.FindElement(home).Click();
        }
        public void clickOnItem()
        {
            _driver.FindElement(item).Click();
        }
        public void clickOnStoreTransfer()
        {
            _driver.FindElement(storeTransfer).Click();
        }
        public void clickOnStockAdjustment()
        {
            _driver.FindElement(stockAdjustment).Click();
        }
        public void clickOnReports()
        {
            _driver.FindElement(reports).Click();
        }
        public void clickOnAnalytics()
        {
            _driver.FindElement(analytics).Click();
        }
        public void clickOnPeriodicProcess()
        {
            _driver.FindElement(periodicProcess).Click();
        }
        public void clickOnSetups()
        {
            _driver.FindElement(setups).Click();
        }
        #endregion
    }
}
