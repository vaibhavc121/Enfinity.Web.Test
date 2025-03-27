using Enfinity.Common.Test.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.Login
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Page Objects

        #endregion

        #region Action Methods
        public void Login(string uname, string pwd)
        {
            var usernameField = _driver.FindElement(By.Name("Username"));
            var passwordField = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.ClassName("login-btn"));

            usernameField.SendKeys(uname);
            passwordField.SendKeys(pwd);
            loginButton.Click();
        }
        #endregion
    }
}
