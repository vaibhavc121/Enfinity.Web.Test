using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Payroll
{
    public class SalaryComponentPage : BasePage
    {
        public SalaryComponentPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By selectRow = By.XPath("(//tr)[12]//td[2]");
        private By general = By.XPath("//td[@id='General_HC']");
        private By restrictToCompany = By.XPath("//input[@id='SalaryComponent.SalaryComponentCompanyIdLookup_I']");
        #endregion

        #region action methods

        public void FilterCode(string value)
        {
            CommonPageActions.FilterByIndex(1, value);
        }
        public void SelectRow()
        {
            Find(selectRow).Click();
        }
        public void ClickEdit()
        {
            CommonPageActions.ClickEdit();
        }
        public void ClickGeneral()
        {
            Find(general).Click();
        }
        public void SelectRestrictToCompany(string value)
        {
            CommonPageActions.ClearAndProvide1(restrictToCompany, value);
        }
        public void ClickSaveAndBack()
        {
            CommonPageActions.ClickSaveAndBack();
            
        }
        #endregion
    }
}
