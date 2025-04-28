
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private By plusBtn = By.XPath("(//i[@class='dx-icon dx-icon-plus'])[2]");
        private By slider = By.XPath("(//div[@class='dx-trackbar-container dx-slider-bar'])[1]");
        private By loanAmount = By.CssSelector("input[aria-label='Loan Amount Slider Value']");
        private By installmentAmt = By.XPath("//input[@aria-label='Slider Value']");
        private By emiDD = By.XPath("//input[contains(@id,'RepaymentStartPeriodId')]");

        #endregion

        #region action methods
        public void ClickLoanRequest()
        {
             Find(loanRequest).Click();
        }
        public void ClickOnNew()
        {
            WaitTS(3);
            ClickNew();           
        }
        public void ClickPlusBtn()
        {            
            HoverOverElement(plusBtn);
            Find(plusBtn).Click();
        }
        public void ProvideLoanAmt(string value)
        {
            ClearAndProvide1(loanAmount, value);
        }
        public void ProvideInstallmentAmt(string value)
        {
            ClearAndProvide1(installmentAmt, value);
        }

        public void SelectRepaymentStartPeriod(string value)
        {
            Find(emiDD).Click();
            SelectDropdownOption(value);
        }
       
        public void ProvideRemarks(string value)
        {
            ProvideDescription(value);
        }
        public void ClickOnSave()
        {
             ClickSaveAndBack();
        }
        public bool IsTxnCreated(string loanType, string loanAmt)
        {
            if (ResultValue(7).Contains(loanType) && ResultValue(7).Contains(loanAmt))
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
