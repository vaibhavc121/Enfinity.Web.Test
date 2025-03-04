using AventStack.ExtentReports.Model;
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
    public class WarehousePage
    {
        private readonly IWebDriver _driver;
        public WarehousePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Module name Locator
        private By moduleName = By.XPath("//span[normalize-space()='Inventory']");
        #endregion

        #region Warehouse Listing Top Menu Button Locators
        private By newOne = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='New']");
        private By view = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='View']");
        private By edit = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Edit']");
        #endregion

        #region Warehouse Sort/Filter Locators
        private By provideName = By.XPath("//input[@aria-describedby='dx-col-3']");
        private By selectName = By.XPath("(//td[@aria-describedby='dx-col-3' and @role='gridcell' and @aria-colindex='2'])[2]");
        #endregion

        #region Warehouse Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        private By contextMenuDelete = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Delete']");
        private By confirmOk = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Ok']");
        private By confirmCancel = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Cancel']");
        #endregion

        #region Warehouse Page Locators
        private By code = By.CssSelector("input[name='Warehouse.Code']");
        private By name = By.CssSelector("input[name='Warehouse.Name']");
        private By nameArabic = By.CssSelector("input[name='Warehouse.NameL2']");
        private By skip = By.Id("Warehouse.SkipNegativeStockCheck");
        private By description = By.CssSelector("textarea[name='Warehouse.Description']");
        private By save = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Save']");
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Warehouse']");
        #endregion

        #endregion

        #region  Action Methods

        #region Module name action methods
        public void ClickOnInventoryModule()
        {
            _driver.FindElement(moduleName).Click();
        }
        #endregion

        #region Warehouse Listing Top Menu Action Methods 
        public void ClickOnNew()
        {
            _driver.FindElement(newOne).Click();
        }
        public void ClickOnView()
        {
            _driver.FindElement(view).Click();
        }
        public void ClickOnEdit()
        {
            _driver.FindElement(edit).Click();
        }
        #endregion

        #region Warehouse Sort/Filter Action Methods
        public void ProvideNameOnListing(string name)
        {
            _driver.FindElement(provideName).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickOnSelectedName()
        {
            //_driver.FindElement(itemSelect).Click();
            IWebElement element = _driver.FindElement(selectName);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
        #endregion

        #region Warehouse Contextmenu Action Methods
        public void clickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        public void clickOnContextMenuItemDelete()
        {
            _driver.FindElement(contextMenuDelete).Click();
        }
        public void clickOnConfirmOk()
        {
            _driver.FindElement(confirmOk).Click();
        }
        public void clickOnConfirmCancel()
        {
            _driver.FindElement(confirmCancel).Click();
        }
        #endregion

        #region Warehouse Action Methods
        public void ProvideCode(string data)
        {               
            CommonPageActions.ClearAndProvideValue(code, data);
        }
        public void ProvideName(string data)
        {            
            CommonPageActions.ClearAndProvideValue(name, data);
        }
        public void ProvideArabicName(string data)
        {
            CommonPageActions.ClearAndProvideValue(nameArabic, data);
        }
        public void ClickOnSkipNegativeStockCheck()
        {
            _driver.FindElement(skip).Click();
        }
        public void ProvideDescription(string data)
        {
            _driver.FindElement(description).SendKeys(data);
        }
        public void ClickOnSave()
        {
            _driver.FindElement(save).Click();
        }
        public void ClickOnWarehouse()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #endregion
    }
}
