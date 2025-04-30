using Bogus;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;




namespace Enfinity.Hrms.Test.UI
{
    public class HardCodedPayrollEmployeePage
    {
        private readonly IWebDriver _driver;
        public static Faker faker = new Faker();
        

        // Constructor
        public HardCodedPayrollEmployeePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private readonly By newbtn = By.CssSelector("#MainMenu_DXI0_Img");

        private readonly By workEmail = By.Name("Email");

        private readonly By name = By.Name("Name");

        private readonly By clkmgr = By.CssSelector("div[class='dx-first-col dx-last-col dx-last-row dx-field-item dx-col-0 dx-field-item-optional dx-field-item-has-group'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctmgr = By.XPath("//div[contains(text(),'001 | Vaibhav Chavan')]");

        private readonly By mobileNumber = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");

        private readonly By joiningDate = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");

        private readonly By clkdept = By.CssSelector("div[class='dx-first-row dx-first-col dx-last-row dx-field-item dx-col-0 dx-field-item-required dx-flex-layout dx-label-v-align'] div[class='dx-show-invalid-badge dx-selectbox dx-textbox dx-texteditor dx-show-clear-button dx-dropdowneditor-button-visible dx-editor-outlined dx-texteditor-empty dx-widget dx-dropdowneditor dx-dropdowneditor-field-clickable dx-validator dx-visibility-change-handler'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctdept = By.XPath("//div[contains(text(),'prod')]");

        private readonly By clkdesg = By.CssSelector("div[class='dx-first-row dx-last-row dx-field-item dx-col-1 dx-field-item-required dx-flex-layout dx-label-v-align'] div[class='dx-show-invalid-badge dx-selectbox dx-textbox dx-texteditor dx-show-clear-button dx-dropdowneditor-button-visible dx-editor-outlined dx-texteditor-empty dx-widget dx-dropdowneditor dx-dropdowneditor-field-clickable dx-validator dx-visibility-change-handler'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctdesg = By.XPath("//div[contains(text(),'Systems Analyst')]");

        private readonly By clkcalendar = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private readonly By clkgrade = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private readonly By clkgender = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private readonly By clkreligion = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private readonly By clkmaritalstatus = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private readonly By save = By.XPath("//span[normalize-space()='Save']");

        private readonly By empname = By.XPath("//h2[normalize-space()='Suraj']");

        private readonly By filterCell = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[5]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");

        private readonly By result = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]");

        private readonly By clkfilteredemp = By.XPath("//a[normalize-space()='001 | Vaibhav Chavan']");

        /// <summary>
        //string expname = faker.Name.FirstName();
        /// </summary>
        string expname = "Suraj";

        public void ClickNewBtn()
        {
            BasePage.ClickOnNew(); 
            
            
            
            
            
        }

        public void ProvideWorkEmail()
        {
            _driver.FindElement(workEmail).SendKeys(faker.Internet.Email());
            
        }

              
        
        public void SetName()
        {
            _driver.FindElement(name).SendKeys("Suraj");
        }

        public void ClickMgrDropdown()
        {
            _driver.FindElement(clkmgr).Click();
            Thread.Sleep(1000);
        }

        public void SelectMgr()
        {
            //CommonActions.SelectDropdownOption("Vaibhav Chavan");
            _driver.FindElement(slctmgr).Click();
        }

        public void SetMobileNumber()
        {
            _driver.FindElement(mobileNumber).SendKeys(faker.Phone.PhoneNumber());
        }

        public void SetDOJ()
        {
            _driver.FindElement(joiningDate).Clear();
            _driver.FindElement(joiningDate).SendKeys("01-Jan-2024");
            
        }

        public void ClickDept()
        {
            _driver.FindElement(clkdept).Click();
            Thread.Sleep(1000);
        }

        public void SelectDept()
        {
            //.SelectDropdownOption("prod");
        }

        public void ClickDesig()
        {
            _driver.FindElement(clkdesg).Click();
            Thread.Sleep(1000);
        }

        public void SelectDesig()
        {
            BasePage.SelectDropdownOption("Systems Analyst");
        }

        public void ClickCalendar()
        {
            _driver.FindElement(clkcalendar).Click();
            Thread.Sleep(1000);
        }

        public void SelectCalendar()
        {
            BasePage.SelectDropdownOption("for flipkart");
        }

        public void ClickGrade()
        {
            _driver.FindElement(clkgrade).Click();
            Thread.Sleep(1000);
        }

        public void SetGrade()
        {
            BasePage.SelectDropdownOption("Contributor");
        }

        public void ClickGender()
        {
            _driver.FindElement(clkgender).Click();
            Thread.Sleep(1000);
        }

        public void SetGender()
        {
            BasePage.SelectDropdownOption("Male");
        }

        public void ClickReligion()
        {
            _driver.FindElement(clkreligion).Click();
            Thread.Sleep(1000);
        }

        public void SetReligion()
        {
            BasePage.SelectDropdownOption("Hindu");
        }

        public void ClickMaritalStatus()
        {
            _driver.FindElement(clkmaritalstatus).Click();
            Thread.Sleep(1000);
        }

        public void SetMaritalStatus()
        {
            BasePage.SelectDropdownOption("Married");
        }

        public void ClickSave()
        {
            BasePage.ClickSaveAndBack();
            
        }

        public bool IsEmployeeCreated()
        {
            if (BasePage.ResultEmployee().Contains(expname))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
    }
}
