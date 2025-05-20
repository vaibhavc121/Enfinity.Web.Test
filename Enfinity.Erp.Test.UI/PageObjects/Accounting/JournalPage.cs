using Enfinity.Common.Test;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class JournalPage
    {
        private readonly IWebDriver _driver;
        public JournalPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Transactions
        private By journal = By.XPath("//span[normalize-space()='Journal']");
        private By expense = By.XPath("//span[normalize-space()='Expense']");
        private By receipt = By.XPath("//span[normalize-space()='Receipt']");
        private By payment = By.XPath("//span[normalize-space()='Payment']");
        #endregion

        #region Journal Line Locators
        private By account = By.XPath("//td[@id='JournalLine_AccountId_B-1']");
        private By drcr = By.XPath("(//div[contains(@class, 'dxgBCTC') and contains(@class, 'dx-ellipsis')])[4]");
        private By drCr = By.XPath("(//div[contains(@id, 'JournalLine_DXBEC5')])");
        private By enteredAmount = By.XPath("(//div[contains(@class, 'dxgBCTC') and contains(@class, 'dx-ellipsis')])[5]");
        #endregion

        #endregion

        #region Action Methods

        #region Transactions
        public void ClickOnJournal()
        {
            _driver.FindElement(journal).Click();
        }
        public void ClickOnExpense()
        {
            _driver.FindElement(expense).Click();
        }
        public void ClickOnReceipt()
        {
            _driver.FindElement(receipt).Click();
        }
        public void ClickOnPayment()
        {
            _driver.FindElement(payment).Click();
        }
        #endregion

        #region Journal Line Action Methods
        public void ClickOnAccount()
        {
            _driver.FindElement(account).Click();
        }
        public void ClickOnDrCr()
        {
            _driver.FindElement(drcr).Click();
        }        
        public void SelectDebitCreditValue(string data)
        {            
            _driver.FindElement(drCr).Click();
            IWebElement option = BaseTest._wait.Until(driver => driver.FindElement(By.XPath($"//table[contains(@id, 'JournalLine_DXEditor5')]//td[text()='{data}']")));           
            option.Click();
        }
        public void ProvideEnteredAmount(string data)
        {            
            CommonPageActions.ClearAndProvideValue(By.XPath("(//div[contains(@class, 'dxgBCTC') and contains(@class, 'dx-ellipsis')])[5]"), data);
        }       
        #endregion

        #region Transaction form related Action Methods
        public void ProvideReference(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("//input[contains(@id, 'ReferenceNum')]"), data);
        }
        public void ProvideRemarks(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("//textarea[contains(@id, 'Description')]"), data);
        }
        #endregion

        #endregion
    }
}
