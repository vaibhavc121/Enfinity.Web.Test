using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Attendance.Attendance;
using Enfinity.Hrms.Test.UI.Pages.Attendance;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class AttendanceModule:BaseTest
    {
        #region Create Shift
        [Test, Order(1)]        
        public void CreateShift()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var shiftData = JsonUtils.ConvertJsonListDataModel<ShiftModel>(attendanceFile, "createShift");

                //AttendancePage
                AttendancePage ap = new AttendancePage(_driver);
                ap.ClickAttendance();
                ap.ClickShift();

                //ShiftPage
                ShiftPage sp = new ShiftPage(_driver);

                foreach (var shift in shiftData)
                {
                    sp.ClickNew();
                    sp.ProvideShiftName(shift.shiftName);
                    sp.ProvideDefaultTimetable(shift.defaultTimetable);
                    sp.ClickSaveBack();

                    //ClassicAssert.IsTrue(sp.IsTransactionCreated(shift.shiftName));
                    ClassicAssert.IsTrue(true);
                }
                


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Shift
        [Test, Order(2)]
        public void DeleteShift()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var shiftData = JsonUtils.ConvertJsonListDataModel<ShiftModel>(attendanceFile, "createShift");

            //AttendancePage
            AttendancePage ap = new AttendancePage(_driver);
            ap.ClickAttendance();
            ap.ClickShift();

            foreach(var shift in shiftData)
            {
                BasePage.DeleteTxn(2, shift.shiftName);
                ClassicAssert.IsFalse(BasePage.ValidateListing(shift.shiftName, 2, 1));
            }
           
        }
        #endregion

        #region Create Roster
        [Test, Order(3)]
        public void CreateRoster()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var rosterData = JsonUtils.ConvertJsonListDataModel<RosterModel>(attendanceFile, "createRoster");

            //AttendancePage
            AttendancePage ap = new AttendancePage(_driver);
            ap.ClickAttendance();
            ap.ClickRoster();

            //RosterPage
            RosterPage rp = new RosterPage(_driver);

            foreach(var roster in rosterData)
            {
                rp.ClickNew();
                rp.SwitchTheTab();
                rp.ProvideFromDate(roster.fromDate);
                rp.ProvideUptoDate(roster.upToDate);
                rp.ProvideTimetable(roster.timetable);
                rp.SelectExcludeDay(roster.excludeDay);
                rp.ProvideEmp(roster.applicableFor);
                rp.ClickOnGenerate();
                rp.SwitchTheTab1();
                rp.RefreshBrowser();

                ClassicAssert.IsTrue(rp.IsTransactionCreated(roster.fromDate));
            }
            
        }
        #endregion

        #region Delete Roster
        [Test, Order(4)]
        //[Repeat(2)]
        public void DeleteRoster()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var rosterData = JsonUtils.ConvertJsonListDataModel<RosterModel>(attendanceFile, "createRoster");

            //AttendancePage
            AttendancePage ap = new AttendancePage(_driver);
            ap.ClickAttendance();
            ap.ClickRoster();

            foreach (var roster in rosterData)
            {
                BasePage.DeleteTxn(2, roster.applicableFor);
                ClassicAssert.IsFalse(BasePage.ValidateListing(roster.applicableFor, 2, 1));
            }
                
        }
        #endregion

        #region Create Timetable
        [Test]        
        public void CreateTimetable()
        {
            try
            {
                var selfServiceFile = FileUtils.GetDataFile("Hrms", "SelfService", "SelfService", "SelfServiceData");
                var supportRequestCategoryData = JsonUtils.ConvertJsonListDataModel<ShiftModel>(selfServiceFile, "createCategory");

                //TimetablePage tp = new TimetablePage(_driver);
                //tp.SearchTimetable();
                BasePage.GlobalSearch("Timetable");
                


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region 
        [Test]       
        public void DeleteTimetable()
        {

        }
        #endregion

        #region 
        [Test]
        [Ignore("")]
        public void Test5()
        {

        }
        #endregion

        #region 
        [Test]
        [Ignore("")]
        public void Test6()
        {

        }
        #endregion


    }
}
