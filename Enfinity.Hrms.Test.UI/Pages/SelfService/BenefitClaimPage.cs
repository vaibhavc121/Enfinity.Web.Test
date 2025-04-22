
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class BenefitClaimPage : BasePage
    {
        public BenefitClaimPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By profileUpdate = By.XPath("//a[@id='TxnInstanceView_I0i19_T']//span[@class='dx-vam'][normalize-space()='Profile Update']");
        private By benefitClaim = By.XPath("//span[normalize-space()='Benefit Claim']");
        private By claimDate = By.XPath("//input[@id='BenefitClaim.ClaimDate_I']");
        private By EmpBenefitScheme = By.XPath("//input[@id='BenefitClaim.EmployeeBenefitSchemeIdLookup_I']");
        private By claimAmount = By.XPath("//input[@id='BenefitClaim.ClaimAmount_I']");
        private By paymentType = By.XPath("//input[@id='BenefitClaim.PaymentType_I']");
        private By remarks = By.XPath("//textarea[@id='BenefitClaim.Description_I']");
        #endregion

        #region action methods
        public void ScrollDownWebpage()
        {
            ScrollDownWebPage(profileUpdate);
        }
        public void ClickBenefitClaim()
        {
            Find(benefitClaim).Click();
        }
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideClaimDate(string value)
        {
            ClearAndProvide1(claimDate, value);
        }
       
        public void ProvideBenefitScheme(string value)
        {
            ClearAndProvide1(EmpBenefitScheme, value);

        }
        public void ProvideClaimAmt(string value)
        {
            Find(claimAmount).SendKeys(value);
        }
        
        public void ProvidePaymentType(string value)
        {
            ClearAndProvide1(paymentType, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickOnSave()
        {
            ClickSaveAndBack();
            //ClickSave();
        }
        public bool IsTxnCreated(string emp, string claimAmt)
        {
            if (ResultValue(6).Contains(emp) && ResultValue(8).Contains(claimAmt))
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
