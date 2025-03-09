using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SupplierListingPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public SupplierListingPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Supplier Listing Top Menu Button Locators
        private By newSupplier = By.Id("MainMenu_DXI0_T");
        private By view = By.Id("MainMenu_DXI2_T");
        private By edit = By.Id("MainMenu_DXI3_T");
        private By reports = By.Id("MainMenu_DXI7_T");
        private By transactions = By.Id("MainMenu_DXI9_T");
        private By related = By.Id("MainMenu_DXI10_T");
        private By refresh = By.Id("MainMenu_DXI13_T");
        #endregion

        #region Customer Filter Locators
        private By supplierName = By.XPath("//input[@aria-describedby='dx-col-3']");
        //private By itemSelect = By.XPath("//tr//td[@aria-describedby='dx-col-3']");
        //private By itemSelect = By.ClassName("list-hyperlink");
        //private By itemSelect = By.XPath("//td[@aria-describedby='dx-col-2' and @role='gridcell' and @aria-colindex='1' and text()='T00729']");
        private By supplierSelect = By.XPath("(//td[@aria-describedby='dx-col-3' and @role='gridcell' and @aria-colindex='2'])[2]");
        #endregion

        #region Customer Context Menu Locators 
        private By contextmenuItem = By.Id("MainMenu_DXI18_P");
        private By contextmenuDelete = By.Id("MainMenu_DXI4_T");
        private By confirmOk = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Ok']");
        private By confirmCancel = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Cancel']");
        #endregion

        #endregion

        #region Action Methods

        #region Customer Listing Top Menu Action Methods 
        public void ClickOnNewSupplier()
        {
            _driver.FindElement(newSupplier).Click();
        }
        public void ClickOnView()
        {
            _driver.FindElement(view).Click();
        }
        public void ClickOnEdit()
        {
            _driver.FindElement(edit).Click();
        }
        public void ClickOnReports()
        {
            _driver.FindElement(reports).Click();
        }
        public void ClickOnTransactions()
        {
            _driver.FindElement(transactions).Click();
        }
        public void ClickOnRelated()
        {
            _driver.FindElement(related).Click();
        }
        public void ClickOnRefresh()
        {
            _driver.FindElement(refresh).Click();
        }
        #endregion

        #region Customer Filter Action Methods
        public void ProvideSupplierName(string name)
        {
            _driver.FindElement(supplierName).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickOnSelectedSupplierName()
        {
            //_driver.FindElement(itemSelect).Click();
            IWebElement element = _driver.FindElement(supplierSelect);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(1000);
        }
        #endregion

        #region Customer Contextmenu Action Methods
        public void clickOnContextMenuItem()
        {
            _driver.FindElement(contextmenuItem).Click();
            Thread.Sleep(500);
        }
        public void clickOnContextMenuDelete()
        {
            _driver.FindElement(contextmenuDelete).Click();
            Thread.Sleep(1000);
        }
        public void clickOnConfirmOk()
        {
            _driver.FindElement(confirmOk).Click();
            Thread.Sleep(1000);
        }
        public void clickOnConfirmCancel()
        {
            _driver.FindElement(confirmCancel).Click();
        }
        #endregion

        #endregion
    }
}
