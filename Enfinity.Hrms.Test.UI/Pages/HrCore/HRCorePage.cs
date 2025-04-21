using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class HRCorePage:BasePage
    {

        // Locators
        private readonly By HRCore = By.XPath("//span[normalize-space()='HR Core']");
        private readonly By Setups = By.XPath("//span[normalize-space()='Setups']");
        private By assetIssue = By.XPath("//span[normalize-space()='Asset Issue']");

        public HRCorePage(IWebDriver _driver) : base(_driver)
        {
        }



        // Methods for actions
        public void ClickHRCore()
        {
            Find(HRCore).Click();
        }

        public void ClickSetupForm()
        {
            Find(Setups).Click();
        }

        public void ClickAssetIssue()
        {
            Find(assetIssue).Click();
        }
    }
}
