using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.HRCore.Grade
{
    public class CreateGradeModel
    {
        public string gradeName { get; set; }
        public string minSal { get; set; }
        public string maxSal { get; set; }
    }
    public class DeleteGradeModel
    {
        public string gradeName { get; set; }
        
    }
}
