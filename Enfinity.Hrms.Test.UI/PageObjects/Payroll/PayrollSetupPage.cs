using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Payroll
{
    public class PayrollSetupPage : BasePage
    {
        public PayrollSetupPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By salaryComponent = By.XPath("//span[normalize-space()='Salary Component']");
        #endregion

        #region action methods
        public void ClickSalaryComponent()
        {
            Find(salaryComponent).Click();
        }
        #endregion
    }
}
