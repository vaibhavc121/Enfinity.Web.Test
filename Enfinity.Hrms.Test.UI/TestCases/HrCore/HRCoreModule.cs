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
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
  

    public class HRCoreModule:BaseTest
    {
        public string Product = "Hrms";

        #region Employee Test

        #region Create Employee With System Access 
        [Test]
        //[Ignore("")]
        [TestCaseSource(typeof(HRCoreDataProvider), nameof(HRCoreDataProvider.EmployeeWithSystemAccess))]
        public void ValidateEmployeeCreationWithValidAccess(string email, string name, string mbl, string doj, string dept, string desg, string payrollset, string calendar, string indemnity, string grade, string gender, string religion, string martitalStatus, string username, string roles)
        {
            try
            {
                Login(Product);

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage pe = new EmployeePage(_driver);
                pe.ClickNewBtn();
                pe.ProvideWorkEmail(email);
                pe.ProvideName(name);
                //pe.ClickMgrDropdown();
                //pe.SelectMgr();
                pe.ProvideMobileNumber(mbl);
                pe.ProvideDOJ(doj);
                pe.ClickDepartment();
                pe.SelectDepartment(dept);
                pe.ClickDesignation();
                pe.SelectDesignation(desg);
                //pe.ClearPayrollSet();
                pe.ClickPayrollSet();
                pe.SelectPayrollSet(payrollset);
                pe.ClickCalendar();
                pe.SelectCalendar(calendar);
                pe.ClickIndemnity();
                pe.SelectIndemnity(indemnity);
                pe.ClickGrade();
                pe.SelectGrade(grade);
                pe.ClickGender();
                pe.SelectGender(gender);
                pe.ClickReligion();
                pe.SelectReligion(religion);
                pe.ClickMaritalStatus();
                pe.SelectMaritalStatus(martitalStatus);
                pe.ClickSystemAccessBtn();
                pe.ProvideUserName(username);
                pe.ClickRoles();
                pe.SelectRole(roles);
                pe.ClickSave();

                ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

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
                Login(Product);

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage pe = new EmployeePage(_driver);
                pe.ClickNewBtn();
                pe.ProvideWorkEmail(email);
                pe.ProvideName(name);
                pe.ClickMgrDropdown();
                pe.SelectMgr();
                pe.ProvideMobileNumber(mbl);
                pe.ProvideDOJ(doj);
                pe.ClickNonPayrollBtn();
                pe.ClickGrade();
                pe.SelectGrade(grade);
                pe.ClickGender();
                pe.SelectGender(gender);
                pe.ClickReligion();
                pe.SelectReligion(religion);
                pe.ClickMaritalStatus();
                pe.SelectMaritalStatus(martitalStatus);
                pe.ClickSave();

                ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

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
                Login(Product);

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
                EmployeePage pe = new EmployeePage(_driver);

                foreach (var employee in employeeInfo)
                {
                    pe.ClickNewBtn();
                    pe.ProvideWorkEmail(employee.email);
                    pe.ProvideName(employee.name);
                    pe.ClickMgrDropdown();
                    pe.SelectMgr();
                    pe.ProvideMobileNumber(employee.mobile);
                    pe.ProvideDOJ(employee.DOJ);
                    pe.ClickDepartment();
                    pe.SelectDepartment(employee.department);
                    pe.ClickDesignation();
                    pe.SelectDesignation(employee.designation);
                    //pe.ClearPayrollSet();
                    pe.ClickPayrollSet();
                    pe.SelectPayrollSet(employee.payrollSet);
                    pe.ClickCalendar();
                    pe.SelectCalendar(employee.calendar);
                    pe.ClickIndemnity();
                    pe.SelectIndemnity(employee.indemnity);
                    pe.ClickGrade();
                    pe.SelectGrade(employee.grade);
                    pe.ClickGender();
                    pe.SelectGender(employee.gender);
                    pe.ClickReligion();
                    pe.SelectReligion(employee.religion);
                    pe.ClickMaritalStatus();
                    pe.SelectMaritalStatus(employee.maritalStatus);
                    pe.ClickSave();
                }


                //ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

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
                    Login(Product);

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
                        CommonPageActions.NavigateToEmployee(delete.empName);
                        CommonPageActions.SwitchTab();

                        EmployeePage ep = new EmployeePage(_driver);
                        ep.ClickSettingButton();
                        ep.ClickDelete();
                        ep.ClickOk();
                        //ClassicAssert.IsTrue(CommonPageActions.IsEmployeeDeleted(), "Employee not deleted");
                        ep.ClickRightAreaMenu();
                        ep.ClicklogOff();
                        //CommonPageActions.CloseTab();

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
                Login(Product);

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
                    dp.ClickNew();
                    dp.ProvideDepartmentName(department.deptname);
                    //dp.ProvideDepartmentName();
                    //dp.SelfServiceDD();
                    //dp.ClickDeptMgrDD();
                    //dp.SelectDeptMgrName();
                    //dp.SelectDeptMgr();               
                    dp.ClickSaveBack();

                    ClassicAssert.IsTrue(CommonPageActions.ValidateListing(department.deptname, 3, 2));
                   
                }


                //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());

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
                Login(Product);

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

                foreach(var desg in designationData)
                {
                    dp.ClickNewButton();
                    //dp.SetDesignationCode();
                    //dp.SetDesignation(faker.Name.JobTitle());
                    dp.SetDesignation(desg.designationName);
                    dp.ClickGrade();
                    dp.SelectGrade();
                    dp.SetJobDescription();
                    dp.ClickSaveBack();

                    CommonPageActions.ValidateListing(desg.designationName, 3,2);
                    //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
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
                Login(Product);

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
                    gp.ClickNew();
                    gp.ProvideGradeName(grade.gradeName);
                    gp.ProvideMinSal(grade.minSal);
                    gp.ProvideMaxSal(grade.maxSal);
                    gp.ClickSaveBack();

                    CommonPageActions.ValidateListing(grade.gradeName, 2, 1);
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
                Login(Product);

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

                    CommonPageActions.ValidateListing(calendar.calendarName, 2, 1);
                }


                //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
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
                Login(Product);

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
                    rp.ClickNew();
                    rp.ProvideReligionName(religion.religionName);                   
                    rp.ClickSaveBack();

                    CommonPageActions.ValidateListing(religion.religionName, 2, 1);
                }
                //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());

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
                Login(Product);

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
                    wl.ClickNew();
                    wl.ProvideWorkLocName(workLocation.workLocationName);                    
                    wl.ClickSaveBack();

                    CommonPageActions.ValidateListing(workLocation.workLocationName, 2, 1);
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
                Login(Product);

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
                    bp.ClickNew();
                    bp.provideBankName(bank.bankName);                     
                    bp.clickSaveBack();

                    CommonPageActions.ValidateListing(bank.bankName, 2, 1);
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
                Login(Product);

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
                    qp.ClickNew();
                    qp.ProvideQualificationName(qualification.qualificationName);                    
                    qp.ClickSaveBack();

                    CommonPageActions.ValidateListing(qualification.qualificationName, 2, 1);
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
                Login(Product);

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
                    dt.ClickNew();
                    dt.ProvideDocumentTypeName(document.documentTypeName);                    
                    dt.ClickSaveBack();

                    CommonPageActions.ValidateListing(document.documentTypeName, 2, 1);
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
            Login(Product);

            var departmentFile = FileHelper.GetDataFile("Hrms", "HRCore", "Department", "DepartmentData");
            var departmentData = JsonHelper.ConvertJsonListDataModel<DeleteDepartmentModel>(departmentFile, "deleteDepartment");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var dept in departmentData)
            {
                sp.ClickDepartment();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(3, dept.deptname);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(dept.deptname, 3, 2));
            }
            
        }
        #endregion

        #region Delete Designation
        [Test, Order(11)]
        public void DeleteDesignation()
        {
            Login(Product);

            var DesignationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Designation", "DesignationData");
            var DesignationData = JsonHelper.ConvertJsonListDataModel<DeleteDesignationModel>(DesignationFile, "deleteDesignation");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var desg in DesignationData)
            {
                sp.ClickDesignation();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(3, desg.designationName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(desg.designationName, 3, 2));
            }
            
        }
        #endregion

        #region Delete Grade
        [Test, Order(12)]
        public void DeleteGrade()
        {
            Login(Product);

            var gradeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Grade", "GradeData");
            var gradeData = JsonHelper.ConvertJsonListDataModel<DeleteGradeModel>(gradeFile, "deleteGrade");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            Thread.Sleep(5000);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var grade in gradeData)
            {
                sp.ClickGrade();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, grade.gradeName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(grade.gradeName, 2, 1));
            }
            
        }
        #endregion

        #region Delete Calendar
        [Test, Order(13)]
        public void DeleteCalendar()
        {
            Login(Product);

            var calendarFile = FileHelper.GetDataFile("Hrms", "HRCore", "Calendar", "CalendarData");
            var calendarData = JsonHelper.ConvertJsonListDataModel<DeleteCalendarModel>(calendarFile, "deleteCalendar");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var calendar in calendarData)
            {
                sp.ClickCalendar();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, calendar.calendarName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(calendar.calendarName, 2, 1));
            }
            
        }
        #endregion

        #region Delete Religion
        [Test, Order(14)]
        public void DeleteReligion()
        {
            Login(Product);

            var ReligionFile = FileHelper.GetDataFile("Hrms", "HRCore", "Religion", "ReligionData");
            var ReligionData = JsonHelper.ConvertJsonListDataModel<DeleteReligionModel>(ReligionFile, "createReligion");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var religion in ReligionData)
            {
                sp.ClickReligion();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, religion.religionName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(religion.religionName, 2, 1));
            }
            
        }
        #endregion

        #region Delete Work Location
        [Test, Order(15)]
        public void DeleteWorkLocation()
        {

            Login(Product);

            var workLocationFile = FileHelper.GetDataFile("Hrms", "HRCore", "WorkLocation", "WorkLocationData");
            var workLocationData = JsonHelper.ConvertJsonListDataModel<DeleteWorkLocationModel>(workLocationFile, "createWorkLocation");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var wl in workLocationData)
            {
                sp.ClickWorkLocation();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, wl.workLocationName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(wl.workLocationName, 2, 1));
            }
            
        }
        #endregion

        #region Delete Bank
        [Test, Order(16)]
        public void DeleteBank()
        {
            Login(Product);

            var bankFile = FileHelper.GetDataFile("Hrms", "HRCore", "Bank", "BankData");
            var bankData = JsonHelper.ConvertJsonListDataModel<DeleteBankModel>(bankFile, "createBank");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var bank in bankData)
            {
                sp.ClickBank();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, bank.bankName); 

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(bank.bankName, 2, 1));
                //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
            }
           
        }
        #endregion

        #region Delete Qualification
        [Test, Order(17)]
        public void DeleteQualification()
        {
            Login(Product);

            var qualificationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Qualification", "QualificationData");
            var qualificationData = JsonHelper.ConvertJsonListDataModel<DeleteQualificationModel>(qualificationFile, "deleteQualification");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var qualification in qualificationData)
            {
                sp.ClickQualification();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, qualification.qualificationName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(qualification.qualificationName, 2, 1));
            }
            
        }
        #endregion

        #region Delete Document Type
        [Test, Order(18)]
        public void DeleteDocumentType()
        {
            Login(Product);

            var documentTypeFile = FileHelper.GetDataFile("Hrms", "HRCore", "DocumentType", "DocumentTypeData");
            var documentTypeData = JsonHelper.ConvertJsonListDataModel<DeleteDocumentTypeModel>(documentTypeFile, "createDocumentType");

            //hr core page
            HRCorePage hc = new HRCorePage(_driver);
            hc.ClickHRCore();
            hc.ClickSetupForm();

            //setup page
            SetupPage sp = new SetupPage(_driver);
            foreach(var doc in documentTypeData)
            {
                sp.ClickDocumentType();
                Thread.Sleep(2000);
                CommonPageActions.DeleteHrCoreTxn(2, doc.documentTypeName);

                ClassicAssert.IsFalse(CommonPageActions.ValidateListing(doc.documentTypeName, 2, 1));
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
                Login(Product);

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
                EmployeePage pe = new EmployeePage(_driver);

                foreach (var employee in employeeInfo)
                {
                    pe.ClickNewBtn();
                    pe.ProvideWorkEmail(employee.email);
                    pe.ProvideName(employee.name);
                    //pe.ClickMgrDropdown();
                    //pe.SelectMgr();
                    pe.ProvideMobileNumber(employee.mobile);
                    pe.ProvideDOJ(employee.DOJ);
                    pe.ClickDepartment();
                    pe.SelectDepartment(employee.department);
                    pe.ClickDesignation();
                    pe.SelectDesignation(employee.designation);
                    //pe.ClearPayrollSet();
                    pe.ClickPayrollSet();
                    pe.SelectPayrollSet(employee.payrollSet);
                    pe.ClickCalendar();
                    pe.SelectCalendar(employee.calendar);
                    pe.ClickIndemnity();
                    pe.SelectIndemnity(employee.indemnity);
                    pe.ClickGrade();
                    pe.SelectGrade(employee.grade);
                    pe.ClickGender();
                    pe.SelectGender(employee.gender);
                    pe.ClickReligion();
                    pe.SelectReligion(employee.religion);
                    pe.ClickMaritalStatus();
                    pe.SelectMaritalStatus(employee.maritalStatus);
                    pe.ClickSave();

                    ClassicAssert.IsTrue(pe.Validation(employee.name));
                }


                //ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
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
                    Login(Product);

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
                        CommonPageActions.NavigateToEmployee(delete.empName);
                        CommonPageActions.SwitchTab();

                        EmployeePage ep = new EmployeePage(_driver);
                        ep.ClickSettingButton();
                        ep.ClickDelete();
                        ep.ClickOk();
                        //ClassicAssert.IsTrue(CommonPageActions.IsEmployeeDeleted(), "Employee not deleted");
                        //ep.ClickRightAreaMenu();
                        //ep.ClicklogOff();
                        //CommonPageActions.CloseTab();

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
