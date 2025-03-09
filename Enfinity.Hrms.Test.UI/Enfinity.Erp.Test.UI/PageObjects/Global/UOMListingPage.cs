using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class UOMListingPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public UOMListingPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Unit of measure Listing Top Menu Button Locators
        private By newUOM = By.Id("MainMenu_DXI0_T");
        private By view = By.Id("MainMenu_DXI1_T");
        private By edit = By.Id("MainMenu_DXI2_T");
        private By related = By.Id("MainMenu_DXI6_T");
        #endregion

        #region UOM Filter Locators
        private By uomName = By.XPath("//input[@aria-describedby='dx-col-3']");
        private By uomSelect = By.XPath("(//td[@aria-describedby='dx-col-3' and @role='gridcell' and @aria-colindex='2'])[2]");
        #endregion

        #region UOM Context Menu Locators 
        private By contextmenuItem = By.Id("MainMenu_DXI13_P");
        private By contextmenuDelete = By.Id("MainMenu_DXI3_T");
        private By confirmOk = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Ok']");
        private By confirmCancel = By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Cancel']");
        #endregion

        #endregion

        #region Action Methods

        #region UOM Listing Top Menu Action Methods 
        public void ClickOnNewUOM()
        {
            _driver.FindElement(newUOM).Click();
        }
        public void ClickOnView()
        {
            _driver.FindElement(view).Click();
        }
        public void ClickOnEdit()
        {
            _driver.FindElement(edit).Click();
        }
        public void ClickOnRelated()
        {
            _driver.FindElement(related).Click();
        }
        #endregion

        #region UOM Filter Action Methods
        public void ProvideUOMName(string name)
        {
            _driver.FindElement(uomName).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickOnSelectedUOM()
        {
            //_driver.FindElement(itemSelect).Click();
            IWebElement element = _driver.FindElement(uomSelect);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(1000);
        }
        #endregion

        #region UOM Contextmenu Action Methods
        public void ClickOnContextMenuItem()
        {
            _driver.FindElement(contextmenuItem).Click();
            Thread.Sleep(500);
        }
        public void ClickOnContextMenuDelete()
        {
            _driver.FindElement(contextmenuDelete).Click();
            Thread.Sleep(1000);
        }
        public void ClickOnConfirmOk()
        {
            _driver.FindElement(confirmOk).Click();
            Thread.Sleep(1000);
        }
        public void ClickOnConfirmCancel()
        {
            _driver.FindElement(confirmCancel).Click();
        }
        #endregion

        #endregion
    }
}
