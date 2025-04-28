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
        #region 
        [Test]
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
                    sp.ClickOnNew();
                    sp.ProvideShiftName(shift.shiftName);
                    sp.ProvideDefaultTimetable(shift.defaultTimetable);
                    sp.ClickSaveBack();

                    ClassicAssert.IsTrue(sp.IsTransactionCreated(shift.shiftName));
                }
                


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("VRC- Test case failed: " + e);

            }
        }
        #endregion

        #region 
        [Test]
        public void DeleteShift()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test3()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test4()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test5()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test6()
        {

        }
        #endregion


    }
}
