using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class DocumentTypePage : BasePage
    {
        public DocumentTypePage(IWebDriver driver) : base(driver)
        {
        }

        private By documentType = By.XPath("//input[@id='DocumentType.Name_I']");

        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }

        public void ProvideDocumentTypeName(string value)
        {
            Find(documentType).SendKeys(value);
        }

        public void ProvideDocumentTypeName()
        {
            Find(documentType).SendKeys(RandomString());
        }

        public void ClickSave()
        {
            CommonPageActions.ClickSave();
        }
        public bool IsTxnCreated()
        {
            return CommonPageActions.IsTxnCreated();
        }
    }
}
