
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class LeaveRequestPage : BasePage
    {
        public LeaveRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By leaveRequest = By.XPath("(//span[text()='Leave Request'])[2]");
        //private By leaveRequest = By.XPath("a[id='TxnInstanceView_I0i7_T'] span[class='dx-vam']");           
        private By sickLeave = By.XPath("//p[@title='Sick Leave']");
        private By plusBtn = By.XPath("(//i[@class='dx-icon dx-icon-new-icon'])[2]");
        private By fromDate = By.XPath("//div[@class='dx-start-datebox dx-datebox dx-textbox dx-texteditor dx-editor-outlined dx-widget dx-visibility-change-handler dx-auto-width dx-dropdowneditor dx-datebox-date dx-datebox-calendar dx-dropdowneditor-field-clickable']//input[@role='combobox']");
        //private By toDate = By.XPath("//div[@class='dx-end-datebox dx-show-invalid-badge dx-datebox dx-textbox dx-texteditor dx-editor-outlined dx-widget dx-visibility-change-handler dx-auto-width dx-dropdowneditor dx-datebox-date dx-datebox-calendar dx-dropdowneditor-field-clickable dx-state-hover']//input[@role='combobox']");        
        private By toDate = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/input[1]");
        private By saveAndSubmit = By.XPath("//span[normalize-space()='Save and Submit']");
        private By newBtn = By.XPath("/html[1]/body[1]/div[6]/div[1]/div[1]/div[1]/ul[1]/li[1]/div[1]/img[1]");
        private By plusBtn1 = By.XPath("//img[@id='MainMenu_DXI0_Img']");
        private By attachFiles = By.XPath("//span[text()='Attach Files']");
        private By uploadFile = By.XPath("//span[text()='Upload File']");

        




        #endregion

        #region action methods
        public void ClickLeaveRequest()
        {
            Find(leaveRequest).Click();
        }

        public void ClickNew()
        {
            //ClickNew();
            //Find(newBtn).Click();
            Find(plusBtn1).Click(); 
            Thread.Sleep(5000);
        }

        public void HoverAndClick(string leaveType)
        {
            By dynamicLeaveType = By.XPath($"//p[@title='{leaveType}']");
            HoverAndClick(dynamicLeaveType, plusBtn);
        }
        public void ProvideFromDate(string value)
        {
            ClearAndProvide1(fromDate, value);
            PressTab();
        }

        public void ProvideToDate(string value)
        {
            ClearAndProvide1(toDate, value);
        }

        public void ClickSaveAndSubmit()
        {
            Find(saveAndSubmit).Click();
        }
        public void ClickSave()
        {
            ClickSaveAndBack();
        }

        public void AttachFile()
        {
            Find(attachFiles).Click();
            Find(uploadFile).SendKeys("C:\\Users\\Vaibhav\\Downloads\\universe.png");

        }
        public bool IsTxnCreated(string fromDate, string toDate)
        {
            if(ResultValue(8).Contains(fromDate) &&
            ResultValue(8).Contains(toDate))              
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
