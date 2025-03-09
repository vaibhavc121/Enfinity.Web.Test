using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class HRCorePage
    {
        private readonly IWebDriver _driver;

        public HRCorePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private readonly By HRCore = By.XPath("//span[normalize-space()='HR Core']");
        private readonly By Setups = By.XPath("//span[normalize-space()='Setups']");

        

        // Methods for actions
        public void ClickHRCore()
        {
            _driver.FindElement(HRCore).Click();
        }

        public void ClickSetupForm()
        {
            _driver.FindElement(Setups).Click();
        }
    }
}
