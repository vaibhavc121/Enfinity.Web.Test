using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V130.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Pages.Attendance
{
    public class ShiftPage : BasePage
    {
        public ShiftPage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By name = By.XPath("//input[@id='Shift.Name_I']");
        private By DefaultTimetableIdLookup = By.XPath("//input[@id='Shift.DefaultTimetableIdLookup_I']");
        #endregion

        #region Action Methods
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideShiftName(string value)
        {
            Find(name).SendKeys(value);
        }
        public void ProvideDefaultTimetable(string value)
        {
            ClearAndProvide1(DefaultTimetableIdLookup, value);
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }
        public bool IsTransactionCreated(string expShift)
        {
            FilterByIndex(2, expShift);

            if(ResultValue(1).Contains(expShift))
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
