using Bogus.DataSets;
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Employee;
using Enfinity.Hrms.Test.UI.Utilities;
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
    public class UpdateFullEmployeeTest : BaseTest
    {
        #region Personal Tab
        [Test, Order(1)]
        //[Ignore("")]       
        public void UpdatePersonalTab()
        {
            try
            {
                

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                BasePage.NavigateToEmployee("213");
                BasePage.SwitchTab();

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var personalInfo = JsonUtils.ConvertJsonListDataModel<PersonalTabModel>(employeeFile, "personal");

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
                    //BasePage.ClickSave();
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
        [Test, Order(2)]
        //[Ignore("")]
        public void UpdateJobTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var jobInfo = JsonUtils.ConvertJsonListDataModel<JobTabModel>(employeeFile, "job");

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
                    //BasePage.ClickSave();
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Payroll Tab
        [Test, Order(3)]
        public void UpdatePayrollTab()
        {
            try
            {


                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var payrollInfo = JsonUtils.ConvertJsonListDataModel<PayrollTabModel>(employeeFile, "payroll");

                //payroll tab
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
                    foreach (var component in payroll.salaryComponents)
                    {
                        ep.ClickAddSalaryComponentBtn();
                        ep.ClickSalaryComponent();
                        ep.SelectSalComponent(component.salaryComponent);
                        ep.ProvideAmt(component.amount);
                        ep.ProvideEffectiveFromDate(component.effectiveFromDate);
                        ep.SaveSalComponent();
                    }

                    //commented bcos 3 overtime is already gets added for new employee
                    //foreach (var overtime in payroll.overtimeTypes)
                    //{
                    //    ep.ClickOvertimeTypesBtn();
                    //    ep.ClickOvertimeType();
                    //    ep.SelectOvertimeType(overtime.overtimeType);
                    //    ep.SaveOvertimeType();
                    //}

                    ep.ScrollDownWebPageTicket();
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
                    //ep.ClickBenefitSchemes();
                    //ep.ClickRelationshipType();
                    //ep.BSSelectRelationshipType(payroll.BSrelationshipType);
                    //ep.ClickBenefitScheme();
                    //ep.SelectBenefitScheme(payroll.benefitScheme);
                    //ep.ProvideBSEffectiveFromDate(payroll.BSeffectiveFromDate);
                    //ep.ProvideBSEffectiveToDate(payroll.BSeffectiveToDate);
                    //ep.BSSave();

                }


                //ClassicAssert.IsTrue(true);


            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region TimeOff Tab
        [Test, Order(4)]
        public void UpdateTimeOffTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var timeOffInfo = JsonUtils.ConvertJsonListDataModel<TimeOffTabModel>(employeeFile, "timeOff");

                //timeOff tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var timeoff in timeOffInfo)
                {
                    foreach (var leave in timeoff.leaveTypes)
                    {
                        ep.ClickTimeOff();
                        ep.ClickAssignLeaveType();
                        ep.ClickLeaveType();
                        ep.SelectLeaveType(leave.leaveType);
                        ep.LTProvideEffectiveFromDate(leave.LTeffectiveFromDate);
                        ep.LTClickSave();
                    }

                    //BasePage.ClickSave();
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region AttendanceTab
        [Test, Order(5)]
        public void UpdateAttendanceTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var attendanceInfo = JsonUtils.ConvertJsonListDataModel<AttendanceTabModel>(employeeFile, "attendance");

                //attendance tab
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
                    //BasePage.ClickSave();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Documents Tab
        [Test, Order(6)]
        public void UpdateDocumentsTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var documentsInfo = JsonUtils.ConvertJsonListDataModel<DocumentsTabModel>(employeeFile, "documents");


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
        [Test, Order(7)]
        public void UpdatePerformanceTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var performanceInfo = JsonUtils.ConvertJsonListDataModel<PerformanceTabModel>(employeeFile, "performance");


                //performance tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var performance in performanceInfo)
                {
                    ep.ClickPerformance();
                    foreach (var KRA in performance.KRA)
                    {
                        ep.AddKRABtn();
                        ep.ClickKeyResultAreaName();
                        ep.SelectResultAreaName(KRA.KeyResultAreaName);
                        ep.ProvideWeightage(KRA.weightage);
                        ep.ClickKRAsave();
                    }
                    foreach (var competencies in performance.Competencies)
                    {
                        ep.ClickAddCompetencies();
                        ep.ClickCompetencyName();
                        ep.SelectCompetencyName(competencies.competencyName);
                        ep.ProvideCompetenciesWeightage(competencies.competenciesWeightage);
                        ep.ClickCompetenciesSave();
                    }

                    foreach (var skillset in performance.SkillSets)
                    {
                        ep.ClickaddSkillSetBtn();
                        ep.ClickSkillSetName();
                        ep.SelectSkillSetName(skillset.skillSetName);
                        ep.ClickLevel();
                        ep.SelectLevel(skillset.level);
                        ep.ProvideSkillSetWeightage(skillset.skillSetWeightage);
                        ep.ClickskillSetsave();
                    }

                    foreach (var goal in performance.Goals)
                    {
                        ep.ClickaddGoalsBtn();
                        ep.ProvideGoalName(goal.goalName);
                        ep.ProvideGoalsStartDate(goal.startDate);
                        ep.ProvideGoalsDueDate(goal.dueDate);
                        ep.ClickPriority();
                        ep.SelectPriority(goal.priority);
                        ep.ProvideGoalsWeightage(goal.goalsWeightage);
                        ep.ClickGoalSave();
                    }


                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region Integration Tab

        [Test, Order(8)]
        public void UpdateIntegrationTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var integrationInfo = JsonUtils.ConvertJsonListDataModel<IntegrationTabModel>(employeeFile, "integration");


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

                    foreach (var project in integration.Projects)
                    {
                        ep.ClickAddProjectsBtn();
                        ep.ClickProject();
                        ep.SelectProject(project.Project);
                        ep.ProvideProjectEffectiveFromDate(project.EffectiveFromDate);
                        ep.ProvideProjectEffectiveToDate(project.EffectiveToDate);
                        ep.ClickEmpProjectsave();
                    }

                    //ep.SaveAllInfo();

                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        #endregion

        #region ResidencyInfo Tab
        [Test, Order(9)]
        public void UpdateResidencyInfoTab()
        {
            try
            {

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var residencyInfo = JsonUtils.ConvertJsonListDataModel<ResidencyInfoTabModel>(employeeFile, "residencyInfo");



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
                    ep.ClickContractQualification();
                    ep.SelectContractQualification(residency.ContractQualification);
                    ep.ClickNewResidencyPeriod();
                    ep.SelectNewResidencyPeriod(residency.NewResidencyPeriod);
                    ep.ClickNewGovtDesignation();
                    ep.SelectNewGovtDesignation(residency.NewGovtDesignation);
                    ep.ClickGovermenttLicense();
                    ep.SelectGovermenttLicense(residency.GovtLicense);
                    ep.ProvideNewContractSalary(residency.NewContractSalary);
                    ep.ScrollDownWebPageOldContract();
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
                    //ep.SaveResidencyInfo();




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
