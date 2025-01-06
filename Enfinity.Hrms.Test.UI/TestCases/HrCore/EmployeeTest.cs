using Bogus.DataSets;
using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Employee;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    //[Ignore("")]
    public class EmployeeTest:BaseTest
    {
        public string Product = "Hrms";

        #region Create New Payroll Employee
        [Test, Order(1)]
        [Ignore ("")]
        public void CreateNewPayrollEmployee()
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
                    pe.ProvideName();
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

        #region Create New Non Payroll Employee

        #endregion

        #region Create Employee With System Access
        #endregion

        #region Personal Tab
        [Test, Order(2)]
        //[Ignore("")]       
        public void VerifyPersonalTab()
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

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var personalInfo = JsonHelper.ConvertJsonListDataModel<PersonalTabModel>(employeeFile, "personal");

                //personal tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var personal in personalInfo)
                {
                    ep.ProvideNameL2(personal.nameL2);
                    ep.ProvideDisplayName(personal.displayName);
                    ep.ProvideDisplayNameL2(personal.displayNameL2);
                    ep.ProvideDOB(personal.DOB);
                    //ep.ClickNationality();
                    //ep.SelectNationality(personal.nationality);
                    ep.ClickBloodGroup();
                    ep.SelectBloodGroup(personal.bloodGroup);
                    ep.ClickPhotoVisibility();
                    ep.SelectPhotoVisibility(personal.photoVisibility);
                    ep.ClickMblNoVisibility();
                    ep.SelectMblNoVisibility(personal.mobileNumberVisibility);
                    ep.ClickEmailVisibility();
                    ep.SelectEmailVisibility(personal.emailVisibility);
                    CommonPageActions.ClickSave();
                }


                //ClassicAssert.IsTrue(true);



            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Job Tab
        [Test, Order(3)]
        //[Ignore("")]
            public void VerifyJobTab()
            {
                try
                {
                    Login(Product);

                    var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                    var jobInfo = JsonHelper.ConvertJsonListDataModel<JobTabModel>(employeeFile, "job");

                    //hr core page
                    HRCorePage hc = new HRCorePage(_driver);
                    hc.ClickHRCore();
                    hc.ClickSetupForm();

                    //setup page
                    SetupPage sp = new SetupPage(_driver);
                    sp.ClickEmployee();
                    Thread.Sleep(2000);

                    //navigate to desired employee
                    CommonPageActions.NavigateToEmployee("188");
                    CommonPageActions.SwitchTab();

                    //job tab
                    EmployeePage ep = new EmployeePage(_driver);
                    foreach (var job in jobInfo)
                    {
                        ep.ClickJob();
                        //ep.ClickManager(); //not working
                        //ep.SelectManager(job.manager); //not working
                        //ep.EnableKeyEmp();
                        //ep.ClickSubstituteEmployee();
                        //ep.SelectSubstituteEmployee(job.substituteEmployee); //not working
                        ep.ClickEmployeeCategory();
                        ep.SelectEmployeeCategory(job.category);
                        ep.ClickWorkLocation();
                        ep.SelectWorkLocation(job.workLocation); //not working
                        ep.ClickEmploymentType();
                        ep.SelectEmploymentType(job.employmentType);
                        ep.ProvideProbationPeriod(job.probationPeriod);
                        ep.ProvideNoticePeriod(job.noticePeriod);
                        ep.ClickAddWorkExpBtn();
                        ep.ProvidePriorCompany(job.priorCompany);
                        ep.ProvideStartDate(job.startDate);
                        ep.ClickSaveBtn();
                        //ep.AddQualificationBtn();
                        //ep.ClickQualification();
                        //ep.SelectQualification();
                        //ep.ProvideUniversity(job.university);
                        //ep.ProvideYOP(job.YearOfPassing);
                        //ep.SaveQualification();
                        CommonPageActions.ClickSave();
                    }


                    //ClassicAssert.IsTrue(true);



                }
                catch (Exception e)
                {
                    ClassicAssert.Fail("Test case failed: " + e);
                }
            }
        #endregion

        #region Payroll Tab
        [Test,Order(4)]
        [Ignore("")]
        public void VerifyPayrollTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var payrollInfo = JsonHelper.ConvertJsonListDataModel<PayrollTabModel>(employeeFile, "payroll");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //job tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var payroll in payrollInfo)
                {
                    ep.ClickPayroll();
                    ep.ClickPaymentMode();
                    ep.SelectPaymentMode(payroll.paymentMode);
                    ep.ClickEmpBank();
                    ep.SelectEmpBank(payroll.employeebank);
                    ep.ProvideBankAcNo();
                    ep.ProvideIBANNo();
                    ep.ClickBankAcType();
                    ep.SelectBankAcType(payroll.bankAccountType);
                    ep.ClickGovtLicense();
                    ep.SelectGovtLicense(payroll.govtRecruitmentContractLicense);
                    ep.ClickAddSalaryComponentBtn();
                    ep.ClickSalaryComponent();
                    ep.SelectSalComponent(payroll.salaryComponent);
                    ep.ProvideAmt(payroll.amount);
                    ep.ProvideEffectiveFromDate(payroll.effectiveFromDate);
                    ep.SaveSalComponent();
                    ep.ClickOvertimeTypesBtn();
                    ep.ClickOvertimeType();
                    ep.SelectOvertimeType(payroll.overtimeType);
                    ep.SaveOvertimeType();
                    ep.AddTicketBtn();
                    ep.clickRelationshipType();
                    ep.SelectRelationshipType(payroll.relationshipType);
                    ep.ProvideDesc(payroll.description);
                    ep.ClickTicketAccrual();
                    ep.SelectTicketAccrual(payroll.ticketAccrual);
                    ep.ClickTicketDestination();
                    ep.SelectTicketDestination(payroll.ticketDestination);
                    ep.ProvideTicketEffectiveFromDate(payroll.ticketEffectiveFromDate);
                    ep.ClickSaveTicket();
                    ep.ClickAddMiscellaneousAccrualEarnings();
                    ep.ClickAccrualType();
                    ep.SelectAccrualType(payroll.accrualType);
                    ep.ClickResetAvailedDaysMethod();
                    ep.SelectResetAvailedDaysMethod(payroll.resetAvailedDaysMethod);
                    ep.SaveMiscellaneousAccrual();
                    ep.ClickBenefitSchemes();
                    ep.ClickRelationshipType();
                    ep.BSSelectRelationshipType(payroll.BSrelationshipType);
                    ep.ClickBenefitScheme();
                    ep.SelectBenefitScheme(payroll.benefitScheme);
                    ep.ProvideBSEffectiveFromDate(payroll.BSeffectiveFromDate);
                    ep.ProvideBSEffectiveToDate(payroll.BSeffectiveToDate);
                    ep.BSSave();

                }


                //ClassicAssert.IsTrue(true);


            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Time Off Tab
        [Test, Order(5)]
        [Ignore("")]
        public void VerifyTimeOffTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var timeOffInfo = JsonHelper.ConvertJsonListDataModel<TimeOffTabModel>(employeeFile, "timeOff");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //timeOff tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var timeoff in timeOffInfo)
                {
                    ep.ClickTimeOff();
                    ep.ClickAssignLeaveType();
                    ep.ClickLeaveType();
                    ep.SelectLeaveType(timeoff.leaveType);
                    ep.LTProvideEffectiveFromDate(timeoff.LTeffectiveFromDate);
                    ep.LTClickSave();
                    CommonPageActions.ClickSave();
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Attendance Tab
        [Test, Order(6)]
        [Ignore("")]
        public void VerifyAttendanceTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var attendanceInfo = JsonHelper.ConvertJsonListDataModel<AttendanceTabModel>(employeeFile, "attendance");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //timeOff tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var attendance in attendanceInfo)
                {
                    ep.ClickAttendance();
                    ep.ClickAttendanceCalendar();
                    ep.SelectAttendanceCalendar(attendance.calendar);
                    ep.EnablePresentByDefault();
                    ep.ClickCheckInType();
                    ep.SelectCheckInType(attendance.checkInType);
                    ep.ClickDefaultShift();
                    ep.SelectDefaultShift(attendance.defaultShift);
                    ep.ClickPolicy();
                    ep.SelectPolicy(attendance.policy);
                    ep.ClickShiftPreference();
                    ep.SelectShiftPreference(attendance.shiftPreference);
                    CommonPageActions.ClickSave();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Documents Tab
        [Test, Order(7)]
        [Ignore("")]
        public void VerifyDocumentsTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var documentsInfo = JsonHelper.ConvertJsonListDataModel<DocumentsTabModel>(employeeFile, "documents");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //documents tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var documents in documentsInfo)
                {
                    ep.ClickDocuments();
                    ep.AddDocuments();
                    ep.ClickDocType();
                    ep.SelectDocType(documents.documentType);
                    ep.ProvideDocNumber();
                    ep.ProvideDateOfExpiry(documents.dateOfExpiry);
                    ep.ClickPlaceOfDocument();
                    ep.SelectPlaceOfDocument(documents.placeOfDocument);
                    ep.EmpDocClickSave();

                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
        #endregion

        #region Performance Tab
        [Test, Order(8)]
        [Ignore("")]
        public void VerifyPerformanceTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var performanceInfo = JsonHelper.ConvertJsonListDataModel<PerformanceTabModel>(employeeFile, "performance");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //performance tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var performance in performanceInfo)
                {
                    ep.ClickPerformance();
                    ep.AddKRABtn();
                    ep.ClickKeyResultAreaName();
                    ep.SelectResultAreaName(performance.KeyResultAreaName);
                    ep.ProvideWeightage(performance.weightage);
                    ep.ClickKRAsave();
                    ep.ClickAddCompetencies();
                    ep.ClickCompetencyName();
                    ep.SelectCompetencyName(performance.competencyName);
                    ep.ProvideCompetenciesWeightage(performance.competenciesWeightage);
                    ep.ClickCompetenciesSave();
                    ep.ClickaddSkillSetBtn();
                    ep.ClickSkillSetName();
                    ep.SelectSkillSetName(performance.skillSetName);
                    ep.ClickLevel();
                    ep.SelectLevel(performance.level);
                    ep.ProvideSkillSetWeightage(performance.skillSetWeightage);
                    ep.ClickskillSetsave();
                    ep.ClickaddGoalsBtn();
                    ep.ProvideGoalName(performance.goalName);
                    ep.ProvideGoalsStartDate(performance.startDate);
                    ep.ProvideGoalsDueDate(performance.dueDate);
                    ep.ClickPriority();
                    ep.SelectPriority(performance.priority);
                    ep.ProvideGoalsWeightage(performance.goalsWeightage);
                    ep.ClickGoalSave();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Integration Tab
        [Test, Order(9)]
        [Ignore("")]
        public void VerifyIntegrationTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var integrationInfo = JsonHelper.ConvertJsonListDataModel<IntegrationTabModel>(employeeFile, "integration");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //Integration tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var integration in integrationInfo)
                {
                    ep.ClickIntegration();
                    ep.ClickFinancialIntegrationGroup();
                    ep.SelectFinancialIntegrationGroup(integration.financialIntegrationGroup);
                    ep.ProvideDivision(integration.division);
                    ep.ProvideDepartment(integration.department);
                    ep.ProvideProject(integration.project);
                    ep.ProvideSegmentWorkLocation(integration.segmentWorkLocation);
                    //ep.ClickDefaultCostAllocationBtn();
                    //ep.ClickFromPeriod();
                    //ep.SelectFromPeriod(integration.FromPeriod);
                    //ep.ClickToPeriod();
                    //ep.SelectToPeriod(integration.ToPeriod);
                    //ep.ClickAddRowBtn();
                    //ep.Providesdivision(integration.sdivision);
                    //ep.Providesdepartment(integration.sdepartment);
                    //ep.Providesproject(integration.sproject);
                    //ep.ProvidesWorkLocation(integration.sWorkLocation);
                    //ep.ClickCostAllocationsave();
                    ep.ClickAddProjectsBtn();
                    ep.ClickProject();
                    ep.SelectProject(integration.Project);
                    ep.ProvideProjectEffectiveFromDate(integration.EffectiveFromDate);
                    //ep.ProvideProjectEffectiveToDate();
                    ep.ClickEmpProjectsave();
                    ep.SaveAllInfo();

                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Dependents Tab
        [Test, Order(10)]
        [Ignore("")]
        public void VerifyDependentsTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var dependentsInfo = JsonHelper.ConvertJsonListDataModel<DependentsTabModel>(employeeFile, "dependents");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //Dependents tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var dependents in dependentsInfo)
                {
                    ep.ClickDependents();
                    ep.ClickAddSpousesBtn();
                    ep.ProvideSpouseName(dependents.spouseName);
                    ep.ProvideSpouseBirthDate(dependents.birthDate);
                    ep.ProvideSpouseMarriageDate(dependents.marriageDate);
                    ep.ClickAddChildrensBtn();
                    ep.ProvideChildrenName(dependents.childrenName);
                    ep.ProvidechildrenBirthDate(dependents.childrenBirthDate);
                    ep.ClickChildrenSave();
                    ep.ClickAddOthersBtn();
                    ep.ProvideDependentName(dependents.dependentName);
                    ep.ProvideDependentBirthDate(dependents.dependentBirthDate);
                    ep.ClickOtherSave();
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region ResidencyInfo Tab
        [Test, Order(11)]
        [Ignore("")]
        public void VerifyResidencyInfoTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var residencyInfo = JsonHelper.ConvertJsonListDataModel<ResidencyInfoTabModel>(employeeFile, "residencyInfo");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //ResidencyInfo tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var residency in residencyInfo)
                {
                    ep.ClickMetaballsMenu();
                    ep.ClickResidencyInfo();
                    ep.ProvideSecondName(residency.secondName);
                    ep.ProvidethirdName(residency.thirdName);
                    ep.ProvidefourthName(residency.fourthName);
                    ep.ProvidelastName(residency.lastName);
                    ep.ProvidebirthPlace(residency.birthPlace);
                    ep.ProvidedateOfEntry(residency.dateOfEntry);
                    ep.ProvideVisaNumber(residency.VisaNumber);
                    ep.ProvideWorkPermitNumber(residency.WorkPermitNumber);
                    ep.ProvideResidenceNumber(residency.ResidenceNumber);
                    CommonPageActions.ScrollDownWebPage();
                    ep.ClickContractQualification();
                    ep.SelectContractQualification(residency.ContractQualification);
                    ep.ClickNewResidencyPeriod();
                    ep.SelectNewResidencyPeriod(residency.NewResidencyPeriod);
                    ep.ClickNewGovtDesignation();
                    ep.SelectNewGovtDesignation(residency.NewGovtDesignation);
                    ep.ClickGovermenttLicense();
                    ep.SelectGovermenttLicense(residency.GovtLicense);
                    ep.ProvideNewContractSalary(residency.NewContractSalary);
                    ep.ProvideOldContractSalary(residency.OldContractSalary);
                    ep.ProvideBlock(residency.Block);
                    ep.ProvideBuildingNumber(residency.BuildingNumber);
                    ep.ProvideFlatNumber(residency.FlatNumber);
                    ep.ProvideFloorNumber(residency.FloorNumber);
                    ep.ProvideLane(residency.Lane);
                    ep.ClickTypeOfBuilding();
                    ep.SelectTypeOfBuilding(residency.TypeOfBuilding);
                    ep.ProvideStreet(residency.Street);
                    ep.ProvideQasima(residency.Qasima);
                    ep.ProvideArea(residency.Area);
                    ep.ProvidePaciNumber(residency.PaciNumber);
                    ep.ProvidePreviousSponsorName(residency.PreviousSponsorName);
                    ep.ProvidePreviousCompanyAuthorizedSign(residency.PreviousCompanyAuthorizedSign);
                    ep.ProvidePreviousCompanyName(residency.PreviousCompanyName);
                    ep.ClickOldGovtDesignation(residency.OldGovtDesignation);
                    ep.SelectOldGovtDesignation(residency.OldFileNumber);
                    ep.ProvideOldGovernmentLicense(residency.OldGovernmentLicense);
                    ep.SaveResidencyInfo();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion 

        #region Delete Employee
        [Test]
        //[Ignore("")]
        public void DeleteEmployee()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var deleteEmployee = JsonHelper.ConvertJsonListDataModel<DeleteEmpModel>(employeeFile, "deleteEmployee");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                

                foreach (var delete in deleteEmployee)
                {
                    //navigate to desired employee
                    CommonPageActions.NavigateToEmployee(delete.EMPID);
                    CommonPageActions.SwitchTab();

                    //ResidencyInfo tab
                    EmployeePage ep = new EmployeePage(_driver);
                    ep.ClickSettingButton();
                    ep.ClickDelete();
                    ep.ClickOk();

                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region 
        #endregion

        #region 
        #endregion

        #region 
        #endregion
    }
}
