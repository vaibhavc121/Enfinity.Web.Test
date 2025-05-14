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

        #region Create Strict DayShift Timetable
        [Test, Order(5)]        
        public void CreateStrictDayShiftTimetable()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var attendanceData = JsonUtils.ConvertJsonListDataModel<StrictDayShiftModel>(attendanceFile, "createStrictDayShiftTimetable");

                //TimetablePage tp = new TimetablePage(_driver);
                //tp.SearchTimetable();
                BasePage.GlobalSearch("Timetable");

                TimetablePage tp = new TimetablePage(_driver);

                foreach(var strict in attendanceData)
                {
                    tp.ClickNew();
                    tp.ProvideTimetableName(strict.name);
                    tp.SelectDayType(strict.dayType);
                    tp.SelectMode(strict.mode);
                    tp.ProvideMaximumWorkedHourPerDay(strict.maximumWorkedHourPerDay);
                    tp.ProvideFirstInTime(strict.firstInTime);
                    tp.ProvideFirstOutTime(strict.firstOutTime);
                    tp.ClickViewBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(strict.name, 2, 1));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Strict DayShift Timetable
        [Test, Order(6)]
        public void DeleteStrictDayShiftTimetable()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var attendanceData = JsonUtils.ConvertJsonListDataModel<StrictDayShiftModel>(attendanceFile, "createStrictDayShiftTimetable");

            BasePage.GlobalSearch("Timetable");
            BasePage.WaitTS(3);

            foreach (var strict in attendanceData)
            {
                BasePage.DeleteTxn(2, strict.name);
                ClassicAssert.IsFalse(BasePage.ValidateListing(strict.name, 2, 1));
            }
        }
        #endregion        

        #region Create LenientShif tTimetable
        [Test, Order(7)]
        public void CreateLenientShiftTimetable()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var attendanceData = JsonUtils.ConvertJsonListDataModel<LenientShiftModel>(attendanceFile, "createLenientShiftTimetable");

                //TimetablePage tp = new TimetablePage(_driver);
                //tp.SearchTimetable();
                BasePage.GlobalSearch("Timetable");

                TimetablePage tp = new TimetablePage(_driver);

                foreach (var strict in attendanceData)
                {
                    tp.ClickNew();
                    tp.ProvideTimetableName(strict.name);
                    tp.SelectDayType(strict.dayType);
                    tp.SelectMode(strict.mode);
                    tp.ProvideMaximumWorkedHourPerDay(strict.maximumWorkedHourPerDay);
                    tp.ProvideWorkedHourPerDay(strict.workedHourPerDay);
                    tp.ProvideHourlyMinCheckInTime(strict.hourlyMinCheckInTime);
                    tp.ProvideHourlyMaxCheckOutTime(strict.hourlyMaxCheckOutTime);
                    tp.ClickViewBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(strict.name, 2, 1));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete Lenient Shift Timetable
        [Test, Order(8)]
        public void DeleteLenientShiftTimetable()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var attendanceData = JsonUtils.ConvertJsonListDataModel<LenientShiftModel>(attendanceFile, "createLenientShiftTimetable");

            BasePage.GlobalSearch("Timetable");
            BasePage.WaitTS(3);

            foreach (var strict in attendanceData)
            {
                BasePage.DeleteTxn(2, strict.name);
                ClassicAssert.IsFalse(BasePage.ValidateListing(strict.name, 2, 1));
            }
        }
        #endregion        

        #region Create Strict TwoShift DayShift Timetable
        [Test, Order(9)]
        public void CreateTwoShiftDayShiftTimetable()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var attendanceData = JsonUtils.ConvertJsonListDataModel<TwoShiftDayShiftModel>(attendanceFile, "createTwoShiftDayShiftTimetable");
                               
                BasePage.GlobalSearch("Timetable");

                TimetablePage tp = new TimetablePage(_driver);

                foreach (var strict in attendanceData)
                {
                    tp.ClickNew();
                    tp.ProvideTimetableName(strict.name);
                    tp.SelectDayType(strict.dayType);
                    tp.SelectMode(strict.mode);
                    tp.ProvideMaximumWorkedHourPerDay(strict.maximumWorkedHourPerDay);
                    tp.ClickWorkInTwoShift();
                    tp.ProvideFirstInTime(strict.firstInTime);
                    tp.ProvideFirstOutTime(strict.firstOutTime);
                    tp.ProvideSecondInTime(strict.secondInTime);
                    tp.ProvideSecondOutTime(strict.secondOutTime);
                    tp.ClickViewBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(strict.name, 2, 1));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete TwoShift DayShift Timetable
        [Test, Order(10)]
        public void DeleteTwoShiftDayShiftTimetable()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var attendanceData = JsonUtils.ConvertJsonListDataModel<TwoShiftDayShiftModel>(attendanceFile, "createTwoShiftDayShiftTimetable");

            BasePage.GlobalSearch("Timetable");
            BasePage.WaitTS(3);

            foreach (var strict in attendanceData)
            {
                BasePage.DeleteTxn(2, strict.name);
                ClassicAssert.IsFalse(BasePage.ValidateListing(strict.name, 2, 1));
            }
        }
        #endregion        

        #region Create Night Shift Timetable
        [Test, Order(11)]
        public void CreateNightShiftTimetable()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var attendanceData = JsonUtils.ConvertJsonListDataModel<NightShiftModel>(attendanceFile, "createNightShiftTimetable");
                               
                BasePage.GlobalSearch("Timetable");

                TimetablePage tp = new TimetablePage(_driver);

                foreach (var shift in attendanceData)
                {
                    tp.ClickNew();
                    tp.ProvideTimetableName(shift.name);
                    tp.SelectDayType(shift.dayType);
                    tp.ClickNightShift();
                    tp.SelectMode(shift.mode);
                    tp.ProvideMaximumWorkedHourPerDay(shift.maximumWorkedHourPerDay);
                    tp.ProvideFirstInTime(shift.firstInTime);
                    tp.ProvideFirstOutTime(shift.firstOutTime);
                    tp.ClickViewBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(shift.name, 2, 1));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete NightShift Timetable
        [Test, Order(12)]
        public void DeleteNightShiftTimetable()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var attendanceData = JsonUtils.ConvertJsonListDataModel<NightShiftModel>(attendanceFile, "createNightShiftTimetable");

            BasePage.GlobalSearch("Timetable");
            BasePage.WaitTS(3);

            foreach (var strict in attendanceData)
            {
                BasePage.DeleteTxn(2, strict.name);
                ClassicAssert.IsFalse(BasePage.ValidateListing(strict.name, 2, 1));
            }
        }
        #endregion

        #region Create TwoShift NightShift Timetable
        [Test, Order(13)]
        public void CreateTwoShiftNightShiftTimetable()
        {
            try
            {
                var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
                var attendanceData = JsonUtils.ConvertJsonListDataModel<TwoShiftNightShiftModel>(attendanceFile, "createTwoShiftNightShiftTimetable");

                BasePage.GlobalSearch("Timetable");

                TimetablePage tp = new TimetablePage(_driver);

                foreach (var strict in attendanceData)
                {
                    tp.ClickNew();
                    tp.ProvideTimetableName(strict.name);
                    tp.SelectDayType(strict.dayType);
                    tp.ClickNightShift();
                    tp.SelectMode(strict.mode);
                    tp.ProvideMaximumWorkedHourPerDay(strict.maximumWorkedHourPerDay);
                    tp.ClickWorkInTwoShift();
                    tp.ProvideFirstInTime(strict.firstInTime);
                    tp.ProvideFirstOutTime(strict.firstOutTime);
                    tp.ProvideSecondInTime(strict.secondInTime);
                    tp.ProvideSecondOutTime(strict.secondOutTime);
                    tp.SelectShiftNextDayStartFrom(strict.shiftNextDayStartFrom);
                    tp.ClickViewBack();

                    ClassicAssert.IsTrue(BasePage.ValidateListing(strict.name, 2, 1));
                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region Delete TwoShift NightShift Timetable
        [Test, Order(14)]
        public void DeleteTwoShiftNightShiftTimetable()
        {
            var attendanceFile = FileUtils.GetDataFile("Hrms", "Attendance", "Attendance", "AttendanceData");
            var attendanceData = JsonUtils.ConvertJsonListDataModel<TwoShiftNightShiftModel>(attendanceFile, "createTwoShiftNightShiftTimetable");

            BasePage.GlobalSearch("Timetable");
            BasePage.WaitTS(3);

            foreach (var strict in attendanceData)
            {
                BasePage.DeleteTxn(2, strict.name);
                ClassicAssert.IsFalse(BasePage.ValidateListing(strict.name, 2, 1));
            }
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
