
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
        private By restrictToCompanyDD = By.XPath("//img[@id='SalaryComponent.SalaryComponentCompanyIdLookup_B-1Img']");
        #endregion

        #region action methods

        public void FilterCode(string value)
        {
            FilterByIndex(2, value);
            Thread.Sleep(2000);
        }
        public void SelectTheRow()
        {
            Find(selectRow).Click();
        }
        public void ClickEdit()
        {
            ClickOnEdit();
        }
        public void ClickGeneral()
        {
            Find(general).Click();
        }
        public void SelectRestrictToCompany(string value)
        {
            //Find(restrictToCompanyDD).Click();
            ClearAndProvide1(restrictToCompany, value);
            //SelectDropdownValueOffice365(value);
        }
        public void ClickViewBack()
        {
            ClickViewAndBack();
            
        }
        #endregion
    }
}
