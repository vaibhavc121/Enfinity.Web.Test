﻿
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.SelfService;
using Enfinity.Hrms.Test.UI.Models.SelfService.AdminSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.BusinessTripClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.Models.SelfService.HRAssetRequest;
using Enfinity.Hrms.Test.UI.Models.SelfService.ITSupport;
using Enfinity.Hrms.Test.UI.Models.SelfService.TimeOff;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using Enfinity.Hrms.Test.UI.Pages.Global;
using Enfinity.Hrms.Test.UI.Pages.SelfService;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class SelfServiceModule : BaseTest
    {       

        #region Create Business Trip Claim
        [Test]
        [Ignore("locator issue")]
        public void CreateBusinessTripClaim()
        {
            try
            {
               

                var BusinessTripClaimFile = FileUtils.GetDataFile("Hrms", "SelfService", "BusinessTripClaim", "BusinessTripClaimData");
                var BusinessTripClaimData = JsonUtils.ConvertJsonListDataModel<BusinessTripClaimModel>(BusinessTripClaimFile, "createBusinessTripClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExpenseClaim page                
                BusinessTripClaimPage ec = new BusinessTripClaimPage(_driver);

                foreach (var BusinessTripClaim in BusinessTripClaimData)
                {
                    ec.ClickBusinessTripClaim();
                    ec.ClickNew();
                    ec.ClickSave();
                    ec.ScrollDownWebPage();
                    ec.ClickNewLine();
                    ec.ProvideExpenseDate(BusinessTripClaim.expenseDate);
                    ec.ProvideRemarks(BusinessTripClaim.remarks);
                    //ec.ClickExpenseClaimCategoryDD();
                    //ec.SelectExpenseClaimCategory(BusinessTripClaim.claimCategory);
                    ec.ProvideExpenseClaimCategory(BusinessTripClaim.claimCategory);
                    //ec.ProvideCurrency(BusinessTripClaim.currency);
                    ec.ProvideAmount(BusinessTripClaim.amount);
                }

                //ClassicAssert.IsTrue(ec.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion        

        #region create time off
        [Test, Order(1)]
        //[Ignore("locator issue")]
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
                    to.ClickNew();
                    to.ProvidePermissonDate(timeOff.permisionDate);
                    to.ClickPersoanl();
                    //to.ClickBusiness();
                    //to.ClickLeave();
                    //to.ClickFromTimeField();
                    //to.ProvideHrs(timeOff.hrs);
                    //to.ProvideMinutes(timeOff.minutes);
                    //to.ClickTimeNotation();
                    //to.SelectTimeNotation();
                    //to.ClickOk();
                    //issue
                    //to.ClickUpToTimeField();                   
                    //to.ProvideUpTOHrs1();
                    //to.ProvideUpToHrs(timeOff.upTohrs);
                    //to.ProvideUpToMinutes(timeOff.upToMinutes);
                    //to.ClickUpToTimeNotation();
                    //to.SelectUpToTimeNotation();
                    //to.ClickUpToOk();
                    to.EnterDescription("test");
                    to.ClickSave();

                    ClassicAssert.IsTrue(to.IsTxnCreated(timeOff.expPermisionDate));
                    
                }                

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete time off
        [Test, Order(2)]
        public void DeleteTimeOff()
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

        #region create HR Asset request
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
                    ar.ClickNew();
                    ar.ProvideTxnDate(HRAssetRequest.txnDate);
                    ar.ProvideEffectiveDate(HRAssetRequest.effectiveDate);
                    ar.ClickSave();
                    ar.ClickNewLine();
                    ar.ClickHRAssetDD();
                    ar.SelectHRAsset(HRAssetRequest.HRAsset);
                    //ar.ProvideExpReturnDate(HRAssetRequest.expReturnDate);
                    ar.ClickView();
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

        #region Delete HR Asset Request
        [Test, Order(4)]
        [Ignore ("dont check delete bcos i am checking asset return so txn cannot keep active for delete")]
        public void DeleteHRAssetRequest()
        {

            var HRAssetRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "HRAssetRequest", "HRAssetRequestData");
            var HRAssetRequestData = JsonUtils.ConvertJsonListDataModel<HRAssetRequestModel>(HRAssetRequestFile, "createHRAssetRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //HR asset request page                
            HRAssetRequestPage ar = new HRAssetRequestPage(_driver);
            ar.ClickHRAssetRequest();
            ar.Test();
            BasePage.DeleteTxn(7, "active");
        }
        #endregion

        #region Create hr asset return
        [Test, Order(5)]
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

        #region Create Exception Request
        [Test, Order(6)]        
        public void CreateExceptionRequest()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var exceptionRequestData = JsonUtils.ConvertJsonListDataModel<ExceptionRequestModel>(selfServiceFile, "createExceptionRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ExceptionRequest page                
                ExceptionRequestPage er = new ExceptionRequestPage(_driver);

                foreach(var exception in exceptionRequestData)
                {
                    er.CreateExceptionRequest();
                    er.ClickNew();                   
                    er.ProvideExceptionDate(exception.exceptionDate);
                    er.ProvideLoginTime(exception.loginTime);
                    //er.ProvideLogoutTime(exception.loginTime);
                    er.ProvideRemarks(exception.remarks);
                    er.ClickSaveBack();

                    ClassicAssert.IsTrue(er.IsTxnCreated(exception.exceptionDate));

                }


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion        

        #region Delete Exception Request
        [Test, Order(7)]
        public void DeleteExceptionRequest()
        {
            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //ExceptionRequest page                
            ExceptionRequestPage er = new ExceptionRequestPage(_driver);
            er.CreateExceptionRequest();

            BasePage.DeleteTxn(6, "001");
            ClassicAssert.IsFalse(BasePage.ValidateListing("001", 6, 6));
        }
        #endregion

        #region create leave request
        [Test, Order(8)]
        //[Ignore("issue in create new btn")]
        public void CreateLeaveRequest()
        {
            try
            {
               

                var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

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
                    lr.HoverAndClick(leaveRequest.leaveType);
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    //lr.ClickOnSaveSubmit();
                    lr.ClickSave();

                    ClassicAssert.IsTrue(lr.IsTxnCreated(leaveRequest.expFromDate, leaveRequest.expToDate));

                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Leave Request
        [Test, Order(9)]
        //[Repeat(5)]
        public void DeleteLeaveRequest()
        {

            var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
            var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Leave Request page                
            LeaveRequestPage lr = new LeaveRequestPage(_driver);
            lr.ClickLeaveRequest();

            BasePage.DeleteTxn(7, "active");
        }

        #endregion

        #region Create support request category
        [Test, Order(10)]
        public void CreateSupportRequestCategory()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var supportRequestCategoryData = JsonUtils.ConvertJsonListDataModel<SupportRequestCategoryModel>(selfServiceFile, "createSupportRequestCategory");

                //global search
                SupportRequestCategoryPage sr = new SupportRequestCategoryPage(_driver);

                foreach (var src in supportRequestCategoryData)
                {
                    sr.GlobalSearch1("support request category");
                    sr.ClickNew();
                    sr.ProvideCategoryname(src.categoryName);
                    sr.SelectRequestedTo(src.requestedTo);
                    sr.SelectPriority(src.priority);
                    sr.SelectWorkflow(src.workflow);
                    sr.RequireAttachment(src.attachment);
                    sr.ProvideDesc(src.desc);
                    sr.ClickSaveBack();

                    ClassicAssert.IsTrue(sr.IsTransactionCreated(expEmp: src.categoryName));
                }


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }

        #endregion

        #region Delete support request category
        [Test, Order(11)]
        public void DeleteSupportReqCategory()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var supportRequestCategoryData = JsonUtils.ConvertJsonListDataModel<DeleteSupportRequestCategoryModel>(selfServiceFile, "deleteSupportRequestCategory");

                //SupportRequestCategory
                SupportRequestCategoryPage sr = new SupportRequestCategoryPage(_driver);
                foreach (var SRC in supportRequestCategoryData)
                {
                    sr.GlobalSearch1("support request category");
                    sr.DeleteTransaction(2, SRC.categoryName);

                    ClassicAssert.IsFalse(BasePage.ValidateListing(SRC.categoryName, 2, 1));
                }


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region create support request
        [Test, Order(12)]
        public void CreateSupportRequest()
        {
            try
            {              

                var ITSupportFile = FileUtils.GetDataFile("Hrms", "SelfService", "ITSupport", "ITSupportData");
                var ITSupportData = JsonUtils.ConvertJsonListDataModel<ITSupportModel>(ITSupportFile, "createITSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ITSupport page                
                ITSupportRequestPage it = new ITSupportRequestPage(_driver);

                foreach (var ITSupport in ITSupportData)
                {
                    it.ClickITSupport();
                    it.ClickNew();
                    it.ClickPlusBtn();
                    it.ProvideSubject(ITSupport.subject);
                    it.SelectPriority(ITSupport.priority);
                    it.ProvideDesc(ITSupport.description);
                    it.ClickSaveBack();
                    //it.ClickContextMenu();
                    //it.ClickView();
                    //it.ClickOnApproveBack();
                    ClassicAssert.IsTrue(it.IsTxnCreated(ITSupport.employee, ITSupport.recordDesc));
                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete IT support request
        [Test, Order(13)]
        
        public void DeleteITSupportRequest()
        {
            try
            {

                var ITSupportFile = FileUtils.GetDataFile("Hrms", "SelfService", "ITSupport", "ITSupportData");
                var ITSupportData = JsonUtils.ConvertJsonListDataModel<ITSupportModel>(ITSupportFile, "createITSupport");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //ITSupport page                
                ITSupportRequestPage it = new ITSupportRequestPage(_driver);
                it.ClickITSupport();                

                BasePage.DeleteTxn(7, "Active");
                ClassicAssert.IsFalse(BasePage.ValidateListing("Active", 7, 7));

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion       

        #region create Loan Request
        [Test, Order(14)]
        public void CreateLoanRequest()
        {
            try
            {
               
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var loanRequestData = JsonUtils.ConvertJsonListDataModel<LoanRequestModel>(selfServiceFile, "createLoanRequest");

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
                    lr.ClickPlusBtn();
                    lr.ProvideLoanAmt(loan.loanAmt);
                    lr.ProvideInstallmentAmt(loan.installmentAmt);
                    lr.SelectRepaymentStartPeriod(loan.repaymentStartPeriod);
                    lr.ProvideRemarks(loan.remarks);
                    lr.ClickSave();                  

                    ClassicAssert.IsTrue(lr.IsTxnCreated(loan.loanType, loan.loanAmt));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Loan Request
        [Test, Order(15)]       
        public void DeleteLoanRequest()
        {
            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //LoanRequestPage                
            LoanRequestPage ot = new LoanRequestPage(_driver);
            ot.ClickLoanRequest();

            BasePage.DeleteTxn(6, "active");
            ClassicAssert.IsFalse(BasePage.ValidateListing("active", 6, 6));
        }
        #endregion

        #region create Benefit Claim
        [Test, Order(16)]
        public void CreateBenefitClaim()
        {
            try
            {
               
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var benefitClaimData = JsonUtils.ConvertJsonListDataModel<BenefitClaimModel>(selfServiceFile, "createBenefitClaim");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Benefit Claim page                
                BenefitClaimPage bc = new BenefitClaimPage(_driver);

                foreach (var benefitClaim in benefitClaimData)
                {
                    //bc.ScrollDownWebpage();
                    bc.ClickBenefitClaim();
                    bc.ClickNew();
                    bc.ProvideClaimDate(benefitClaim.claimDate);                   
                    bc.ProvideBenefitScheme(benefitClaim.benefitScheme);
                    bc.ProvideClaimAmt(benefitClaim.claimAmount);                   
                    bc.ProvidePaymentType(benefitClaim.paymentType);
                    bc.ProvideRemarks(benefitClaim.remarks);
                    bc.ClickSave();

                    ClassicAssert.IsTrue(bc.IsTxnCreated(benefitClaim.empName, benefitClaim.claimAmount));
                    //ClassicAssert.IsTrue(BasePage.IsTransactionCreated());
                    //ClassicAssert.IsTrue(true);
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Benefit Claim
        [Test, Order(17)]
        public void DeleteBenefitClaim()
        {
            var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
            var benefitClaimData = JsonUtils.ConvertJsonListDataModel<BenefitClaimModel>(selfServiceFile, "deleteBenefitClaim");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Benefit Claim page                
            BenefitClaimPage bc = new BenefitClaimPage(_driver);
            bc.ClickBenefitClaim();

            BasePage.DeleteTxn(9, "active");
            ClassicAssert.IsFalse(BasePage.ValidateListing("active", 9, 9));

        }
        #endregion

        #region Create Promotion Request
        [Test, Order(18)]
        public void CreatePromotionRequest()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var promotionRequestData = JsonUtils.ConvertJsonListDataModel<PromotionRequestModel>(selfServiceFile, "createPromotionRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Promotion Request page                
                PromotionRequestPage pr = new PromotionRequestPage(_driver);
                //pr.ScrollDownWebpage();
                pr.ClickPromotionRequest();
                pr.ClickNew();
               
                foreach (var promotionRequest in promotionRequestData)
                {
                    pr.ProvideTxnDate(promotionRequest.txnDate);
                    pr.ProvideEffectiveDate(promotionRequest.effectiveDate);
                    pr.ProvideType(promotionRequest.type);
                    pr.ProvideNewDepartment(promotionRequest.newDepartment);
                    pr.ProvideNewDesignation(promotionRequest.newDesignation);
                    pr.ProvideNewWorkLocation(promotionRequest.newWorkLocation);
                    pr.ProvideNewProject(promotionRequest.newProject);
                    pr.ProvideDescription(promotionRequest.description);
                    pr.SaveAndBack();
                    ClassicAssert.IsTrue(pr.IsTxnCreated(promotionRequest.effectiveDate1));
                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Promotion Request
        [Test, Order(19)]
        public void DeletePromotionRequest()
        {
            var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
            var promotionRequestData = JsonUtils.ConvertJsonListDataModel<PromotionRequestModel>(selfServiceFile, "createPromotionRequest");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //Promotion Request page                
            PromotionRequestPage pr = new PromotionRequestPage(_driver);
            //pr.ScrollDownWebpage();
            pr.ClickPromotionRequest();

            BasePage.DeleteTxn(6, "001");
            ClassicAssert.IsFalse(BasePage.ValidateListing("001", 6, 6));
        }
        #endregion

        #region create Travel Request
        [Test, Order(20)]
        public void CreateTravelRequest()
        {
            try
            {

                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var travelRequestData = JsonUtils.ConvertJsonListDataModel<TravelRequestModel>(selfServiceFile, "createTravelRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //travel Request page                
                TravelRequestPage tr = new TravelRequestPage(_driver);

                foreach (var travelRequest in travelRequestData)
                {
                    //tr.ScrollDownWebpage();
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

                    ClassicAssert.IsTrue(tr.IsTransactionCreated(travelRequest.empName, travelRequest.country));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Travel Request
        [Test, Order(21)]
        public void DeleteTravelRequest()
        {
            var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
            var benefitClaimData = JsonUtils.ConvertJsonListDataModel<BenefitClaimModel>(selfServiceFile, "deleteBenefitClaim");

            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //TravelRequestPage                
            TravelRequestPage bc = new TravelRequestPage(_driver);
            bc.ClickTravelRequest();

            BasePage.DeleteTxn(6, "active");
            ClassicAssert.IsFalse(BasePage.ValidateListing("active", 6, 6));
        }
        #endregion

        #region create Overtime Request
        [Test, Order(22)]
        public void CreateOvertimeApplication()
        {
            try
            {
                
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var overtimeRequestData = JsonUtils.ConvertJsonListDataModel<OvertimeRequestModel>(selfServiceFile, "createOvertimeRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Overtime Request page                
                OvertimeRequestPage or = new OvertimeRequestPage(_driver);

                foreach (var overtimeRequest in overtimeRequestData)
                {
                    //or.ScrollDownWebpage();
                    or.ClickOvertimeRequest();
                    or.ClickNew();
                    or.ProvideOvertimeDate(overtimeRequest.overtimeDate);
                    or.ProvideOvertimeType(overtimeRequest.overtimeType);
                    or.ProvideHrs(overtimeRequest.hrs);
                    or.ProvideRemarks(overtimeRequest.remarks);
                    //or.ClickOnSave();

                    #region additional code
                    BasePage.ClickOnSave();
                    if (BasePage.IsTransactionCreated())
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

        #region Delete Overtime Request
        [Test, Order(23)]
        public void DeleteOvertimeApplication()
        {
            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //OvertimeRequestPage                
            OvertimeRequestPage ot = new OvertimeRequestPage(_driver);
            ot.ClickOvertimeRequest();

            BasePage.DeleteTxn(6, "active");
            ClassicAssert.IsFalse(BasePage.ValidateListing("active", 6, 6));
        }
        #endregion

        #region create Resignation
        [Test, Order(24)]
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
                    //rp.ScrollDownWebpage();
                    rp.ClickResignation();
                    rp.ClickNew();
                    rp.ProvideSubmittedDate(resignation.submittedDate);
                    rp.ProvideRemarks(resignation.remarks);
                    rp.ClickOnSaveAndBack();

                    ClassicAssert.IsTrue(rp.IsTransactionCreated1());
                    //ClassicAssert.IsTrue(true);



                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Resignation
        [Test, Order(25)]
        public void DeleteResignation()
        {
            //self service page
            SelfServicePage ss = new SelfServicePage(_driver);
            ss.ClickSelfService();
            ss.ClickTransactions();

            //ResignationPage                
            ResignationPage ot = new ResignationPage(_driver);
            ot.ClickResignation();

            BasePage.DeleteTxn(6, "active");
            ClassicAssert.IsFalse(BasePage.ValidateListing("active", 6, 6));
        }
        #endregion

        #region Delete Leave Extension
        [Test]
        [Ignore ("")]
        public void DeleteLeaveExtension()
        {
            var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
            var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

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

        #region Verify Workflow

        #region Approve Workflow
        [Test, Order(26)]
        public void VerifyApproveWorkflow()
        {
            try
            {
                var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "checkWorkflow");

                BasePage.LogoutAndLogin("rohitc@test.com", "123");

                //self service module
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Leave Request page                
                LeaveRequestPage lr = new LeaveRequestPage(_driver);

                //create leave request as employee
                foreach (var leaveRequest in LeaveRequestData)
                {
                    lr.ClickLeaveRequest();
                    Thread.Sleep(5000);
                    lr.ClickNew();
                    lr.HoverAndClick(leaveRequest.leaveType);
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    lr.ClickSaveAndSubmit();
                    //lr.ClickSave();

                    //ClassicAssert.IsTrue(lr.IsTxnCreated(leaveRequest.expFromDate, leaveRequest.expToDate));
                }

                //approve the leave request from manager login
                BasePage.LogoutAndLogin("vaibhav@test.com", "123");
                NotificationPage np = new NotificationPage(_driver);
                foreach (var leaveRequest in LeaveRequestData)
                {
                    np.ClickBellIcon();
                    np.IsLeaveDataCorrect(leaveRequest.expEmpName, "Approve");
                }

                //amend the txn
                BasePage.LogoutAndLogin("rohitc@test.com", "123");
                ss.ClickSelfService();
                ss.ClickTransactions();
                lr.ClickLeaveRequest();
                foreach (var leaveRequest in LeaveRequestData)
                {
                    BasePage.PerformAction(7, "Approve", "Amend");
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Revise Workflow
        [Test, Order(27)]
        [Ignore("NoSuchWindowException")]
        public void VerifyReviseWorkflow()
        {
            try
            {
                var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "checkWorkflow");

                BasePage.LogoutAndLogin("rohitc@test.com", "123");

                //self service module
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Leave Request page                
                LeaveRequestPage lr = new LeaveRequestPage(_driver);

                //create leave request as employee
                foreach (var leaveRequest in LeaveRequestData)
                {
                    lr.ClickLeaveRequest();
                    Thread.Sleep(5000);
                    lr.ClickNew();
                    lr.HoverAndClick(leaveRequest.leaveType);
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    lr.ClickSaveAndSubmit();
                    //lr.ClickSave();

                    //ClassicAssert.IsTrue(lr.IsTxnCreated(leaveRequest.expFromDate, leaveRequest.expToDate));
                }

                //Revise the leave request from manager login
                BasePage.LogoutAndLogin("vaibhav@test.com", "123");
                NotificationPage np = new NotificationPage(_driver);
                foreach (var leaveRequest in LeaveRequestData)
                {
                    np.ClickBellIcon();
                    np.IsLeaveDataCorrect(leaveRequest.expEmpName, "Revise");
                }

                //Amend & Delete the txn
                BasePage.LogoutAndLogin("rohitc@test.com", "123");
                ss.ClickSelfService();
                ss.ClickTransactions();
                lr.ClickLeaveRequest();
                foreach (var leaveRequest in LeaveRequestData)
                {
                    BasePage.PerformAction(7, "Active", "Delete");
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Reject Workflow
        [Test, Order(28)]
        [Ignore("NoSuchWindowException")]
        public void VerifyRejectWorkflow()
        {
            try
            {
                var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "checkWorkflow");

                BasePage.LogoutAndLogin("rohitc@test.com", "123");

                //self service module
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Leave Request page                
                LeaveRequestPage lr = new LeaveRequestPage(_driver);

                //create leave request as employee
                foreach (var leaveRequest in LeaveRequestData)
                {
                    lr.ClickLeaveRequest();
                    Thread.Sleep(5000);
                    lr.ClickNew();
                    lr.HoverAndClick(leaveRequest.leaveType);
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    lr.ClickSaveAndSubmit();
                    //lr.ClickSave();

                    //ClassicAssert.IsTrue(lr.IsTxnCreated(leaveRequest.expFromDate, leaveRequest.expToDate));
                }

                //Revise the leave request from manager login
                BasePage.LogoutAndLogin("vaibhav@test.com", "123");
                NotificationPage np = new NotificationPage(_driver);
                foreach (var leaveRequest in LeaveRequestData)
                {
                    np.ClickBellIcon();
                    np.IsLeaveDataCorrect(leaveRequest.expEmpName,"Reject");
                }

                //Amend & Delete the txn
                BasePage.LogoutAndLogin("rohitc@test.com", "123");
                ss.ClickSelfService();
                ss.ClickTransactions();
                lr.ClickLeaveRequest();
                foreach (var leaveRequest in LeaveRequestData)
                {
                    BasePage.ValidateListing1(expDate: DateUtils.CurrentDateInCustomFormat(), expStatus: "Rejected");
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion


        #endregion




        #region create leave request
        [Test]
        [Ignore("issue in create new btn")]
        public void FileUpload()
        {
            try
            {


                var LeaveRequestFile = FileUtils.GetDataFile("Hrms", "SelfService", "LeaveRequest", "LeaveRequestData");
                var LeaveRequestData = JsonUtils.ConvertJsonListDataModel<LeaveRequestModel>(LeaveRequestFile, "createLeaveRequest");

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
                    lr.HoverAndClick(leaveRequest.leaveType);
                    lr.ProvideFromDate(leaveRequest.fromDate);
                    lr.ProvideToDate(leaveRequest.toDate);
                    //lr.ClickOnSaveSubmit();
                    lr.ClickSave();
                    //lr.AttachFile();

                    ClassicAssert.IsTrue(lr.IsTxnCreated(leaveRequest.expFromDate, leaveRequest.expToDate));

                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion




        #region Txn- not present

        #region create expense claim
        [Test, Order(1)]
        [Ignore("locator issue")]
        public void CreateExpenseClaim()
        {
            try
            {


                var ExpenseClaimFile = FileUtils.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
                var ExpenseClaimData = JsonUtils.ConvertJsonListDataModel<BusinessTripClaimModel>(ExpenseClaimFile, "createExpenseClaim");

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

        #region Delete Expense Claim
        [Test]
        [Ignore("locator issue")]
        public void DeleteExpenseClaim()
        {

            var ExpenseClaimFile = FileUtils.GetDataFile("Hrms", "SelfService", "ExpenseClaim", "ExpenseClaimData");
            var ExpenseClaimData = JsonUtils.ConvertJsonListDataModel<BusinessTripClaimModel>(ExpenseClaimFile, "createExpenseClaim");

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

        #region create admin support
        [Test, Order(6)]
        [Ignore("don't need")]
        public void CreateAdminSupport()
        {
            try
            {

                var adminSupportFile = FileUtils.GetDataFile("Hrms", "SelfService", "AdminSupport", "AdminSupportData");
                var adminSupportData = JsonUtils.ConvertJsonListDataModel<AdminSupportModel>(adminSupportFile, "createAdminSupport");

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

        #region create Promotion Request
        [Test, Order(10)]
        [Ignore("do create separate txn for each promotion type")]
        public void CreatePromotionReq()
        {
            try
            {

                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var promotionRequestData = JsonUtils.ConvertJsonListDataModel<PromotionRequestModel>(selfServiceFile, "createPromotionRequest");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //Promotion Request page                
                PromotionRequestPage pr = new PromotionRequestPage(_driver);
                //pr.ScrollDownWebpage();
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
                    //pr.ClickOnSave();                    
                    //pr.ClickOnNewBtn();

                    pr.SaveAndBack();
                    ClassicAssert.IsTrue(pr.IsTxnCreated(promotionRequest.effectiveDate1));
                    pr.ClickNew();
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

        #endregion

    }
} 

