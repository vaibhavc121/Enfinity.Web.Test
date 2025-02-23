using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public class ScrollHelper
    {
        private IWebDriver _driver;
        public ScrollHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)BaseTest._driver;
            js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
        }
    }
}
