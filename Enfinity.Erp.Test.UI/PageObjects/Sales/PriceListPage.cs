using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class PriceListPage
    {
        private readonly IWebDriver _driver;
        public PriceListPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Price List Page
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Price List']");
        private By percentageType = By.XPath("//input[contains(@id, 'PercentageType')]");
        private By percentage = By.XPath("(//input[contains(@id, 'Percentage')])[2]");
        private By applyminmaxLimit = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[1]");        
        private By minunitpricePercent= By.XPath("//input[contains(@id, 'PriceRuleMinimumUnitPrice')]");
        private By maxunitpricePercent = By.XPath("//input[contains(@id, 'PriceRuleMaximumUnitPrice')]");
        private By applydiscountPercent = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[2]");
        private By defaultdiscountPercent = By.XPath("//input[contains(@id, 'PriceRuleDefaultDiscountInPercent')]");
        private By maxdiscountPrecent = By.XPath("//input[contains(@id, 'PriceRuleMaximumDiscountInPercent')]");
        private By allitemswithbaseUom = By.XPath("(//div[contains(@class, 'dx-radiobutton-icon-dot')])[2]");
        private By selectedItems = By.XPath("(//div[contains(@class, 'dx-radiobutton-icon-dot')])[3]");
        private By selectedBox = By.XPath("//input[contains(@id, 'SelectedItemIds')]");
        private By byitemCategory = By.XPath("(//div[contains(@class, 'dx-radiobutton-icon-dot')])[5]");
        private By byBrand = By.XPath("(//div[contains(@class, 'dx-radiobutton-icon-dot')])[6]");
        private By selectAll = By.XPath("(//div[contains(@class, 'dx-list-select-all-label')])");
        #endregion

        #region Price List Context Menu
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        #endregion

        #endregion

        #region Action Methods

        #region Price List Page
        public void ClickOnPriceList()
        {
            _driver.FindElement(link).Click();
        }
        public void ClickOnPercentageType()
        {
            _driver.FindElement(percentageType).Click();
        }
        public void ProvidePercentage(string data)
        {            
            CommonPageActions.ClearAndProvideValue(percentage, data);
        }
        public void ClickOnApplyMinMaxLimit()
        {
            _driver.FindElement(applyminmaxLimit).Click();
        }
        public void ProvideMinUnitPricePercent(string data)
        {            
            CommonPageActions.ClearAndProvideValue(minunitpricePercent, data);
        }
        public void ProvideMaxUnitPricePercent(string data)
        {            
            CommonPageActions.ClearAndProvideValue(maxunitpricePercent, data);
        }
        public void ClickOnApplyDiscountPercent()
        {
            _driver.FindElement(applydiscountPercent).Click();
        }
        public void ProvideDefaultDiscountPercent(string data)
        {
            CommonPageActions.ClearAndProvideValue(defaultdiscountPercent, data);
        }
        public void ProvideMaxDiscountPrecent(string data)
        {
            CommonPageActions.ClearAndProvideValue(maxdiscountPrecent, data);
        }
        public void ClickOnAllItemsWithBaseUom()
        {
            _driver.FindElement(allitemswithbaseUom).Click();
        }
        public void ClickOnSelectedItems()
        {
            _driver.FindElement(selectedItems).Click();
        }
        public void ClickOnSelectedBox()
        {
            _driver.FindElement(selectedBox).Click();
        }
        public void ClickOnByItemCategory()
        {
            _driver.FindElement(byitemCategory).Click();
        }
        public void ClickOnByBrand()
        {
            _driver.FindElement(byBrand).Click();
        }
        public void ClickOnSelectAll()
        {
            _driver.FindElement(selectAll).Click();
        }
        #endregion

        #region Price List Context Menu
        public void ClickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #endregion
    }
}
