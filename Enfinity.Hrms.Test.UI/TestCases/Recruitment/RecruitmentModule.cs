using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Learning.Learning;
using Enfinity.Hrms.Test.UI.Models.Recruitment.Recruitment;
using Enfinity.Hrms.Test.UI.PageObjects.Learning;
using Enfinity.Hrms.Test.UI.PageObjects.Recruitment;
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
    public class RecruitmentModule:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void CreateJob()
        {
            try
            {
                Login(Product);

                var RecruitmentFile = FileHelper.GetDataFile("Hrms", "Recruitment", "Recruitment", "RecruitmentData");
                var jobData = JsonHelper.ConvertJsonListDataModel<JobModel>(RecruitmentFile, "createJob");

                //Recruitment page
                RecruitmentPage rp = new RecruitmentPage(_driver);
                rp.ClickRecruitment();
                rp.ClickJob();

                //job page
                JobPage jp = new JobPage(_driver);

                foreach(var job in jobData)
                {
                    jp.ClickOnNew();
                    jp.ProvideJobTitle(job.jobTitle);
                    jp.ProvideDepartment(job.department);
                    jp.ProvideDesignation(job.designation);
                    jp.ProvideNumberOfPosition(job.numberOfPosition);
                    jp.ProvideEmploymentType(job.employmentType);
                    jp.ProvideIndustry(job.Industry);
                    jp.ProvideTargetDate(job.TargetDate);
                    jp.ProvideMonthlySal(job.MonthlySal);
                    jp.ProvideAssignedManager(job.assignedManager);
                    jp.ProvideAssignedRecruiter(job.assignedRecruiter);
                    jp.ProvideWorkExperience(job.workExperience);
                    jp.ProvideSkills(job.skills);
                    jp.ProvideCity(job.city);
                    jp.ProvideState(job.state);
                    jp.ProvideCountry(job.country);
                    jp.ProvidePostalCode(job.postalCode);
                    jp.ProvideGender(job.gender);
                    jp.ProvideMaritalStatus(job.maritalStatus);
                    jp.ProvideNationality(job.nationality);
                    jp.ClickOnSave();

                    ClassicAssert.IsTrue(jp.IsTxnCreated(job.jobTitle));

                }
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }

        #region 
        [Test]
        public void Test()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test2()
        {

        }
        #endregion

        #region 
        [Test]
        public void Test3()
        {

        }
        #endregion

        
        
    }
}
