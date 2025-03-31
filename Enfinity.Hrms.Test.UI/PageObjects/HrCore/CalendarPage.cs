using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class CalendarPage : BasePage
    {
        public CalendarPage(IWebDriver driver) : base(driver)
        {
        }

        private By calname = By.Name("Name");
        private By fromDate = By.XPath("//input[contains(@id,'FromDate')]");
        private By weekoffcheckbox = By.XPath("//div[@id='SundayAsWeeklyoff']//span[@class='dx-checkbox-icon']");
        private By restdaycheckbox = By.XPath("//div[@id='SaturdayAsRestDay']//span[@class='dx-checkbox-icon']");

        public void ClickNewButton()
        {
            ClickNew();
        }
        public void ProvideCalendarName()
        {
            Find(calname).SendKeys(RandomString());
        }
        public void ProvideCalendarName(string value)
        {
            Find(calname).SendKeys(value);
        }
        public void ProvideFromDate(string value)
        {
            Find(fromDate).Clear();
            Find(fromDate).SendKeys(value);
        }
        public void SetWeekoff()
        {
            Find(weekoffcheckbox).Click();
        }
        public void SetRestday()
        {
            Find(restdaycheckbox).Click();
        }
        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }
        


    }
}
