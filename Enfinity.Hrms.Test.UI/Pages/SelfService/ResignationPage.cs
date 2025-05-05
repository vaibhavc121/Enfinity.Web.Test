
using Enfinity.Hrms.Test.UI.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class ResignationPage : BasePage
    {
        public ResignationPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By profileUpdate = By.XPath("//a[@id='TxnInstanceView_I0i19_T']//span[@class='dx-vam'][normalize-space()='Profile Update']");
        private By resignationApplication = By.XPath("//span[normalize-space()='Resignation Application']");
        private By submittedDate = By.XPath("//input[@id='ResignationApplication.SubmittedDate_I']");
        private By remarks = By.XPath("//textarea[@id='ResignationApplication.Description_I']");
        #endregion

        #region action methods
        public void ScrollDownWebpage()
        {
            ScrollDownWebPage(profileUpdate);
        }
        public void ClickResignation()
        {
            Find(resignationApplication).Click();
        }
        public void ClickNew()
        {
            ClickOnNew();
        }
        public void ProvideSubmittedDate(string value)
        {
            ClearAndProvide1(submittedDate, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickOnSaveAndBack()
        {
            ClickSaveAndBack();
        }
        public bool IsTxnCreated()
        {
           return IsTransactionCreated();
        }
        public bool IsTransactionCreated1()
        {
            string expectedDate = DateUtils.CurrentDateInCustomFormat();
            string expectedDesc = DateUtils.AddDaysToGivenDate("01-01-2025",100);

            if (ResultValue(2).Contains(expectedDate) || ResultValue(7).Contains(expectedDesc))
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
