
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class ITSupportRequestPage : BasePage
    {
        public ITSupportRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By iTSupportRequest = By.XPath("//span[normalize-space()='IT Support Request']");
        private By subject = By.XPath("//input[contains(@id,'Title')]");
        private By supportRequest = By.XPath("//input[@id='SupportRequest.SupportRequestCategoryIdLookup_I']");
        private By priority = By.Id("SupportRequest.Priority_B-1Img");
        private By desc = By.XPath("//div[@aria-label='Editor content']");
        private By plusBtn = By.XPath("(//i[@class='dx-icon dx-icon-new-icon'])[1]");
        private By low = By.XPath("Low");
        private By normal = By.XPath("Normal");
        private By high = By.XPath("//div[text()='High']");
        private By contextMenu = By.XPath("//img[@id='MainMenu_DXI15_PImg']");

        #endregion

        #region action methods
        public void ClickITSupport()
        {
            Find(iTSupportRequest).Click();
            WaitTS(3);
        }
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ClickPlusBtn()
        {
            HoverOverElement(plusBtn);           
            Find(plusBtn).Click();
        }       
        public void ProvideSubject(string value)
        {
            Find(subject).SendKeys(value);
        }
        public void SelectPriority(string value)
        {
            if (value.Contains("High"))
            {
                Find(high).Click();
            }
            else if (value.Contains("Normal"))
            {
                Find(normal).Click();
            }
            else if (value.Contains("Low"))
            {
                Find(low).Click();
            }
            else
            {
                Find(low).Click();
                throw new Exception("VRC- Matching priority not found");
            }
        }
       
        public void ProvideDescription(string value)
        {
            Find(desc).SendKeys(value);
        }
        public void ClickOnSave()
        {
            ClickSave();
        }
        public void ClickOnContextMenu()
        {
            Find(contextMenu).Click();
        }
        public void ClickOnView()
        {
            ClickView();
        }
        public void ClickOnApproveBack()
        {
            ClickApproveAndBack();
           
        }
        public bool IsTxnCreated(string emp, string desc)
        {
            if (ResultValue(5).Contains(emp) && ResultValue(7).Contains(desc))
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
