
using Enfinity.Hrms.Test.UI.Base;
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

        public void ClickOnNew()
        {
           ClickNew();
        }

        public void provideBankName(string value)
        {
            Find(bankName).SendKeys(value);
        }

        public void provideBankName()
        {
            Find(bankName).SendKeys(RandomString());
        }

        public void clickSaveBack()
        {
            ClickSaveAndBack();
        }

        public bool IsTransactionCreated()
        {
            return IsTxnCreated();
        }

    }
}
