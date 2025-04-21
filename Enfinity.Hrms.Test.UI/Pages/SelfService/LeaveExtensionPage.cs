using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class LeaveExtensionPage : BasePage
    {
        public LeaveExtensionPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By leaveExtension = By.XPath("//a[@id='TxnInstanceView_I0i8_T']//span[@class='dx-vam'][normalize-space()='Leave Extension']");
        #endregion

        #region action methods
        public void ClickLeaveExtension()
        {
            Find(leaveExtension).Click();
        }
        #endregion
    }
}
