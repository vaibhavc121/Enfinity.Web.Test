using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enfinity.Hrms.Test.UI.Base;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class DriverUtils
    {
        private static IWebDriver driver;
        public static void InitializeDriver(string browserType)
        {
            if (driver != null)
            {
                return; // Prevent reinitialization if the driver is already set
            }

            if (browserType.Equals("Chrome", StringComparison.OrdinalIgnoreCase))
            {
                driver = new ChromeDriver();
            }
            else if (browserType.Equals("Edge", StringComparison.OrdinalIgnoreCase))
            {
                driver = new EdgeDriver();
            }
            else
            {
                throw new ArgumentException("Unsupported browser type: " + browserType);
            }
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                throw new InvalidOperationException("Driver is not initialized. Call InitializeDriver first.");
            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null; // Ensure it is properly disposed
            }
        }
        
        //another methods
        public static void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void MinimizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Minimize();
        }

        public static void DeleteAllCookies(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void SetImplicitWait(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void QuitDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        // **Alert Handling Methods**
        public static void AcceptAlert(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }

        public static void DismissAlert(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public static string GetAlertText(IWebDriver driver)
        {
            return driver.SwitchTo().Alert().Text;
        }

        public static void SendKeysToAlert(IWebDriver driver, string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        // **Frame Handling Methods**
        public static void SwitchToFrameByIndex(IWebDriver driver, int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public static void SwitchToFrameByNameOrId(IWebDriver driver, string nameOrId)
        {
            driver.SwitchTo().Frame(nameOrId);
        }

        public static void SwitchToFrameByElement(IWebDriver driver, By locator)
        {
            IWebElement frameElement = driver.FindElement(locator);
            driver.SwitchTo().Frame(frameElement);
        }

        public static void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void SwitchToParentFrame(IWebDriver driver)
        {
            driver.SwitchTo().ParentFrame();
        }
    }
}

