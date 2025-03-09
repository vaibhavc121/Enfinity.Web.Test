using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Learning
{
    public class LearningPage : BasePage
    {
        public LearningPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By learning = By.XPath("//span[normalize-space()='Learning']");
        private By course = By.XPath("//span[normalize-space()='My Course']//preceding::span[@class='dx-vam'][normalize-space()='Course']");
        #endregion

        #region action methods
        public void ClickLearning()
        {
            Find(learning).Click();
        }
        public void ClickCourse()
        {
            Find(course).Click();
        }
        #endregion
    }
}
