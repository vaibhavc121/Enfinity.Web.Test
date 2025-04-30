using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Enfinity.Hrms.Test.UI.Pages.Attendance
{
    public class TimetablePage : BasePage
    {
        public TimetablePage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By name = By.XPath("//input[@id='Timetable.Name_I']");
        private By dayType= By.XPath("//input[@id='Timetable.DayType_I']");
        private By nightShift = By.XPath("//span[@id='Timetable.NightShift_S_D']");
        private By mode = By.XPath("//input[@id='Timetable.TimetableType_I']");
        private By maximumWorkedHourPerDay = By.XPath("//input[@id='Timetable.MaximumWorkedHourPerDay_I']");
        private By workInTwoShift = By.XPath("//span[@id='Timetable.WorkInTwoShift_S_D']");
        private By firstInTime = By.XPath("//input[@id='Timetable.FirstInTime_I']");
        private By firstOutTime = By.XPath("//input[@id='Timetable.FirstOutTime_I']");
        #endregion

        #region Action Methods

        public void ClickNew()
        {
            ClickOnNew();
        }
        public void ProvideTimetableName(string value)
        {
            ClearAndProvide1(name, value);
        }
        public void SelectDayType(string value)
        {
            Find(dayType).Click();
            SelectDropdownValueOffice365(value);
        }
        public void ClickNightShift()
        {
            Find(nightShift).Click();
        }
        public void SelectMode(string value)
        {
            Find(mode).Click();
            SelectDropdownValueOffice365(value);

        }
        public void ProvideMaximumWorkedHourPerDay(string value)
        {
            ClearAndProvide1(maximumWorkedHourPerDay, value);
        }
        public void ClickWorkInTwoShift()
        {
            Find(workInTwoShift).Click();
        }
        public void ProvideFirstInTime(string value)
        {
            ClearAndProvide1(firstInTime, value);
        }
        public void ProvideFirstOutTime(string value)
        {
            ClearAndProvide1(firstOutTime, value);
        }
        public void a()
        {

        }

        #endregion
    }
}
