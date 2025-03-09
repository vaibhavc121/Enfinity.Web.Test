using Enfinity.Erp.Test.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test
{
    public class CustomerListingPage
    {
        private readonly IWebDriver _driver;
        public CustomerListingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Customer Listing Top Menu Button Locators
        private By newCustomer = By.Id("MainMenu_DXI0_T");
        private By view = By.Id("MainMenu_DXI1_T");
        private By edit = By.Id("MainMenu_DXI2_T");
        private By reports = By.Id("MainMenu_DXI4_T");
        private By transactions = By.Id("MainMenu_DXI6_T");
        private By related = By.Id("MainMenu_DXI7_T");
        private By refresh = By.Id("MainMenu_DXI14_T");
        #endregion

        #region Customer Filter Locators
        private By customerName = By.XPath("//input[@aria-describedby='dx-col-3']");
        //private By itemSelect = By.XPath("//tr//td[@aria-describedby='dx-col-3']");
        //private By itemSelect = By.ClassName("list-hyperlink");
        //private By itemSelect = By.XPath("//td[@aria-describedby='dx-col-2' and @role='gridcell' and @aria-colindex='1' and text()='T00729']");
        private By customerSelect = By.XPath("(//td[@aria-describedby='dx-col-3' and @role='gridcell' and @aria-colindex='2'])[2]");
        #endregion

        #region Customer Context Menu Locators 
        private By contextmenuItem = By.Id("MainMenu_DXI19_P");
        private By contextmenuDelete = By.Id("MainMenu_DXI3_T");
        private By confirmOk = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Ok']");
        private By confirmCancel = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Cancel']");
        #endregion

        #region Customer Listing Top Menu Action Methods 
        public void ClickOnNewCustomer()
        {
            _driver.FindElement(newCustomer).Click();
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
        public void ProvideCustomerName(string name)
        {
            _driver.FindElement(customerName).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickOnSelectedCustomerName()
        {
            //_driver.FindElement(itemSelect).Click();
            IWebElement element = _driver.FindElement(customerSelect);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
        #endregion

        #region Customer Contextmenu Action Methods
        public void clickOnContextMenuItem()
        {
            _driver.FindElement(contextmenuItem).Click();
        }
        public void clickOnContextMenuDelete()
        {
            _driver.FindElement(contextmenuDelete).Click();
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
    }
}
