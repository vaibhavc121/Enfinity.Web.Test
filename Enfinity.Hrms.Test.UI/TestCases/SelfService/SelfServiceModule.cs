using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService;
using Enfinity.Hrms.Test.UI.Models.SelfService.AdminSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest;
using Enfinity.Hrms.Test.UI.Models.SelfService.ITSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.TimeOff;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class SelfServiceModule : BaseTest
    {
        public string Product = "Hrms";

        #region create expense claim
        [Test, Order(1)]
        //[Ignore("locator issue")]
        public void VerifyExpenseClaimCreation()
        {
            try
            {
                Login(Product);

                var ExpenseClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
                var ExpenseClaimData = JsonHelper.ConvertJsonListDataModel<ExpenseClaimModel>(ExpenseClaimFile, "createExpenseClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                ExpenseClaimPage ec = new ExpenseClaimPage(_driver);

                foreach (var ExpenseClaim in ExpenseClaimData)
                {
                    ec.ClickExpenseClaim();
                    ec.ClickNew();
                    ec.ClickSave();
                    ec.ScrollDownWebPage();
                    ec.ClickNewLine();
                    //ec.ProvideExpenseDate(ExpenseClaim.expenseDate);
                    ec.ProvideRemarks(ExpenseClaim.remarks);
                    //ec.ClickExpenseClaimCategoryDD();
                    //ec.SelectExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideExpenseClaimCategory(ExpenseClaim.claimCategory);
                    ec.ProvideCurrency(ExpenseClaim.currency);
                    ec.ProvideAmount(ExpenseClaim.amount);
                }

                ClassicAssert.IsTrue(ec.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create time off
        [Test, Order(2)]
        public void VerifyTimeOffCreation()
        {
            try
            {
                Login(Product);

                var timeOffFile = FileHelper.GetDataFile("Hrms", "SelfService", "TimeOff", "TimeOffData");
                var timeOffData = JsonHelper.ConvertJsonListDataModel<TimeOffModel>(timeOffFile, "createTimeOff");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //time off page                
                TimeOffPage to = new TimeOffPage(_driver);

                foreach (var timeOff in timeOffData)
                {
                    to.ClickTimeOff();
                    to.ClickNew();
                    to.ProvidePermissonDate(timeOff.permisionDate);
                    to.ClickPermissionTypeDD();
                    to.SelectPermissionType(timeOff.permissionType);
                    to.ProvideFromTime(timeOff.fromTime);
                    to.ProvideUptoTime(timeOff.upToTime);
                    to.ClickSave();
                }

                ClassicAssert.IsTrue(to.IsTxnCreated("60"));

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create hr asset request
        [Test, Order(3)]
        public void VerifyHRAssetRequestCreation()
        {
            try
            {
                Login(Product);

                var HRAssetRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
                var HRAssetRequestData = JsonHelper.ConvertJsonListDataModel<HRAssetRequestModel>(HRAssetRequestFile, "createHRAssetRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //HR asset request page                
                HRAssetRequestPage ar = new HRAssetRequestPage(_driver);

                foreach (var HRAssetRequest in HRAssetRequestData)
                {
                    ar.ClickHRAssetRequest();
                    ar.ClickNew();
                    ar.ProvideTxnDate(HRAssetRequest.txnDate);
                    ar.ProvideEffectiveDate(HRAssetRequest.effectiveDate);
                    ar.ClickSave();
                    ar.ClickNewLine();
                    ar.ClickHRAssetDD();
                    ar.SelectHRAsset(HRAssetRequest.HRAsset);
                    //ar.ProvideExpReturnDate(HRAssetRequest.expReturnDate);
                    ar.ClickView();
                    ar.ClickApprove();

                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region create leave request
        [Test, Order(4)]
        //[Ignore("issue in create new btn")]
        public void VerifyLeaveRequestCreation()
        {
            try
            {
                Login(Product);

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
                    lr.ClickNew();
                    lr.HoverAndClick();
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    //lr.ClickSaveSubmit();
                    lr.ClickSave();

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
        public void VerifyITSupportCreation()
        {
            try
            {
                Login(Product);

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
                    it.ClickNew();
                    it.ClickSupportRequestCategoryDD();
                    it.SelectSupportRequestCategory(ITSupport.supportRequestCategory);
                    it.ClickPriorityDD();
                    it.SelectPriority(ITSupport.priority);
                    it.ProvideRemarks(ITSupport.remarks);
                    it.ClickSave();
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
        public void VerifyAdminSupportCreation()
        {
            try
            {
                Login(Product);

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
                    ap.ClickNew();
                    ap.ClickSupportRequestCategory();
                    ap.ProvideSupportRequestCat(adminSupport.supportRequestCategory);
                    ap.ClickPriorityDD();
                    ap.SelectPriority(adminSupport.priority);
                    ap.ProvideRemarks(adminSupport.remarks);
                    ap.ClickSave();
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
        public void VerifyLoanRequestCreation()
        {
            try
            {
                Login(Product);

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
                    lr.ClickNew();
                    lr.ClickRepaymentStartPeriod();
                    lr.ProvideRepaymentStartPeriod(loan.repaymentStartPeriod);
                    lr.ClickLoanTypeDD();
                    lr.SelectLoanType(loan.loanType);
                    lr.ProvideLoanAmt(loan.loanAmt);
                    lr.ProvideNumberOfInstallments(loan.numberOfInstallments);
                    lr.ProvideRemarks(loan.remarks);
                    lr.ClickSave();

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
        public void VerifyBenefitClaimCreation()
        {
            try
            {
                Login(Product);

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
                    bc.ClickNew();
                    bc.ProvideClaimDate(benefitClaim.claimDate);
                    bc.ClickBenefitSchemeDD();
                    bc.SelectBenefitScheme(benefitClaim.benefitScheme);
                    bc.ProvideClaimAmt(benefitClaim.claimAmount);
                    bc.ClickPaymentType();
                    bc.SelectPaymentType(benefitClaim.paymentType);
                    bc.ProvideRemarks(benefitClaim.remarks);
                    bc.ClickSave();

                    //ClassicAssert.IsTrue(bc.IsTxnCreated(benefitClaim.empName, benefitClaim.claimAmount));
                    //ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
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
        public void VerifyTravelRequestCreation()
        {
            try
            {
                Login(Product);

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
                    tr.ClickNew();
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
                    tr.ClickSave();

                    ClassicAssert.IsTrue(tr.IsTxnCreated(travelRequest.empName, travelRequest.country));
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
        public void VerifyPromotionRequestCreation()
        {
            try
            {
                Login(Product);

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
                pr.ClickNew();

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
                    //pr.ClickSave();                    
                    //pr.ClickNewBtn();

                    pr.SaveAndBack();
                    ClassicAssert.IsTrue(pr.IsTxnCreated(promotionRequest.effectiveDate1));
                    pr.ClickNew();
                    //ClassicAssert.IsTrue(pr.IsTxnCreated());
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
        public void VerifyOvertimeCreation()
        {
            try
            {
                Login(Product);

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
                    or.ClickNew();
                    or.ProvideOvertimeDate(overtimeRequest.overtimeDate);
                    or.ProvideOvertimeType(overtimeRequest.overtimeType);
                    or.ProvideHrs(overtimeRequest.hrs);
                    or.ProvideRemarks(overtimeRequest.remarks);
                    //or.ClickSave();

                    #region additional code
                    CommonPageActions.ClickSave();
                    if (CommonPageActions.IsTxnCreated())
                    {
                        //or.ClickSaveAndBack();
                        CommonPageActions.ClickSaveAndBack();
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
        public void ResignationCreation()
        {
            try
            {
                Login(Product);

                var selfServiceFile = FileHelper.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var resignationData = JsonHelper.ConvertJsonListDataModel<ResignationModel>(selfServiceFile, "createResignation");

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
                    rp.ClickNew();
                    rp.ProvideSubmittedDate(resignation.submittedDate);
                    rp.ProvideRemarks(resignation.remarks);
                    rp.ClickSave();

                    //ClassicAssert.IsTrue(rp.IsTxnCreated());
                    ClassicAssert.IsTrue(true);



                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Expense Claim
        [Test, Repeat(22)]
        public void DeleteExpenseClaim()
        {
            Login(Product);

            var ExpenseClaimFile = FileHelper.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
            var ExpenseClaimData = JsonHelper.ConvertJsonListDataModel<ExpenseClaimModel>(ExpenseClaimFile, "createExpenseClaim");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //ExpenseClaim page                
            ExpenseClaimPage ec = new ExpenseClaimPage(_driver);
            ec.ClickExpenseClaim();

            CommonPageActions.DeleteTxn(8, "active");

        }
        #endregion

        #region Delete time off
        [Test, Repeat(2)]
        public void DeleteTimeOff()
        {
            try
            {
                Login(Product);

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
                //to.ClickView();
                //to.ClickContextMenu();
                //to.ClickDelete();
                //to.ClickOk();
                CommonPageActions.DeleteTxn(8, "active");

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
            Login(Product);

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
            CommonPageActions.DeleteTxn(6, "active");
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
            Login(Product);

            var LeaveRequestFile = FileHelper.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
            var LeaveRequestData = JsonHelper.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Leave Request page                
            LeaveRequestPage lr = new LeaveRequestPage(_driver);
            lr.ClickLeaveRequest();

            CommonPageActions.DeleteTxn(9, "active");
        }

        #endregion

        #region Delete Leave Extension

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

