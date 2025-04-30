
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class ReligionPage : BasePage
    {
        public ReligionPage(IWebDriver driver) : base(driver)
        {
        }

        private By religionName = By.XPath("//input[@id='Religion.Name_I']");

        public void ClickNew()
        {
            ClickOnNew();
        }
        public void ProvideReligionName(string value)
        {
            Find(religionName).SendKeys(value);
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }
       
    }
}
