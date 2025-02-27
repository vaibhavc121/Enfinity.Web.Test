﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.SelfService;
using Enfinity.Hrms.Test.UI.Models.SelfService.ITSupport;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class CreateLoanRequestTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
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

                foreach(var loan in loanRequestData)
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
    }
}
