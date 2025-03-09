using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class NavigationBarPage
    {
        private readonly IWebDriver _driver;
        public NavigationBarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Navigation bar Page Objects/Locators
        private By userInfo = By.Id("rightAreaMenu_DXI0_T");
        private By globalSetting = By.Id("globalSettingMenu_DXI0_T");
        private By notification = By.Id("notificationContext");
        private By quickCreate = By.Id("quickCreateMenu_DXI0_T");
        private By globalSearch = By.Id("GlobalSearch");
        private By searchText = By.CssSelector("input.dx-texteditor-input[aria-haspopup='listbox']");
        #endregion

        #region Navigation bar Action Methods
        public void ClickOnUserInfo()
        {
            _driver.FindElement(userInfo).Click();
        }
        public void ClickOnGlobalSetting()
        {
            _driver.FindElement(globalSetting).Click();
        }
        public void ClickOnNotification()
        {
            _driver.FindElement(notification).Click();
        }
        public void ClickOnQuickCreate()
        {
            _driver.FindElement(quickCreate).Click();
        }
        public void ClickOnGlobalSearch()
        {
            _driver.FindElement(globalSearch).Click();
        }
        public void ProvideSearchText(string data)
        {
            _driver.FindElement(searchText).SendKeys(data);
        }
        #endregion
    }
}
