using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

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

        //2 shift
        private By secondInTime = By.XPath("//input[@id='Timetable.SecondInTime_I']");
        private By secondOutTime = By.XPath("//input[@id='Timetable.SecondOutTime_I']");
        private By shiftNextDayStartFromSpe = By.XPath("//input[@id='Timetable.ShiftNextDayStartFrom_I']");

        //Lenient Mode
        private By workedHourPerDay = By.XPath("//input[@id='Timetable.WorkedHourPerDay_I']");
        private By hourlyMinCheckInTime = By.XPath("//input[@id='Timetable.HourlyMinCheckInTime_I']");
        private By hourlyMaxCheckOutTime = By.XPath("//input[@id='Timetable.HourlyMaxCheckOutTime_I']");
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
            WaitTS(2);

        }
        public void ProvideMaximumWorkedHourPerDay(string value)
        {
            ClearAndProvide(maximumWorkedHourPerDay, value);
            
        }
        public void ClickWorkInTwoShift()
        {
            Find(workInTwoShift).Click();
            WaitTS(2);
        }
        public void ProvideFirstInTime(string value)
        {
            ClearAndProvide1(firstInTime, value);
        }
        public void ProvideFirstOutTime(string value)
        {
            ClearAndProvide1(firstOutTime, value);
        }

        //2 shift
        public void ProvideSecondInTime(string value)
        {
            ClearAndProvide1(secondInTime, value);
        }
        public void ProvideSecondOutTime(string value)
        {
            ClearAndProvide1(secondOutTime, value);
        }
        public void SelectShiftNextDayStartFrom(string value)
        {
            Find(shiftNextDayStartFromSpe).Click();
            SelectDropdownValueOffice365(value);
        }

        //Lenient Mode
        public void ProvideWorkedHourPerDay(string value)
        {
            ClearAndProvide1(workedHourPerDay, value);
        }
        public void ProvideHourlyMinCheckInTime(string value)
        {
            ClearAndProvide1(hourlyMinCheckInTime, value);
        }       
        public void ProvideHourlyMaxCheckOutTime(string value)
        {
            ClearAndProvide1(hourlyMaxCheckOutTime, value);
        }
        public void ClickViewBack()
        {           
            ClickViewAndBack();            
        }
       

        #endregion
    }
}
