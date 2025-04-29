using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.Attendance.Attendance
{
    public class ShiftModel
    {
        public string shiftName { get; set; }
        public string defaultTimetable { get; set; }

    }
    public class RosterModel
    {
        public string fromDate { get; set; }
        public string upToDate { get; set; }
        public string excludeDay { get; set; }
        public string applicableFor { get; set; }
    }
}   
