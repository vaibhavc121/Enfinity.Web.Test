using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Pages.SelfService
{
    public class ExceptionRequestPage : BasePage
    {
        public ExceptionRequestPage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By exceptionRequest = By.XPath("(//span[text()='Exception Request'])[2]");
        #endregion

        #region Action Methods
        public void CreateExceptionRequest()
        {
            Find(exceptionRequest).Click();
        }
        public void ClickNew()
        {
            ClickOnNew();
        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }

        #endregion
    }
}
