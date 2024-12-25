//using Bogus;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class EmployeePage
    {
        private readonly IWebDriver _driver;
        //public static Faker faker = new Faker();


        // Constructor
        public EmployeePage(IWebDriver driver)
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

        

        //string expname = faker.Name.FirstName();
        //string expname = "Suraj";

        public void ClickNewBtn()
        {
            CommonActions.ClickNew();
        }

        public void ProvideWorkEmail(string email)
        {
            _driver.FindElement(workEmail).SendKeys(email);
        }



        public void ProvideName(string empname)
        {
            _driver.FindElement(name).SendKeys(empname);
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

        public void ProvideMobileNumber(string mbl)
        {
            _driver.FindElement(mobileNumber).SendKeys(mbl);
        }

        public void ProvideDOJ(string doj)
        {
            _driver.FindElement(joiningDate).Clear();
            _driver.FindElement(joiningDate).SendKeys(doj);

        }

        public void ClickNonPayrollBtn()
        {
            _driver.FindElement(nonpayroll).Click();
        }

        public void ClickDepartment()
        {
            _driver.FindElement(clkdept).Click();
            Thread.Sleep(1000);
        }

        public void SelectDepartment(string dept)
        {
            CommonActions.SelectDropdownOption(dept);
        }

        public void ClickDesignation()
        {
            _driver.FindElement(clkdesg).Click();
            Thread.Sleep(1000);
        }

        public void SelectDesignation(string desg)
        {
            CommonActions.SelectDropdownOption(desg);
        }

        public void ClearPayrollSet()
        {
            _driver.FindElement(clearpayrollSet).Click();
            _driver.FindElement(clearpayrollSet).Clear();

        }
        public void ClickPayrollSet()
        {
            _driver.FindElement(payrollset).Click();
            Thread.Sleep(1000);
        }

        public void SelectPayrollSet(string payrollset)
        {
            CommonActions.SelectDropdownOption(payrollset);
        }

        public void ClickCalendar()
        {
            _driver.FindElement(clkcalendar).Click();
            Thread.Sleep(1000);
        }

        public void SelectCalendar(string calendar)
        {
            CommonActions.SelectDropdownOption(calendar);
        }

        public void ClickIndemnity()
        {
            _driver.FindElement(clkindemnity).Click();
            Thread.Sleep(1000);
        }

        public void SelectIndemnity(string indemnity)
        {
            CommonActions.SelectDropdownOption(indemnity);
        }

        public void ClickGrade()
        {
            _driver.FindElement(clkgrade).Click();
            Thread.Sleep(1000);
        }

        public void SelectGrade(string grade)
        {
            CommonActions.SelectDropdownOption(grade);
        }

        public void ClickGender()
        {
            _driver.FindElement(clkgender).Click();
            Thread.Sleep(1000);
        }

        public void SelectGender(string gender)
        {
            CommonActions.SelectDropdownOption(gender);
        }

        public void ClickReligion()
        {
            _driver.FindElement(clkreligion).Click();
            Thread.Sleep(1000);
        }

        public void SelectReligion(string religion)
        {
            CommonActions.SelectDropdownOption(religion);
        }

        public void ClickMaritalStatus()
        {
            _driver.FindElement(clkmaritalstatus).Click();
            Thread.Sleep(1000);
        }

        public void SelectMaritalStatus(string maritalStatus)
        {
            CommonActions.SelectDropdownOption(maritalStatus);
        }

        public void ClickSystemAccessBtn()
        {
            _driver.FindElement(systemaccess).Click();
        }

        public void ProvideUserName(string actusername)
        {
            //_driver.FindElement(username).SendKeys(actusername);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            IWebElement element = _driver.FindElement(By.Id("dx_dx-4d99a9bc-290c-2c0c-16c8-c7017645bb87_CustomUsername"));
            js.ExecuteScript("arguments[0].value='mohan@test.com';", element);

            Thread.Sleep(2000);
        }

        public void ClickRoles()
        {
            _driver.FindElement(roles).Click();
            Thread.Sleep(1000);
        }

        public void SelectRole(string role)
        {
            CommonActions.SelectDropdownOption(role);
        }

        public void ClickSave()
        {
            CommonActions.ClickSaveWithoutBack();
        }

        public bool IsEmployeeCreated(string empname)
        {
            if (CommonActions.ResultEmployee().Contains(empname))
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
