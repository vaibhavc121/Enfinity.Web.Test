using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Models.Learning.Learning
{
    public class CourseModel
    {
        public string courseName { get; set; }
        public string category { get; set; }
        public string mode { get; set; }
        public string courseTrainer { get; set; }
        public string type { get; set; }
        public string enroller { get; set; }
        public List<Skill> Skills { get; set; }
        public class Skill
        {
            public string SkillName { get; set; }
            public string Level { get; set; }
            public string Weightage { get; set; }
        }
        public string batchName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

    }
    
}
