using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class BrowserUtils
    {
        public static void OpenUrl(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static string GetCurrentUrl(IWebDriver driver)
        {
            return driver.Url;
        }

        public static string GetTitle(IWebDriver driver)
        {
            return driver.Title;
        }

        public static void RefreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void MinimizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Minimize();
        }

        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Quit();
        }

        public static void NavigateBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void NavigateForward(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        #region Swich Tab
        public static void OpenNewTab(IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
        }

        public static void SwitchToTabByIndex(IWebDriver driver, int tabIndex)
        {
            List<string> windowHandles = new List<string>(driver.WindowHandles);
            if (tabIndex < windowHandles.Count)
            {
                driver.SwitchTo().Window(windowHandles[tabIndex]);
            }
        }

        public static void SwitchToLastTab(IWebDriver driver)
        {
            List<string> windowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);
        }

        public static void CloseCurrentTab(IWebDriver driver)
        {
            driver.Close();
        }

        public static void SwitchToMainTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
        #endregion
    }
}
