﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Calendar;
using Enfinity.Hrms.Test.UI.Models.HRCore.Employee;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class CreateCalendarTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void verifyCalendarCreation()
        {
            try
            {
                Login(Product);

                var calendarFile = FileHelper.GetDataFile("Hrms", "HRCore", "Calendar", "CalendarData");
                var calendarData = JsonHelper.ConvertJsonListDataModel<CalendarModel>(calendarFile, "createCalendar");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickCalendar();
                Thread.Sleep(2000);

                //calendar page                
                CalendarPage cp = new CalendarPage(_driver);
                foreach(var calendar in calendarData)
                {
                    cp.ClickNewButton();
                    cp.ProvideCalendarName();
                    //cp.ProvideCalendarName(calendar.calendarName);
                    cp.ProvideFromDate(calendar.fromDate);
                    cp.SetWeekoff();
                    cp.SetRestday();
                    cp.ClickSave();
                }
                

                ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
