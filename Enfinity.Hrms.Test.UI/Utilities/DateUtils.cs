using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class DateUtils
    {
        public static string GetCurrentDateTime(string format = "yyyy-MM-dd HH:mm:ss")
        {
            return DateTime.Now.ToString(format);
        }

        public static string GetCurrentDate(string format = "yyyy-MM-dd")
        {
            return DateTime.Now.ToString(format);
        }

        public static string GetCurrentTime(string format = "HH:mm:ss")
        {
            return DateTime.Now.ToString(format);
        }

        public static string AddDaysToCurrentDate(int days, string format = "yyyy-MM-dd")
        {
            return DateTime.Now.AddDays(days).ToString(format);
        }

        public static string SubtractDaysFromCurrentDate(int days, string format = "yyyy-MM-dd")
        {
            return DateTime.Now.AddDays(-days).ToString(format);
        }

        public static string AddMonthsToCurrentDate(int months, string format = "yyyy-MM-dd")
        {
            return DateTime.Now.AddMonths(months).ToString(format);
        }

        public static string AddYearsToCurrentDate(int years, string format = "yyyy-MM-dd")
        {
            return DateTime.Now.AddYears(years).ToString(format);
        }

        public static string GetDayOfWeek()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        public static string FormatDate(string date, string inputFormat, string outputFormat)
        {
            DateTime parsedDate = DateTime.ParseExact(date, inputFormat, CultureInfo.InvariantCulture);
            return parsedDate.ToString(outputFormat);
        }
    }
}
