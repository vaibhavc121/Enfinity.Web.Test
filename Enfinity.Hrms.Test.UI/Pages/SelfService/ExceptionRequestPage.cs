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
        private By exceptionDate = By.XPath("//input[contains(@id,'ExceptionDate')]");
        private By loginTime = By.XPath("//input[contains(@id,'LoginTime')]");
        private By logotTime = By.XPath("//input[contains(@id,'LogoutTime')]");
        //(//input[@class='dx-texteditor-input'])[4]
        private By loginCal = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[2]");
        private By logoutCal = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[3]");
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
        public void ProvideExceptionDate(string value)
        {
            ClearAndProvide1(exceptionDate, value);
        }
        public void ProvideLoginTime(string value)
        {
            ClearAndProvide1(loginTime, value);
            Find(loginCal).Click();
        }        
        public void ProvideLogoutTime(string value)
        {
            ClearAndProvide1(logotTime, value);
            Find(logoutCal).Click();
        }       
        public void ProvideRemarks(string value)
        {
            ProvideDescription(value);
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }
        public bool IsTxnCreated(string expDate)
        {
            FilterDateByIndex(5, expDate);
            if(ResultValue(5).Contains(expDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void a()
        {

        }
        

        #endregion
    }
}
