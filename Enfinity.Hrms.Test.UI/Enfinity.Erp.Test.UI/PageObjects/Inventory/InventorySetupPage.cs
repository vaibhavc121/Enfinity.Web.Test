using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class InventorySetupPage
    {
        private readonly IWebDriver _driver;
        public InventorySetupPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Setups - Common
        private By itemOption = By.Id("NavViewCommon_I0i0_T");
        private By warehouseOption = By.Id("NavViewCommon_I0i1_T");
        private By stockcountbatchOption = By.Id("NavViewCommon_I0i2_T");
        private By stockadjustmentreasonOption = By.Id("NavViewCommon_I0i3_T");
        private By documenttypeOption = By.Id("NavViewCommon_I0i4_T");
        // Optional Locators
        //private By itemOption = By.XPath("//*[contains(@id, 'NavViewCommon_I0i0_T') and contains(., 'Item')]");
        //private By warehouseOption = By.XPath("//*[contains(@id, 'NavViewCommon_I0i1_T') and contains(., 'Warehouse')]");
        //private By stockcountbatchOption = By.XPath("//*[contains(@id, 'NavViewCommon_I0i2_T') and contains(., 'Stock Count Batch')]");
        //private By stockadjustmentreasonOption = By.XPath("//*[contains(@id, 'NavViewCommon_I0i3_T') and contains(., 'Stock Adjustment Reason')]");
        //private By documenttypeOption = By.XPath("//*[contains(@id, 'NavViewCommon_I0i4_T') and contains(., 'Document Type')]");
        #endregion

        #region Setups - Settings
        private By itemSetting = By.XPath("//*[contains(@id, 'NavViewSettings_I0i0_') and contains(., 'Item')]");
        private By storetransferSetting = By.XPath("//*[contains(@id, 'NavViewSettings_I0i1_') and contains(., 'Store Transfer')]");
        private By stockadjustment = By.XPath("//*[contains(@id, 'NavViewSettings_I0i2_') and contains(., 'Stock Adjustment')]");
        #endregion

        #region Setups - Commom Action Methods
        public void ClickOnItem()
        {
            _driver.FindElement(itemOption).Click();
        }
        public void ClickOnWarehouse()
        {
            _driver.FindElement(warehouseOption).Click();
        }
        public void ClickOnStockCountBatch()
        {
            _driver.FindElement(stockcountbatchOption).Click();
        }
        public void ClickOnStockAdjustmentReason()
        {
            _driver.FindElement(stockadjustmentreasonOption).Click();
        }
        public void ClickOnDocumentType()
        {
            _driver.FindElement(documenttypeOption).Click();
        }
        #endregion

        #region Setups - Settings Action Methods
        public void ClickOnItemSetting()
        {
            _driver.FindElement(itemSetting).Click();
        }
        public void ClickOnStoreTransferSetting()
        {
            _driver.FindElement(storetransferSetting).Click();
        }
        public void ClickOnStockAdjustment()
        {
            _driver.FindElement(stockadjustment).Click();
        }
        #endregion
    }
}
