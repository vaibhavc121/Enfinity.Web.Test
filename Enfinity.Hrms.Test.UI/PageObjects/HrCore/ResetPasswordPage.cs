using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class ResetPasswordPage : BasePage
    {
        public ResetPasswordPage(IWebDriver driver) : base(driver)
        {
        }

        #region Page Objects
        private By newPassword = By.XPath("//input[@id='NewPassword_I']");
        private By confirmPassword= By.XPath("//input[@id='ReConfirmPassword_I']");
        private By close = By.XPath("//img[@alt='Close']");

        #endregion

        #region Action Methods

        public void ResetPwd(string pwd)
        {
            
            _driver.SwitchTo().Frame("PopupWindow_CIF-1");
            Thread.Sleep(2000);
            Find(newPassword).SendKeys(pwd);
            Find(confirmPassword).SendKeys(pwd);
            ClickSave();
            _driver.SwitchTo().DefaultContent();
            Find(close).Click();

        }

        #endregion
    }
}
