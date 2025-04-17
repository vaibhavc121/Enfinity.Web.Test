using Enfinity.Hrms.Test.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class Test
    {
        //[Test]
        [Ignore("Ignored bcos I want to see different POM implementation")]
        public void VerifyLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://testhrms.onenfinity.com");

            TestPage tp = new TestPage(driver);
            tp.ProvideUsername();
            tp.ProvidePwd();
            tp.ClickLogin();

            //test
            //test

        }
    }
}
