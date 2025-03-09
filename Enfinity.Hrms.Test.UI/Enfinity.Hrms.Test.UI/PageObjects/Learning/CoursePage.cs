using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Learning
{
    public class CoursePage : BasePage
    {
        public CoursePage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By name = By.Name("Name");
        private By category = By.XPath("//input[contains(@id,'CourseCategoryId')]");
        private By mode = By.XPath("//input[contains(@id,'Mode')]");
        private By courseTrainer = By.XPath("//input[contains(@id,'CourseTrainerId')]");
        private By type = By.XPath("//input[contains(@id,'Type')]");
        private By enroller = By.XPath("//input[contains(@id,'Enroller')]");
        private By addSkills = By.XPath("//span[normalize-space()='+ Add Skills']");
        //private By skillName = By.XPath("//input[contains(@id,'SkillName')]");

        //skills section
        private By skillName1 = By.XPath("(//input[contains(@id,'SkillName')])[1]");         
        private By level1 = By.XPath("(//input[contains(@id,'Level')])[1]");
        private By weightage1 = By.XPath("(//input[contains(@id,'Weightage')])[1]");
        private By skillName2 = By.XPath("(//input[contains(@id,'SkillName')])[2]");
        private By level2 = By.XPath("(//input[contains(@id,'Level')])[2]");
        private By weightage2 = By.XPath("(//input[contains(@id,'Weightage')])[2]");
        private By skillName3 = By.XPath("(//input[contains(@id,'SkillName')])[3]");
        private By level3 = By.XPath("(//input[contains(@id,'Level')])[3]");
        private By weightage3 = By.XPath("(//input[contains(@id,'Weightage')])[3]");
        private By hR = By.XPath("//div[@class='dx-item-content dx-list-item-content'][normalize-space()='HR']");

        //batches
        private By addBatch = By.XPath("//span[normalize-space()='+ Add Batch']");
        private By batchName = By.Name("courseBatch[0].Name");
        private By startDate = By.XPath("//input[contains(@id,'StartDate')]");
        private By endDate = By.XPath("//input[contains(@id,'EndDate')]");

        private By courses = By.XPath("//h4[@class='course-title']");
        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideCourseName(string value)
        {
            Find(name).SendKeys(value);
        }
        public void ProvideCategory(string value)
        {
            Find(category).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideMode(string value)
        {
            Find(mode).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideCourseTrainer(string value)
        {
            Find(courseTrainer).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideType(string value)
        {
            Find(type).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideEnroller(string value)
        {
            Find(enroller).Click();
            Find(hR).Click();
            //CommonPageActions.SelectDropdownOption(value);
        }
        public void ClickAddSkillsBtn()
        {
            Find(addSkills).Click();
        }
        public void ProvideSkillName1(string value)
        {
            Find(skillName1).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideLevel1(string value)
        {
            Find(level1).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideWeightage1(string value)
        {
            //Find(weightage).Click();
            CommonPageActions.ClearAndProvide1(weightage1, value);
        }
        public void ProvideSkillName2(string value)
        {
            Find(skillName2).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideLevel2(string value)
        {
            Find(level2).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideWeightage2(string value)
        {
            //Find(weightage).Click();
            CommonPageActions.ClearAndProvide(weightage2, value);
        }
        public void ProvideSkillName3(string value)
        {
            Find(skillName3).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideLevel3(string value)
        {
            Find(level3).Click();
            CommonPageActions.SelectDropdownOption(value);
        }
        public void ProvideWeightage3(string value)
        {
            //Find(weightage).Click();
            CommonPageActions.ClearAndProvide1(weightage3, value);
        }

          public void ScrollWebPage()
          {
            CommonPageActions.ScrollDownWebPage(addBatch);
          }
          public void ClickAddBatch()
          {
              Find(addBatch).Click();
          }
          public void ProvideBatchName(string value)
          {
            Find(batchName).SendKeys(value);
          }
          public void ProvideStartDate(string value)
          {
            CommonPageActions.ClearAndProvide1(startDate, value);
          } 
        public void ProvideEndDate(string value)
        {
            CommonPageActions.ClearAndProvide1(endDate, value);
        }
        public void ClickSave()
        {
            CommonPageActions.ClickSaveAndBack();
        }
        public bool IsTxnCreated(string value)
        {
            return  CommonPageActions.IsValuePresent(courses,value);
        }

        #endregion
    }
}
