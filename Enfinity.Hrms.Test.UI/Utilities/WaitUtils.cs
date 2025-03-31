using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Enfinity.Hrms.Test.UI.Base;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class WaitUtils
    {
        public static void WaitUntil(By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(BaseTest._driver)
            {
                Timeout = TimeSpan.FromSeconds(10), // Maximum wait time
                PollingInterval = TimeSpan.FromMilliseconds(500) // Poll every 500ms
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            IWebElement element = fluentWait.Until(driver =>
            {
                IWebElement el = driver.FindElement(locator);
                return (el.Displayed && el.Enabled) ? el : null; // Ensures visibility & clickability
            });

            element.Click(); // Click after ensuring element is ready
        }

        public static async Task Wait(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }

        public static void WaitTS(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        


        
    }
}
