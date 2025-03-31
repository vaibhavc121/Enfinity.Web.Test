using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class JavaScriptUtils
    {
        public static void ExecuteScript(IWebDriver driver, string script, params object[] args)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(script, args);
        }

        public static object ExecuteScriptWithReturn(IWebDriver driver, string script, params object[] args)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return jsExecutor.ExecuteScript(script, args);
        }

        public static void ScrollToBottom(IWebDriver driver)
        {
            ExecuteScript(driver, "window.scrollTo(0, document.body.scrollHeight);");
        }

        public static void ScrollToTop(IWebDriver driver)
        {
            ExecuteScript(driver, "window.scrollTo(0, 0);");
        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].scrollIntoView(true);", element);
        }

        public static void ClickElementByJavaScript(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].click();", element);
        }

        public static void SetAttribute(IWebDriver driver, IWebElement element, string attributeName, string attributeValue)
        {
            ExecuteScript(driver, $"arguments[0].setAttribute('{attributeName}', '{attributeValue}');", element);
        }

        public static string GetAttribute(IWebDriver driver, IWebElement element, string attributeName)
        {
            return (string)ExecuteScriptWithReturn(driver, $"return arguments[0].getAttribute('{attributeName}');", element);
        }

        public static void HighlightElement(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].style.border='3px solid red'", element);
        }

        public static void RefreshBrowserUsingJS(IWebDriver driver)
        {
            ExecuteScript(driver, "history.go(0);");
        }

        public static void OpenNewTabUsingJS(IWebDriver driver)
        {
            ExecuteScript(driver, "window.open();");
        }
    }
}
