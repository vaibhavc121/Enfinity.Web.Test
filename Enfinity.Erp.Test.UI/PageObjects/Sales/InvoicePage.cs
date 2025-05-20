using Enfinity.Common.Test;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class InvoicePage
    {
        private readonly IWebDriver _driver;
        public InvoicePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Header Locators
        private By invoice = By.XPath("(//span[normalize-space(text())='Invoice'])[2]");
        private By customer = By.XPath("(//input[contains(@id, '_CustomerId')])");        
        private By warehouse = By.XPath("(//input[contains(@id, '_WarehouseId')])");
        private By salesman = By.XPath("(//input[contains(@id, '_SalesmanId')])");
        private By priceList = By.XPath("(//input[contains(@id, '_PriceListId')])");
        private By paymentMethod = By.XPath("(//input[contains(@id, '_PaymentMethod')])");
        private By paymentTerm = By.XPath("(//input[contains(@id, '_PaymentTermId')])");
        private By project = By.XPath("(//input[contains(@id, '_ProjectId')])");
        #endregion

        #region Invoice Line Locators        
        private By item = By.XPath("(//input[contains(@id, '_ItemId')])");        
        private By lineWarehouse = By.XPath("(//input[contains(@id, '_WarehouseId')])[2]");
        private By size = By.XPath("(//input[contains(@id, '_ItemSizeId')])");
        private By color = By.XPath("(//input[contains(@id, '_ItemColorId')])");
        private By uom = By.XPath("(//input[contains(@id, '_UnitOfMeasureId')])");
        private By unitPrice = By.XPath("(//input[contains(@id, '_UnitPrice')])");
        private By add = By.XPath("//span[normalize-space()='Add']");
        #endregion

        #region Tab Locators
        private By lines = By.XPath("(//span[normalize-space(text())='Lines'])");
        private By payments = By.XPath("(//span[normalize-space(text())='Payments'])");
        private By charges = By.XPath("(//span[normalize-space(text())='Charges'])");
        private By other = By.XPath("(//span[normalize-space(text())='Other'])");
        #endregion

        #region Payment Tab Locators
        private By addpaymentMethod = By.CssSelector(".dx-icon.dx-icon-add");
        private By saveButton = By.XPath("(//span[@class='dx-button-text'][normalize-space(text())='Save'])");
        private By card = By.XPath("(//input[contains(@id, '_CardNum')])");
        private By amountFC = By.XPath("(//input[contains(@id, '_AmountFC')])");
        #endregion

        #endregion

        #region Action Methods

        #region Header Action Methods
        public void ClickOnInvoice()
        {
            _driver.FindElement(invoice).Click();
        }
        public void ClickOnCustomer()
        {
            _driver.FindElement(customer).Click();
        }
        public void ClickOnWarehouse()
        {
            _driver.FindElement(warehouse).Click();
        }
        public void ProvideMobile(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("//input[@placeholder='Mobile #']"), data);
        }
        public void ClickOnSalesman()
        {
            _driver.FindElement(salesman).Click();
        }
        public void ClickOnPriceList()
        {
            _driver.FindElement(priceList).Click();
        }
        public void ClickOnPaymentMethod()
        {
            _driver.FindElement(paymentMethod).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(paymentTerm).Click();
        }
        public void ClickOnProject()
        {
            _driver.FindElement(project).Click();
        }
        #endregion

        #region Invoice Line Action Methods
        public void ProvideBarcode(string data)
        {            
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_ItemBarcode')])"), data);
        }
        public void ClickOnItem()
        {
            _driver.FindElement(item).Click();
        }
        public void ProvideItemDescription(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//textarea[contains(@id, '_ItemDescription')])"), data);
        }
        public void ClickOnLineWarehouse()
        {
            _driver.FindElement(lineWarehouse).Click();
        }
        public void ClickOnSize()
        {
            _driver.FindElement(size).Click();
        }
        public void ClickOnColor()
        {
            _driver.FindElement(color).Click();
        }
        public void ClickOnUOM()
        {
            _driver.FindElement(uom).Click();
        }
        public void ProvideQty(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_Qty')])"), data);
        }
        public void CheckAndProvideUnitPrice(string data)
        {
            var unitPriceElement = _driver.FindElement(unitPrice);            
            unitPriceElement.Click();
            
            string value = unitPriceElement.GetAttribute("value");
            
            if (value == "0.000")
            {
                unitPriceElement.SendKeys(Keys.Control + "a");
                unitPriceElement.SendKeys(Keys.Delete);
                Thread.Sleep(200);
                unitPriceElement.SendKeys(data);
            }                  
        }
        public void ProvideUnitPrice(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_UnitPrice')])"), data);
        }
        public void ProvideDiscountInPercent(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_DiscountInPercent')])"), data);
        }
        public void ProvideDiscountValue(string data)
        {            
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_DiscountValue')])"), data);
        }
        public void ProvideTotalDiscountInPercent(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_DiscountInPercent')])[2]"), data);
        }
        public void ProvideToalDiscountValue(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_DiscountValue')])[2]"), data);
        }
        public void ProvideGrossValue(string data)
        {            
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_GrossValue')])"), data);
        }
        public void ProvideRemarks(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//textarea[contains(@id, '_Remarks')])"), data);
        }
        public void ProvideBonusQty(string data)
        {            
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_BonusQty')])"), data);
        }
        public void ClickOnAdd()
        {
            _driver.FindElement(add).Click();
        }
        #endregion

        #region Tab Action Methods
        public void ClickOnLines()
        {
            _driver.FindElement(lines).Click();
        }
        public void ClickOnPayments()
        {
            _driver.FindElement(payments).Click();
        }
        public void ClickOnCharges()
        {
            _driver.FindElement(charges).Click();
        }
        public void ClickOnOther()
        {
            _driver.FindElement(other).Click();
        }
        #endregion

        #region Payment Tab Action Methods
        public void ClickOnAddPaymentMethod()
        {
            _driver.FindElement(saveButton).Click();
        }
        public void ProvideCardNumber(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_CardNum')])"), data);
        }
        public void ProvideAmountFC(string data)
        {
            CommonPageActions.ClearAndProvideValue(By.XPath("(//input[contains(@id, '_AmountFC')])"), data);
        }
        public void ClickOnSave()
        {
            _driver.FindElement(saveButton).Click();
        }
        #endregion

        #endregion
    }
}
