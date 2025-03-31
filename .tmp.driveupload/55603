using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class LoanRequestPage : BasePage
    {
        public LoanRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By loanRequest = By.XPath("//span[normalize-space()='Loan Request']");
        private By repaymentStartPeriod = By.XPath("//input[@id='LoanRequest.RepaymentStartPeriodIdLookup_I']");
        private By loanTypeDD = By.XPath("//img[@id='LoanRequest.LoanTypeIdLookup_B-1Img']");
        private By loanAmount = By.XPath("//input[@id='LoanRequest.LoanAmountFC_I']");
        private By numberOfInstallments = By.XPath("//input[@id='LoanRequest.NumberOfInstallments_I']");
        private By remarks = By.XPath("//textarea[@id='LoanRequest.Description_I']");
        #endregion

        #region action methods
        public void ClickLoanRequest()
        {
             Find(loanRequest).Click();
        }
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ClickRepaymentStartPeriod()
        {
             Find(repaymentStartPeriod).Click();
        }
        public void ProvideRepaymentStartPeriod(string value)
        {
            Find(repaymentStartPeriod).SendKeys(value);
        }
        public void ClickLoanTypeDD()
        {
           Find(loanTypeDD).Click();
        }
        public void SelectLoanType(string value)
        {
            SelectDropdownValue(value);
        }
        public void ProvideLoanAmt(string value)
        {
            ClearAndProvide1(loanAmount,value);
        }
        public void ProvideNumberOfInstallments(string value)
        {
            ClearAndProvide1(numberOfInstallments, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickOnSave()
        {
             ClickSaveAndBack();
        }
        public bool IsTxnCreated(string emp, string loanAmt)
        {
            if (Result5().Contains(emp) && Result7().Contains(loanAmt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
