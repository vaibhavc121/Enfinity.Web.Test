using AventStack.ExtentReports.Gherkin.Model;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class BusinessTripClaimPage : BasePage
    {
        public BusinessTripClaimPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By businessTripClaim = By.XPath("//span[normalize-space()='Business Trip Claim']");
        private By newLine = By.XPath("//i[@class='dx-icon dx-icon-new-icon']");
        private By expenseDate = By.XPath("(//div[@class='dxgBCTC dx-ellipsis'])[1]"); 
        private By remarks = By.XPath("//td[contains(@class,'grid-cell hide-error-frame dx-wrap dxgv dx-ellipsis')]//div[@class='dxgBCTC dx-ellipsis']");
        private By expenseClaimCategory = By.XPath("(//div[@class='dxgBCTC dx-ellipsis'])[3]");
        private By expenseClaimLineCurrency = By.XPath("//input[@id='ExpenseClaimLine_CurrencyId_I']");
        private By amount = By.XPath("(//div[@class='dxgBCTC dx-ellipsis'])[6]");
        #endregion

        #region action methods
        public void ClickBusinessTripClaim()
        {
            Find(businessTripClaim).Click();
        }

        public void ClickNew()
        {
            ClickOnNew();
        }

        public void ClickSave()
        {
            ClickOnSave();
        }
        
        public void ScrollDownWebPage()
        {
            ScrollDownWebPage(newLine);
        }

        public void ClickNewLine()
        {
            Find(newLine).Click();
        }
        public void ProvideExpenseDate(string value)
        {
            ClearAndProvide1(expenseDate, value);
        }

        public void ProvideRemarks(string value)
        {
            //IWebElement inputField = driver.FindElement(By.XPath("//td[contains(@class,'grid-cell hide-error-frame dx-wrap dxgv dx-ellipsis')]//div[@class='dxgBCTC dx-ellipsis']"));
            ClearAndProvide1(remarks, value);
            
        }
        public void ProvideExpenseClaimCategory(string value)
        {
            ClearAndProvide1(expenseClaimCategory, value);
        }
        public void ClickExpenseClaimCategoryDD()
        {
            Find(expenseClaimCategory).Click();
        }
        public void SelectExpenseClaimCategory(string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = driver.FindElements(By.XPath("//div[@class='lookup-text']"));

            foreach (var valueElement in valuesList)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(value))
                {
                    valueElement.Click();
                    break;
                }
            }
        }

        public void ProvideCurrency(string value)
        {
            Find(expenseClaimLineCurrency).Click();
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = driver.FindElements(By.XPath("//div[@class='lookup-text']"));

            foreach (var valueElement in valuesList)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(value))
                {
                    valueElement.Click();
                    break;
                }
            }
        }
        public void ProvideAmount(string value) 
        {
            ClearAndProvide1(amount, value);
        }

        public bool IsTxnCreated()
        {
           return IsTransactionCreated();
        }
        #endregion


    }
}
