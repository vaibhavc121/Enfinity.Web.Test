using AventStack.ExtentReports.Gherkin.Model;
using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class ExpenseClaimPage : BasePage
    {
        public ExpenseClaimPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By expenseClaim = By.XPath("//span[normalize-space()='Expense Claim']");
        private By newLine = By.XPath("//i[@class='dx-icon dx-icon-new-icon']");
        private By expenseDate = By.XPath("//td[@class=' grid-cell dx-wrap dxgv dx-ellipsis']//div[@class='dxgBCTC dx-ellipsis']");
        private By remarks = By.XPath("//td[contains(@class,'grid-cell hide-error-frame dx-wrap dxgv dx-ellipsis')]//div[@class='dxgBCTC dx-ellipsis']");
        private By expenseClaimCategory = By.XPath("//input[@id='ExpenseClaimLine_ExpenseClaimCategoryId_I']");
        private By expenseClaimLineCurrency = By.XPath("//input[@id='ExpenseClaimLine_CurrencyId_I']");
        private By amount = By.XPath("//td[@class=' grid-cell dx-wrap dxgv dx-ellipsis dx-ar']//div[@class='dxgBCTC dx-ellipsis'][normalize-space()='0']");
        #endregion

        #region action methods
        public void ClickExpenseClaim()
        {
            Find(expenseClaim).Click();
        }

        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }

        public void ClickSave()
        {
            CommonPageActions.ClickSave();
        }
        
        public void ScrollDownWebPage()
        {
            CommonPageActions.ScrollDownWebPage(newLine);
        }

        public void ClickNewLine()
        {
            Find(newLine).Click();
        }
        public void ProvideExpenseDate(string value)
        {
            Find(expenseDate).Click();
            Find(expenseDate).SendKeys(value);
        }

        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickExpenseClaimCategoryDD()
        {
            Find(expenseClaimCategory).Click();
        }
        public void SelectExpenseClaimCategory(string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = BaseTest._driver.FindElements(By.XPath("//div[@class='lookup-text']"));

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
            IList<IWebElement> valuesList = BaseTest._driver.FindElements(By.XPath("//div[@class='lookup-text']"));

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
            CommonPageActions.ClearAndProvide1(amount, value);
        }

        public bool IsTxnCreated()
        {
           return CommonPageActions.IsTxnCreated();
        }
        #endregion


    }
}
