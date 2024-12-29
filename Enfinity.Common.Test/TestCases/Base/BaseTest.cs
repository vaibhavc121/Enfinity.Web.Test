using Enfinity.Common.Test.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public class BaseTest
    {

        public static IWebDriver _driver;        
        
        [SetUp]
        public void Setup()
        {
            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
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
        public void Login(string product)
        {
            #region Get Login Model
            var loginModelFile = FileHelper.GetDataFile(product, "Global", string.Empty, "LoginData");
            var loginModel = JsonHelper.ConvertJsonDataModel<LoginModel>(loginModelFile);
            #endregion

            // Navigate to the web application            
            _driver.Navigate().GoToUrl(loginModel.Url);

            // Locate and interact with web elements
            var usernameField = _driver.FindElement(By.Name("Username"));
            var passwordField = _driver.FindElement(By.Name("Password"));
            var loginButton = _driver.FindElement(By.ClassName("login-btn"));


            usernameField.SendKeys(loginModel.Username);
            passwordField.SendKeys(loginModel.Password);
            loginButton.Click();
        }
        #endregion      
    }
}
