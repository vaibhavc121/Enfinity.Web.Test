using Bogus;
using Enfinity.Common.Test.Models;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RealTimeProject.Reporting;
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
        private static string reportPath = $"{TestContext.CurrentContext.WorkDirectory}\\ExtentReport\\ExtentReport.html";
        public static WebDriverWait _wait;
        #region for fake data generation
        public Faker faker = new Faker();
        #endregion

        [SetUp]
        //[OneTimeSetUp]
        public void Setup()
        {
            #region Disable automation extension and "Save Password" prompt
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            // Disable the "Save Password" prompt
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            #endregion

            // Add Headless Mode
            //options.AddArgument("--headless");

            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            ExtentReportsUtility.InitializeReport(reportPath);
            ExtentReportsUtility.SetDriver(_driver); // Set driver for screenshot capture
            ExtentReportsUtility.CreateTest(TestContext.CurrentContext.Test.Name);
        }



        [TearDown]
        //[OneTimeTearDown]
        public void TearDown()
        {
            // Close the browser
            if (_driver != null)
            {
                ExtentReportsUtility.LogTestResult();
                //_driver.Quit();
                //_driver.Dispose();
                ExtentReportsUtility.FlushReport();
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
