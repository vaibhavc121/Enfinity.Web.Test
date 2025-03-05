using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Recruitment
{
    public class JobPage : BasePage
    {
        public JobPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By jobTitle = By.Name("JobTitle");
        private By department = By.XPath("//input[contains(@id,'DepartmentId')]");  
        private By designation = By.XPath("//input[contains(@id,'DesignationId')]");
        private By numberOfPosition = By.XPath("//input[contains(@id,'NumberOfPosition')]");
        private By employmentType = By.XPath("//input[contains(@id,'EmploymentType')]");
        private By industry = By.Name("Industry");
        private By targetDate = By.XPath("//input[contains(@id,'TargetDate')]");
        private By monthlySalary = By.XPath("//input[contains(@id,'Salary')]");

        private By assignedManager = By.XPath("//input[contains(@id,'AssignedManagerIds')]");
        private By assignedRecruiter = By.XPath("//input[contains(@id,'AssignedRecruiterIds')]");

        private By workExperience = By.XPath("//input[contains(@id,'WorkExperienceInYear')]");
        private By skills = By.XPath("//input[contains(@id,'SkillIds')]");

        private By city = By.XPath("//input[contains(@id,'City')]");
        private By state = By.XPath("//input[contains(@id,'State')]");
        private By country = By.XPath("//span[contains(text(),'Country:')]//following::input[@id='dx_dx-78c8a8ef-674b-a3da-9836-735ab19beeae_CountryId']");
        private By postalCode = By.XPath("//input[contains(@id,'PostalCode')]");

        private By gender = By.XPath("//input[contains(@id,'Gender')]");
        private By maritalStatus = By.XPath("//input[contains(@id,'MaritalStatus')]");
        private By nationality = By.XPath(" //input[contains(@id,'NationalityCountryId')]");
           


        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideJobTitle(string value)
        {
            Find(jobTitle).SendKeys(value);
        }
        public void ProvideDepartment(string value)
        {
            CommonPageActions.ProvideAndEnter(department, value);
        }
        public void ProvideDesignation(string value)
        {
            CommonPageActions.ProvideAndEnter(designation, value);
        }
        public void ProvideNumberOfPosition(string value)
        {
            CommonPageActions.ClearAndProvide1(numberOfPosition, value);
        }
        public void ProvideEmploymentType(string value)
        {
            CommonPageActions.ProvideAndEnter(employmentType, value);
        }
        public void ProvideIndustry(string value)
        {
            Find(industry).SendKeys(value);
        }
        public void ProvideTargetDate(string value)
        {
            CommonPageActions.ClearAndProvide1(industry, value);
        }
        public void ProvideMonthlySal(string value)
        {
            CommonPageActions.ClearAndProvide1(monthlySalary, value);    
        }
        public void ProvideAssignedManager(string value)
        {
            CommonPageActions.ProvideAndEnter(assignedManager, value);
        }
        public void ProvideAssignedRecruiter(string value)
        {
            CommonPageActions.ProvideAndEnter(assignedRecruiter, value);
        }
        public void ProvideWorkExperience(string value)
        {
            CommonPageActions.ClearAndProvide1(workExperience, value);
        }
        public void ProvideSkills(string value)
        {
            CommonPageActions.ProvideAndEnter(skills, value);
        }
        public void ProvideCity(string value)
        {
            Find(city).SendKeys(value);
        }
        public void ProvideState(string value)
        {
            Find(state).SendKeys(value);
        }
        public void ProvideCountry(string value)
        {
            CommonPageActions.ProvideAndEnter(country, value);
        }
        public void ProvidePostalCode(string value)
        {
            Find(postalCode).SendKeys(value);
        }
        public void ProvideGender(string value)
        {
            CommonPageActions.ProvideAndEnter(gender, value);
        }
        public void ProvideMaritalStatus(string value)
        {
            CommonPageActions.ProvideAndEnter(maritalStatus, value);
        }
        public void ProvideNationality(string value)
        {
            CommonPageActions.ProvideAndEnter(nationality, value);
        }
        #endregion
    }
}
