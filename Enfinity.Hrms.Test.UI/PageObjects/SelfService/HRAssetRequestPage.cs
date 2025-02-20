using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class HRAssetRequestPage : BasePage
    {
        public HRAssetRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By timeOff = By.XPath("//a[@id='TxnInstanceView_I0i4_T']//span[@class='dx-vam'][normalize-space()='Time Off']//following::span[@class='dx-vam'][normalize-space()='HR Asset Request']");
        private By txnDate = By.XPath("//input[@id='HrAssetRequest.TxnDate_I']");
        private By effectiveDate = By.XPath("//input[@id='HrAssetRequest.EffectiveDate_I']");
        

        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideTxnDate(string value)
        {
            CommonPageActions.ClearAndProvide1(txnDate, value);
        }

        public void ProvideEffectiveDate(string value)
        {
            CommonPageActions.ClearAndProvide1(effectiveDate, value);
        }

        public void ClickSave()
        {
            CommonPageActions.ClickSave();
        }

        public void ClickNewLine()
        {
            CommonPageActions.ClickNewLine();
        }
        #endregion
    }
}
