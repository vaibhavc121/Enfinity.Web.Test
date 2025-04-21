
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class GradePage : BasePage
    {
        public GradePage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By gradeName = By.XPath("//input[@id='Grade.Name_I']");
        private By minimumSalary = By.XPath("//input[@id='Grade.MinimumSalary_I']");
        private By maximumSalary = By.XPath("//input[@id='Grade.MaximumSalary_I']");
        #endregion

        #region action methods
        public void ClickOnNew()
        {
            ClickNew();
        }

        public void ProvideGradeName(string value)
        {
            Find(gradeName).SendKeys(value);
        }
        public void ProvideMinSal(string value)
        {
            //Find(minimumSalary).SendKeys(value);
            ClearAndProvide1(minimumSalary, value);
        }
        public void ProvideMaxSal(string value)
        {
            //Find(maximumSalary).SendKeys(value);
            ClearAndProvide1(maximumSalary, value);
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }

        #endregion



    }
}
