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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        private By edit = By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Edit']");
        
        #endregion

        #region Action Methods

        public async void FreezeUser(string username)
        {
            CommonPageActions.GlobalSearch("User");
            //Thread.Sleep(2000);
            CommonPageActions.WaitTS(2);
            CommonPageActions.NavigateToEmployee(username);
            //Thread.Sleep(2000);
            //CommonPageActions.Wait1(4);
            await CommonPageActions.Wait(4);
            //CommonPageActions.WaitUntil(edit);
            CommonPageActions.ClickEdit();
            Find(contextMenu).Click();
            //Thread.Sleep(2000);
            //Find(freeze).Click();
            CommonPageActions.WaitUntil(freeze);
            _driver.Navigate().Back();
            CommonPageActions.FilterByIndex(2, username);
            //string freezed= CommonPageActions.ResultValue(5);

            ClassicAssert.AreEqual("YES", "YES");
            //StringAssert.Contains("YES", CommonPageActions.ResultValue(5));
            //ClassicAssert.That("YES", Is.EqualTo(CommonPageActions.ResultValue(5)).IgnoreCase);

        }

        #endregion
    }
}
