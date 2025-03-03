using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class SupplierPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public SupplierPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Supplier Tabs
        private By KeyinfoTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Key Info']");
        private By contactPersonTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Contact Persons']");
        private By addressTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Addresses']");
        private By itemsTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Items']");
        private By documentsTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Documents']");
        #endregion

        #region Create New Supplier
        private By supplierCode = By.CssSelector("input[name='Code']");
        private By supplierName = By.CssSelector("input[name='Name']");
        private By supplierarabicName = By.CssSelector("input[name='NameL2']");
        private By dropdownofCurrency = By.XPath("(//input[contains(@id, '_CurrencyId')])");
        private By dropdownofCountry = By.XPath("(//input[contains(@id, '_CountryId')])");
        private By dropdownofState = By.XPath("(//input[contains(@id, '_StateId')])");
        private By dropdownofTaxTreatment = By.XPath("(//input[contains(@id, '_TaxTreatment')])");
        private By taxRegistrationNumber = By.XPath("(//input[contains(@id, 'TaxRegistrationNumber')])");
        private By saveSupplier = By.CssSelector("#MainMenu_DXI0_T, #MainMenu_DXI0_");
        private By back = By.Id("pre-Button");
        #endregion

        #region Key Info Tab
        private By dropdownofSupplierGroup = By.XPath("(//input[contains(@id, '_SupplierGroupId')])");
        private By contactPerson = By.XPath("(//input[contains(@id, '_ContactPersonName')])");
        private By mobile = By.CssSelector("input[name='ContactPersonMobile']");
        private By email = By.CssSelector("input[name='ContactPersonEmail']");
        private By restrictPaymentTerm = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[1]");
        private By dropdownofPayableMainAccount = By.XPath("(//input[contains(@id, '_PayableMainAccountId')])");
        private By description = By.XPath("(//textarea[contains(@id, '_Description')])");       
        private By enableCreditControl = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[2]");
        private By setDefaults = By.XPath("(//span[contains(@class, 'dx-checkbox-icon')])[3]");       
        private By creditLimitAmount = By.XPath("(//input[contains(@id, '_CreditLimitAmount')])");
        private By creditLimitDays = By.XPath("(//input[contains(@id, '_CreditLimitDays')])");      
        private By dropdownofDefaultPaymentTerm = By.XPath("(//input[contains(@id, '_DefaultPaymentTermId')])");
        private By dropdownofDefaultShippingTerm = By.XPath("(//input[contains(@id, '_DefaultShippingTerm')])");
        private By defaultLoadingPort = By.CssSelector("input[name='DefaultLoadingPort']");
        private By defaultDestinationPort = By.CssSelector("input[name='DefaultDestinationPort']");
        private By dropdownofDefaultShippingMethod = By.XPath("(//input[contains(@id, '_DefaultShippingMethod')])");
        private By dropdownofDefaultShipmentPriority = By.XPath("(//input[contains(@id, '_DefaultShipmentPriority')])");
        private By savekeyInfo = By.Id("InfoSave");
        //private By savekeyInfo = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])");
        #endregion

        #region Contact Person Tab
        private By addPerson = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])");
        private By prefix = By.XPath("(//input[contains(@id, '_Prefix')])");
        private By firstName = By.XPath("(//input[contains(@id, '_FirstName')])");
        private By middleName = By.XPath("(//input[contains(@id, '_MiddleName')])");
        private By lastName = By.XPath("(//input[contains(@id, '_LastName')])");
        private By jobTitle = By.XPath("(//input[contains(@id, '_JobTitle')])");
        private By gender = By.XPath("(//input[contains(@id, '_Gender')])");
        private By mobileNumber = By.XPath("(//input[contains(@id, '_MobileNumber')])");
        private By telNumber = By.XPath("(//input[contains(@id, '_TelNumber')])");
        private By fax = By.XPath("(//input[contains(@id, '_FaxNumber')])");
        private By emailId = By.XPath("(//input[contains(@id, '_Email')])[2]");
        private By defaultId = By.XPath("(//div[contains(@id, '_Default')])");
        private By freezed = By.XPath("(//div[contains(@id, '_Freezed')])");
        private By savePerson = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[2]");
        #endregion

        #region Address Tab
        private By addAddress = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])");
        private By addressDescription = By.XPath("(//input[contains(@id, '_Description')])");
        private By address1 = By.XPath("(//input[contains(@id, '_Address1')])");
        private By address2 = By.XPath("(//input[contains(@id, '_Address2')])");
        private By address3 = By.XPath("(//input[contains(@id, '_Address3')])");
        private By address4 = By.XPath("(//input[contains(@id, '_Address4')])");
        private By address5 = By.XPath("(//input[contains(@id, '_Address5')])");
        private By city = By.XPath("(//input[contains(@id, '_City')])");
        private By state = By.XPath("(//input[contains(@id, '_State')])");
        private By dialingCode = By.XPath("(//input[contains(@id, '_CountryCode')])");          
        private By zipCode = By.XPath("(//input[contains(@id, '_Zipcode')])");
        private By contact = By.XPath("(//input[contains(@id, '_Contact')])");
        private By addressEmail = By.XPath("(//input[contains(@id, '_Email')])[3]");
        private By addressMobileNumber = By.XPath("(//input[contains(@id, '_MobileNumber')])[2]");
        private By addressTelNumber = By.XPath("(//input[contains(@id, '_TelNumber')])[2]");
        private By addressFax = By.XPath("(//input[contains(@id, '_FaxNumber')])[2]");
        private By saveAddress = By.Id("InfoSaveAddress");
        #endregion

        #region Items Tab
        private By addItems = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])");
        private By itemId = By.XPath("(//input[contains(@id, '_ItemId')])");
        private By saveItem = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[3]");
        #endregion

        #endregion

        #region Action Methods

        #region Common Action Methods
        public void ClickOnBack()
        {
            _driver.FindElement(back).Click();
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

        #region Supplier Tabs Action Methods
        public void ClickOnKeyInfoTab()
        {
            _driver.FindElement(KeyinfoTab).Click();
        }
        public void ClickOnContactPersonTab()
        {
            _driver.FindElement(contactPersonTab).Click();
        }
        public void ClickOnAddressTab()
        {
            _driver.FindElement(addressTab).Click();
        }
        public void ClickOnItemTab()
        {
            _driver.FindElement(addressTab).Click();
        }
        public void ClickOnDocumentsTab()
        {
            _driver.FindElement(documentsTab).Click();
        }
        #endregion

        #region Create New Customer Action Methods
        public void ProvideSupplierCode(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(supplierCode, data);
        }
        public void ProvideSupplierName(string data)
        {
            //_driver.FindElement(customerName).SendKeys(customername);
            ClearAndProvide(supplierName, data);
        }
        public void ProvideSupplierArabicName(string data)
        {
            _driver.FindElement(supplierarabicName).SendKeys(data);
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
        public void ClickOnSaveSupplier()
        {
            _driver.FindElement(saveSupplier).Click();
        }
        #endregion

        #region Key Info Action Methods
        public void ClickOnSupplierGroup()
        {
            _driver.FindElement(dropdownofSupplierGroup).Click();
        }
        public void ProvideContactPerson(string data)
        {
            //_driver.FindElement(email).SendKeys(emailId);
            ClearAndProvide(contactPerson, data);
        }
        public void ProvideMobile(string mobileId)
        {
            //_driver.FindElement(mobile).SendKeys(mobileId);
            ClearAndProvide(mobile, mobileId);
        }
        public void ProvideEmail(string emailId)
        {
            //_driver.FindElement(email).SendKeys(emailId);
            ClearAndProvide(email, emailId);
        }        
        public void ClickOnRestrictPaymentTerm()
        {
            _driver.FindElement(restrictPaymentTerm).Click();
        }
        public void ClickOnPayableMainAccount()
        {
            _driver.FindElement(dropdownofPayableMainAccount).Click();
        }
        public void ProvideDescription(string desc)
        {
            //_driver.FindElement(description).SendKeys(desc);
            ClearAndProvide(description, desc);
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
        public void ClickOnSetDefaults()
        {
            _driver.FindElement(setDefaults).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(dropdownofDefaultPaymentTerm).Click();
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
        public void ProvideMiddleName(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(middleName, data);
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
        public void ProvideFax(string data)
        {
            //_driver.FindElement(customerCode).SendKeys(data);
            ClearAndProvide(fax, data);
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
        public void ClickOnFreezed()
        {
            _driver.FindElement(freezed).Click();
        }
        public void ClickOnSavePerson()
        {
            _driver.FindElement(savePerson).Click();
        }
        #endregion

        #region Address Tab Action Methods
        public void ClickOnAddAddress()
        {
            _driver.FindElement(addAddress).Click();
        }
        public void ProvideAddressDescription(string data)
        {
            _driver.FindElement(addressDescription).SendKeys(data);
        }
        public void ProvideAddress1(string data)
        {
            _driver.FindElement(address1).SendKeys(data);
        }
        public void ProvideAddress2(string data)
        {
            _driver.FindElement(address2).SendKeys(data);
        }
        public void ProvideAddress3(string data)
        {
            _driver.FindElement(address3).SendKeys(data);
        }
        public void ProvideAddress4(string data)
        {
            _driver.FindElement(address4).SendKeys(data);
        }
        public void ProvideAddress5(string data)
        {
            _driver.FindElement(address5).SendKeys(data);
        }
        public void ProvideCity(string data)
        {
            _driver.FindElement(city).SendKeys(data);
        }
        public void ProvideState()
        {
            _driver.FindElement(state).Click();
        }
        public void ProvideDialingCode()
        {
            _driver.FindElement(dialingCode).Click();
        }
        public void ProvideBillingZipCode(string data)
        {
            _driver.FindElement(zipCode).SendKeys(data);
        }
        public void ProvideAddressContactPerson(string data)
        {
            _driver.FindElement(contact).SendKeys(data);
        }
        public void ProvideAddressEmail(string data)
        {
            _driver.FindElement(addressEmail).Click();
        }
        public void ProvideAddressMobileNumber(string data)
        {
            _driver.FindElement(addressMobileNumber).Click();
        }
        public void ProvideAddressTelNumber(string data)
        {
            _driver.FindElement(addressTelNumber).Click();
        }
        public void ProvideAddressFaxNumber(string data)
        {
            _driver.FindElement(addressFax).Click();
        }
        public void ClickOnSaveAddress()
        {
            _driver.FindElement(saveAddress).Click();
        }
        #endregion

        #region Items Tab Action Methods
        public void ClickOnAddItems()
        {
            _driver.FindElement(addItems).Click();
        }
        public void ClickOnItem()
        {
            _driver.FindElement(itemId).Click();
        }
        public void ClickOnSaveItem()
        {
            _driver.FindElement(saveItem).Click();
        }
        #endregion

        #endregion
    }
}
