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
        private By country = By.XPath("(//input[contains(@id,'CountryId')])[1]");
        private By postalCode = By.XPath("//input[contains(@id,'PostalCode')]");

        private By gender = By.XPath("//input[contains(@id,'Gender')]");
        private By maritalStatus = By.XPath("//input[contains(@id,'MaritalStatus')]");
        private By nationality = By.XPath(" //input[contains(@id,'NationalityCountryId')]");

        //private By col1 = By.XPath("//tr[@class='dx-row dx-data-row dx-row-lines dx-column-lines dx-selection']//td[1]//span");        
        private By col1 = By.XPath("//tr[@class='dx-row dx-data-row dx-row-lines dx-column-lines']//td[1]//span");





        #endregion

        #region action methods
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideJobTitle(string value)
        {
            Find(jobTitle).SendKeys(value);
        }
        public void ProvideDepartment(string value)
        {
            ProvideAndEnter(department, value);
        }
        public void ProvideDesignation(string value)
        {
            ProvideAndEnter(designation, value);
        }
        public void ProvideNumberOfPosition(string value)
        {
            ClearAndProvide1(numberOfPosition, value);
        }
        public void ProvideEmploymentType(string value)
        {
            Find(employmentType).Click();
            SelectDropdownOption(value);
        }
        public void ProvideIndustry(string value)
        {
            Find(industry).SendKeys(value);
        }
        public void ProvideTargetDate(string value)
        {
            ClearAndProvide1(targetDate, value);
        }
        public void ProvideMonthlySal(string value)
        {
            ClearAndProvide1(monthlySalary, value);    
        }
        public void ProvideAssignedManager(string value)
        {
            ProvideAndEnter(assignedManager, value);
        }
        public void ProvideAssignedRecruiter(string value)
        {
            ProvideAndEnter(assignedRecruiter, value);
        }
        public void ProvideWorkExperience(string value)
        {
            ClearAndProvide1(workExperience, value);
        }
        public void ProvideSkills(string value)
        {
            ProvideAndEnter(skills, value);
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
            ProvideAndEnter(country, value);
        }
        public void ProvidePostalCode(string value)
        {
            Find(postalCode).SendKeys(value);
        }
        public void ProvideGender(string value)
        {
            ProvideAndEnter(gender, value);
        }
        public void ProvideMaritalStatus(string value)
        {
            ProvideAndEnter(maritalStatus, value);
        }
        public void ProvideNationality(string value)
        {
            ProvideAndEnter(nationality, value);
        }
        public void ClickOnSave()
        {
            ClickSaveAndBack();
        }
        public bool IsTxnCreated(string value)
        {
            IWebElement element = driver.FindElement(col1);
           
            string jobTitle = element.Text;
            if(jobTitle.Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
