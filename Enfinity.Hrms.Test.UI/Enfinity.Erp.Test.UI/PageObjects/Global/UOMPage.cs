using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class UOMPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public UOMPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Unit of measure Top Menu Button Locators
        private By save = By.Id("MainMenu_DXI0_T");
        private By view = By.Id("MainMenu_DXI1_T");
        private By newUOM = By.Id("MainMenu_DXI2_T");
        #endregion

        #region Common Locators
        private By code = By.CssSelector("input[name='UnitOfMeasure.Code']");
        private By name = By.CssSelector("input[name='UnitOfMeasure.Name']");
        //private By name = By.Id("UnitOfMeasure.Name_I");
        private By arabicName = By.CssSelector("input[name='UnitOfMeasure.NameL2']");
        private By description = By.CssSelector("textarea[name='UnitOfMeasure.Description']");
        private By baseId = By.Id("UnitOfMeasure.Base_S_D");
        private By defaultId = By.Id("UnitOfMeasure.Default_S_D");
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Unit of Measure']");
        #endregion

        #endregion

        #region Action Methods

        #region Unit of measure Top Menu Action Methods 
        public void ClickOnSave()
        {
            _driver.FindElement(save).Click();
        }
        public void ClickOnView()
        {
            _driver.FindElement(view).Click();
        }
        public void ClickOnNew()
        {
            _driver.FindElement(newUOM).Click();
        }
        #endregion

        #region Common Action Methods
        public void ProvideUOMCode(string data)
        {
            //_driver.FindElement(code).SendKeys(data);
            CommonPageActions.ClearAndProvideValue(code, data);
        }
        public void ProvideUOMName(string data)
        {
            //_driver.FindElement(name).SendKeys(data);
            CommonPageActions.ClearAndProvideValue(name, data);
        }
        public void ProvideUOMArabicName(string data)
        {
            _driver.FindElement(arabicName).SendKeys(data);
        }
        public void ProvideDescription(string data)
        {
            _driver.FindElement(description).SendKeys(data);
        }
        public void ClickOnBase()
        {
            _driver.FindElement(baseId).Click();
        }
        public void ClickOnDefault()
        {
            _driver.FindElement(defaultId).Click();
        }
        public void ClickOnLink()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #endregion
    }
}
