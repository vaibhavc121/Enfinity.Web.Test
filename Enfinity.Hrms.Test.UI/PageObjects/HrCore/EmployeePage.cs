//using Bogus;
using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class EmployeePage:BasePage
    {
        //private readonly IWebDriver _driver;
        //public static Faker faker = new Faker();        

        public EmployeePage(IWebDriver driver) : base(driver)
        {
        }


        #region Create Page Objects
        private readonly By newbtn = By.CssSelector("#MainMenu_DXI0_Img");

        private readonly By workEmail = By.Name("Email");

        private readonly By name = By.Name("Name");

        private readonly By clkmgr = By.CssSelector("div[class='dx-first-col dx-last-col dx-last-row dx-field-item dx-col-0 dx-field-item-optional dx-field-item-has-group'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctmgr = By.XPath("//div[contains(text(),'001 | Vaibhav Chavan')]");

        private readonly By mobileNumber = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");

        private readonly By joiningDate = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");

        By nonpayroll = By.XPath("//div[normalize-space()='OFF']");

        private readonly By clkdept = By.CssSelector("div[class='dx-first-row dx-first-col dx-last-row dx-field-item dx-col-0 dx-field-item-required dx-flex-layout dx-label-v-align'] div[class='dx-show-invalid-badge dx-selectbox dx-textbox dx-texteditor dx-show-clear-button dx-dropdowneditor-button-visible dx-editor-outlined dx-texteditor-empty dx-widget dx-dropdowneditor dx-dropdowneditor-field-clickable dx-validator dx-visibility-change-handler'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctdept = By.XPath("//div[contains(text(),'prod')]");

        private readonly By clkdesg = By.CssSelector("div[class='dx-first-row dx-last-row dx-field-item dx-col-1 dx-field-item-required dx-flex-layout dx-label-v-align'] div[class='dx-show-invalid-badge dx-selectbox dx-textbox dx-texteditor dx-show-clear-button dx-dropdowneditor-button-visible dx-editor-outlined dx-texteditor-empty dx-widget dx-dropdowneditor dx-dropdowneditor-field-clickable dx-validator dx-visibility-change-handler'] div[class='dx-dropdowneditor-icon']");

        private readonly By slctdesg = By.XPath("//div[contains(text(),'Systems Analyst')]");

        private By clearpayrollSet = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");

        private By payrollset = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private readonly By clkcalendar = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private By clkindemnity = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private readonly By clkgrade = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]");

        private readonly By clkgender = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private readonly By clkreligion = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private readonly By clkmaritalstatus = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]");

        private By systemaccess = By.XPath("//div[normalize-space()='No']");

        //private By username = By.XPath("/html[1]/body[1]/div[7]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        //private By username=By.Id("dx_dx-4d99a9bc-290c-2c0c-16c8-c7017645bb87_CustomUsername");
        private By username = By.XPath("//div[@aria-label='Yes']//div[@class='dx-switch-handle']//following::input[@id='dx_dx-4d99a9bc-290c-2c0c-16c8-c7017645bb87_CustomUsername']");

        private By roles = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        ////div[@class='dx-texteditor-input-container dx-tag-container']
        //private By roles = By.XPath("//div[@class='dx-texteditor-input-container dx-tag-container']");
        //private By roles = By.CssSelector(".dx-texteditor-input-container.dx-tag-container");
        //private By roles = By.XPath("//div[@class='dx-texteditor-input-container dx-tag-container']");        

        private readonly By save = By.XPath("//span[normalize-space()='Save']");

        private readonly By empname = By.XPath("//h2[normalize-space()='Suraj']");

        private readonly By filterCell = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[5]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");

        private readonly By result = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]");

        private readonly By clkfilteredemp = By.XPath("//a[normalize-space()='001 | Vaibhav Chavan']");
        #endregion

        #region Personal Tab
        private By nameL2 = By.XPath("//input[@name='NameL2']");
        private By displayName = By.Name("DisplayName");
        private By displayNameL2 = By.Name("DisplayNameL2");
        private By DOB = By.XPath("//input[@aria-haspopup='true']");
        private By nationality = By.XPath("//input[@aria-expanded='true']");
        private By bloodGroup = By.XPath("//input[contains(@id,'BloodGroup')]");
        private By photoVisibility = By.XPath("//input[contains(@id,'PhotoVisibility')]");
        private By mobileNumberVisibility = By.XPath("//input[contains(@id,'MobileNumberVisibility')]");
        private By emailVisibility = By.XPath("//input[contains(@id,'EmailVisibility')]");
        #endregion

        //string expname = faker.Name.FirstName();
        //string expname = "Suraj";

        #region Create Action Methods
        public void ClickNewBtn()
        {
            CommonPageActions.ClickNew();
        }

        public void ProvideWorkEmail(string email)
        {
            Find(workEmail).SendKeys(email);
        }



        public void ProvideName(string empname)
        {
            Find(name).SendKeys(empname);
        }

        public void ClickMgrDropdown()
        {
            Find(clkmgr).Click();
            Thread.Sleep(1000);
        }

        public void SelectMgr()
        {
            //CommonActions.SelectDropdownOption("Vaibhav Chavan");
            Find(slctmgr).Click();
        }

        public void ProvideMobileNumber(string mbl)
        {
            Find(mobileNumber).SendKeys(mbl);
        }

        public void ProvideDOJ(string doj)
        {
            Find(joiningDate).Clear();
            Find(joiningDate).SendKeys(doj);

        }

        public void ClickNonPayrollBtn()
        {
            Find(nonpayroll).Click();
        }

        public void ClickDepartment()
        {
            Find(clkdept).Click();
            Thread.Sleep(1000);
        }

        public void SelectDepartment(string dept)
        {
            CommonPageActions.SelectDropdownOption(dept);
        }

        public void ClickDesignation()
        {
            Find(clkdesg).Click();
            Thread.Sleep(1000);
        }

        public void SelectDesignation(string desg)
        {
            CommonPageActions.SelectDropdownOption(desg);
        }

        public void ClearPayrollSet()
        {
            Find(clearpayrollSet).Click();
            Find(clearpayrollSet).Clear();

        }
        public void ClickPayrollSet()
        {
            Find(payrollset).Click();
            Thread.Sleep(1000);
        }

        public void SelectPayrollSet(string payrollset)
        {
            CommonPageActions.SelectDropdownOption(payrollset);
        }

        public void ClickCalendar()
        {
            Find(clkcalendar).Click();
            Thread.Sleep(1000);
        }

        public void SelectCalendar(string calendar)
        {
            CommonPageActions.SelectDropdownOption(calendar);
        }

        public void ClickIndemnity()
        {
            Find(clkindemnity).Click();
            Thread.Sleep(1000);
        }

        public void SelectIndemnity(string indemnity)
        {
            CommonPageActions.SelectDropdownOption(indemnity);
        }

        public void ClickGrade()
        {
            Find(clkgrade).Click();
            Thread.Sleep(1000);
        }

        public void SelectGrade(string grade)
        {
            CommonPageActions.SelectDropdownOption(grade);
        }

        public void ClickGender()
        {
            Find(clkgender).Click();
            Thread.Sleep(1000);
        }

        public void SelectGender(string gender)
        {
            CommonPageActions.SelectDropdownOption(gender);
        }

        public void ClickReligion()
        {
            Find(clkreligion).Click();
            Thread.Sleep(1000);
        }

        public void SelectReligion(string religion)
        {
            CommonPageActions.SelectDropdownOption(religion);
        }

        public void ClickMaritalStatus()
        {
            Find(clkmaritalstatus).Click();
            Thread.Sleep(1000);
        }

        public void SelectMaritalStatus(string maritalStatus)
        {
            CommonPageActions.SelectDropdownOption(maritalStatus);
        }

        public void ClickSystemAccessBtn()
        {
            Find(systemaccess).Click();
        }

        public void ProvideUserName(string actusername)
        {
            //Find(username).SendKeys(actusername);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement element = Find(By.Id("dx_dx-4d99a9bc-290c-2c0c-16c8-c7017645bb87_CustomUsername"));
            js.ExecuteScript("arguments[0].value='mohan@test.com';", element);

            Thread.Sleep(2000);
        }

        public void ClickRoles()
        {
            Find(roles).Click();
            Thread.Sleep(1000);
        }

        public void SelectRole(string role)
        {
            CommonPageActions.SelectDropdownOption(role);
        }

        public void ClickSave()
        {
            CommonPageActions.ClickSaveAndBack();
        }

        public bool IsEmployeeCreated(string empname)
        {
            if (CommonPageActions.ResultEmployee().Contains(empname))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Personal Tab Action Methods
        public void ProvideNameL2()
        {
            Find(nameL2).SendKeys("");
        }

        public void ProvideDisplayName()
        {
            Find(displayName).SendKeys("");
        }

        public void ProvideDisplayNameL2()
        {
            Find(displayNameL2).SendKeys("");
        }

        public void ProvideDOB()
        {
            Find(DOB).SendKeys("");
        }

        public void SelectNationality()
        {
            CommonPageActions.SelectDropdownOption("");
            
        }
        #endregion

    }
}
