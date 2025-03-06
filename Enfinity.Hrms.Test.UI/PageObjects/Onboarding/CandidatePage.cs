using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Onboarding
{

    public class CandidatePage : BasePage
    {
        public CandidatePage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        //Personal Information
        private By name = By.XPath("//input[contains(@id,'Name')]");
        private By nameArabic = By.XPath("//input[contains(@id,'NameL2')]");
        private By email = By.XPath("//input[contains(@id,'Email')]");
        private By mobileNumber = By.XPath("//input[contains(@id,'MobileNumber')]");
        private By dateOfBirth = By.XPath("//input[contains(@id,'DateOfBirth')]");
        private By gender = By.XPath("//input[contains(@id,'Gender')]");
        private By maritalStatus = By.XPath("//input[contains(@id,'MaritalStatus')]");

        //Address Information
        private By city = By.XPath("//input[contains(@id,'City')]");
        private By state = By.XPath("//input[contains(@id,'State')]");
        private By country = By.XPath("//input[contains(@id,'CountryId')]");
        private By postalCode = By.XPath("//input[contains(@id,'PostalCode')]");

        //Professional Information
        private By workExperienceInYear = By.XPath("//input[contains(@id,'WorkExperienceInYear')]");
        private By currentJobTitle = By.XPath("//input[contains(@id,'CurrentJobTitle')]");
        private By currentEmployer = By.XPath("//input[contains(@id,'CurrentEmployer')]");
        private By skills = By.XPath("//input[contains(@id,'SkillIds')]");
        private By currentSalary = By.XPath("//input[contains(@id,'CurrentSalary')]");
        private By expectedSalary = By.XPath("//input[contains(@id,'ExpectedSalary')]");
        private By noticePeriodInDays = By.XPath("//input[contains(@id,'NoticePeriodInDays')]");

        //Document Information
        private By passportNumber = By.XPath("//input[contains(@id,'PassportNumber')]");
        private By passportIssueDate = By.XPath("//input[contains(@id,'PassportIssueDate')]");
        private By passportExpiryDate = By.XPath("//input[contains(@id,'PassportExpiryDate')]");
        private By visaType = By.XPath("//input[contains(@id,'VisaType')]");
        private By civilIdNumber = By.XPath("//input[contains(@id,'CivilIdNumber')]");

        //Qualification Details
        private By addQualification = By.XPath("//span[normalize-space()='+ Add Qualification']");
        private By university = By.XPath("//input[contains(@id,'candidateQualification[0].University')]");
        private By academicDegree = By.XPath("//input[contains(@id,'candidateQualification[0].AcademicDegree')]");
        private By majorDegree = By.XPath("//input[contains(@id,'candidateQualification[0].Major')]");
        private By yearOfPassing = By.XPath("//input[contains(@id,'candidateQualification[0].YearOfPassing')]");
        private By checkbox = By.XPath("//div[contains(@class,'dx-checkbox-icon')]");

        //Experience Details
        private By addExperience = By.XPath("//span[normalize-space()='+ Add Experience']");
        private By jobTitle = By.XPath("//input[contains(@id,'candidateExperience[0].JobTitle')]");
        private By company = By.XPath("//input[contains(@id,'candidateExperience[0].PriorCompanyName')]");
        private By startDate = By.XPath("//input[contains(@id,'candidateExperience[0].StartDate')]");
        private By endDate = By.XPath("//input[contains(@id,'candidateExperience[0].EndDate')]");
        private By workProfile = By.XPath("//textarea[contains(@id,'candidateExperience[0].WorkProfile')]");
        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
            Thread.Sleep(2000);
        }
        public string candidateName = RandomString();
        public void ProvideName()
        {
            Find(name).SendKeys(candidateName);
            //Thread.Sleep(1000);
            //Find(name).SendKeys(value);
        }
        public void ProvideEmail()
        {
            Find(email).SendKeys(RandomEmail());
        }
        public void ProvideMbl(string value)
        {
            Find(mobileNumber).SendKeys(value);
        }
        public void ProvideDOB(string value)
        {
            CommonPageActions.ClearAndProvide1(dateOfBirth,value);
        }
        public void ProvideGender(string value)
        {
            CommonPageActions.ProvideAndEnter(gender, value);
        }
        public void ProvideMaritalStatus(string value)
        {
            CommonPageActions.ProvideAndEnter(maritalStatus, value);
        }
        public void ProvideCity(string value)
        {
            CommonPageActions.ClearAndProvide1(city, value);
        }

        public void ProvideState(string value)
        {
            CommonPageActions.ClearAndProvide1(state, value);
        }

        public void ProvideCountry(string value)
        {
            CommonPageActions.ProvideAndEnter(country, value);
        }

        public void ProvidePostalCode(string value)
        {
            CommonPageActions.ClearAndProvide1(postalCode, value);
        }

        public void ProvideWorkExperienceInYear(string value)
        {
            CommonPageActions.ClearAndProvide1(workExperienceInYear, value);
        }

        public void ProvideCurrentJobTitle(string value)
        {
            CommonPageActions.ClearAndProvide1(currentJobTitle, value);
        }

        public void ProvideCurrentEmployer(string value)
        {
            CommonPageActions.ClearAndProvide1(currentEmployer, value);
        }

        public void ProvideSkills(string value)
        {
            CommonPageActions.ProvideAndEnter(skills, value);
        }

        public void ProvideCurrentSalary(string value)
        {
            CommonPageActions.ClearAndProvide1(currentSalary, value);
        }

        public void ProvideExpectedSalary(string value)
        {
            CommonPageActions.ClearAndProvide1(expectedSalary, value);
        }

        public void ProvideNoticePeriodInDays(string value)
        {
            CommonPageActions.ClearAndProvide1(noticePeriodInDays, value);
        }

        public void ProvidePassportNumber(string value)
        {
            CommonPageActions.ClearAndProvide1(passportNumber, value);
        }

        public void ProvidePassportIssueDate(string value)
        {
            CommonPageActions.ClearAndProvide1(passportIssueDate, value);
        }

        public void ProvidePassportExpiryDate(string value)
        {
            CommonPageActions.ClearAndProvide1(passportExpiryDate, value);
        }
                                                                                                            
        public void ProvideVisaType(string value)
        {
            CommonPageActions.ClearAndProvide1(visaType, value);
        }

        public void ProvideCivilIdNumber(string value)
        {
            CommonPageActions.ClearAndProvide1(civilIdNumber, value);
        }
        public void ClickAddQualification()
        {
            Find(addQualification).Click();
        }

        public void ProvideUniversity(string value)
        {
            CommonPageActions.ClearAndProvide1(university, value);
        }

        public void ProvideAcademicDegree(string value)
        {
            Find(academicDegree).Click();
            CommonPageActions.SelectDropdownOption(value);
        }

        public void ProvideMajorDegree(string value)
        {
            CommonPageActions.ClearAndProvide1(majorDegree, value);
        }

        public void ProvideYearOfPassing(string value)
        {
            CommonPageActions.ClearAndProvide1(yearOfPassing, value);
        }

        public void ClickCheckbox()
        {
            Find(checkbox).Click();
        }

        public void ClickAddExperience()
        {
            Find(addExperience).Click();
        }

        public void ProvideJobTitle(string value)
        {
            CommonPageActions.ClearAndProvide1(jobTitle, value);
        }

        public void ProvideCompany(string value)
        {
            CommonPageActions.ClearAndProvide1(company, value);
        }

        public void ProvideStartDate(string value)
        {
            CommonPageActions.ClearAndProvide1(startDate, value);
        }

        public void ProvideEndDate(string value)
        {
            CommonPageActions.ClearAndProvide1(endDate, value);
        }

        public void ProvideWorkProfile(string value)
        {
            CommonPageActions.ClearAndProvide1(workProfile, value);
        }
        public void ClickSave()
        {
            CommonPageActions.ClickSave();
            Thread.Sleep(2000);
        }
        public bool IsTxnCreated()
        {
            String actualCandidateName= _driver.FindElement(By.XPath("//span[@class='bCardHover']")).Text;
            if(actualCandidateName.Equals(candidateName))
            {
                return true;
            }
            else
            {
                return false;
            }
               
            //return CommonPageActions.IsTxnCreated();
        }


        #endregion
    }
}
