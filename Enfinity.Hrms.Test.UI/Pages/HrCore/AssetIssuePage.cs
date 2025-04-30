using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class AssetIssuePage : BasePage
    {
        public AssetIssuePage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Page Objects/Locators
        private By contextMenu = By.XPath("//img[@id='MainMenu_DXI19_PImg']");
        private By returnBtn = By.XPath("//span[normalize-space()='Return']");
        private By actualReturnDate = By.XPath("//input[@id='HrAssetIssue.ActualReturnDate_I']");
        private By iframe = By.XPath("//iframe[contains(@id,'PopupWindow')]");
        private By actualReturnDt = By.XPath("//input[@id='HrAssetIssue.ActualReturnDate_I']");
        private By cancelReturn = By.XPath("//span[normalize-space()='Cancel Return']");
        #endregion

        #region Action Methods
        public void FilterAndOpenTxn(string value)
        {
            FilterAndOpenTransaction(9,9,value,"view");
        }
        public void ClickContextMenu()
        {
            Find(contextMenu).Click();
        }
        public void ClickReturn()
        {
            Find(returnBtn).Click();
            WaitTS(2);
        }
        public void ProvideReturnDate(string value)
        {
            SwitchToFrameByElement(iframe);
            Find(actualReturnDt).SendKeys(value);
            ClickOnSave();
            SwitchToDefaultContent();
        }        
        public bool ReturnDate()
        {
            Find(contextMenu).Click();
            IWebElement element = Find(cancelReturn);
            return element.Displayed;
        }
       
        #endregion
    }
}
