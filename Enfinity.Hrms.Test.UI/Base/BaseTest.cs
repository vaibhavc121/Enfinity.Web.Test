using Bogus;
using Enfinity.Common.Test.Models;
using Enfinity.Common.Test;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using RealTimeProject.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enfinity.Hrms.Test.UI.Utilities;
using Enfinity.Hrms.Test.UI.Models.Global;
using LoginModel = Enfinity.Hrms.Test.UI.Models.Global.LoginModel;


namespace Enfinity.Hrms.Test.UI.Base
{
    public class BaseTest
    {        
        public static string HrmsProduct = "Hrms";
        public static IWebDriver _driver;
        private static string reportPath = $"{TestContext.CurrentContext.WorkDirectory}\\ExtentReport\\ExtentReport.html";
        public static WebDriverWait _wait;         
        public Faker faker = new Faker();


        #region Setup
        //[SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            #region Disable automation extension and "Save Password" prompt
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);

            // Disable the "Save Password" prompt
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Add Headless Mode
            //options.AddArgument("--headless");
            #endregion

            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            ExtentReportsUtils.InitializeReport(reportPath);
            ExtentReportsUtils.SetDriver(_driver); // Set driver for screenshot capture
            ExtentReportsUtils.CreateTest(TestContext.CurrentContext.Test.Name);

            Login(HrmsProduct);
        }
        #endregion

        #region TearDown

        //[TearDown]
        [OneTimeTearDown]
        public void TearDown()
        {
            // Close the browser
            if (_driver != null)
            {
                ExtentReportsUtils.LogTestResult();
                _driver.Quit();
                _driver.Dispose();
                ExtentReportsUtils.FlushReport();
            }
        }
        #endregion

        #region Login Method
        public void Login(string product)
        {
            #region Get Login Model
            var loginModelFile = FileUtils.GetDataFile(product, "Login", string.Empty, "LoginData");
            var loginModel = JsonUtils.ConvertJsonDataModel<LoginModel>(loginModelFile);
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
