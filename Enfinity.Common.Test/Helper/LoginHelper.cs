using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test.Helper
{
    public class LoginHelper
    {
        public static IWebDriver _driver;
        public void Login(string url, string username, string password)
        {
            // Navigate to the web application
            _driver.Navigate().GoToUrl("ErpApplicationUrl");
            // Locate and interact with web elements
            var usernameField = _driver.FindElement(By.Name("Username"));
            var passwordField = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.ClassName("login-btn"));

            usernameField.SendKeys("habid@demo.com");
            passwordField.SendKeys("123");
            loginButton.Click();
        }
    }
}
