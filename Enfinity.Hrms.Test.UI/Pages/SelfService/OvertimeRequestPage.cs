
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class OvertimeRequestPage : BasePage
    {
        public OvertimeRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By profileUpdate = By.XPath("//a[@id='TxnInstanceView_I0i19_T']//span[@class='dx-vam'][normalize-space()='Profile Update']");
        private By overtimeApplication = By.XPath("//span[normalize-space()='Overtime Application']");
        private By overtimeDate = By.XPath("//input[@id='OvertimeApplication.OvertimeDate_I']");
        private By overtimeType = By.XPath("//input[@id='OvertimeApplication.OvertimeTypeIdLookup_I']");
        private By hours = By.XPath("//input[@id='OvertimeApplication.Hours_I']");
        private By remarks = By.XPath("//textarea[@id='OvertimeApplication.Description_I']");
        private By validation = By.XPath("//span[@id='ValidationSummary']");
        #endregion

        #region action methods
        public void ScrollDownWebpage()
        {
            ScrollDownWebPage(profileUpdate);
        }
        public void ClickOvertimeRequest()
        {
            Find(overtimeApplication).Click();
        }
        public void ClickNew()
        {
            ClickOnNew();
        }
        public void ProvideOvertimeDate(string value)
        {
            //Find(overtimeDate).SendKeys(value);
            ClearAndProvide1(overtimeDate, value);
        }
        public void ProvideOvertimeType(string value)
        {
            //Find(overtimeType).SendKeys(value);
            ClearAndProvide1(overtimeType, value);
        }
        public void ProvideHrs(string value)
        {
            ClearAndProvide1(hours, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickSaveBack()
        {
             ClickSaveAndBack();
        }
        public string DisplayErrorMsg()
        {
            string msg = Find(validation).Text;
            return msg;
        }
        public bool IsTxnCreated(string overtimeType, string hrs)
        {
            //if (Result6().Contains(overtimeType) && Result6().Contains(hrs))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            if(ResultValue(7).Contains(overtimeType) && ResultValue(7).Contains(hrs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        #endregion
    }
}
