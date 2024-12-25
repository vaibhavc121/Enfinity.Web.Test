using Enfinity.Hrms.Test.UI.PageObjects.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class SetupPage: BasePage
    {
        public SetupPage(IWebDriver driver) : base(driver)
        {
        }

        // Locators
        private readonly By Employee = By.XPath("//a[@class='dxnb-link']//span[@class='dx-vam'][normalize-space()='Employee']");
        By department = By.XPath("//span[text()='Department']");

        

        public void ClickEmployee()
        {
            _driver.FindElement(Employee).Click();
        }

        public void ClickDepartment()
        {
            Find(department).Click();
        }
    }
}
