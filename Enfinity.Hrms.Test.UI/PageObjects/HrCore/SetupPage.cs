using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class SetupPage
    {
        private readonly IWebDriver _driver;

        public SetupPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private readonly By Employee = By.XPath("//a[@class='dxnb-link']//span[@class='dx-vam'][normalize-space()='Employee']");

        public void ClickEmployee()
        {
            _driver.FindElement(Employee).Click();
        }
    }
}
