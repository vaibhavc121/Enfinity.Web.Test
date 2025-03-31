using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class FrameUtils
    {
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
