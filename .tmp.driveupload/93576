using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class UnitofMeasurePage
    {
        private readonly IWebDriver _driver;
        public UnitofMeasurePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Item Unit of Measure Page
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Unit of Measure']");
        #endregion

        #region Item Unit of Measure Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI13_P");
        #endregion

        #region Commom Locators
        private By baseId = By.Id("UnitOfMeasure.Base_S_D");
        private By defaultId = By.Id("UnitOfMeasure.Default_S_D");
        #endregion

        #endregion

        #region Action Methods 

        #region Item Unit of Measure Page
        public void ClickOnUnitofMeasure()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #region Item Unit of Measure Context Menu Action Methods
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #region Commom Locators
        public void ClickOnBase()
        {
            _driver.FindElement(baseId).Click();
        }
        public void ClickOnDefault()
        {
            _driver.FindElement(defaultId).Click();
        }
        #endregion

        #endregion
    }
}
