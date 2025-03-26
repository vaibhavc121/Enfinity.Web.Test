using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.HRCore.Calendar
{
    public class CreateCalendarModel
    {
        public string calendarName { get; set; }
        public string fromDate { get; set; }
    }
    public class DeleteCalendarModel
    {
        public string calendarName { get; set; }
        
    }
}
