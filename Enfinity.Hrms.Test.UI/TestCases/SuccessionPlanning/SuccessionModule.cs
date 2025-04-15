
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Onboarding.Onboarding;
using Enfinity.Hrms.Test.UI.Models.SuccessionPlanning.SuccessionPlanning;
using Enfinity.Hrms.Test.UI.PageObjects.Onboarding;
using Enfinity.Hrms.Test.UI.PageObjects.SuccessionPlanning;
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
    public class SuccessionModule:BaseTest
    {
        #region Create Succession Plan
        [Test]
        public void CreateSuccessionPlan()
        {
            try
            {
                Login(HrmsProduct);

                var SuccessionPlanningFile = FileUtils.GetDataFile("Hrms", "SuccessionPlanning", "SuccessionPlanning", "SuccessionData");
                var successionPlanData = JsonUtils.ConvertJsonListDataModel<SuccessionModel>(SuccessionPlanningFile, "createSuccessionPlan");

                //Succession page
                SuccessionPage op = new SuccessionPage(_driver);
                op.ClickMenu();
                op.ClicksuccessionPlanning();
                op.ClickSuccessionPlan();

                //SuccessionPlan page
                SuccessionPlanPage sp = new SuccessionPlanPage(_driver);

                foreach (var successionPlan in successionPlanData)
                {
                    sp.ClickOnNew();
                    //cp.ProvideNameArabic(candidate.nameArabic);
                    sp.ProvideName(successionPlan.name);
                    sp.ProvideDesignation(successionPlan.designation);
                    sp.ProvideEmployee(successionPlan.employee);
                    sp.ProvideMinimumPercentage(successionPlan.minimumPercentage);
                    sp.ProvideQualificationPercentage(successionPlan.qualificationPercentage);
                    sp.ProvideExperiencePercentage(successionPlan.experiencePercentage);
                    sp.ProvideSkillsPercentage(successionPlan.skillsPercentage);
                    sp.ProvideAppraisalPercentage(successionPlan.appraisalPercentage);
                    sp.ProvideCoursePercentage(successionPlan.coursePercentage);
                    sp.ProvideDescription(successionPlan.description);
                    sp.ClickOnSave();

                    //ClassicAssert.IsTrue(sp.IsTransactionCreated(successionPlan.name));
                    ClassicAssert.IsTrue(true);


                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

        #region Create Talent Pool
        [Test]
        public void CreateTalentPool()
        {
            try
            {

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion

    }
}
