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
        public string timetable { get; set; }
        public string excludeDay { get; set; }
        public string applicableFor { get; set; }
    }
    public class StrictDayShiftModel
    {
        public string name { get; set; }
        public string dayType { get; set; }
        public string mode { get; set; }
        public string maximumWorkedHourPerDay { get; set; }
        public string firstInTime { get; set; }
        public string firstOutTime { get; set; }
    }
    public class LenientShiftModel 
    {
        public string name { get; set; }
        public string dayType { get; set; }
        public string mode { get; set; }
        public string maximumWorkedHourPerDay { get; set; }
        public string workedHourPerDay { get; set; }
        public string hourlyMinCheckInTime { get; set; }
        public string hourlyMaxCheckOutTime { get; set; }
    }
    public class TwoShiftDayShiftModel
    {
        public string name { get; set; }
        public string dayType { get; set; }
        public string mode { get; set; }
        public string maximumWorkedHourPerDay { get; set; }
        public string firstInTime { get; set; }
        public string firstOutTime { get; set; }
        public string secondInTime { get; set; }
        public string secondOutTime { get; set; }
    }
    public class NightShiftModel
    {
        public string name { get; set; }
        public string dayType { get; set; }
        public string mode { get; set; }
        public string maximumWorkedHourPerDay { get; set; }
        public string firstInTime { get; set; }
        public string firstOutTime { get; set; }
    }

    public class TwoShiftNightShiftModel
    {
        public string name { get; set; }
        public string dayType { get; set; }
        public string mode { get; set; }
        public string maximumWorkedHourPerDay { get; set; }
        public string firstInTime { get; set; }
        public string firstOutTime { get; set; }
        public string secondInTime { get; set; }
        public string secondOutTime { get; set; }
        public string shiftNextDayStartFrom { get; set; }
    }
}   
