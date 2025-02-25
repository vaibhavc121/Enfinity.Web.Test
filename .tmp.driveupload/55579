using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class BankPage : BasePage
    {
        public BankPage(IWebDriver driver) : base(driver)
        {
        }

        private By  bankName= By.XPath("//input[@id='Bank.Name_I']");

        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }

        public void provideBankName(string value)
        {
            Find(bankName).SendKeys(value);
        }

        public void provideBankName()
        {
            Find(bankName).SendKeys(RandomString());
        }

        public void clickSave()
        {
            CommonPageActions.ClickSave();
        }

        public bool IsTxnCreated()
        {
            return CommonPageActions.IsTxnCreated();
        }

    }
}
