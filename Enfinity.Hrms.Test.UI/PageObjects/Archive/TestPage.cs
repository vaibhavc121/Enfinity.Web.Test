using Bogus.DataSets;
using Enfinity.Hrms.Test.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class TestPage : BasePage
    {      

        public TestPage(IWebDriver driver) : base(driver) 
        { 
        }

        private readonly By username = By.Name("Username");
        private readonly By pwd = By.Name("Password");
        private readonly By loginbtn = By.ClassName("login-btn");

        public void ProvideUsername()
        {
            Find(username).SendKeys("vaibhavc121@demo.com");
        }

        public void ProvidePwd()
        {
            Find(pwd).SendKeys("rohitc121");
        }

        public void ClickLogin()
        {
            Find(loginbtn).Click();
        }

    }
}
