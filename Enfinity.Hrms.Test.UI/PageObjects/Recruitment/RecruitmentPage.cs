using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Recruitment
{
    public class RecruitmentPage : BasePage
    {
        public RecruitmentPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By recruitment = By.XPath("//span[normalize-space()='Recruitment']");
        private By job = By.XPath("//a[@title='Job']//span[@class='dx-vam'][normalize-space()='Job']");
        #endregion

        #region action methods
        public void ClickRecruitment()
        {
            Find(recruitment).Click();
        }
        public void ClickJob()
        {
            Find(job).Click();
        }
       
        #endregion
    }
}
