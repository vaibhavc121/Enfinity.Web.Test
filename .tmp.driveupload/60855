using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class PurchasePage
    {
        private readonly IWebDriver _driver;
        public PurchasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Sales Module Page Objects
        private By moduleName = By.XPath("//span[normalize-space()='Purchase']");
        #endregion

        #region Action Methods        
        public void ClickOnPurchaseModule()
        {
            _driver.FindElement(moduleName).Click();
        }        
        #endregion
    }
}
