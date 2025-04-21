
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class QualificationPage : BasePage
    {
        public QualificationPage(IWebDriver driver) : base(driver)
        {
        }

        private By qualificationName = By.XPath("//input[@id='Qualification.Name_I']");

        public void ClickOnNew()
        {
            ClickNew();
        }

        public void ProvideQualificationName(string value)
        {
            Find(qualificationName).SendKeys(value);
        }

        public void ProvideQualificationName()
        {
            Find(qualificationName).SendKeys(RandomString());
        }

        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }

        public bool IsTransactionCreated()
        {
            return IsTxnCreated();
        }
    }
}
