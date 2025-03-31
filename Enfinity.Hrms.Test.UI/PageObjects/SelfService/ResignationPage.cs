using Enfinity.Common.Test;
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
        private By resignation = By.XPath("//span[normalize-space()='Resignation']");
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
            Find(resignation).Click();
        }
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideSubmittedDate(string value)
        {
            ClearAndProvide1(submittedDate, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickOnSave()
        {
            ClickSave();
        }
        public bool IsTransactionCreated()
        {
           return IsTxnCreated();
        }
        
        #endregion
    }
}
