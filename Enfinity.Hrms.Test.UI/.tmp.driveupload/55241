using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class ItemQueryPage
    {
        private readonly IWebDriver _driver;
        public ItemQueryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Item Query Top Menu Button Locators
        private By previous = By.Id("MainMenu_DXI0_T");
        private By next = By.Id("MainMenu_DXI1_T");
        private By advanceFilter = By.Id("MainMenu_DXI2_T");
        private By close = By.Id("MainMenu_DXI3_T");
        #endregion

        #region Advance Filter Locators
        private By search = By.XPath("//input[@aria-label='Search in the data grid']");
        private By itemCode = By.XPath("//input[@aria-describedby='dx-col-14']");
        private By itemName = By.XPath("//input[@aria-describedby='dx-col-15']");
        private By itemGroupName = By.XPath("//input[@aria-describedby='dx-col-16']");
        private By itemCategoryName = By.XPath("//input[@aria-describedby='dx-col-17']");
        private By itemBrandName = By.XPath("//input[@aria-describedby='dx-col-18']");
        private string brandColumn = "//tr[contains(@class, 'dx-row dx-data-row')]//td[@aria-colindex='5']";
        private string categoryColumn = "//tr[contains(@class, 'dx-row dx-data-row')]//td[@aria-colindex='4']";
        private string groupColumn = "//tr[contains(@class, 'dx-row dx-data-row')]//td[@aria-colindex='3']";
        private string nameColumn = "//tr[contains(@class, 'dx-row dx-data-row')]//td[@aria-colindex='2']";
        private string codeColumn = "//tr[contains(@class, 'dx-row dx-data-row')]//td[@aria-colindex='1']";
        private string searchData = "//tr[contains(@class, 'dx-row dx-data-row')]//span";
        #endregion

        #endregion

        #region Action Methods

        #region Item Query Top Menu 
        public void ClickOnPrevious()
        {
            _driver.FindElement(previous).Click();
        }
        public void ClickOnNext()
        {
            _driver.FindElement(next).Click();
        }
        public void ClickOnAdvanceFilter()
        {
            _driver.FindElement(advanceFilter).Click();
        }
        public void ClickOnClose()
        {
            _driver.FindElement(close).Click();
        }
        #endregion

        #region Advance Filter
        public void ProvideSearch(string name)
        {
            _driver.FindElement(search).SendKeys(name);            
        }
        public void ClearSearch()
        {
            _driver.FindElement(search).Clear();
        }
        public void ProvideItemCode(string name)
        {
            _driver.FindElement(itemCode).SendKeys(name);            
        }
        public void ClearItemCode()
        {
            _driver.FindElement(itemCode).Clear();
        }
        public void ProvideItemName(string name)
        {
            _driver.FindElement(itemName).SendKeys(name);            
        }
        public void ClearItemName()
        {
            _driver.FindElement(itemName).Clear();
        }
        public void ProvideItemGroupName(string name)
        {
            _driver.FindElement(itemGroupName).SendKeys(name);            
        }
        public void ClearItemGroupName()
        {
            _driver.FindElement(itemGroupName).Clear();
        }
        public void ProvideItemCategoryName(string name)
        {
            _driver.FindElement(itemCategoryName).SendKeys(name);            
        }
        public void ClearItemCategoryName()
        {
            _driver.FindElement(itemCategoryName).Clear();
        }
        public void ProvideItemBrandName(string name)
        {
            _driver.FindElement(itemBrandName).SendKeys(name);            
        }
        public void ClearItemBrandName()
        {
            _driver.FindElement(itemBrandName).Clear();
        }
        public bool ValidateBrandColumnData(string expectedBrand)
        {
            var brandElements = _driver.FindElements(By.XPath(brandColumn));
            return brandElements.Any(e => e.Text.ToLower().Contains(expectedBrand.ToLower()));
        }
        public bool ValidateCategoryColumnData(string expectedCategory)
        {
            var categoryElements = _driver.FindElements(By.XPath(categoryColumn));
            return categoryElements.Any(e => e.Text.ToLower().Contains(expectedCategory.ToLower()));
        }
        public bool ValidateGroupColumnData(string expectedGroup)
        {
            var groupElements = _driver.FindElements(By.XPath(groupColumn));
            return groupElements.Any(e => e.Text.ToLower().Contains(expectedGroup.ToLower()));
        }
        public bool ValidateNameColumnData(string expectedName)
        {
            var nameElements = _driver.FindElements(By.XPath(nameColumn));
            return nameElements.Any(e => e.Text.ToLower().Contains(expectedName.ToLower()));
        }
        public bool ValidateCodeColumnData(string expectedCode)
        {
            var codeElements = _driver.FindElements(By.XPath(codeColumn));
            return codeElements.Any(e => e.Text.Contains(expectedCode));
        }
        public bool ValidateSearchTextData(string expectedSearchText) 
        {
            var codeElements = _driver.FindElements(By.XPath(searchData));
            return codeElements.Any(e => e.Text.Contains(expectedSearchText));
        }
        #endregion

        #region Common Action Methods
        #endregion

        #endregion
    }
}
