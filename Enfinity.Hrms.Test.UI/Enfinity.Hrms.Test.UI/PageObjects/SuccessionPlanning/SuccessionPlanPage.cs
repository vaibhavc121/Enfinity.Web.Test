using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SuccessionPlanning
{
    public class SuccessionPlanPage : BasePage
    {
        public SuccessionPlanPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects

        private By nameArabic = By.XPath("//input[contains(@id,'NameL2')]");
        private By designation = By.XPath("//input[contains(@id,'DesignationId')]");
        private By employee = By.XPath("//input[contains(@id,'EmployeeId')]");
        private By minimumPercentage = By.XPath("//input[contains(@id,'MinimumPercentage')]");
        private By qualificationPercentage = By.XPath("//input[contains(@id,'RequiredQualificationPercentage')]");
        private By experiencePercentage = By.XPath("//input[contains(@id,'RequiredExperiencePercentage')]");
        private By skillsPercentage = By.XPath("//input[contains(@id,'RequiredSkillPercentage')]");
        private By appraisalPercentage = By.XPath("//input[contains(@id,'RequiredAppraisalPercentage')]");
        private By coursePercentage = By.XPath("//input[contains(@id,'RequiredCoursePercentage')]");
        private By description = By.XPath("//textarea[contains(@id,'Description')]");

        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideNameArabic(string value)
        {
            CommonPageActions.ClearAndProvide1(nameArabic, value);
        }

        public void ProvideDesignation(string value)
        {
            CommonPageActions.ClearAndProvide1(designation, value);
        }

        public void ProvideEmployee(string value)
        {
            CommonPageActions.ClearAndProvide1(employee, value);
        }

        public void ProvideMinimumPercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(minimumPercentage, value);
        }

        public void ProvideQualificationPercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(qualificationPercentage, value);
        }

        public void ProvideExperiencePercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(experiencePercentage, value);
        }

        public void ProvideSkillsPercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(skillsPercentage, value);
        }

        public void ProvideAppraisalPercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(appraisalPercentage, value);
        }

        public void ProvideCoursePercentage(string value)
        {
            CommonPageActions.ClearAndProvide1(coursePercentage, value);
        }

        public void ProvideDescription(string value)
        {
            CommonPageActions.ClearAndProvide1(description, value);
        }

        #endregion
    }
}
