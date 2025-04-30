using Enfinity.Hrms.Test.UI.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Pages.Attendance
{
    public class RosterPage : BasePage
    {
        public RosterPage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By fromDate = By.XPath("//input[@id='FromDate_I']");
        private By uptoDate = By.XPath("//input[@id='UptoDate_I']");
        private By timetableIdLookup = By.XPath("//input[@id='TimetableIdLookup_I']");
        private By days = By.XPath("//label[contains(text(),'day')]");
        private By employee = By.XPath("//input[@id='EmployeeIds_I']");
        private By generate = By.XPath("//span[text()='Generate']");
        

        #endregion

        #region Action Methods
        public void ClickNew()
        {
            WaitTS(3);
            ClickOnNew();
        }
        public void SwitchTheTab()
        {
            WaitTS(3);
            SwitchTab();
        }
        public void ProvideFromDate(string value)
        {
            WaitTS(3);
            ClearAndProvide1(fromDate ,value);
        }
        public void ProvideUptoDate(string value)
        {
            ClearAndProvide1(uptoDate, value);
        }
        public void ProvideTimetable(string value)
        {
            ClearAndProvide1(timetableIdLookup, value);
        }        
        public void SelectExcludeDay(string expDay)
        {
            var labels = driver.FindElements(By.XPath("//label[contains(text(),'day')]"));

            for (int i = 0; i < labels.Count; i++)
            {
                if (labels[i].Text.Contains(expDay))
                {
                    // Find the corresponding toggle using the same index
                    var toggleXpath = $"(//span[@class='dxSwitcher dx-not-acc'])[{i + 1}]";
                    driver.FindElement(By.XPath(toggleXpath)).Click();
                    return;
                }
            }

            throw new Exception("No matching day found: " + expDay);
        }
        public void ProvideEmp(string value)
        {
            ClearAndProvide1(employee, value);
        }
        public void ClickOnGenerate()
        {
            Find(generate).Click();            
        }
        public void SwitchTheTab1()
        {
            SwitchTab();
        }
        public void RefreshBrowser()
        {
            BrowserUtils.RefreshPage(driver);
        }

        public bool IsTransactionCreated(string date)
        {
            string expDate= DateUtils.FormattedDateMMM(date);
        
            if(ResultValue(2).Contains(expDate))
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
