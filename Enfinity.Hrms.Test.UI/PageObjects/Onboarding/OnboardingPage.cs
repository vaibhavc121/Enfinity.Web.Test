using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Onboarding
{
    public class OnboardingPage : BasePage
    {
        public OnboardingPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By menu = By.XPath("//img[@id='applicationMenu_DXI10_PImg']");
        private By onboarding = By.XPath("//span[normalize-space()='Onboarding']");
        private By candidate = By.XPath("//a[@title='Candidate']//span[@class='dx-vam'][normalize-space()='Candidate']");
        #endregion

        #region action methods
        public void ClickMenu()
        {
            Find(menu).Click();
        }
        public void ClickOnboarding()
        {
            Find(onboarding).Click();
        }
        public void ClickCandidate()
        {
            Find(candidate).Click();
        }
        #endregion

    }
}
