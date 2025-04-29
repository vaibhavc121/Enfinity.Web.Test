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
        #endregion

        #region Action Methods
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void SwitchTheTab()
        {
            SwitchTab();
        }
        public void ProvideFromDate(string value)
        {
            Find(fromDate).SendKeys(value);
        }
        public void ProvideUptoDate(string value)
        {
            Find(uptoDate).SendKeys(value);
        }
        public void a()
        {

        }
        public void a()
        {

        }
        public void a()
        {

        }
        #endregion
    }
}
