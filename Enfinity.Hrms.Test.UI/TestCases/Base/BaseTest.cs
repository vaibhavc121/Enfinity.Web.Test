using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class BaseTest
    {
        public const string HrmsApplicationUrl = "https://testhrms.onenfinity.com";        
        public static IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Login();
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        #region Helper Methods
        public void Login()
        {
            // Navigate to the web application            
            _driver.Navigate().GoToUrl(HrmsApplicationUrl);
            //_driver.Navigate().GoToUrl(HrmsApplicationUrl);
            // Locate and interact with web elements
            var usernameField = _driver.FindElement(By.Name("Username"));
            var passwordField = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.ClassName("login-btn"));

            usernameField.SendKeys("vaibhavc121@demo.com");
            passwordField.SendKeys("rohitc121");
            loginButton.Click();
        }
        #endregion
        #region test

        #endregion
    }
}
