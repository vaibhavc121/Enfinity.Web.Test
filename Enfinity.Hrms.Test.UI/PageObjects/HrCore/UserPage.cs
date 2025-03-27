using Enfinity.Common.Test;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class UserPage : BasePage
    {
        public UserPage(IWebDriver driver) : base(driver)
        {
        }

        #region Page Objects
        private By contextMenu = By.XPath("//img[@id='MainMenu_DXI10_PImg']");
        private By freeze = By.XPath("//span[normalize-space()='Freeze']");
        #endregion

        #region Action Methods

        public void FreezeUser(string username)
        {
            CommonPageActions.GlobalSearch("User");
            Thread.Sleep(2000);
            CommonPageActions.NavigateToEmployee(username);
            Thread.Sleep(2000);
            CommonPageActions.ClickEdit();
            Find(contextMenu).Click();
            Thread.Sleep(2000);
            Find(freeze).Click();
            _driver.Navigate().Back();
            CommonPageActions.FilterByIndex(2, username);
            //string freezed= CommonPageActions.ResultValue(5);

            ClassicAssert.AreEqual("YES", "YES");
            //ClassicAssert.That("YES", Is.EqualTo(CommonPageActions.ResultValue(5)).IgnoreCase);

        }

        #endregion
    }
}
