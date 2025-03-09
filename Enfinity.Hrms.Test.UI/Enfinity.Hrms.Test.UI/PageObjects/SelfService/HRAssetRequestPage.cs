using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class HRAssetRequestPage : BasePage
    {
        public HRAssetRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By hrAssetRequest = By.XPath("//a[@id='TxnInstanceView_I0i4_T']//span[@class='dx-vam'][normalize-space()='Time Off']//following::span[@class='dx-vam'][normalize-space()='HR Asset Request']");
        private By txnDate = By.XPath("//input[@id='HrAssetRequest.TxnDate_I']");
        private By effectiveDate = By.XPath("//input[@id='HrAssetRequest.EffectiveDate_I']");
        private By hrAsset = By.Id("HrAssetRequestLine_HrAssetId_B-1Img");
        private By expReturnDate = By.Id("HrAssetRequestLine_DXEditor3_I");


        #endregion

        #region action methods
        public void ClickHRAssetRequest()
        {
            Find(hrAssetRequest).Click();
        }

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

        public void ClickHRAssetDD()
        {
            Find(hrAsset).Click();
        }

        public void SelectHRAsset(string value)
        {
            while (true)
            {
                // Finding all the elements in the dropdown
                IList<IWebElement> valuesList = BaseTest._driver.FindElements(By.XPath("//div[@class='lookup-text']"));

                foreach (var valueElement in valuesList)
                {
                    string actualValue = valueElement.Text;
                    if (actualValue.Contains(value))
                    {
                        valueElement.Click();
                        return;
                    }
                }

                // Click on the next icon to load more items in the dropdown
                BaseTest._driver.FindElement(By.XPath("//img[@alt='Next']")).Click();
                Thread.Sleep(3000);  // Wait for 3 seconds for next page to load
            }
        }

        public void ProvideExpReturnDate(string value)
        {
            Find(expReturnDate).Click();
            Find(expReturnDate).SendKeys(value);
        }

        public void ClickView()
        {
            CommonPageActions.ClickView();
        }

        public void ClickApprove()
        {
            CommonPageActions.ClickApprove();
        }
        #endregion
    }
}
