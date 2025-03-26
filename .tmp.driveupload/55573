using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class WorkLocationPage : BasePage
    {
        public WorkLocationPage(IWebDriver driver) : base(driver)
        {
        }

        private By workLocationName = By.XPath("//input[@id='WorkLocation.Name_I']");

        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideWorkLocName(string value)
        {
            Find(workLocationName).SendKeys(value);
        }
        public void ProvideWorkLocName()
        {
            Find(workLocationName).SendKeys(RandomString());
        }
        public void ClickSaveBack()
        {
            CommonPageActions.ClickSaveAndBack();
        }
        public bool IsTxnCreated()
        {
            return CommonPageActions.IsTxnCreated();
        }

    }
}
