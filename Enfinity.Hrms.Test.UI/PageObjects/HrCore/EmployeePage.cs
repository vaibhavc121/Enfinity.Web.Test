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
        //string expname = faker.Name.FirstName();
        //string expname = "Suraj";

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

        #region Tab Page Objects
        //private By job = By.XPath("//span[normalize-space()='Job']");
        //private By job = By.XPath("/html[1]/body[1]/div[6]/div[1]/main[1]/div[2]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]/a[1]/span[1]");
        private By job = By.XPath("//span[contains(text(),'Job')]");
        
        private By payroll = By.XPath("//a[@id='employeeProfileMenu_DXI2_T']//span[@class='dx-vam dxm-contentText'][normalize-space()='Payroll']");
        private By timeOff = By.XPath("//span[normalize-space()='Time Off']");
        private By attendance = By.XPath("//a[@id='employeeProfileMenu_DXI4_T']//span[@class='dx-vam dxm-contentText'][normalize-space()='Attendance']");
        private By documents = By.XPath("//span[normalize-space()='Documents']");
        private By performance = By.XPath("//a[@id='employeeProfileMenu_DXI6_T']//span[@class='dx-vam dxm-contentText'][normalize-space()='Performance']");
        private By learning = By.XPath("//a[@id='employeeProfileMenu_DXI7_T']//span[@class='dx-vam dxm-contentText'][normalize-space()='Learning']");
        private By integration = By.XPath("//span[normalize-space()='Integration']");
        private By dependents = By.XPath("//span[normalize-space()='Dependents']");
        private By residencyInfo = By.XPath("//span[normalize-space()='Residency Info']");
        private By onboarding = By.XPath("//a[@id='employeeProfileMenu_DXI11_T']//span[@class='dx-vam dxm-contentText'][normalize-space()='Onboarding']");
        private By offboarding = By.XPath("//span[normalize-space()='Offboarding']");
        private By careerPath = By.XPath("//span[normalize-space()='Career Path']");
        #endregion

        #region Personal Tab Page Objects
        private By nameL2 = By.XPath("//input[@name='NameL2']");
        private By displayName = By.Name("DisplayName");
        private By displayNameL2 = By.Name("DisplayNameL2");
        private By DOB = By.XPath("//input[@aria-haspopup='true']");
        //private By clicknationality = By.XPath("//div[@class='dx-widget dx-button-normal dx-dropdowneditor-button']//div[@class='dx-dropdowneditor-icon']");
        private By clicknationality = By.XPath("/html[1]/body[1]/div[6]/div[1]/main[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By nationality = By.XPath("//input[@aria-expanded='true']");
        //private By clickBloodGroup = By.XPath("//div[@class='dx-widget dx-button-normal dx-dropdowneditor-button']//div[@class='dx-dropdowneditor-icon']");
        private By clickBloodGroup = By.XPath("//input[contains(@id,'BloodGroup')]");
        private By bloodGroup = By.XPath("//input[contains(@id,'BloodGroup')]");
        //private By clickPhotoVisibility = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        private By clickPhotoVisibility = By.XPath("//input[contains(@id,'PhotoVisibility')]");
        private By photoVisibility = By.XPath("//input[contains(@id,'PhotoVisibility')]");
        //private By clickMobileNumberVisibility = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        private By clickMobileNumberVisibility = By.XPath("//input[contains(@id,'MobileNumberVisibility')]");
        private By mobileNumberVisibility = By.XPath("//input[contains(@id,'MobileNumberVisibility')]");
        //private By clickEmailVisibility = By.XPath("//div[@class='dx-dropdowneditor-icon']");
        private By clickEmailVisibility = By.XPath("//input[contains(@id,'EmailVisibility')]");
        private By emailVisibility = By.XPath("//input[contains(@id,'EmailVisibility')]");

        #endregion

        #region Job Page Objects
        private By manager = By.XPath("//input[contains(@id,'ManagerEmployeeId')]");
        private By keyEmployee = By.XPath("//div[@class='dx-switch-off']");
        private By substituteEmployee= By.XPath("//input[contains(@id,'SubstituteEmployeeId')]");
        private By employeeCategory = By.XPath("//input[contains(@id,'EmployeeCategoryId')]");
        private By workLocation = By.XPath("//input[contains(@id,'WorkLocationId')]");
        private By employmentType = By.XPath("//input[contains(@id,'EmploymentType')]");
        private By probationPeriod = By.XPath("//input[contains(@id,'ProbationPeriodInDays')]");
        private By noticePeriod = By.XPath("//input[contains(@id,'NoticePeriodInDays')]");
        private By addWorkExpButton = By.XPath("//div[@title='Add Work Experience']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By priorCompany = By.XPath("//input[contains(@id,'PriorCompany')]");
        private By StartDate= By.XPath("//input[contains(@id,'StartDate')]");
        private By saveWorkExp = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");        
        private By addQualification = By.XPath("//div[@title='Add Qualification']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By qualification = By.XPath("//input[contains(@id,'QualificationId')]");
        private By university = By.XPath("//input[contains(@id,'University')]");
        private By YOP = By.XPath("//input[contains(@id,'YearOfPassing')]");
        //private By saveQualification = By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//div[@aria-label='Save']//div[@class='dx-button-content']");
        private By saveQualification = By.XPath("/html[1]/body[1]/div[9]/div[1]/div[3]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/span[1]");



        #endregion

        #region Payroll Tab Page Objects
        private By payrollsetid = By.XPath("//input[contains(@id,'PayrollSetId')]");
        private By nonpayrollbtn = By.XPath("//div[@id='NonPayroll']//div[@class='dx-switch-off'][normalize-space()='OFF']");
        private By paymentMode = By.XPath("//input[contains(@id,'PaymentMode')]");
        private By employeebank = By.XPath("//input[contains(@id,'BankId')]");
        private By bankAccountNumber = By.XPath("//input[contains(@id,'BankAccountNumber')]");
        private By IbanNumber = By.XPath("//input[contains(@id,'IbanNumber')]");
        private By bankAccountType = By.XPath("//input[contains(@id,'BankAccountType')]");
        private By govtRecruitmentContractLicense = By.XPath("//input[contains(@id,'GovtRecruitmentContractLicenseId')]");
        private By addSalaryComponentsBtn = By.XPath("//p[normalize-space()='Salary Components']/../..//i[@class='dx-icon dx-icon-add']");
        private By salaryComponent = By.XPath("//input[contains(@id,'SalaryComponentId')]");
        private By amount = By.XPath("//input[contains(@id,'Amount')]");
        private By effectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");
        private By saveSalComponent = By.XPath("//div[@id='SaveButton']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addOvertimeTypes = By.XPath("//p[normalize-space()='Overtime Types']//following::i[@class='dx-icon dx-icon-add']");
        private By overtimeType = By.XPath("//input[contains(@id,'OvertimeTypeId')]");
        private By saveOvertimeType = By.XPath("//div[@id='SaveButton']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addTicketsBtn = By.XPath("//div[@title='Add Ticket']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By relationshipType = By.XPath("//input[contains(@id,'RelationshipType')]");
        private By description = By.XPath("//input[contains(@id,'Description')]");
        private By ticketAccrual = By.XPath("//input[contains(@id,'TicketAccrualId')]");
        private By ticketDestination = By.XPath("//input[contains(@id,'TicketDestinationId')]");
        private By ticketEffectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");
        private By saveTicket = By.XPath("//div[@class='dx-widget dx-button dx-button-mode-contained dx-button-normal dx-button-has-text']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addMiscellaneousAccrual = By.XPath("//div[@title='Add Miscellaneous Accrual Earning']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By accrualType = By.XPath("//input[contains(@id,'AccrualType')]");
        private By accrualAmount = By.XPath("//input[contains(@id,'_Amount')]");
        private By resetAvailedDaysMethod = By.XPath("//input[contains(@id,'ResetAvailedDaysMethod')]");
        private By miscellaneousAccrualSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addBenefitScheme = By.XPath("//div[@title='Add Benefit Scheme']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By BSrelationshipType = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By benefitScheme = By.XPath("//input[contains(@id,'BenefitSchemeId')]");
        private By BSeffectiveFromDate = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By BSeffectiveToDate = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By BSsave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        #endregion

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

        #region Tab Action Methods
        public void ClickJob()
        {
            Find(job).Click();
        }
        public void ClickPayroll()
        {
            Find(payroll).Click();
        }

        public void ClickTimeOff()
        {
            Find(timeOff).Click();
        }
        public void ClickAttendance()
        {
            Find(attendance).Click();
        }
        public void ClickDocuments()
        {
            Find(documents).Click();
        }
        public void Performance()
        {
            Find(performance).Click();
        }
        public void ClickLearning()
        {
            Find(learning).Click();
        }

        public void ClickIntegration()
        {
            Find(integration).Click();
        }
        public void ClickDependents()
        {
            Find(dependents).Click();
        }
        public void ClickResidencyInfo()
        {
            Find(residencyInfo).Click();
        }
        public void ClickOnboarding()
        {
            Find(onboarding).Click();
        }
        public void ClickOffboarding()
        {
            Find(offboarding).Click();
        }
        public void ClickCareerPath()
        {
            Find(careerPath).Click();
        }
        #endregion           

        #region Personal Tab Action Methods
        public void ProvideNameL2(string value)
        {
            Find(nameL2).SendKeys(value);
        }

        public void ProvideDisplayName(string value)
        {
            Find(displayName).SendKeys(value);
        }

        public void ProvideDisplayNameL2(string value)
        {
            Find(displayNameL2).SendKeys(value);
        }

        public void ProvideDOB(string value)
        {
            Find(DOB).SendKeys(value);
        }

        public void ClickNationality()
        {
            Find(clicknationality).Click();


        }

        public void SelectNationality(string value)
        {
            CommonPageActions.SelectDropdownOption(value);

        }

        public void ClickBloodGroup()
        {
            Find(clickBloodGroup).Click();
            Thread.Sleep(1000);

        }

        public void SelectBloodGroup(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickPhotoVisibility()
        {
            Find(clickPhotoVisibility).Click();
            Thread.Sleep(1000);

        }

        public void SelectPhotoVisibility(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickMblNoVisibility()
        {
            Find(clickMobileNumberVisibility).Click();
            Thread.Sleep(1000);
        }

        public void SelectMblNoVisibility(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickEmailVisibility()
        {
            Find(clickEmailVisibility).Click();
            Thread.Sleep(1000);
        }

        public void SelectEmailVisibility(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        #endregion

        #region Job Action Methods
        public void ClickManager()
        {
            Find(manager).Click();
            Thread.Sleep(1000);
        }
        public void SelectManager(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void EnableKeyEmp()
        {
            Find(keyEmployee).Click();
            Thread.Sleep(1000);
        }

        public void ClickSubstituteEmployee()
        {
            Find(substituteEmployee).Click();
            Thread.Sleep(1000);
        }
        public void SelectSubstituteEmployee(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickEmployeeCategory()
        {
            Find(employeeCategory).Click();
            Thread.Sleep(1000);
        }
        public void SelectEmployeeCategory(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ClickWorkLocation()
        {
            Find(workLocation).Click();
            Thread.Sleep(1000);
        }
        public void SelectWorkLocation(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickEmploymentType()
        {
            Find(employmentType).Click();
            Thread.Sleep(1000);
        }
        public void SelectEmploymentType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ProvideProbationPeriod(string value)
        {
            Find(probationPeriod).Click();
            //Find(probationPeriod).Clear();
            Find(probationPeriod).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(probationPeriod).SendKeys(Keys.Delete);
            Find(probationPeriod).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ProvideNoticePeriod(string value)
        {
            Find(noticePeriod).Click();
            //Find(noticePeriod).Clear();
            Find(noticePeriod).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(noticePeriod).SendKeys(Keys.Delete);
            Find(noticePeriod).SendKeys(value);
            Thread.Sleep(1000);
        }

        //work experience starts
        public void ClickAddWorkExpBtn()
        {
            Find(addWorkExpButton).Click();
            Thread.Sleep(1000);
        }

        public void ProvidePriorCompany(string value)
        {
            Find(priorCompany).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ProvideStartDate(string value)
        {
            Find(StartDate).SendKeys(value);
            Thread.Sleep(1000);
        }

        public void ClickSaveBtn()
        {
            Find(saveWorkExp).Click();
            Thread.Sleep(1000);
        }
        //work experience ends

        //qualification starts
        public void AddQualificationBtn()
        {
            Find(addQualification).Click();
            Thread.Sleep(1000);
        }

        public void ClickQualification()
        {
            Find(qualification).Click();
            Thread.Sleep(1000);
        }

        public void SelectQualification()
        {
            CommonPageActions.SelectDropdownOption("BCA");
            Thread.Sleep(1000);
        }

        public void ProvideUniversity(string value)
        {
            Find(university).SendKeys(value);
            Thread.Sleep(1000);
        }

        public void ProvideYOP(string value)
        {
            Find(YOP).SendKeys(value);
            Thread.Sleep(1000);
        }

        public void SaveQualification()
        {
            Find(saveQualification).Click();
            Thread.Sleep(1000);
        }


        //qualification ends

        #endregion

        #region Payroll Tab Action Methods
        public void ClickPayrollSetID()
        {
            Find(payrollsetid).Click();
        }

        public void SelectPayrollSetID(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void EnableNonPayrollBtn()
        {
            Find(nonpayrollbtn).Click();
        }

        public void ClickPaymentMode()
        {
            Find(paymentMode).Click();
        }

        public void SelectPaymentMode(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ClickEmpBank()
        {
            Find(employeebank).Click();
        }

        public void SelectEmpBank(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ProvideBankAcNo()
        {
            Find(bankAccountNumber).SendKeys(RandomNumber());
        }

        public void ProvideIBANNo()
        {
            Find(IbanNumber).SendKeys(RandomNumber());
        }

        public void ClickBankAcType()
        {
            Find(bankAccountType).Click();
        }

        public void SelectBankAcType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ClickGovtLicense()
        {
            Find(govtRecruitmentContractLicense).Click();
        }

        public void SelectGovtLicense(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ClickAddSalaryComponentBtn()
        {
            Find(addSalaryComponentsBtn).Click();
        }

        public void ClickSalaryComponent()
        {
            Find(salaryComponent).Click();
        }
        
        public void SelectSalComponent(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideAmt(string value)
        {
            Find(amount).Click();
            //Find(probationPeriod).Clear();
            Find(amount).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(amount).SendKeys(Keys.Delete);
            Find(probationPeriod).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ProvideEffectiveFromDate(string value)
        {
            Find(effectiveFromDate).Click();
            //Find(probationPeriod).Clear();
            Find(effectiveFromDate).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(effectiveFromDate).SendKeys(Keys.Delete);
            Find(probationPeriod).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void SaveSalComponent()
        {
            Find(saveSalComponent).Click();
        }
        public void ClickOvertimeTypesBtn()
        {
            Find(addOvertimeTypes).Click();
        }
        public void ClickOvertimeType()
        {
            Find(overtimeType).Click();
        }
        public void SelectOvertimeType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void SaveOvertimeType()
        {
            Find(saveOvertimeType).Click();
        }
        public void AddTicketBtn()
        {
            Find(addTicketsBtn).Click();
        }
        public void clickRelationshipType()
        {
            Find(relationshipType).Click();
        }
        public void SelectRelationshipType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideDesc(string value)
        {
            Find(description).SendKeys(value);
        }
        public void ClickTicketAccrual()
        {
            Find(ticketAccrual).Click();
        }
        public void SelectTicketAccrual(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickTicketDestination()
        {
            Find(ticketDestination).Click();
        }
        public void SelectTicketDestination(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideTicketEffectiveFromDate(string value)
        {
            Find(ticketEffectiveFromDate).SendKeys(value);
        }
        public void ClickSaveTicket()
        {
            Find(saveTicket).Click();
        }
        public void ClickAddMiscellaneousAccrualEarnings()
        {
            Find(addMiscellaneousAccrual).Click();
        }
        public void ClickAccrualType()
        {
            Find(accrualType).Click();
        }
        public void SelectAccrualType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickResetAvailedDaysMethod()
        {
            Find(resetAvailedDaysMethod).Click();
        }
        public void SelectResetAvailedDaysMethod(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void SaveMiscellaneousAccrual()
        {
            Find(miscellaneousAccrualSave).Click();
        }
        public void ClickBenefitSchemes()
        {
            Find(addBenefitScheme).Click();
        }
        public void ClickRelationshipType()
        {
            Find(relationshipType).Click();
        }
        public void BSSelectRelationshipType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickBenefitScheme()
        {
            Find(benefitScheme).Click();
        }
        public void SelectBenefitScheme(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideBSEffectiveFromDate(string value)
        {
            Find(BSeffectiveFromDate).SendKeys(value);
        }
        public void ProvideBSEffectiveToDate(string value)
        {
            Find(BSeffectiveToDate).SendKeys(value);
        }
        public void BSSave()
        {
            Find(BSsave).Click();
        }

        #endregion

    }
}
