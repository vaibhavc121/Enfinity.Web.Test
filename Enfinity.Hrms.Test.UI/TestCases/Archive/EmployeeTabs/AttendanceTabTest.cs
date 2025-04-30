
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Employee;
using Enfinity.Hrms.Test.UI.Utilities;
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
    public class AttendanceTabTest:BaseTest
    {
        public string Product = "Hrms";
        //[Test]
        [Ignore ("")]
        public void VerifyAttendanceTab()
        {
            try
            {
                

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var attendanceInfo = JsonUtils.ConvertJsonListDataModel<AttendanceTabModel>(employeeFile, "attendance");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                BasePage.NavigateToEmployee("188");
                BasePage.SwitchTab();

                //attendance tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var attendance in attendanceInfo)
                {
                    ep.ClickAttendance();
                    ep.ClickAttendanceCalendar();
                    ep.SelectAttendanceCalendar(attendance.calendar);
                    ep.EnablePresentByDefault();
                    ep.ClickCheckInType();
                    ep.SelectCheckInType(attendance.checkInType);
                    ep.ClickDefaultShift();
                    ep.SelectDefaultShift(attendance.defaultShift);
                    ep.ClickPolicy();
                    ep.SelectPolicy(attendance.policy);
                    ep.ClickShiftPreference();
                    ep.SelectShiftPreference(attendance.shiftPreference);
                    BasePage.ClickOnSave();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
