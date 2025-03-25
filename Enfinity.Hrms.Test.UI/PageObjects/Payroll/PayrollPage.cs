using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Payroll
{
    public class PayrollPage : BasePage
    {
        public PayrollPage(IWebDriver driver) : base(driver)
        {
        }


        #region page objects
        private By payroll = By.XPath("//span[normalize-space()='Payroll']");
        private By setups = By.XPath("//span[normalize-space()='Setups']");
       
       
        #endregion

        #region action methods
        public void ClickPayroll()
        {
            Find(payroll).Click();
        }
        public void ClickSetups()
        {
            Find(setups).Click();
        }
        
        
        #endregion
    }
}
