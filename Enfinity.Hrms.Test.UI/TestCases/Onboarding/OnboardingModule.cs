
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Onboarding.Onboarding;
using Enfinity.Hrms.Test.UI.Models.Recruitment.Recruitment;
using Enfinity.Hrms.Test.UI.PageObjects.Onboarding;
using Enfinity.Hrms.Test.UI.PageObjects.Recruitment;
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
    public class OnboardingModule:BaseTest
    {
        [Test]
        public void CreateCandidate()
        {
            try
            {
                

                var OnboardingFile = FileUtils.GetDataFile("Hrms", "Onboarding", "Onboarding", "OnboardingData");
                var candidateData = JsonUtils.ConvertJsonListDataModel<CandidateModel>(OnboardingFile, "createCandidate");

                //Onboarding page
                OnboardingPage op = new OnboardingPage(_driver);
                op.ClickMenu();
                op.ClickOnboarding();
                op.ClickCandidate();

                //candidate page
                CandidatePage cp = new CandidatePage(_driver);

                foreach(var candidate in candidateData)
                {
                    cp.ClickOnNew();
                    cp.ProvideName();
                    //cp.ProvideNameArabic(candidate.nameArabic);
                    cp.ProvideEmail();
                    cp.ProvideMbl(candidate.mobileNumber);
                    cp.ProvideDOB(candidate.dateOfBirth);
                    cp.ProvideGender(candidate.gender);
                    cp.ProvideMaritalStatus(candidate.maritalStatus);
                    cp.ProvideCity(candidate.city);
                    cp.ProvideState(candidate.state);
                    cp.ProvideCountry(candidate.country);
                    cp.ProvidePostalCode(candidate.postalCode);
                    cp.ProvideWorkExperienceInYear(candidate.workExperienceInYear);
                    cp.ProvideCurrentJobTitle(candidate.currentJobTitle);
                    cp.ProvideCurrentEmployer(candidate.currentEmployer);
                    cp.ProvideSkills(candidate.skills);
                    cp.ProvideCurrentSalary(candidate.currentSalary);
                    cp.ProvideExpectedSalary(candidate.expectedSalary);
                    cp.ProvideNoticePeriodInDays(candidate.noticePeriodInDays);
                    cp.ProvidePassportNumber(candidate.passportNumber);
                    cp.ProvidePassportIssueDate(candidate.passportIssueDate);
                    cp.ProvidePassportExpiryDate(candidate.passportExpiryDate);
                    cp.ProvideVisaType(candidate.visaType);
                    cp.ProvideCivilIdNumber(candidate.civilIdNumber);
                    cp.ClickAddQualification();
                    cp.ProvideUniversity(candidate.university);
                    cp.ProvideAcademicDegree(candidate.academicDegree);
                    cp.ProvideMajorDegree(candidate.majorDegree);
                    cp.ProvideYearOfPassing(candidate.yearOfPassing);
                    cp.ClickAddExperience();
                    cp.ProvideJobTitle(candidate.jobTitle);
                    cp.ProvideCompany(candidate.company);
                    cp.ProvideStartDate(candidate.startDate);
                    cp.ProvideEndDate(candidate.endDate);
                    cp.ProvideWorkProfile(candidate.workProfile);
                    cp.ClickOnSave();

                    ClassicAssert.IsTrue(cp.IsTransactionCreated());
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

       
    }
}
