using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SuccessionPlanning
{
    public class SuccessionPage : BasePage
    {
        public SuccessionPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By menu = By.XPath("//img[@id='applicationMenu_DXI10_PImg']");
        private By successionPlanning = By.XPath("//span[normalize-space()='Succession Planning']");
        private By successionPlan = By.XPath("//a[@title='Succession Plan']//span[@class='dx-vam'][normalize-space()='Succession Plan']");
        #endregion

        #region action methods
        public void ClickMenu()
        {
            Find(menu).Click();
        }
        public void ClicksuccessionPlanning()
        {
            Find(successionPlanning).Click();
        }
        public void ClickSuccessionPlan()
        {
            Find(successionPlan).Click();
        }
        #endregion
    }
}
