using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Learning.Learning;
using Enfinity.Hrms.Test.UI.Models.SelfService.ExpenseClaim;
using Enfinity.Hrms.Test.UI.PageObjects.Learning;
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
    public class LearningModule:BaseTest
    {
        public string Product = "Hrms";

        #region Create Course
        [Test]
        public void CreateCourse()
        {
            try
            {
                Login(Product);

                var LearningFile = FileHelper.GetDataFile("Hrms", "Learning", "Learning", "LearningData");
                var courseData = JsonHelper.ConvertJsonListDataModel<CourseModel>(LearningFile, "createCourse");

                //learning page
                LearningPage lp = new LearningPage(_driver);
                lp.ClickLearning();
                lp.ClickCourse();

                //course page
                CoursePage cp  = new CoursePage(_driver);

                foreach(var course in courseData)
                {
                    cp.ClickNew();
                    cp.ProvideCourseName(course.courseName);
                    cp.ProvideCategory(course.category);
                    cp.ProvideMode(course.mode);
                    cp.ProvideCourseTrainer(course.courseTrainer);
                    cp.ProvideType(course.type);
                    cp.ProvideEnroller(course.enroller);

                    int iteration = 1;
                    foreach(var skill in course.Skills)
                    {
                        cp.ClickAddSkillsBtn();
                        if(iteration ==1)
                        {
                            cp.ProvideSkillName1(skill.SkillName);
                            cp.ProvideLevel1(skill.Level);
                            cp.ProvideWeightage1(skill.Weightage);
                        }
                        if (iteration == 2)
                        {
                            cp.ProvideSkillName2(skill.SkillName);
                            cp.ProvideLevel2(skill.Level);
                            cp.ProvideWeightage2(skill.Weightage);
                        }
                        if (iteration == 3)
                        {
                            cp.ProvideSkillName3(skill.SkillName);
                            cp.ProvideLevel3(skill.Level);
                            cp.ProvideWeightage3(skill.Weightage);
                        }

                        iteration++;

                    }
                    
                }


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion
    }
}
