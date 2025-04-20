
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class ITSupportPage : BasePage
    {
        public ITSupportPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By iTSupportRequest = By.XPath("//span[normalize-space()='IT Support Request']");
        private By supportRequestCategory = By.Id("SupportRequest.SupportRequestCategoryIdLookup_B-1Img");
        private By supportRequest = By.XPath("//input[@id='SupportRequest.SupportRequestCategoryIdLookup_I']");
        private By priority = By.Id("SupportRequest.Priority_B-1Img");
        private By remarks = By.XPath("//textarea[@id='SupportRequest.Description_I']");
        #endregion

        #region action methods
        public void ClickITSupport()
        {
            Find(iTSupportRequest).Click();
        }
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ClickSupportRequestCategoryDD()
        {
            Find(supportRequestCategory).Click();
        }
        public void SelectSupportRequestCategory(string value)
        {
            Find(supportRequest).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ClickPriorityDD()
        {
            Find(priority).Click();
        }
        public void SelectPriority(string value)
        {
            SelectDropdownValueOffice365(value);

        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickOnSave()
        {
            ClickSaveAndBack();
        }
        public bool IsTxnCreated(string value)
        {
            if (Result6().Contains(value))
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
