using Bogus;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public class BasePage
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Find(By locator) => _driver.FindElement(locator);

       
        

    }
}
