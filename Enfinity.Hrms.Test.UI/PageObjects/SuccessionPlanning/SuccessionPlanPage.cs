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
        private By name = By.Name("Name");
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
        public void ClickOnNew()
        {
            ClickNew();
        }
        public void ProvideName(string value)
        {
            Find(name).SendKeys(value);
        }
        public void ProvideNameArabic(string value)
        {
            ClearAndProvide1(nameArabic, value);
        }

        public void ProvideDesignation(string value)
        {
            ProvideAndEnter(designation, value);
        }

        public void ProvideEmployee(string value)
        {
            ProvideAndEnter(employee, value);
        }

        public void ProvideMinimumPercentage(string value)
        {
            ClearAndProvide1(minimumPercentage, value);
        }

        public void ProvideQualificationPercentage(string value)
        {
            ClearAndProvide1(qualificationPercentage, value);
        }

        public void ProvideExperiencePercentage(string value)
        {
            ClearAndProvide1(experiencePercentage, value);
        }

        public void ProvideSkillsPercentage(string value)
        {
            ClearAndProvide1(skillsPercentage, value);
        }

        public void ProvideAppraisalPercentage(string value)
        {
            ClearAndProvide1(appraisalPercentage, value);
        }

        public void ProvideCoursePercentage(string value)
        {
            ClearAndProvide1(coursePercentage, value);
        }

        public void ProvideDescription(string value)
        {
            ClearAndProvide1(description, value);
        }

        public void ClickOnSave()
        {
            ClickSaveAndBack();
        }
        public bool IsTxnCreated(string value)
        {
            IList<IWebElement> results =_driver.FindElements(By.XPath("(//tbody)[7]//tr"));

            foreach(var result in results)
            {
                string resultName= result.Text;
                if(resultName.Contains(value))
                {
                    return true;
                }
                
            }
            return false;
           
        }
        

        #endregion
    }
}
