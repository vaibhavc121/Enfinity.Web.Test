//using Bogus;
using Bogus.DataSets;
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

        //Page Objects
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
        private By metaballsMenu = By.XPath("//img[@id='employeeProfileMenu_DXI14_PImg']");
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
        //private By salaryComponent = By.XPath("//input[contains(@id,'SalaryComponentId')]");
        private By salaryComponent = By.XPath("//span[normalize-space()='Salary Component']//following::input[contains(@id,'SalaryComponentId')]");
        private By amount = By.XPath("//input[contains(@id,'Amount')]");
        private By effectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");
        private By saveSalComponent = By.XPath("//div[@id='SaveButton']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addOvertimeTypes = By.XPath("//p[normalize-space()='Overtime Types']//following::i[@class='dx-icon dx-icon-add']");
        private By overtimeType = By.XPath("//input[contains(@id,'OvertimeTypeId')]");
        private By saveOvertimeType = By.XPath("//div[@id='EmployeeOvertimeTypePopupForm']//span[@class='dx-button-text'][normalize-space()='Save']");
        //private By saveOvertimeType = By.XPath("//div[@id='SaveButton']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addTicketsBtn = By.XPath("//div[@title='Add Ticket']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By relationshipType = By.XPath("//input[contains(@id,'RelationshipType')]");
        private By description = By.XPath("//input[contains(@id,'Description')]");
        private By ticketAccrual = By.XPath("//input[contains(@id,'TicketAccrualId')]");
        private By ticketDestination = By.XPath("//input[contains(@id,'TicketDestinationId')]");
        //private By ticketEffectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");
        private By ticketEffectiveFromDate = By.XPath("//span[normalize-space()='Effective From Date:']//following::input[contains(@id,'EffectiveFromDate')]");
        private By saveTicket = By.XPath("//div[@class='dx-widget dx-button dx-button-mode-contained dx-button-normal dx-button-has-text']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addMiscellaneousAccrual = By.XPath("//div[@title='Add Miscellaneous Accrual Earning']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By accrualType = By.XPath("//input[contains(@id,'AccrualType')]");
        private By accrualAmount = By.XPath("//input[contains(@id,'_Amount')]");
        private By resetAvailedDaysMethod = By.XPath("//input[contains(@id,'ResetAvailedDaysMethod')]");
        private By miscellaneousAccrualSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");
        private By addBenefitScheme = By.XPath("//div[@title='Add Benefit Scheme']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        //private By BSrelationshipType = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By BSrelationshipType = By.XPath("//input[contains(@id,'RelationshipType')]");        
        private By benefitScheme = By.XPath("//input[contains(@id,'BenefitSchemeId')]");
        private By BSeffectiveFromDate = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By BSeffectiveToDate = By.XPath("/html[1]/body[1]/div[12]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By BSsave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        #endregion

        #region TimeOff Tab Page Objects
        private By assignLeaveType = By.XPath("//span[normalize-space()='Assign Leave Type']");
        private By leaveType = By.XPath("//input[contains(@id,'NewLeaveTypeId')]");
        private By LTeffectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");


        #endregion

        #region Attendance Tab Page Objects
        private By calendar = By.XPath("//input[contains(@id,'CalendarId')]");
        private By presentByDefault = By.XPath("//div[@class='dx-switch-off']");
        private By checkInType = By.XPath("//input[contains(@id,'CheckInType')]");
        private By defaultShift = By.XPath("//input[contains(@id,'DefaultShiftId')]");
        private By policy = By.XPath("//input[contains(@id,'PolicyGroupId')]");
        private By shiftPreference = By.XPath("//input[contains(@id,'ShiftPreference')]");

        #endregion

        #region Documents Tab Page Objects
        private By showActive = By.XPath("//div[@class='dx-switch-on']");
        private By showAll = By.XPath("//div[@class='dx-switch-off']");
        private By addDocuments = By.XPath("//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By documentType = By.XPath("//input[contains(@id,'DocumentTypeId')]");
        private By documentNumber = By.XPath("//input[contains(@id,'DocumentNumber')]");
        private By dateOfExpiry = By.XPath("//input[contains(@id,'DateOfExpiry')]");
        private By placeOfDocument = By.XPath("//input[contains(@id,'PlaceOfDocument')]");
        //save

        #endregion

        #region Performance Tab Page Objects
        //Key Result Areas
        private By addKRABtn = By.XPath("//div[@title='Add Key Result Area']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By KeyResultAreaName = By.XPath("//input[contains(@id,'KeyResultAreaName')]");
        private By weightage = By.XPath("//input[contains(@id,'Weightage')]");
        private By KRAsave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        //Competencies
        private By addCompetencies = By.XPath("//div[@title='Add Competency']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By competencyName = By.XPath("//input[contains(@id,'CompetencyName')]");
        private By competenciesWeightage = By.XPath("//input[contains(@id,'CompetencyName')]//following::input[contains(@id,'Weightage')]");
        private By competenciesSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        //Skill Sets
        private By addSkillSetBtn = By.XPath("//div[@title='Add Skill Set']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By skillSetName = By.XPath("//input[contains(@id,'SkillSetName')]");
        private By level = By.XPath("//input[contains(@id,'Level')]");
        private By skillSetWeightage = By.XPath("//input[contains(@id,'Level')]//following::input[//input[contains(@id,'Weightage')]][2]");
        private By skillSetsave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        //goals
        private By addGoalsBtn = By.XPath("//div[@title='Add Goal']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By goalName = By.XPath("//span[contains(text(),'Goal (Arabic):')]//preceding::input[contains(@id,'GoalName')]");
        private By startDate = By.XPath("//input[contains(@id,'StartDate')]");
        private By dueDate = By.XPath("//input[contains(@id,'DueDate')]");
        private By priority = By.XPath("//input[contains(@id,'Priority')]");
        private By goalsWeightage = By.XPath("//input[contains(@id,'DescriptionL2')]//following::input[contains(@id,'Weightage')]");
        private By goalSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");



        #endregion

        #region Integration Tab Page Objects
        //Cost Allocation section
        private By financialIntegrationGroup = By.XPath("//input[contains(@id,'FinancialIntegrationGroupId')]");
        private By division = By.XPath("//input[contains(@id,'Segment1')]");
        private By department = By.XPath("//input[contains(@id,'Segment2')]");
        private By project = By.XPath("//input[contains(@id,'Segment3')]");
        private By segmentWorkLocation = By.XPath("//input[contains(@id,'Segment4')]");

        //Default Cost Allocation section
        private By defaultCostAllocationBtn = By.XPath("//i[@class='dx-icon dx-icon-add']");
        private By FromPeriod = By.XPath("//input[contains(@id,'FromPeriodId')]");
        private By ToPeriod = By.XPath("//input[contains(@id,'ToPeriodId')]");
        private By addRowBtn = By.XPath("//div[@aria-label='Data grid with 0 rows and 5 columns']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By sdivision = By.XPath("//div[@class='dx-show-invalid-badge dx-textbox dx-texteditor dx-editor-outlined dx-texteditor-empty dx-widget']//input[@role='textbox']");
        private By sdepartment = By.XPath("//div[@class='dx-show-invalid-badge dx-textbox dx-texteditor dx-editor-outlined dx-texteditor-empty dx-widget']//input[@role='textbox']");
        private By sproject = By.XPath("td[role='gridcell'][aria-describedby='dx-col-9']");
        private By sWorkLocation = By.XPath("td[role='gridcell'][aria-describedby='dx-col-10']");
        private By costAllocationsave = By.XPath("//div[@id='SaveButton']//span[@class='dx-button-text'][normalize-space()='Save']");

        //project section
        private By AddProjectsBtn = By.XPath("/html[1]/body[1]/div[6]/div[1]/main[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[5]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/i[1]");
        private By Project = By.XPath("//input[contains(@id,'ProjectId')]");
        private By EffectiveFromDate = By.XPath("//input[contains(@id,'EffectiveFromDate')]");
        private By EffectiveToDate = By.XPath("//input[contains(@id,'EffectiveToDate')]");
        private By empProjectsave = By.XPath("//div[@class='dx-item-content dx-toolbar-item-content']//div[@aria-label='Save']//div[@class='dx-button-content']");

        #endregion

        #region Dependents Tab Page Objects

        //spouse section
        private By addSpousesBtn = By.XPath("//div[@title='Add Spouse']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By spouseName = By.XPath("//span[normalize-space()='Name:']//following::input[contains(@id,'Name')][1]");        
        private By birthDate = By.XPath("/html[1]/body[1]/div[9]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By marriageDate = By.XPath("//input[contains(@id,'MarriageDate')]");
        private By spouseSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        //Childrens section
        private By addChildrensBtn = By.XPath("//div[@title='Add Child']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By childrenName = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By childrenBirthDate = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By childrenSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");

        //Others section
        private By addOthersBtn = By.XPath("//div[@title='Add Dependent']//i[@class='dx-icon dx-icon-edit-button-addrow']");
        private By dependentName = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By dependentBirthDate = By.XPath("/html[1]/body[1]/div[10]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]");
        private By OtherSave = By.XPath("//div[@class='dx-overlay-content dx-popup-normal dx-popup-draggable dx-resizable']//span[@class='dx-button-text'][normalize-space()='Save']");
        #endregion

        #region ResidencyInfo Tab Page Objects
        //basic details
        private By secondName = By.Name("SecondName");
        private By thirdName = By.Name("ThirdName");
        private By fourthName = By.Name("FourthName");
        private By lastName = By.Name("LastName");
        private By firstNameArabic = By.Name("FirstNameL2");
        private By secondNameArabic = By.Name("SecondNameL2");
        private By thirdNameArabic = By.Name("ThirdNameL2");
        private By fourthNameArabic = By.Name("FourthNameL2");
        private By lastNameArabic = By.Name("LastNameL2");
        private By birthPlace = By.Name("BirthPlace");

        //Work Permit Details
        private By OnCompanyResidencyYes = By.XPath("//div[@class='dx-switch-off']");
        private By OnCompanyResidencyNo = By.XPath("//div[@class='dx-switch-on']");
        private By dateOfEntry = By.XPath("//input[contains(@id,'DateOfEntry')]");
        private By VisaNumber = By.XPath("//input[contains(@id,'VisaNumber')]");
        private By WorkPermitNumber = By.XPath("//input[contains(@id,'WorkPermitNumber')]");
        private By ResidenceNumber = By.XPath("//input[contains(@id,'ResidenceNumber')]");
        private By ContractQualification = By.XPath("//input[contains(@id,'ContractQualification')]");
        private By NewResidencyPeriod = By.XPath("//input[contains(@id,'NewResidencyPeriod')]");
        private By NewGovtDesignation = By.XPath("//input[contains(@id,'NewGovtDesignationId')]");
        private By GovtLicense = By.XPath("//input[contains(@id,'GovtRecruitmentContractLicenseId')]");
        private By NewContractSalary = By.XPath("//input[contains(@id,'NewContractSalary')]");
        private By OldContractSalary = By.XPath("//input[contains(@id,'OldContractSalary')]");

        //Address Details
        private By Block = By.XPath("//input[contains(@id,'Block')]");
        private By BuildingNumber = By.XPath("//input[contains(@id,'BuildingNumber')]");
        private By FlatNumber = By.XPath("//input[contains(@id,'FlatNumber')]");
        private By FloorNumber = By.XPath("//input[contains(@id,'FloorNumber')]");
        private By Lane = By.XPath("//input[contains(@id,'Lane')]");
        private By TypeOfBuilding = By.XPath("//input[contains(@id,'TypeOfBuilding')]");
        private By Street = By.XPath("//input[contains(@id,'Street')]");
        private By Qasima = By.XPath("//input[contains(@id,'Qasima')]");
        private By Area = By.XPath("//input[contains(@id,'Area')]");
        private By PaciNumber = By.XPath("//input[contains(@id,'PaciNumber')]");

        //Previous Sponsor Details
        private By PreviousSponsorName = By.XPath("//input[contains(@id,'PreviousSponsorName')]");
        private By PreviousCompanyAuthorizedSign = By.XPath("//input[contains(@id,'PreviousCompanyAuthorizedSign')]");
        private By PreviousCompanyName = By.XPath("//input[contains(@id,'PreviousCompanyName')]");
        private By OldGovtDesignation = By.XPath("//input[contains(@id,'OldGovtDesignationId')]");
        private By OldFileNumber = By.XPath("//input[contains(@id,'OldFileNumber')]");
        private By OldGovernmentLicense = By.XPath("//input[contains(@id,'OldGovernmentLicense')]");
        #endregion

        #region Delete Employee Page Objects
        private By settingButton = By.XPath("//i[@class='dx-icon dx-icon-setup-icon']");
        private By delete = By.XPath("//div[contains(text(),'Delete')]");
        //private By ok = By.XPath("//span[normalize-space()='Ok']");
        //private By ok = By.XPath("/html[1]/body[1]/div[9]/div[1]/div[1]/div[3]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]");
        //private By ok = By.XPath("div[aria-label='Ok'] span[class='dx-button-text']");
        private By ok = By.XPath("//div[@aria-label='Ok']//div[@class='dx-button-content']");
        private By rightAreaMenu = By.XPath("//img[@class='account-image']");
        private By logOff = By.XPath("//span[normalize-space()='Log Off']");
        #endregion

        //Action Methods
        #region Create Action Methods
        public void ClickNewBtn()
        {
            CommonPageActions.ClickNew();
        }

        public void ProvideWorkEmail(string email)
        {
            Find(workEmail).SendKeys(email);
        }

        public void ProvideName()
        {
            Find(name).SendKeys(faker.Name.FirstName());
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
            CommonPageActions.ClickSave();
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
        public void ClickPerformance()
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
        public void ClickMetaballsMenu()
        {
            Find(metaballsMenu).Click();
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
            Thread.Sleep(1000);
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
            Thread.Sleep(1000);
        }

        public void SelectGovtLicense(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickAddSalaryComponentBtn()
        {
            Find(addSalaryComponentsBtn).Click();
            Thread.Sleep(2000);
        }

        public void ClickSalaryComponent()
        {
            Find(salaryComponent).Click();
            Thread.Sleep(5000);
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
            Find(amount).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ProvideEffectiveFromDate(string value)
        {
            Find(effectiveFromDate).Click();
            //Find(probationPeriod).Clear();
            Find(effectiveFromDate).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(effectiveFromDate).SendKeys(Keys.Delete);
            Find(effectiveFromDate).SendKeys(value);
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
            Thread.Sleep(1000);
        }
        public void SelectOvertimeType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void SaveOvertimeType()
        {
            Find(saveOvertimeType).Click();
            Thread.Sleep(3000);
        }
        public void AddTicketBtn()
        {
            Find(addTicketsBtn).Click();
            Thread.Sleep(1000);
        }
        public void clickRelationshipType()
        {
            Find(relationshipType).Click();
            Thread.Sleep(1000);
        }
        public void SelectRelationshipType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ProvideDesc(string value)
        {
            Find(description).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ClickTicketAccrual()
        {
            Find(ticketAccrual).Click();
            Thread.Sleep(1000);
        }
        public void SelectTicketAccrual(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ClickTicketDestination()
        {
            Find(ticketDestination).Click();
            Thread.Sleep(1000);
        }
        public void SelectTicketDestination(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ProvideTicketEffectiveFromDate(string value)
        {
            Find(ticketEffectiveFromDate).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ClickSaveTicket()
        {
            Find(saveTicket).Click();
            Thread.Sleep(1000);
        }
        public void ClickAddMiscellaneousAccrualEarnings()
        {
            Find(addMiscellaneousAccrual).Click();
            Thread.Sleep(1000);
        }
        public void ClickAccrualType()
        {
            Find(accrualType).Click();
            Thread.Sleep(1000);
        }
        public void SelectAccrualType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ClickResetAvailedDaysMethod()
        {
            Find(resetAvailedDaysMethod).Click();
            Thread.Sleep(1000);
        }
        public void SelectResetAvailedDaysMethod(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void SaveMiscellaneousAccrual()
        {
            Find(miscellaneousAccrualSave).Click();
            Thread.Sleep(1000);
        }
        public void ClickBenefitSchemes()
        {
            Thread.Sleep(1000);
            Find(addBenefitScheme).Click();
            Thread.Sleep(1000);
        }
        public void ClickRelationshipType()
        {
            Find(relationshipType).Click();
            Thread.Sleep(1000);
        }
        public void BSSelectRelationshipType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ClickBenefitScheme()
        {
            Find(benefitScheme).Click();
            Thread.Sleep(1000);
        }
        public void SelectBenefitScheme(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }
        public void ProvideBSEffectiveFromDate(string value)
        {
            Find(BSeffectiveFromDate).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ProvideBSEffectiveToDate(string value)
        {
            Find(BSeffectiveToDate).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void BSSave()
        {
            Find(BSsave).Click();
        }

        #endregion

        #region TimeOff Tab Action Methods
        
        public void ClickAssignLeaveType()
        {
            Find(assignLeaveType).Click();
        }

        public void ClickLeaveType()
        {
            Find(leaveType).Click();
            Thread.Sleep(1000);
        }

        public void SelectLeaveType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void LTProvideEffectiveFromDate(string value)
        {
            Find(LTeffectiveFromDate).Click();
            //Find(probationPeriod).Clear();
            Find(LTeffectiveFromDate).SendKeys(Keys.Control + "a");
            //Find(probationPeriod).SendKeys(Keys.Backspace);
            Find(LTeffectiveFromDate).SendKeys(Keys.Delete);
            Find(LTeffectiveFromDate).SendKeys(value);
            Thread.Sleep(1000);
        }
        
        public void LTClickSave()
        {
            CommonPageActions.ClickSave();
        }



        #endregion

        #region Attendance Tab Action Methods
        public void ClickAttendanceCalendar()
        {
            Find(calendar).Click();
            Thread.Sleep(1000);
        }

        public void SelectAttendanceCalendar(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void EnablePresentByDefault()
        {
            Find(presentByDefault).Click();
            Thread.Sleep(1000);
        }

        public void ClickCheckInType()
        {
            Find(checkInType).Click();
            Thread.Sleep(1000);
        }

        public void SelectCheckInType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickDefaultShift()
        {
            Find(defaultShift).Click();
            Thread.Sleep(1000);
        }

        public void SelectDefaultShift(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickPolicy()
        {
            Find(policy).Click();
            Thread.Sleep(1000);
        }

        public void SelectPolicy(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ClickShiftPreference()
        {
            Find(shiftPreference).Click();
            Thread.Sleep(1000);
        }

        public void SelectShiftPreference(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }


        #endregion

        #region Documents Tab Action Methods
        public void ShowActiveDocs()
        {
            Find(showActive).Click();
        }

        public void ShowAllDocs()
        {
            Find(showAll).Click();
        }

        public void AddDocuments()
        {
            Find(addDocuments).Click();
        }

        public void ClickDocType()
        {
            Find(documentType).Click();
        }

        public void SelectDocType(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ProvideDocNumber()
        {
            Find(documentNumber).SendKeys(RandomNumber());
        }

        public void ProvideDateOfExpiry(string value)
        {
            Find(dateOfExpiry).SendKeys(value);
        }

        public void ClickPlaceOfDocument()
        {
            Find(placeOfDocument).Click();
        }

        public void SelectPlaceOfDocument(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }

        public void EmpDocClickSave()
        {
            CommonPageActions.ClickSave();
        }




        #endregion

        #region Performance Tab Action Methods
        public void AddKRABtn()
        {
            Find(addKRABtn).Click();
        }
        public void ClickKeyResultAreaName()
        {
            Find(KeyResultAreaName).Click();
            Thread.Sleep(1000);
        }
        public void SelectResultAreaName(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            
        }
        public void ProvideWeightage(string value)
        {
            Find(weightage).SendKeys(value);
        }
        public void ClickKRAsave()
        {
            Find(KRAsave).Click();
        }
        public void ClickAddCompetencies()
        {
            Find(addCompetencies).Click();
        }
        public void ClickCompetencyName()
        {
            Find(competencyName).Click();
            Thread.Sleep(1000);
        }
        public void SelectCompetencyName(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideCompetenciesWeightage(string value)
        {
            Find(competenciesWeightage).SendKeys(value);
        }
        public void ClickCompetenciesSave()
        {
            Find(competenciesSave).Click();
        }
        public void ClickaddSkillSetBtn()
        {
            Find(addSkillSetBtn).Click();
            Thread.Sleep(1000);
        }
        public void ClickSkillSetName()
        {
            Find(skillSetName).Click();
            Thread.Sleep(1000);
        }
        public void SelectSkillSetName(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickLevel()
        {
            Find(level).Click();
            Thread.Sleep(1000);
        }
        public void SelectLevel(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideSkillSetWeightage(string value)
        {
            Find(skillSetWeightage).SendKeys(value);
        }
        public void ClickskillSetsave()
        {
            Find(skillSetsave).Click();
            Thread.Sleep(2000);
        }
        public void ClickaddGoalsBtn()
        {
            Find(addGoalsBtn).Click();
        }
        public void ProvideGoalName(string value)
        {
            Find(goalName).SendKeys(value);
        }
        public void ProvideGoalsStartDate(string value)
        {
            Find(startDate).SendKeys(value);
        }
        public void ProvideGoalsDueDate(string value)
        {
            Find(dueDate).SendKeys(value);
        }
        public void ClickPriority()
        {
            Find(priority).Click();
            Thread.Sleep(1000);
        }
        public void SelectPriority(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideGoalsWeightage(string value)
        {
            Find(goalsWeightage).SendKeys(value);
        }
        public void ClickGoalSave()
        {
            Find(goalSave).Click();
        }

        #endregion

        #region Integration Tab Action Methods        
        public void ClickFinancialIntegrationGroup()
        {
            Find(financialIntegrationGroup).Click();
        }
        public void SelectFinancialIntegrationGroup(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideDivision(string value)
        {
            Find(division).SendKeys(value);
        }
        public void ProvideDepartment(string value)
        {
            Find(department).SendKeys(value);
        }
        public void ProvideProject(string value)
        {
            Find(project).SendKeys(value);
        }
        public void ProvideSegmentWorkLocation(string value)
        {
            Find(segmentWorkLocation).SendKeys(value);
            Thread.Sleep(1000);
        }
        public void ClickDefaultCostAllocationBtn()
        {
            Find(defaultCostAllocationBtn).Click();
            Thread.Sleep(1000);
        }
        public void ClickFromPeriod()
        {
            Find(FromPeriod).Click();
            Thread.Sleep(1000);
        }
        public void SelectFromPeriod(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickToPeriod()
        {
            Find(ToPeriod).Click();
            Thread.Sleep(1000);
        }
        public void SelectToPeriod(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickAddRowBtn()
        {
            Find(addRowBtn).Click();
        }
        public void Providesdivision(string value)
        {
            Find(sdivision).SendKeys(value);
        }
        public void Providesdepartment(string value)
        {
            Find(sdepartment).SendKeys(value);
        }
        public void Providesproject(string value)
        {
            Find(sproject).SendKeys(value);
        }
        public void ProvidesWorkLocation(string value)
        {
            Find(sWorkLocation).SendKeys(value);
        }
        public void ClickCostAllocationsave()
        {
            Find(costAllocationsave).Click();
        }
        public void ClickAddProjectsBtn()
        {
            Find(AddProjectsBtn).Click();
            Thread.Sleep(1000);
        }
        public void ClickProject()
        {
            Find(Project).Click();
            Thread.Sleep(1000);
        }
        public void SelectProject(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideProjectEffectiveFromDate(string value)
        {
            Find(EffectiveFromDate).SendKeys(value);
        }
        public void ProvideProjectEffectiveToDate(string value)
        {
            Find(EffectiveToDate).SendKeys(value);
        }
        public void ClickEmpProjectsave()
        {
            Find(empProjectsave).Click();
        }
        public void SaveAllInfo()
        {
            CommonPageActions.ClickSave();
        }

        #endregion

        #region Dependents Tab Action Methods
        //spouse section
        public void ClickAddSpousesBtn()
        {
            Find(addSpousesBtn).Click();
        }
        public void ProvideSpouseName(string value)
        {
            Find(spouseName).SendKeys(value);
        }
        public void ProvideSpouseBirthDate(string value)
        {
            Find(birthDate).SendKeys(value);
        }
        public void ProvideSpouseMarriageDate(string value)
        {
            Find(marriageDate).SendKeys(value);
        }
        //Childrens section
        public void ClickAddChildrensBtn()
        {
            Find(addChildrensBtn).Click();
        }
        public void ProvideChildrenName(string value)
        {
            Find(childrenName).SendKeys(value);
        }
        public void ProvidechildrenBirthDate(string value)
        {
            Find(childrenBirthDate).SendKeys(value);
        }
        public void ClickChildrenSave()
        {
            Find(childrenSave).Click();
        }

        //Others section
        public void ClickAddOthersBtn()
        {
            Find(addOthersBtn).Click();
        }
        public void ProvideDependentName(string value)
        {
            Find(dependentName).SendKeys(value);
        }
        public void ProvideDependentBirthDate(string value)
        {
            Find(dependentBirthDate).SendKeys(value);       
        }
        public void ClickOtherSave()
        {
            Find(OtherSave).Click();
        }

        #endregion

        #region ResidencyInfo Tab Action Methods
        //basic details
        public void ProvideSecondName(string value)
        {
            Find(secondName).SendKeys(value);
        }
        public void ProvidethirdName(string value)
        {
            Find(thirdName).SendKeys(value);
        }
        public void ProvidefourthName(string value)
        {
            Find(fourthName).SendKeys(value);
        }
        public void ProvidelastName(string value)
        {
            Find(lastName).SendKeys(value);
        }
        public void ProvidebirthPlace(string value)
        {
            Find(birthPlace).SendKeys(value);
        }
    
        //Work Permit Details
        public void ProvidedateOfEntry(string value)
        {
            Find(dateOfEntry).SendKeys(value);
        }
       
        public void ProvideVisaNumber(string value)
        {
            Find(VisaNumber).SendKeys(value);
        }
        public void ProvideWorkPermitNumber(string value)
        {
            Find(WorkPermitNumber).SendKeys(value);
        }
        public void ProvideResidenceNumber(string value)
        {
            Find(ResidenceNumber).SendKeys(value);
            Thread.Sleep(2000);

        }
        public void ClickContractQualification()
        {
            Find(ContractQualification).Click();
        }
        public void SelectContractQualification(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickNewResidencyPeriod()
        {
            Find(NewResidencyPeriod).Click();
            Thread.Sleep(1000);

        }
        public void SelectNewResidencyPeriod(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickNewGovtDesignation()
        {
            Find(NewGovtDesignation).Click();
            Thread.Sleep(1000);
        }
        public void SelectNewGovtDesignation(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickGovermenttLicense()
        {
            Find(GovtLicense).Click();
            Thread.Sleep(1000);
        }
        public void SelectGovermenttLicense(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideNewContractSalary(string value)
        {
            Find(NewContractSalary).SendKeys(value);
        }
        public void ProvideOldContractSalary(string value)
        {
            Find(OldContractSalary).SendKeys(value);
        }
        
        //Address Details
        public void ProvideBlock(string value)
        {
            Find(Block).SendKeys(value);
        }
        public void ProvideBuildingNumber(string value)
        {
            Find(BuildingNumber).SendKeys(value);
        }
        public void ProvideFlatNumber(string value)
        {
            Find(FlatNumber).SendKeys(value);
        }
        public void ProvideFloorNumber(string value)
        {
            Find(FloorNumber).SendKeys(value);
        }
        public void ProvideLane(string value)
        {
            Find(Lane).SendKeys(value);
        }
        public void ClickTypeOfBuilding()
        {
            Find(TypeOfBuilding).Click();
            Thread.Sleep(1000);
        }
        public void SelectTypeOfBuilding(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideStreet(string value)
        {
            Find(Street).SendKeys(value);
        }
        public void ProvideQasima(string value)
        {
            Find(Qasima).SendKeys(value);
        }
        
        public void ProvideArea(string value)
        {
            Find(Area).SendKeys(value);
        }
        public void ProvidePaciNumber(string value)
        {
            Find(PaciNumber).SendKeys(value);
        }

        //Previous Sponsor Details
        public void ProvidePreviousSponsorName(string value)
        {
            Find(PreviousSponsorName).SendKeys(value);
        }
        public void ProvidePreviousCompanyAuthorizedSign(string value)
        {
            Find(PreviousCompanyAuthorizedSign).SendKeys(value);
        }
        public void ProvidePreviousCompanyName(string value)
        {
            Find(PreviousCompanyName).SendKeys(value);
        }
        public void ClickOldGovtDesignation(string value)
        {
            Find(OldGovtDesignation).Click();
            Thread.Sleep(2000);
        }
        public void SelectOldGovtDesignation(string value)
        {
            CommonPageActions.SelectDropdownOption(value);
            Thread.Sleep(1000);
        }

        public void ProvideOldFileNumber(string value)
        {
            Find(OldFileNumber).SendKeys(value);
        }
        public void ProvideOldGovernmentLicense(string value)
        {
            Find(OldGovernmentLicense).SendKeys(value);
        }
        
        public void SaveResidencyInfo()
        {
            CommonPageActions.ClickSave();
        }
        #endregion

        #region Delete Employee Action Methods
        public void ClickSettingButton()
        {
            Find(settingButton).Click();
        }
        public void ClickDelete()
        {
            Find(delete).Click();
            Thread.Sleep(2000);
        }
        public void ClickOk()
        {
            Find(ok).Click();
            Thread.Sleep(3000);
        }
        public void ClickRightAreaMenu()
        {
            Find(rightAreaMenu).Click();
            Thread.Sleep(1000);
        }

        public void ClicklogOff()
        {
            Find(logOff).Click();            
        }

        #endregion
    }
}
