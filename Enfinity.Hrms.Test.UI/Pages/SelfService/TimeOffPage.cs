
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class TimeOffPage : BasePage
    {
        public TimeOffPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By timeOff = By.XPath("(//span[text()='Time Off'])[2]");

        private By permissionDate = By.XPath("//input[contains(@id,'LateDate')]");
        private By personal = By.XPath("(//div[@class='dx-item-content'])[1]");
        private By business = By.XPath("(//div[@class='dx-item-content'])[2]");
        private By leave = By.XPath("(//div[@class='dx-item-content'])[3]");

        private By fromTimeField = By.XPath("//input[contains(@id,'FromTime')]");
        private By uptoTime = By.XPath("//input[contains(@id,'UptoTime')]");
        private By hrs = By.XPath("//input[@aria-label='hours']");
        private By minutes = By.XPath("//input[@aria-label='minutes']");
        private By timeNotation = By.XPath("//div[@class='dx-dropdowneditor-input-wrapper dx-selectbox-container']//div[@class='dx-dropdowneditor-icon']");
        private By AM = By.XPath("//div[text()='AM']");
        private By PM = By.XPath("//div[text()='PM']");

        private By hrs1 = By.XPath("//input[@aria-label='hours']");
        private By minutes1 = By.XPath("//input[@aria-label='minutes']");
        private By timeNotation1 = By.XPath("//div[@class='dx-dropdowneditor-input-wrapper dx-selectbox-container']//div[@class='dx-dropdowneditor-icon']");
        private By AM1 = By.XPath("//div[text()='AM']");
        private By PM1 = By.XPath("//div[text()='PM']");

        private By description = By.XPath("//textarea[contains(@id,'Description')]");



        


        private By  selectRow= By.XPath("(//tr)[12]//td[2]");
        private By contextMenu = By.XPath("//img[@id='MainMenu_DXI18_PImg']");
        private By delete = By.XPath("//span[normalize-space()='Delete']");
        private By ok = By.XPath("//div[@aria-label='Ok']//div[@class='dx-button-content']");
        private By ok1 = By.XPath("//span[normalize-space()='Ok']");
        #endregion

        #region action methods
        public void ClickTimeOff()
        {
            Find(timeOff).Click();
        }
        public void ClickOnNew()
        {
            ClickNew();
        }

        public void ProvidePermissonDate(string value)
        {
            ClearAndProvide(permissionDate, value);

        }
        public void ClickPersoanl()
        {
            Find(personal).Click();
        }
        public void ClickBusiness()
        {
            Find(business).Click();
        }
        public void ClickLeave()
        {
            Find(leave).Click();
        }
        public void ClickFromTimeField()
        {
            Find(fromTimeField).Click();
        }
        public void ProvideHrs(string value)
        {
            ClearAndProvide1(hrs, value);
        }
        public void ProvideMinutes(string value)
        {
            ClearAndProvide1(minutes, value);
        }
        public void ClickTimeNotation()
        {
            Find(timeNotation).Click();
        }
        public void SelectTimeNotation()
        {
            Find(AM).Click();
        }
        public void ClickOnOk()
        {
            ClickOk();
        }

        public void ClickUpToTimeField()
        {
            Find(uptoTime).Click();
        }
        public void ProvideUpToHrs(string value)
        {
            ClearAndProvide1(hrs1, value);
        }

        public void ProvideUpTOHrs1()
        {
            //ClickElementByJavaScript(driver, hrs1);
        }
        public void ProvideUpToMinutes(string value)
        {
            ClearAndProvide1(minutes1, value);
        }
        public void ClickUpToTimeNotation()
        {
            Find(timeNotation1).Click();
        }
        public void SelectUpToTimeNotation()
        {
            Find(AM1).Click();
        }
        public void ClickUpToOk()
        {
            ClickOk();
        }
        public void EnterDescription()
        {
            ProvideDescription();
        }

        public void SaveAndSubmit()
        {
            ClickSaveSubmit();
        }

        public void ClickOnSave()
        {
            ClickSaveAndBack();
        }
       

        public bool IsTxnCreated(string value)
        {            
            if(Result7().Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete time off
        public void SelectTheRow()
        {
            Find(selectRow).Click();
        }
        public void ClickOnView()
        {
            ClickView();
        }
        public void ClickContextMenu()
        {
            Find(contextMenu).Click();
        }
        public void ClickDelete()
        {
            Find(delete).Click();
            Thread.Sleep(1000);
        }
        




        #endregion


    }
}
