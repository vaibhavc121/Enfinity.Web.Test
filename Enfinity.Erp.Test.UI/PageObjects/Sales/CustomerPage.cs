using Enfinity.Common.Test;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Enfinity.Erp.Test.UI
{
    public class CustomerPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public CustomerPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Create New Customer
        private By customerCode = By.CssSelector("input[name='Code']");
        private By customerName = By.CssSelector("input[name='Name']");
        private By customerarabicName = By.CssSelector("input[name='NameL2']");
        private By dropdownofCurrency = By.XPath("(//input[contains(@id, '_CurrencyId')])");
        private By dropdownofCountry = By.XPath("(//input[contains(@id, '_CountryId')])");
        private By dropdownofState = By.XPath("(//input[contains(@id, '_StateId')])");
        private By dropdownofTaxTreatment = By.XPath("(//input[contains(@id, '_TaxTreatment')])");
        private By taxRegistrationNumber = By.XPath("(//input[contains(@id, 'TaxRegistrationNumber')])");        
        private By saveCustomer = By.CssSelector("#MainMenu_DXI0_T, #MainMenu_DXI0_");
        private By back = By.Id("pre-Button");
        #endregion

        #region Customer Tabs
        private By KeyinfoTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Key Info']");
        private By addressTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Address']");
        private By contactPersonTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Contact Person']");
        private By documentsTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Documents']");
        #endregion

        #region Key Info Tab
        private By dropdownofCustomerGroup = By.XPath("(//input[contains(@id, '_CustomerGroupId')])");
        private By email = By.XPath("(//input[contains(@id, '_Email')])");
        private By mobile = By.CssSelector("input[placeholder='Mobile']");
        private By telephone = By.CssSelector("input[placeholder='Telephone']");
        private By restrictPaymentTerm = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[1]");
        private By restrictPriceList = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[2]");
        private By enableCreditControl = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[3]");
        private By setDefaults = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[4]");
        private By description = By.XPath("(//textarea[contains(@id, '_Description')])");
        private By dropdownofReceivableMainAccount = By.XPath("(//input[contains(@id, '_ReceivableMainAccountId')])");
        private By creditLimitAmount = By.XPath("(//input[contains(@id, '_CreditLimitAmount')])");
        private By creditLimitDays = By.XPath("(//input[contains(@id, '_CreditLimitDays')])");
        private By dropdownofCreditRating = By.XPath("(//input[contains(@id, '_CreditRating')])");
        private By dropdownofCreditCheckMode = By.XPath("(//input[contains(@id, '_CreditCheckMode')])");
        private By dropdownofDefaultSalesman = By.XPath("(//input[contains(@id, '_DefaultSalesmanId')])"); 
        private By dropdownofDefaultPaymentTerm = By.XPath("(//input[contains(@id, '_DefaultPaymentTermId')])");
        private By dropdownofDefaultPriceList = By.XPath("(//input[contains(@id, '_DefaultPriceListId')])");
        private By dropdownofDefaultShippingTerm = By.XPath("(//input[contains(@id, '_DefaultShippingTerm')])");
        private By defaultLoadingPort = By.CssSelector("input[name='DefaultLoadingPort']");
        private By defaultDestinationPort = By.CssSelector("input[name='DefaultDestinationPort']");
        private By dropdownofDefaultShippingMethod = By.XPath("(//input[contains(@id, '_DefaultShippingMethod')])");
        private By dropdownofDefaultShipmentPriority = By.XPath("(//input[contains(@id, '_DefaultShipmentPriority')])");
        private By savekeyInfo = By.Id("InfoSave"); 
        //private By savekeyInfo = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])");
        #endregion

        #region Address Tab
        private By billingAddress1 = By.XPath("(//input[contains(@id, '_BillingAddress1')])");
        private By billingAddress2 = By.XPath("(//input[contains(@id, '_BillingAddress2')])");
        private By dropdownofBillingCountry = By.XPath("(//input[contains(@id, '_BillingCountry')])");
        private By dropdownofBillingState = By.XPath("(//input[contains(@id, '_BillingState')])");
        private By billingCity = By.XPath("(//input[contains(@id, '_BillingCity')])");
        private By billingZipCode = By.XPath("(//input[contains(@id, '_BillingZipcode')])");
        private By billingContactPerson = By.XPath("(//input[contains(@id, '_BillingContactPerson')])");
        private By sameAddress = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[5]");
        private By shippingAddress1 = By.XPath("(//input[contains(@id, '_ShippingAddress1')])");
        private By shippingAddress2 = By.XPath("(//input[contains(@id, '_ShippingAddress2')])");
        private By dropdownofShippingCountry = By.XPath("(//input[contains(@id, '_ShippingCountry')])");
        private By dropdownofShippingState = By.XPath("(//input[contains(@id, '_ShippingState')])");
        private By shippingCity = By.XPath("(//input[contains(@id, '_ShippingCity')])");
        private By shippingZipcode = By.XPath("(//input[contains(@id, '_ShippingZipcode')])");
        private By shippingContactPerson = By.XPath("(//input[contains(@id, '_ShippingContactPerson')])");
        private By saveAddress = By.Id("InfoSaveAddress");
        #endregion

        #region Contact Person Tab
        private By addPerson = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])");
        private By prefix = By.XPath("(//input[contains(@id, '_Prefix')])");
        private By firstName = By.XPath("(//input[contains(@id, '_FirstName')])");
        private By lastName = By.XPath("(//input[contains(@id, '_LastName')])");
        private By jobTitle = By.XPath("(//input[contains(@id, '_JobTitle')])");
        private By gender = By.XPath("(//input[contains(@id, '_Gender')])");
        private By mobileNumber = By.XPath("(//input[contains(@id, '_MobileNumber')])");
        private By telNumber = By.XPath("(//input[contains(@id, '_TelNumber')])");
        private By emailId = By.XPath("(//input[contains(@id, '_Email')])[2]");
        private By defaultId = By.XPath("(//div[contains(@id, '_Default')])");
        private By portalAccess = By.XPath("(//div[contains(@id, '_PortalAccess')])");
        private By freezed = By.XPath("(//div[contains(@id, '_Freezed')])");
        private By savePerson = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[2]");
        #endregion

        #endregion

        #region Action Methods

        #region Common Action Methods
        public void ClickOnBack()
        {
            _driver.FindElement(back).Click();
        }
        public void Validate(string expectedMessage)
        {
            IWebElement element = _driver.FindElement(By.ClassName("dx-toast-success"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
            //ClassicAssert.AreEqual(expectedMessage, actualMessage);
        }
        public void ValidateError(string expectedMessage)
        {
            IWebElement element = _driver.FindElement(By.ClassName("dx-toast-message"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
            //ClassicAssert.AreEqual(expectedMessage, actualMessage);
        }
        public void ClearAndProvide(By locator, string value)
        {
            var element = _driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            element.SendKeys(value);
        }
        #endregion

        #region Create New Customer Action Methods
        public void ProvideCustomerCode(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(customerCode, data);
        }
        public void ProvideCustomerName(string customername)
        {
            //_driver.FindElement(customerName).SendKeys(customername);
            ClearAndProvide(customerName,customername);
        }
        public void ProvideCustomerArabicName(string customerarabicname)
        {
            _driver.FindElement(customerarabicName).SendKeys(customerarabicname);
        }
        public void ClickOnCurrency()
        {
            _driver.FindElement(dropdownofCurrency).Click();
        }
        public void ClickOnCountry()
        {
            _driver.FindElement(dropdownofCountry).Click();
        }
        public void ClickOnState()
        {
            _driver.FindElement(dropdownofState).Click();
        }
        public void ClickOnTaxTreatment()
        {
            _driver.FindElement(dropdownofTaxTreatment).Click();
        }
        public void ProvideTaxRegistrationNumber(string taxregistrationnumber)
        {
            _driver.FindElement(taxRegistrationNumber).SendKeys(taxregistrationnumber);
        }
        public void ClickOnSaveCustomer()
        {
            _driver.FindElement(saveCustomer).Click();
        }
        #endregion

        #region Customer Tabs Action Methods
        public void ClickOnKeyInfoTab()
        {
            _driver.FindElement(KeyinfoTab).Click();
        }
        public void ClickOnAddressTab()
        {
            _driver.FindElement(addressTab).Click();
        }
        public void ClickOnContactPersonTab()
        {
            _driver.FindElement(contactPersonTab).Click();
        }
        public void ClickOnDocumentsTab()
        {
            _driver.FindElement(documentsTab).Click();
        }
        #endregion

        #region Key Info Action Methods
        public void ClickOnCustomerGroup()
        {
            _driver.FindElement(dropdownofCustomerGroup).Click();
        }
        public void ProvideEmail(string emailId)
        {
            //_driver.FindElement(email).SendKeys(emailId);
            ClearAndProvide(email, emailId);
        }
        public void ProvideMobile(string mobileId)
        {
            //_driver.FindElement(mobile).SendKeys(mobileId);
            ClearAndProvide(mobile, mobileId);
        }
        public void ProvideTelephone(string telephoneId)
        {
            //_driver.FindElement(telephone).SendKeys(telephoneId);
            ClearAndProvide(telephone, telephoneId);
        }
        public void ClickOnRestrictPaymentTerm()
        {
            _driver.FindElement(restrictPaymentTerm).Click();
        }
        public void ClickOnRestrictPriceList()
        {
            _driver.FindElement(restrictPriceList).Click();
        }
        public void ProvideDescription(string desc)
        {
            //_driver.FindElement(description).SendKeys(desc);
            ClearAndProvide(description, desc);
        }
        public void ClickOnReceivableMainAccount()
        {
            _driver.FindElement(dropdownofReceivableMainAccount).Click();
        }
        public void ClickOnEnableCreditControl()
        {
            _driver.FindElement(enableCreditControl).Click();
        }
        public void ProvideCreditLimitAmount(string data)
        {
            //_driver.FindElement(creditLimitAmount).SendKeys(data);
            ClearAndProvide(creditLimitAmount, data);
        }
        public void ProvideCreditLimitDays(string data)
        {
            //_driver.FindElement(creditLimitDays).SendKeys(data);
            ClearAndProvide(creditLimitDays, data);
        }
        public void ClickOnCreditRating()
        {
            _driver.FindElement(dropdownofCreditRating).Click();
        }
        public void ClickOnCreditCheckMode()
        {
            _driver.FindElement(dropdownofCreditCheckMode).Click();
        }        
        public void ClickOnSetDefaults()
        {
            _driver.FindElement(setDefaults).Click();
        }
        public void ClickOnSalesman()
        {
            _driver.FindElement(dropdownofDefaultSalesman).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(dropdownofDefaultPaymentTerm).Click();
        }
        public void ClickOnPriceList()
        {
            _driver.FindElement(dropdownofDefaultPriceList).Click();
        }
        public void ClickOnShippingTerm()
        {
            _driver.FindElement(dropdownofDefaultShippingTerm).Click();
        }
        public void ProvideLoadingPort(string data)
        {
            //_driver.FindElement(defaultLoadingPort).SendKeys(data);
            ClearAndProvide(defaultLoadingPort, data);
        }
        public void ProvideDestinationPort(string data)
        {
            //_driver.FindElement(defaultDestinationPort).SendKeys(data);
            ClearAndProvide(defaultDestinationPort, data);
        }
        public void ClickOnShippingMethod()
        {
            _driver.FindElement(dropdownofDefaultShippingMethod).Click();
        }
        public void ClickOnShipmentPriority()
        {
            _driver.FindElement(dropdownofDefaultShipmentPriority).Click();
        }
        public void ClickOnSaveKeyInfo()
        {
            _driver.FindElement(savekeyInfo).Click();
        }
        #endregion

        #region Address Tab Action Methods
        public void ProvideBillingAddress1(string data)
        {
            _driver.FindElement(billingAddress1).SendKeys(data);
        }
        public void ProvideBillingAddress2(string data)
        {
            _driver.FindElement(billingAddress2).SendKeys(data);
        }
        public void ClickOnBillingCountry()
        {
            _driver.FindElement(dropdownofBillingCountry).Click();
        }
        public void ClickOnBillingState()
        {
            _driver.FindElement(dropdownofBillingState).Click();
        }
        public void ProvideBillingCity(string data)
        {
            _driver.FindElement(billingCity).SendKeys(data);
        }
        public void ProvideBillingZipCode(string data)
        {
            _driver.FindElement(billingZipCode).SendKeys(data);
        }
        public void ProvideBillingContactPerson(string data)
        {
            _driver.FindElement(billingContactPerson).SendKeys(data);
        }
        public void ClickOnSameAddress()
        {
            _driver.FindElement(sameAddress).Click();
        }
        public void ProvideShippingAddress1(string data)
        {
            _driver.FindElement(shippingAddress1).SendKeys(data);
        }
        public void ProvideShippingAddress2(string data)
        {
            _driver.FindElement(shippingAddress2).SendKeys(data);
        }
        public void ClickOnShippingCountry()
        {
            _driver.FindElement(dropdownofShippingCountry).Click();
        }
        public void ClickOnShippingState()
        {
            _driver.FindElement(dropdownofShippingState).Click();
        }
        public void ProvideShippingCity(string data)
        {
            _driver.FindElement(shippingCity).SendKeys(data);
        }
        public void ProvideShippingZipCode(string data)
        {
            _driver.FindElement(shippingZipcode).SendKeys(data);
        }
        public void ProvideShippingContactPerson(string data)
        {
            _driver.FindElement(shippingContactPerson).SendKeys(data);
        }
        public void ClickOnSaveAddress()
        {
            _driver.FindElement(saveAddress).Click();
        }
        #endregion

        #region Contact Person Action Methods
        public void ClickOnAdd()
        {
            _driver.FindElement(addPerson).Click();
        }
        public void ClickOnPrefix()
        {
            _driver.FindElement(prefix).Click();
        }
        public void ProvideFirstName(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(firstName, data);
        }
        public void ProvideLastName(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(lastName, data);
        }
        public void ProvideJobTitle(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(jobTitle, data);
        }
        public void ClickOnGender()
        {
            _driver.FindElement(gender).Click();
        }
        public void ProvideMobileNumber(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(mobileNumber, data);
        }
        public void ProvideTelNumber(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(telNumber, data);
        }
        public void ProvideEmailAddress(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(emailId, data);
        }
        public void ClickOnDefault()
        {
            _driver.FindElement(defaultId).Click();
        }
        public void ClickOnPortalAccess()
        {
            _driver.FindElement(portalAccess).Click();
        }
        public void ClickOnFreezed()
        {
            _driver.FindElement(freezed).Click();
        }
        public void ClickOnSavePerson()
        {
            _driver.FindElement(savePerson).Click();
        }
        #endregion

        #endregion
    }
}
