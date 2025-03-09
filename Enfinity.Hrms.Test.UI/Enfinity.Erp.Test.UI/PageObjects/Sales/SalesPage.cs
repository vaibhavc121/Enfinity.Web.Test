using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SalesPage
    {
        private readonly IWebDriver _driver;
        public SalesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Sales Module Page Objects
        private By moduleName = By.XPath("//span[normalize-space()='Sales']");
        private By priceList = By.CssSelector("li[title='Price List']");
        #endregion

        #region Action Methods        
        public void ClickOnSalesModule()
        {
            _driver.FindElement(moduleName).Click();
        }
        public void ClickOnPriceList()
        {
            _driver.FindElement(priceList).Click();
        }
        #endregion

    }
}
