using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class BaseTest
    {
        public const string ErpApplicationUrl = "https://testerp.onenfinity.com/";
        public static IWebDriver _driver;
        //public const string FilePath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, 1)
        //                                    + @":\Enfinity.Online\Enfinity.WebTest\Enfinity.Erp.Test.UI";

        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
            Login();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // Close the browser
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
            }
        }

        #region Helper Methods
        public void Login()
        {
            // Navigate to the web application
            _driver.Navigate().GoToUrl(ErpApplicationUrl);
            // Locate and interact with web elements
            var usernameField = _driver.FindElement(By.Name("Username"));
            var passwordField = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.ClassName("login-btn"));

            usernameField.SendKeys("habid@demo.com");
            passwordField.SendKeys("123");
            loginButton.Click();
        }
        #endregion
    }
}
