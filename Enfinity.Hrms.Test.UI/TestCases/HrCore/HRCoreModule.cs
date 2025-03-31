using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Employee;
using Enfinity.Hrms.Test.UI.Models.HRCore;
using Enfinity.Hrms.Test.UI.Models.HRCore.Bank;
using Enfinity.Hrms.Test.UI.Models.HRCore.Calendar;
using Enfinity.Hrms.Test.UI.Models.HRCore.Designation;
using Enfinity.Hrms.Test.UI.Models.HRCore.DocumentType;
using Enfinity.Hrms.Test.UI.Models.HRCore.Employee;
using Enfinity.Hrms.Test.UI.Models.HRCore.Grade;
using Enfinity.Hrms.Test.UI.Models.HRCore.Qualification;
using Enfinity.Hrms.Test.UI.Models.HRCore.Religion;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using Enfinity.Hrms.Test.UI.PageObjects.Login;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]


    public class HRCoreModule : BaseTest
    {
        public string Product = "Hrms";

        #region Employee Test

        #region Create Employee With System Access 
        //Scenario- EmployeeWithValidAccess, delete created employee and freeze the user

        [Test]
        [Ignore("")]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.EmployeeWithSystemAccess))]
        public void CreateEmployeeWithValidAccess(string email, string name, string mbl, string doj, string dept, string desg, string payrollset, string calendar, string indemnity, string grade, string gender, string religion, string martitalStatus, string username, string roles)
        {
            try
            {
                //Login(Product);

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();                     
                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage ep = new EmployeePage(_driver);
                ep.ClickNewBtn();
                ep.ProvideWorkEmail(email);
                ep.ProvideName(name);
                //ep.ClickMgrDropdown();
                //ep.SelectMgr();
                ep.ProvideMobileNumber(mbl);
                ep.ProvideDOJ(doj);
                ep.SelectDepartment(dept);               
                ep.SelectDesignation(desg);
                ep.SelectPayrollSet(payrollset);                
                ep.SelectCalendar(calendar);               
                ep.SelectIndemnity(indemnity);               
                ep.SelectGrade(grade);               
                ep.SelectGender(gender);              
                ep.SelectReligion(religion);             
                ep.SelectMaritalStatus(martitalStatus);
                ep.ClickSystemAccessBtn();
                //ep.ProvideUserName(username);
                //ep.ClickRoles();
                ep.SelectRole(roles);
                ep.ClickOnSave();
                ep.ClickSettingButton();
                ep.ClickResetPwd();

                //reset pwd page
                ResetPasswordPage rp = new ResetPasswordPage(_driver);
                rp.ResetPwd("123");

                ep.ClickRightAreaMenu();
                ep.ClicklogOff();

                //Login page
                LoginPage lp = new LoginPage(_driver);
                lp.Login(email, "123");
                ClassicAssert.IsTrue(ep.MyInfoValidation(name));

                #region want to delete created employee

                HRCorePage hr = new HRCorePage(_driver);
                hr.ClickHRCore();
                hr.ClickSetupForm();

                SetupPage stp = new SetupPage(_driver);
                stp.ClickEmployee();

                BasePage.NavigateToEmployee(name);

                ep.ClickSettingButton();
                ep.ClickDelete();
                ep.ClickOk();
                ClassicAssert.IsFalse(ep.ValidateEmpDelete(name));

                #endregion

                #region want to freeze the user

                ep.ClickRightAreaMenu();
                ep.ClicklogOff();
                lp.Login("vaibhav@test.com", "123");
                UserPage up = new UserPage(_driver);
                up.FreezeUser(username);
                //ClassicAssert.IsTrue(ep.IsEmployeeCreated(name));

                #endregion



            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
        #endregion

        #region Create NonPayroll Employee
        [Test]
        [Ignore("")]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.NonPayrollEmployee))]
        public void CreateNonPayrollEmployee(string email, string name, string mbl, string doj, string grade, string gender, string religion, string martitalStatus)
        {
            try
            {
                //Login(Product);

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage ep = new EmployeePage(_driver);
                ep.ClickNewBtn();
                ep.ProvideWorkEmail(email);
                ep.ProvideName(name);
             
               
                ep.ProvideMobileNumber(mbl);
                ep.ProvideDOJ(doj);
                ep.ClickNonPayrollBtn();
             
                ep.SelectGrade(grade);
            
                ep.SelectGender(gender);
               
                ep.SelectReligion(religion);
              
                ep.SelectMaritalStatus(martitalStatus);
                ep.ClickOnSave();

                ClassicAssert.IsTrue(ep.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }

        #endregion

        #region Create Payroll Employee
        [Test]
        [Ignore("")]

        public void CreatePayrollEmployee()
        {
            try
            {
                ////Login(Product);

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var employeeInfo = JsonUtils.ConvertJsonListDataModel<NewEmployeeModel>(employeeFile, "newEmployee");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var employee in employeeInfo)
                {
                    ep.ClickNewBtn();
                    ep.ProvideWorkEmail(employee.email);
                    ep.ProvideName(employee.name);
                
                  
                    ep.ProvideMobileNumber(employee.mobile);
                    ep.ProvideDOJ(employee.DOJ);
               
                    ep.SelectDepartment(employee.department);
                
                    ep.SelectDesignation(employee.designation);
                    //ep.ClearPayrollSet();
                 
                    ep.SelectPayrollSet(employee.payrollSet);
                  
                    ep.SelectCalendar(employee.calendar);
                 
                    ep.SelectIndemnity(employee.indemnity);
                   
                    ep.SelectGrade(employee.grade);
                  
                    ep.SelectGender(employee.gender);
              
                    ep.SelectReligion(employee.religion);
              
                    ep.SelectMaritalStatus(employee.maritalStatus);
                    ep.ClickOnSave();
                }


                //ClassicAssert.IsTrue(ep.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
        #endregion

        #region Delete Multiple Employees
        [Test]
        [Ignore("")]
        public void DeleteMultipleEmployees()
        {
            try
            {
                for (int i = 1; i <= 1; i++)
                {
                    //Login(Product);

                    var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                    var deleteEmployee = JsonHelper.ConvertJsonListDataModel<DeleteEmpModel>(employeeFile, "deleteEmployee");

                    HRCorePage hc = new HRCorePage(_driver);
                    hc.ClickHRCore();
                    hc.ClickSetupForm();

                    SetupPage sp = new SetupPage(_driver);
                    sp.ClickEmployee();
                    Thread.Sleep(2000);

                    foreach (var delete in deleteEmployee)
                    {
                        BasePage.NavigateToEmployee(delete.empName);
                        BasePage.SwitchTab();

                        EmployeePage ep = new EmployeePage(_driver);
                        ep.ClickSettingButton();
                        ep.ClickDelete();
                        ep.ClickOk();
                        //ClassicAssert.IsTrue(BasePage.IsEmployeeDeleted(), "Employee not deleted");
                        ep.ClickRightAreaMenu();
                        ep.ClicklogOff();
                        //BasePage.CloseTab();

                    }

                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #endregion

        #region create department
        [Test, Order(1), Category("hrcore_create")]
        //[Ignore("")]
        public void CreateDepartment()
        {
            try
            {
                //Login(Product);

                var departmentFile = FileHelper.GetDataFile("Hrms", "HRCore", "Department", "DepartmentData");
                var departmentData = JsonHelper.ConvertJsonListDataModel<CreateDepartmentModel>(departmentFile, "createDepartment");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                Thread.Sleep(5000);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDepartment();
                Thread.Sleep(2000);

                //dept pg
                DepartmentPage dp = new DepartmentPage(_driver);

                foreach (var department in departmentData)
                {
                    dp.ClickOnNew();
                    dp.ProvideDepartmentName(department.deptname);
                    //dp.ProvideDepartmentName();
                    //dp.SelfServiceDD();
                    //dp.ClickDeptMgrDD();
                    //dp.SelectDeptMgrName();
                    //dp.SelectDeptMgr();               
                    dp.ClickSaveBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(department.deptname, 3, 2));

                }


                //ClassicAssert.IsTrue(BasePage.IsTxnCreated());

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }

        #endregion

        #region create designation 
        [Test, Order(2), Category("hrcore_create")]
        public void CreateDesignation()
        {
            try
            {
                //Login(Product);

                var designationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Designation", "DesignationData");
                var designationData = JsonHelper.ConvertJsonListDataModel<CreateDesignationModel>(designationFile, "createDesignation");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDesignation();
                Thread.Sleep(2000);

                //desg pg
                DesignationPage dp = new DesignationPage(_driver);

                foreach (var desg in designationData)
                {
                    dp.ClickNewButton();
                    //dp.SetDesignationCode();
                    //dp.SetDesignation(faker.Name.JobTitle());
                    dp.SetDesignation(desg.designationName);
                    dp.ClickGrade();
                    dp.SelectGrade();
                    dp.SetJobDescription();
                    dp.ClickSaveBack();

                    BasePage.ValidateListing(desg.designationName, 3, 2);
                    //ClassicAssert.IsTrue(BasePage.IsTxnCreated());
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region create grade  
        [Test, Order(3), Category("hrcore_create")]
        public void CreateGrade()
        {
            try
            {
                //Login(Product);

                var gradeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Grade", "GradeData");
                var gradeData = JsonHelper.ConvertJsonListDataModel<CreateGradeModel>(gradeFile, "createGrade");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                Thread.Sleep(5000);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickGrade();
                Thread.Sleep(2000);

                //grade pg
                GradePage gp = new GradePage(_driver);

                foreach (var grade in gradeData)
                {
                    gp.ClickOnNew();
                    gp.ProvideGradeName(grade.gradeName);
                    gp.ProvideMinSal(grade.minSal);
                    gp.ProvideMaxSal(grade.maxSal);
                    gp.ClickSaveBack();

                    BasePage.ValidateListing(grade.gradeName, 2, 1);
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region create calendar
        [Test, Order(4)]
        public void CreateCalendar()
        {
            try
            {
                //Login(Product);

                var calendarFile = FileHelper.GetDataFile("Hrms", "HRCore", "Calendar", "CalendarData");
                var calendarData = JsonHelper.ConvertJsonListDataModel<CreateCalendarModel>(calendarFile, "createCalendar");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickCalendar();
                Thread.Sleep(2000);

                //calendar page                
                CalendarPage cp = new CalendarPage(_driver);
                foreach (var calendar in calendarData)
                {
                    cp.ClickNewButton();
                    //cp.ProvideCalendarName();
                    cp.ProvideCalendarName(calendar.calendarName);
                    cp.ProvideFromDate(calendar.fromDate);
                    cp.SetWeekoff();
                    cp.SetRestday();
                    cp.ClickSaveBack();

                    BasePage.ValidateListing(calendar.calendarName, 2, 1);
                }


                //ClassicAssert.IsTrue(BasePage.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion 

        #region create religion 
        [Test, Order(5)]
        public void CreateReligion()
        {
            try
            {
                //Login(Product);

                var ReligionFile = FileHelper.GetDataFile("Hrms", "HRCore", "Religion", "ReligionData");
                var ReligionData = JsonHelper.ConvertJsonListDataModel<CreateReligionModel>(ReligionFile, "createReligion");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickReligion();
                Thread.Sleep(2000);

                //religion page                
                ReligionPage rp = new ReligionPage(_driver);
                foreach (var religion in ReligionData)
                {
                    rp.ClickOnNew();
                    rp.ProvideReligionName(religion.religionName);
                    rp.ClickSaveBack();

                    BasePage.ValidateListing(religion.religionName, 2, 1);
                }
                //ClassicAssert.IsTrue(BasePage.IsTxnCreated());

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        # endregion

        #region create work location
        [Test, Order(6)]
        public void CreateWorkLocation()
        {
            try
            {
                //Login(Product);

                var workLocationFile = FileHelper.GetDataFile("Hrms", "HRCore", "WorkLocation", "WorkLocationData");
                var workLocationData = JsonHelper.ConvertJsonListDataModel<CreateWorkLocationModel>(workLocationFile, "createWorkLocation");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickWorkLocation();
                Thread.Sleep(2000);

                //worklocation page                
                WorkLocationPage wl = new WorkLocationPage(_driver);
                foreach (var workLocation in workLocationData)
                {
                    wl.ClickOnNew();
                    wl.ProvideWorkLocName(workLocation.workLocationName);
                    wl.ClickSaveBack();

                    BasePage.ValidateListing(workLocation.workLocationName, 2, 1);
                }
                //ClassicAssert.IsTrue(wl.IsTxnCreated());


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion         

        #region create bank
        [Test, Order(7)]
        public void CreateBank()
        {
            try
            {
                ////Login(Product);

                var bankFile = FileHelper.GetDataFile("Hrms", "HRCore", "Bank", "BankData");
                var bankData = JsonHelper.ConvertJsonListDataModel<CreateBankModel>(bankFile, "createBank");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickBank();
                Thread.Sleep(2000);

                //bank page                
                BankPage bp = new BankPage(_driver);

                foreach (var bank in bankData)
                {
                    bp.ClickOnNew();
                    bp.provideBankName(bank.bankName);
                    bp.clickSaveBack();

                    BasePage.ValidateListing(bank.bankName, 2, 1);
                }
                //ClassicAssert.IsTrue(bp.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create qualification
        [Test, Order(8)]
        public void CreateQualification()
        {
            try
            {
                //Login(Product);

                var qualificationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Qualification", "QualificationData");
                var qualificationData = JsonHelper.ConvertJsonListDataModel<CreateQualificationModel>(qualificationFile, "createQualification");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickQualification();
                Thread.Sleep(2000);

                //qualification page                
                QualificationPage qp = new QualificationPage(_driver);

                foreach (var qualification in qualificationData)
                {
                    qp.ClickOnNew();
                    qp.ProvideQualificationName(qualification.qualificationName);
                    qp.ClickSaveBack();

                    BasePage.ValidateListing(qualification.qualificationName, 2, 1);
                }
                //ClassicAssert.IsTrue(qp.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create document type
        [Test, Order(9)]
        public void CreateDocumentType()
        {
            try
            {
                //Login(Product);

                var documentTypeFile = FileHelper.GetDataFile("Hrms", "HRCore", "DocumentType", "DocumentTypeData");
                var documentTypeData = JsonHelper.ConvertJsonListDataModel<CreateDocumentTypeModel>(documentTypeFile, "createDocumentType");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDocumentType();
                Thread.Sleep(2000);

                //DocumentType page                
                DocumentTypePage dt = new DocumentTypePage(_driver);

                foreach (var document in documentTypeData)
                {
                    dt.ClickOnNew();
                    dt.ProvideDocumentTypeName(document.documentTypeName);
                    dt.ClickSaveBack();

                    BasePage.ValidateListing(document.documentTypeName, 2, 1);
                }
                //ClassicAssert.IsTrue(dt.IsTxnCreated());
                //ClassicAssert.IsTrue(true);
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Department
        [Test, Order(10)]
        public void DeleteDepartment()
        {
            //Login(Product);

            var departmentFile = FileHelper.GetDataFile("Hrms", "HRCore", "Department", "DepartmentData");
            var departmentData = JsonHelper.ConvertJsonListDataModel<DeleteDepartmentModel>(departmentFile, "deleteDepartment");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var dept in departmentData)
            {
                sp.ClickDepartment();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(3, dept.deptname);

                ClassicAssert.IsFalse(BasePage.ValidateListing(dept.deptname, 3, 2));
            }

        }
        #endregion

        #region Delete Designation
        [Test, Order(11)]
        public void DeleteDesignation()
        {
            //Login(Product);

            var DesignationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Designation", "DesignationData");
            var DesignationData = JsonHelper.ConvertJsonListDataModel<DeleteDesignationModel>(DesignationFile, "deleteDesignation");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var desg in DesignationData)
            {
                sp.ClickDesignation();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(3, desg.designationName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(desg.designationName, 3, 2));
            }

        }
        #endregion

        #region Delete Grade
        [Test, Order(12)]
        public void DeleteGrade()
        {
            //Login(Product);

            var gradeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Grade", "GradeData");
            var gradeData = JsonHelper.ConvertJsonListDataModel<DeleteGradeModel>(gradeFile, "deleteGrade");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var grade in gradeData)
            {
                sp.ClickGrade();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, grade.gradeName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(grade.gradeName, 2, 1));
            }

        }
        #endregion

        #region Delete Calendar
        [Test, Order(13)]
        public void DeleteCalendar()
        {
            //Login(Product);

            var calendarFile = FileHelper.GetDataFile("Hrms", "HRCore", "Calendar", "CalendarData");
            var calendarData = JsonHelper.ConvertJsonListDataModel<DeleteCalendarModel>(calendarFile, "deleteCalendar");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var calendar in calendarData)
            {
                sp.ClickCalendar();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, calendar.calendarName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(calendar.calendarName, 2, 1));
            }

        }
        #endregion

        #region Delete Religion
        [Test, Order(14)]
        public void DeleteReligion()
        {
            //Login(Product);

            var ReligionFile = FileHelper.GetDataFile("Hrms", "HRCore", "Religion", "ReligionData");
            var ReligionData = JsonHelper.ConvertJsonListDataModel<DeleteReligionModel>(ReligionFile, "createReligion");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var religion in ReligionData)
            {
                sp.ClickReligion();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, religion.religionName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(religion.religionName, 2, 1));
            }

        }
        #endregion

        #region Delete Work Location
        [Test, Order(15)]
        public void DeleteWorkLocation()
        {

            //Login(Product);

            var workLocationFile = FileHelper.GetDataFile("Hrms", "HRCore", "WorkLocation", "WorkLocationData");
            var workLocationData = JsonHelper.ConvertJsonListDataModel<DeleteWorkLocationModel>(workLocationFile, "createWorkLocation");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var wl in workLocationData)
            {
                sp.ClickWorkLocation();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, wl.workLocationName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(wl.workLocationName, 2, 1));
            }

        }
        #endregion

        #region Delete Bank
        [Test, Order(16)]
        public void DeleteBank()
        {
            ////Login(Product);

            var bankFile = FileHelper.GetDataFile("Hrms", "HRCore", "Bank", "BankData");
            var bankData = JsonHelper.ConvertJsonListDataModel<DeleteBankModel>(bankFile, "deleteBank");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var bank in bankData)
            {
                sp.ClickBank();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, bank.bankName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(bank.bankName, 2, 1));
                //ClassicAssert.IsTrue(BasePage.IsTxnCreated());
            }

        }
        #endregion

        #region Delete Qualification
        [Test, Order(17)]
        public void DeleteQualification()
        {
            //Login(Product);

            var qualificationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Qualification", "QualificationData");
            var qualificationData = JsonHelper.ConvertJsonListDataModel<DeleteQualificationModel>(qualificationFile, "deleteQualification");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var qualification in qualificationData)
            {
                sp.ClickQualification();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, qualification.qualificationName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(qualification.qualificationName, 2, 1));
            }

        }
        #endregion

        #region Delete Document Type
        [Test, Order(18)]
        public void DeleteDocumentType()
        {
            //Login(Product);

            var documentTypeFile = FileHelper.GetDataFile("Hrms", "HRCore", "DocumentType", "DocumentTypeData");
            var documentTypeData = JsonHelper.ConvertJsonListDataModel<DeleteDocumentTypeModel>(documentTypeFile, "createDocumentType");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach (var doc in documentTypeData)
            {
                sp.ClickDocumentType();
                Thread.Sleep(2000);
                BasePage.DeleteHrCoreTxn(2, doc.documentTypeName);

                ClassicAssert.IsFalse(BasePage.ValidateListing(doc.documentTypeName, 2, 1));
            }

        }
        #endregion

        #region Create Employee
        [Test, Order(19)]
        //[Ignore("")]

        public void CreateEmployee()
        {
            try
            {
                //Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var employeeInfo = JsonHelper.ConvertJsonListDataModel<NewEmployeeModel>(employeeFile, "newEmployee");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var employee in employeeInfo)
                {
                    ep.ClickNewBtn();
                    ep.ProvideWorkEmail(employee.email);                   
                    ep.ProvideName(employee.name);
                    //ep.ClickMgrDropdown();
                    //ep.SelectMgr();
                    ep.ProvideMobileNumber(employee.mobile);
                    ep.ProvideDOJ(employee.DOJ);
               
                    ep.SelectDepartment(employee.department);
                
                    ep.SelectDesignation(employee.designation);
                    //ep.ClearPayrollSet();
                 
                    ep.SelectPayrollSet(employee.payrollSet);
                  
                    ep.SelectCalendar(employee.calendar);
               
                    ep.SelectIndemnity(employee.indemnity);
               
                    ep.SelectGrade(employee.grade);
                   
                    ep.SelectGender(employee.gender);
                  
                    ep.SelectReligion(employee.religion);
                 
                    ep.SelectMaritalStatus(employee.maritalStatus);
                    ep.ClickOnSave();

                    ClassicAssert.IsTrue(ep.Validate(employee.name));
                   

                }


                //ClassicAssert.IsTrue(ep.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("VRC- Test case failed: " + e);  
            }

        }
        #endregion

        #region Delete Employee
        [Test, Order(20)]
        //[Ignore("")]
        public void DeleteEmployee()
        {
            try
            {
                //instead of for loop you can use repeat attribute 
                for (int i = 1; i <= 1; i++)
                {
                    //Login(Product);

                    var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                    var deleteEmployee = JsonHelper.ConvertJsonListDataModel<DeleteEmpModel>(employeeFile, "deleteEmployee");

                    HRCorePage hc = new HRCorePage(_driver);
                    hc.ClickHRCore();
                    hc.ClickSetupForm();

                    SetupPage sp = new SetupPage(_driver);
                    sp.ClickEmployee();
                    Thread.Sleep(2000);

                    foreach (var delete in deleteEmployee)
                    {
                        BasePage.NavigateToEmployee(delete.empName);
                        BasePage.SwitchTab();

                        EmployeePage ep = new EmployeePage(_driver);
                        ep.ClickSettingButton();
                        ep.ClickDelete();
                        ep.ClickOk();
                        //ClassicAssert.IsTrue(BasePage.IsEmployeeDeleted(), "Employee not deleted");
                        //ep.ClickRightAreaMenu();
                        //ep.ClicklogOff();
                        //BasePage.CloseTab();

                        ClassicAssert.IsFalse(ep.ValidateEmpDelete(delete.empName));

                    }

                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion


    }
}
