using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Pages.Attendance
{
    public class AttendancePage : BasePage
    {
        public AttendancePage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By attendance = By.XPath("//span[normalize-space()='Attendance']");
        private By shift = By.XPath("//a[@title='Shift']//span[@class='dx-vam'][normalize-space()='Shift']");
        private By roster = By.XPath("//a[@title='Roster']//span[@class='dx-vam'][normalize-space()='Roster']");
        #endregion

        #region Action Methods
        public void ClickAttendance()
        {
            Find(attendance).Click();
        }
        public void ClickShift()
        {
            Find(shift).Click();
        }
        public void ClickRoster()
        {
            Find(roster).Click();
        }
        #endregion
    }
}
