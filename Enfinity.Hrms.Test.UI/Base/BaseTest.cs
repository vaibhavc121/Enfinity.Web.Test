using Bogus;
using Enfinity.Hrms.Test.UI.Models.Login;
using Enfinity.Hrms.Test.UI.TestData.CredentialProvider;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            options.AddArgument("--headless");
            #endregion

            // Initialize the Chrome WebDriver
            _driver = new ChromeDriver(options);            
            DriverUtils.MaximizeWindow();
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
                //_driver.Quit();
                //_driver.Dispose();
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
            var usernameField = WaitUtils.WaitForElement((By.Name("Username")));
            var passwordField = WaitUtils.WaitForElement((By.Name("Password")));
            var loginButton = WaitUtils.WaitForElement((By.ClassName("login-btn")));

            #region Get Credentials from DB
            //var credentials = new CredentialProvider().GetCredentials();

            //string username = credentials.Username;
            //string password = credentials.Password;
            #endregion

            usernameField.SendKeys(loginModel.Username);
            passwordField.SendKeys(loginModel.Password);
            //usernameField.SendKeys(username);
            //passwordField.SendKeys(password);
            loginButton.Click();
        }
        #endregion
       
    }
}
