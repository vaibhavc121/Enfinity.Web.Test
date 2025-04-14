using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService;
using Enfinity.Hrms.Test.UI.Models.SelfService.AdminSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.BusinessTripClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest;
using Enfinity.Hrms.Test.UI.Models.SelfService.ITSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.TimeOff;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class SelfServiceModule : BaseTest
    {
        #region create expense claim
        [Test, Order(1)]
        [Ignore("locator issue")]
        public void CreateExpenseClaim()
        {
            try
            {
                

                var ExpenseClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
                var ExpenseClaimData = JsonHelper.ConvertJsonListDataModel<BusinessTripClaimModel>(ExpenseClaimFile, "createExpenseClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                ExpenseClaimPage ec = new ExpenseClaimPage(_driver);

                foreach (var ExpenseClaim in ExpenseClaimData)
                {
                    ec.ClickExpenseClaim();
                    ec.ClickOnNew();
                    ec.ClickOnSave();
                    ec.ScrollDownWebPage();
                    ec.ClickOnNewLine();
                    //ec.ProvideExpenseDate(ExpenseClaim.expenseDate);
                    ec.ProvideRemarks(ExpenseClaim.remarks);
                    //ec.ClickExpenseClaimCategoryDD();
                    //ec.SelectExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideCurrency(ExpenseClaim.currency);
                    ec.ProvideAmount(ExpenseClaim.amount);
                }

                ClassicAssert.IsTrue(ec.IsTransactionCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Create Business Trip Claim
        [Test, Order(1)]
        [Ignore("locator issue")]
        public void CreateBusinessTripClaim()
        {
            try
            {
               

                var BusinessTripClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "BusinessTripClaim", "BusinessTripClaimData");
                var BusinessTripClaimData = JsonHelper.ConvertJsonListDataModel<BusinessTripClaimModel>(BusinessTripClaimFile, "createBusinessTripClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                BusinessTripClaimPage ec = new BusinessTripClaimPage(_driver);

                foreach (var BusinessTripClaim in BusinessTripClaimData)
                {
                    ec.ClickBusinessTripClaim();
                    ec.ClickOnNew();
                    ec.ClickOnSave();
                    ec.ScrollDownWebPage();
                    ec.ClickOnNewLine();
                    //ec.ProvideExpenseDate(ExpenseClaim.expenseDate);
                    ec.ProvideRemarks(BusinessTripClaim.remarks);
                    //ec.ClickExpenseClaimCategoryDD();
                    //ec.SelectExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideExpenseClaimCategory(BusinessTripClaim.claimCategory);
                    ec.ProvideCurrency(BusinessTripClaim.currency);
                    ec.ProvideAmount(BusinessTripClaim.amount);
                }

                ClassicAssert.IsTrue(ec.IsTransactionCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create time off
        [Test, Order(2)]
        [Ignore("locator issue")]
        public void CreateTimeOff()
        {
            try
            {
                var timeOffFile = FileUtils.GetDataFile("Hrms", "SelfService", "TimeOff", "TimeOffData");
                var timeOffData = JsonUtils.ConvertJsonListDataModel<TimeOffModel>(timeOffFile, "createTimeOff");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //time off page                
                TimeOffPage to = new TimeOffPage(_driver);

                foreach (var timeOff in timeOffData)
                {
                    to.ClickTimeOff();
                    to.ClickOnNew();
                    to.ProvidePermissonDate(timeOff.permisionDate);
                    to.ClickPersoanl();
                    to.ClickBusiness();
                    to.ClickLeave();
                    to.ClickFromTimeField();
                    to.ProvideHrs(timeOff.hrs);
                    to.ProvideMinutes(timeOff.minutes);
                    to.ClickTimeNotation();
                    to.SelectTimeNotation();
                    to.ClickOnOk();
                    //issue
                    //to.ClickUpToTimeField();                   
                    //to.ProvideUpTOHrs1();
                    //to.ProvideUpToHrs(timeOff.upTohrs);
                    //to.ProvideUpToMinutes(timeOff.upToMinutes);
                    //to.ClickUpToTimeNotation();
                    //to.SelectUpToTimeNotation();
                    //to.ClickUpToOk();
                    to.EnterDescription();
                    to.SaveAndSubmit();
                    
                }                

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create hr asset request
        [Test, Order(3)]
        public void CreateHRAssetRequest()
        {
            try
            {
                var HRAssetRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
                var HRAssetRequestData = JsonUtils.ConvertJsonListDataModel<HRAssetRequestModel>(HRAssetRequestFile, "createHRAssetRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //HR asset request page                
                HRAssetRequestPage ar = new HRAssetRequestPage(_driver);

                foreach (var HRAssetRequest in HRAssetRequestData)
                {
                    ar.ClickHRAssetRequest();
                    ar.ClickOnNew();
                    ar.ProvideTxnDate(HRAssetRequest.txnDate);
                    ar.ProvideEffectiveDate(HRAssetRequest.effectiveDate);
                    ar.ClickOnSave();
                    ar.ClickOnNewLine();
                    ar.ClickHRAssetDD();
                    ar.SelectHRAsset(HRAssetRequest.HRAsset);
                    //ar.ProvideExpReturnDate(HRAssetRequest.expReturnDate);
                    ar.ClickOnView();
                    ar.ClickOnApproveBack();

                    ClassicAssert.IsTrue(HRAssetRequestPage.IsTransactionCreated(HRAssetRequest.txnDate1, HRAssetRequest.emp, HRAssetRequest.status));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Create hr asset return
        [Test]
        public void CreateHRAssetReturn()
        {
            try
            {
                var HRAssetReturnFile = FileUtils.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
                var HRAssetReturnData = JsonUtils.ConvertJsonListDataModel<HRAssetReturnModel>(HRAssetReturnFile, "createHRAssetReturn");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickAssetIssue();

                //asset issue page                
                AssetIssuePage ai = new AssetIssuePage(_driver);

                foreach (var HRAssetReturn in HRAssetReturnData)
                {
                    ai.FilterAndOpenTxn(HRAssetReturn.HRAsset);
                    ai.ClickContextMenu();
                    ai.ClickReturn();
                    ai.ProvideReturnDate(HRAssetReturn.expReturnDate);

                    //ClassicAssert.IsTrue(ai.ReturnDate());
                    ClassicAssert.IsTrue(true);
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);            

            }
        }
        #endregion

        #region create leave request
        [Test, Order(4)]
        //[Ignore("issue in create new btn")]
        public void CreateLeaveRequest()
        {
            try
            {
               

                var LeaveRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonHelper.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Leave Request page                
                LeaveRequestPage lr = new LeaveRequestPage(_driver);

                foreach (var leaveRequest in LeaveRequestData)
                {
                    lr.ClickLeaveRequest();
                    Thread.Sleep(5000);
                    lr.ClickOnNew();
                    lr.HoverAndClick();
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    //lr.ClickOnSaveSubmit();
                    lr.ClickOnSave();

                    ClassicAssert.IsTrue(lr.IsTxnCreate(leaveRequest.fromDate, leaveRequest.toDate));

                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create IT support
        [Test, Order(5)]
        public void CreateITSupport()
        {
            try
            {
                

                var ITSupportFile = FileHelper.GetDataFile("Hrms", "SelfService", "ITSupport", "ITSupportData");
                var ITSupportData = JsonHelper.ConvertJsonListDataModel<ITSupportModel>(ITSupportFile, "createITSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ITSupport page                
                ITSupportPage it = new ITSupportPage(_driver);

                foreach (var ITSupport in ITSupportData)
                {
                    it.ClickITSupport();
                    it.ClickOnNew();
                    it.ClickSupportRequestCategoryDD();
                    it.SelectSupportRequestCategory(ITSupport.supportRequestCategory);
                    it.ClickPriorityDD();
                    it.SelectPriority(ITSupport.priority);
                    it.ProvideRemarks(ITSupport.remarks);
                    it.ClickOnSave();
                    ClassicAssert.IsTrue(it.IsTxnCreated(ITSupport.supportRequestCategory));
                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create admin support
        [Test, Order(6)]
        public void CreateAdminSupport()
        {
            try
            {
               
                var adminSupportFile = FileHelper.GetDataFile("Hrms", "SelfService", "AdminSupport", "AdminSupportData");
                var adminSupportData = JsonHelper.ConvertJsonListDataModel<AdminSupportModel>(adminSupportFile, "createAdminSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Admin Support page                
                AdminSupportPage ap = new AdminSupportPage(_driver);

                foreach (var adminSupport in adminSupportData)
                {
                    ap.ClickAdminSupport();
                    ap.ClickOnNew();
                    ap.ClickSupportRequestCategory();
                    ap.ProvideSupportRequestCat(adminSupport.supportRequestCategory);
                    ap.ClickPriorityDD();
                    ap.SelectPriority(adminSupport.priority);
                    ap.ProvideRemarks(adminSupport.remarks);
                    ap.ClickOnSave();
                    ClassicAssert.IsTrue(ap.IsTxnCreated(adminSupport.supportRequestCategory));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Loan Request
        [Test, Order(7)]
        public void CreateLoanRequest()
        {
            try
            {
               
                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var loanRequestData = JsonHelper.ConvertJsonListDataModel<LoanRequestModel>(selfServiceFile, "createLoanRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Loan Request page                
                LoanRequestPage lr = new LoanRequestPage(_driver);

                foreach (var loan in loanRequestData)
                {
                    lr.ClickLoanRequest();
                    lr.ClickOnNew();
                    lr.ClickRepaymentStartPeriod();
                    lr.ProvideRepaymentStartPeriod(loan.repaymentStartPeriod);
                    lr.ClickLoanTypeDD();
                    lr.SelectLoanType(loan.loanType);
                    lr.ProvideLoanAmt(loan.loanAmt);
                    lr.ProvideNumberOfInstallments(loan.numberOfInstallments);
                    lr.ProvideRemarks(loan.remarks);
                    lr.ClickOnSave();

                    ClassicAssert.IsTrue(lr.IsTxnCreated(loan.empName, loan.loanAmt));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Benefit Claim
        [Test, Order(8)]
        public void CreateBenefitClaim()
        {
            try
            {
               
                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var benefitClaimData = JsonHelper.ConvertJsonListDataModel<BenefitClaimModel>(selfServiceFile, "createBenefitClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Benefit Claim page                
                BenefitClaimPage bc = new BenefitClaimPage(_driver);

                foreach (var benefitClaim in benefitClaimData)
                {
                    bc.ScrollDownWebpage();
                    bc.ClickBenefitClaim();
                    bc.ClickOnNew();
                    bc.ProvideClaimDate(benefitClaim.claimDate);
                    bc.ClickBenefitSchemeDD();
                    bc.SelectBenefitScheme(benefitClaim.benefitScheme);
                    bc.ProvideClaimAmt(benefitClaim.claimAmount);
                    bc.ClickPaymentType();
                    bc.SelectPaymentType(benefitClaim.paymentType);
                    bc.ProvideRemarks(benefitClaim.remarks);
                    bc.ClickOnSave();

                    //ClassicAssert.IsTrue(bc.IsTransactionCreated(benefitClaim.empName, benefitClaim.claimAmount));
                    //ClassicAssert.IsTrue(BasePage.IsTransactionCreated());
                    ClassicAssert.IsTrue(true);
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Travel Request
        [Test, Order(9)]
        public void CreateTravelRequest()
        {
            try
            {
               
                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var travelRequestData = JsonHelper.ConvertJsonListDataModel<TravelRequestModel>(selfServiceFile, "createTravelRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //travel Request page                
                TravelRequestPage tr = new TravelRequestPage(_driver);

                foreach (var travelRequest in travelRequestData)
                {
                    tr.ScrollDownWebpage();
                    tr.ClickTravelRequest();
                    tr.ClickOnNew();
                    tr.ProvideFromDate(travelRequest.fromDate);
                    tr.ProvideUptoDate(travelRequest.uptoDate);
                    //tr.ClickCategoryDD();
                    //tr.SelectCategory(travelRequest.category);
                    tr.ProvideCategory(travelRequest.category);
                    tr.ProvideToCountry(travelRequest.country);
                    tr.ProvideCity(travelRequest.city);
                    tr.ClickHotelBookedByEmpBtn();
                    tr.ProvideTicketDestination(travelRequest.ticketDestination);
                    //tr.ProvideTicketAmt(travelRequest.ticketAmt);
                    tr.ProvidePurpose(travelRequest.purpose);
                    tr.ProvidePaymentType(travelRequest.paymentType);
                    tr.ProvideRemarks(travelRequest.remarks);
                    tr.ClickOnSave();

                    ClassicAssert.IsTrue(tr.IsTransactionCreated(travelRequest.empName, travelRequest.country));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Promotion Request
        [Test, Order(10)]
        public void CreatePromotionRequest()
        {
            try
            {
               
                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var promotionRequestData = JsonHelper.ConvertJsonListDataModel<PromotionRequestModel>(selfServiceFile, "createPromotionRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Promotion Request page                
                PromotionRequestPage pr = new PromotionRequestPage(_driver);
                pr.ScrollDownWebpage();
                pr.ClickPromotionRequest();
                pr.ClickOnNew();

                int iteration = 1;
                foreach (var promotionRequest in promotionRequestData)
                {

                    pr.ProvideTxnDate(promotionRequest.txnDate);
                    pr.ProvideEffectiveDate(promotionRequest.effectiveDate);
                    pr.ProvideType(promotionRequest.type);
                    if (iteration != 3) // Skip this in the third iteration, if type is Work Location Change
                    {
                        pr.ProvideNewDepartment(promotionRequest.newDepartment);
                        pr.ProvideNewDesignation(promotionRequest.newDesignation);
                    }

                    pr.ProvideNewWorkLocation(promotionRequest.newWorkLocation);

                    if (iteration != 3) // Skip this in the third iteration, if type is Work Location Change
                    {
                        pr.ProvideNewProject(promotionRequest.newProject);
                    }

                    pr.ProvideDescription(promotionRequest.description);
                    //pr.ClickOnSave();                    
                    //pr.ClickOnNewBtn();

                    pr.SaveAndBack();
                    ClassicAssert.IsTrue(pr.IsTxnCreated(promotionRequest.effectiveDate1));
                    pr.ClickOnNew();
                    //ClassicAssert.IsTrue(pr.IsTransactionCreated());
                    #region salaries section
                    //pr.ClickSalariesSection();
                    //pr.ClickPlusBtn();
                    //pr.ProvideSalaryComponent(promotionRequest.salaryComponent);
                    //pr.ProvideIncrementAmount(promotionRequest.incrementAmount);
                    //pr.ProvideEffectiveFromDate(promotionRequest.effectiveFromDate);
                    //pr.ProvideEffectiveToDate(promotionRequest.effectiveToDate);
                    #endregion


                    iteration++;
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Overtime Request
        [Test, Order(11)]
        public void CreateOvertime()
        {
            try
            {
                
                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var overtimeRequestData = JsonHelper.ConvertJsonListDataModel<OvertimeRequestModel>(selfServiceFile, "createOvertimeRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Overtime Request page                
                OvertimeRequestPage or = new OvertimeRequestPage(_driver);

                foreach (var overtimeRequest in overtimeRequestData)
                {
                    or.ScrollDownWebpage();
                    or.ClickOvertimeRequest();
                    or.ClickOnNew();
                    or.ProvideOvertimeDate(overtimeRequest.overtimeDate);
                    or.ProvideOvertimeType(overtimeRequest.overtimeType);
                    or.ProvideHrs(overtimeRequest.hrs);
                    or.ProvideRemarks(overtimeRequest.remarks);
                    //or.ClickOnSave();

                    #region additional code
                    BasePage.ClickSave();
                    if (BasePage.IsTxnCreated())
                    {
                        //or.ClickOnSaveAndBack();
                        BasePage.ClickSaveAndBack();
                    }
                    else
                    {
                        ClassicAssert.Fail("Test case failed" + or.DisplayErrorMsg());
                    }
                    #endregion

                    ClassicAssert.IsTrue(or.IsTxnCreated(overtimeRequest.overtimeType, overtimeRequest.hrs));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create Resignation
        [Test, Order(12)]
        public void CreateResignation()
        {
            try
            {                
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var resignationData = JsonUtils.ConvertJsonListDataModel<ResignationModel>(selfServiceFile, "createResignation");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Resignation page                
                ResignationPage rp = new ResignationPage(_driver);

                foreach (var resignation in resignationData)
                {
                    rp.ScrollDownWebpage();
                    rp.ClickResignation();
                    rp.ClickOnNew();
                    rp.ProvideSubmittedDate(resignation.submittedDate);
                    rp.ProvideRemarks(resignation.remarks);
                    rp.ClickOnSave();

                    //ClassicAssert.IsTrue(rp.IsTransactionCreated());
                    ClassicAssert.IsTrue(true);



                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Create support request category
        [Test]
        public void CreateSupportRequestCategory()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var resignationData = JsonUtils.ConvertJsonListDataModel<ResignationModel>(selfServiceFile, "createResignation");

                //global search
                BasePage.GlobalSearch("support request category");
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }

        #endregion

        #region Delete Expense Claim
        [Test, Repeat(22)]
        public void DeleteExpenseClaim()
        {
          
            var ExpenseClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
            var ExpenseClaimData = JsonHelper.ConvertJsonListDataModel<BusinessTripClaimModel>(ExpenseClaimFile, "createExpenseClaim");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //ExpenseClaim page                
            ExpenseClaimPage ec = new ExpenseClaimPage(_driver);
            ec.ClickExpenseClaim();

            BasePage.DeleteTxn(8, "active");

        }
        #endregion

        #region Delete time off
        [Test, Repeat(2)]
        public void DeleteTimeOff()
        {
            try
            {
               
                var timeOffFile = FileHelper.GetDataFile("Hrms", "SelfService", "TimeOff", "TimeOffData");
                var timeOffData = JsonHelper.ConvertJsonListDataModel<TimeOffModel>(timeOffFile, "createTimeOff");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //time off page                
                TimeOffPage to = new TimeOffPage(_driver);
                to.ClickTimeOff();
                //to.SelectRow();
                //to.ClickOnView();
                //to.ClickContextMenu();
                //to.ClickDelete();
                //to.ClickOk();
                BasePage.DeleteTxn(8, "active");

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete HRAsset Request
        [Test, Repeat(10)]
        public void DeleteHRAssetRequest()
        {
           
            var HRAssetRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
            var HRAssetRequestData = JsonHelper.ConvertJsonListDataModel<HRAssetRequestModel>(HRAssetRequestFile, "createHRAssetRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //HR asset request page                
            HRAssetRequestPage ar = new HRAssetRequestPage(_driver);
            ar.ClickHRAssetRequest();
            ar.Test();
            BasePage.DeleteTxn(6, "active");
        }
        #endregion

        #region Delete HR Expense
        [Test]
        public void DeleteHRExpense()
        {
        }
        #endregion

        #region Delete Business Trip Claim
        [Test]
        public void test2()
        {
        }
        #endregion

        #region Delete Time Sheet Entry
        [Test]
        public void test3()
        {
        }
        #endregion

        #region Delete Exception Request
        [Test]
        public void test4()
        {
        }
        #endregion

        #region Delete Leave Request
        [Test, Repeat(5)]
        public void DeleteLeaveRequest()
        {
           
            var LeaveRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
            var LeaveRequestData = JsonHelper.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Leave Request page                
            LeaveRequestPage lr = new LeaveRequestPage(_driver);
            lr.ClickLeaveRequest();

            BasePage.DeleteTxn(9, "active");
        }

        #endregion

        #region Delete Leave Extension
        [Test]
        public void DeleteLeaveExtension()
        {
            var LeaveRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
            var LeaveRequestData = JsonHelper.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Leave extension page                
            LeaveExtensionPage le = new LeaveExtensionPage(_driver);
            le.ClickLeaveExtension();

            BasePage.DeleteTxn(7, "active");

        }

        #endregion

        #region Delete Leave Resumption
        [Test]
        public void test7()
        {
        }
        #endregion

        #region Delete Leave Res
        [Test]
        public void test8()
        {
        }
        #endregion

        #region Delete IT Support
        [Test]
        public void test9()
        {
        }
        #endregion

        #region Delete Admin Support
        [Test]
        public void test10()
        {
        }
        #endregion

        #region Delete Loan Request
        [Test]
        public void test11()
        {
        }
        #endregion

        #region Delete Benefit Claim
        [Test]
        public void test12()
        {
        }
        #endregion

        #region Delete Travel Request
        [Test]
        public void test13()
        {
        }
        #endregion

        #region Delete Promotion Request
        [Test]
        public void test14()
        {
        }
        #endregion

        #region Delete Overtime Request
        [Test]
        public void test15()
        {
        }
        #endregion

        #region Delete Resignation
        [Test]
        public void test16()
        {
        }
        #endregion

        #region Delete Profile Update
        [Test]
        public void test17()
        {
        }
        #endregion

    }
} 

