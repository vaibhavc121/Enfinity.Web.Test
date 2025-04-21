using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V130.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class SupportRequestCategoryPage : BasePage
    {
        public SupportRequestCategoryPage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Page Objects/Locators
        private By name = By.Name("Name");        
        private By requestTo = By.XPath("//input[contains(@id,'RequestTo')]");
        private By low = By.XPath("Low");
        private By normal = By.XPath("Normal");
        private By high = By.XPath("//div[text()='High']");
        private By workflow = By.XPath("//input[contains(@id,'WorkflowId')]");
        private By submit = By.XPath("//span[normalize-space()='Submit']");
        private By approve = By.XPath("//span[normalize-space()='Approve']");
        private By description = By.XPath("//textarea[contains(@id,'Description')]");
        #endregion

        #region Action Methods
        public void GlobalSearch1(string expectedValue)
        {
            IWebElement globalSearchInput = WaitForElement(By.Id("GlobalSearch"));
            globalSearchInput.Click();

            IWebElement comboBoxInput = WaitForElement(By.XPath("//input[@role='combobox']"));
            comboBoxInput.SendKeys(expectedValue);

            Thread.Sleep(2000); // Optional:
            driver.FindElement(By.XPath("//i[normalize-space()='Support Request Category']")).Click();
        }

        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideCategoryname(string value)
        {
            Find(name).SendKeys(value);
        }
        public void SelectRequestedTo(string value)
        {
            Find(requestTo).Click();
            SelectDropdownOption(value);
        }
        public void SelectPriority(string value)
        {
            if(value.Contains("High"))
            {
                Find(high).Click();
            }
            else if(value.Contains("Normal"))
            {
                Find(normal).Click();
            }
            else if (value.Contains("Low"))
            {
                Find(low).Click();
            }
            else
            {
                Find(low).Click();
                throw new Exception("VRC- Matching priority not found");
            }
        }
        public void SelectWorkflow(string value)
        {
            ProvideAndEnter(workflow, value);
        }
        public void RequireAttachment(string value)
        {
            if(value.Contains("Submit"))
            {
                Find(submit).Click();
            }
            else if (value.Contains("Approve"))
            {
                Find(approve).Click();
            }
            else
            {
                throw new Exception("VRC- no matching value found");
            }
        }
        public void ProvideDesc(string value)
        {
            Find(description).SendKeys(value);
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }

        public bool IsTransactionCreated(string expDate = null, string expEmp = null, string expStatus = null)
        {
            if (!string.IsNullOrEmpty(expDate))
            {
                FilterDateByIndex(2, expDate);
                Thread.Sleep(2000);
            }

            if (!string.IsNullOrEmpty(expEmp))
            {
                FilterByIndex(2, expEmp);
                Thread.Sleep(2000);
            }

            if (!string.IsNullOrEmpty(expStatus))
            {
                FilterByIndex(7, expStatus);
                Thread.Sleep(2000);
            }

            bool isMatch = true;

            if (!string.IsNullOrEmpty(expDate))
            {
                string actualDate = ResultValue(2);
                isMatch &= actualDate.Contains(expDate);
            }

            if (!string.IsNullOrEmpty(expEmp))
            {
                string actualEmp = ResultValue(1);
                isMatch &= actualEmp.Contains(expEmp);
            }

            if (!string.IsNullOrEmpty(expStatus))
            {
                string actualStatus = ResultValue(7);
                isMatch &= actualStatus.Contains(expStatus);
            }

            return isMatch;
        }

        public void DeleteTransaction(int index, string value)
        {
            FilterByIndex(index, value);
            //IWebElement status= driver.FindElement(By.XPath("(//tr)[11]//td[8]"));
            //status.Click();
            //status.SendKeys("active");
            //driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/table[1]/tbody[1]/tr[2]/td[8]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]")).SendKeys("active");
            //driver.FindElement(By.XPath("(//input[@class='dx-texteditor-input'])[8]")).SendKeys("active");

            Thread.Sleep(2000);
            try
            {
                //need to select row to click on view
                //driver.FindElement(By.XPath("(//tr)[12]//td[2]")).Click();
                WaitForElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]")).Click();
            }
            catch (Exception)
            {
                ClassicAssert.Fail("Vaibhav- There is no active records..");
                //Console.WriteLine("There is no active records: " + e);
                Environment.Exit(1);  // Exits the application with a non-zero status
            }

            ClickEdit();
            Thread.Sleep(5000);
            //driver.FindElement(By.XPath("(//img[@class='dxWeb_mAdaptiveMenu_Office365 dxm-pImage'])[8]")).Click();
            WaitForElement(By.XPath("(//img[@class='dxWeb_mAdaptiveMenu_Office365 dxm-pImage'])[8]")).Click();
            //driver.FindElement(By.XPath("//span[normalize-space()='Delete']")).Click();
            WaitForElement(By.XPath("//span[normalize-space()='Delete']")).Click();
            Thread.Sleep(1000);

            PressKey("enter");
            //driver.Navigate().Back();


        }
        #endregion
    }
}
