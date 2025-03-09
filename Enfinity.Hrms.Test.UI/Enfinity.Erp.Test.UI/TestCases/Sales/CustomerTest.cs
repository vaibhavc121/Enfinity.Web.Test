using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Legacy;
using Enfinity.Common.Test;
using System.Drawing;
using System.Xml.Linq;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class CustomerTest : BaseTest
    {
        //private string Product = "Erp";

        #region Constructor
        public CustomerTest()
        { }
        #endregion

        #region Create new customer
        [Test, Category("Sales"), Order(1)]
        public async Task CreateCustomer()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "new");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                //cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ProvideCustomerArabicName(customer.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the customer created name
                IWebElement customerName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string actualName = customerName.GetDomProperty("value");
                ClassicAssert.AreEqual(customer.Name, actualName);
                #endregion

                cp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new customer with keyinfo details
        [Test, Category("Sales"), Order(2)]
        public async Task CreateCustomerWithKeyInfoDetail()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "keyinfo");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);
            //ScrollHelper scrollHelper = new ScrollHelper(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                //cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ProvideCustomerArabicName(customer.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(2);
                cp.ClickOnKeyInfoTab();

                cp.ClickOnCustomerGroup();
                CommonPageActions.SelectDropDownOption(customer.Group);
                cp.ProvideEmail(customer.Email);
                cp.ProvideMobile(customer.Mobile);
                cp.ProvideTelephone(customer.Telephone);
                cp.ProvideDescription(customer.Description);
                cp.ClickOnReceivableMainAccount();
                CommonPageActions.SelectDropDownOption(customer.ReceivableAccount);
                cp.ClickOnEnableCreditControl();
                cp.ProvideCreditLimitAmount(customer.CreditLimitAmount);

                IWebElement element = _driver.FindElement(By.XPath("(//input[contains(@id, '_CreditCheckMode')])"));
                ScrollHelper.ScrollToElement(element);
                cp.ClickOnCreditCheckMode();
                CommonPageActions.SelectDropDownOption(customer.CreditCheckMode);
                cp.ClickOnCreditRating();
                CommonPageActions.SelectDropDownOption(customer.CreditrRating);
                cp.ProvideCreditLimitDays(customer.CreditLimitDays);

                cp.ClickOnSetDefaults();
                cp.ClickOnSalesman();
                CommonPageActions.SelectDropDownOption(customer.Salesman);
                cp.ClickOnPaymentTerm();
                CommonPageActions.SelectDropDownOption(customer.PaymentTerm);
                cp.ClickOnPriceList();
                CommonPageActions.SelectDropDownOption(customer.PriceList);
                cp.ClickOnShippingTerm();
                CommonPageActions.SelectDropDownOption(customer.ShippingTerm);
                cp.ProvideLoadingPort(customer.LoadingPort);
                cp.ProvideDestinationPort(customer.DestinationPort);
                cp.ClickOnShippingMethod();
                CommonPageActions.SelectDropDownOption(customer.ShippingMethod);
                cp.ClickOnShipmentPriority();
                CommonPageActions.SelectDropDownOption(customer.ShipmentPriority);

                IWebElement saveElement = _driver.FindElement(By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Documents']"));
                ScrollHelper.ScrollToElement(saveElement);
                await WaitHelper.WaitForSeconds(2);
                cp.ClickOnSaveKeyInfo();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the credit limit is added or not
                IWebElement creditLimit = _driver.FindElement(By.XPath("(//input[contains(@id, '_CreditLimitAmount')])"));
                string creditLimitAmount = creditLimit.GetDomProperty("value");
                ClassicAssert.AreEqual(customer.CreditLimitAmount, creditLimitAmount);
                #endregion

                #region Validate the email is added or not
                IWebElement customerName = _driver.FindElement(By.XPath("(//input[contains(@id, '_Email')])"));
                string actualName = customerName.GetDomProperty("value");
                ClassicAssert.AreEqual(customer.Email, actualName);
                #endregion

                cp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new customer with address details
        [Test, Category("Sales"), Order(3)]
        public async Task CreateCustomerWithAddressDetail()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "address");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);
            //ScrollHelper scrollHelper = new ScrollHelper(_driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;            

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                //cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ProvideCustomerArabicName(customer.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);
                cp.ClickOnAddressTab();

                #region Billing Address
                cp.ProvideBillingAddress1(customer.BillingAddress1);
                cp.ProvideBillingAddress2(customer.BillingAddress2);
                cp.ClickOnBillingCountry();
                CommonPageActions.SelectDropDownOption(customer.BillingCountry);
                cp.ClickOnBillingState();
                CommonPageActions.SelectDropDownOption(customer.BillingState);              
                cp.ProvideBillingCity(customer.BillingCity);                

                IWebElement element = _driver.FindElement(By.XPath("(//input[contains(@id, '_BillingContactPerson')])"));
                ScrollHelper.ScrollToElement(element);
                cp.ProvideBillingContactPerson(customer.BillingContactPerson);
                cp.ProvideBillingZipCode(customer.BillingZipcode);

                IWebElement saveElement = _driver.FindElement(By.XPath("//span[contains(@id, '_ShippingAddress')]"));
                ScrollHelper.ScrollToElement(saveElement);

                await WaitHelper.WaitForSeconds(1);
                cp.ClickOnSaveAddress();
                await WaitHelper.WaitForSeconds(1);
                #endregion

                #region Validate the Address updated sucessfully
                CommonPageActions.ValidateSucess("Customer updated successfully.");
                #endregion                

                //cp.ClickOnSameAddress();

                #region Shipping Address
                cp.ProvideShippingAddress1(customer.ShippingAddress1);
                cp.ProvideShippingAddress2(customer.ShippingAddress2);
                await WaitHelper.WaitForSeconds(2);
                cp.ClickOnShippingCountry();
                CommonPageActions.SelectDropDownOption(customer.ShippingCountry);
                cp.ClickOnShippingState();
                CommonPageActions.SelectDropDownOption(customer.ShippingState);
                cp.ProvideShippingCity(customer.ShippingCity);

                IWebElement shipelement = _driver.FindElement(By.XPath("(//input[contains(@id, '_ShippingContactPerson')])"));
                ScrollHelper.ScrollToElement(shipelement);
                cp.ProvideShippingContactPerson(customer.ShippingContactPerson);
                cp.ProvideShippingZipCode(customer.ShippingZipcode);

                IWebElement saveToElement = _driver.FindElement(By.XPath("//span[contains(@id, '_ShippingAddress')]"));
                ScrollHelper.ScrollToElement(saveToElement);

                await WaitHelper.WaitForSeconds(1);
                cp.ClickOnSaveAddress();
                await WaitHelper.WaitForSeconds(1);
                #endregion

                #region Validate the Address updated sucessfully
                CommonPageActions.ValidateSucess("Customer updated successfully.");
                #endregion 

                cp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new customer with contact person details
        [Test, Category("Sales"), Order(4)]
        public async Task CreateCustomerWithContactPersonDetail()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "multipersons");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);
            //ScrollHelper scrollHelper = new ScrollHelper(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                //cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ProvideCustomerArabicName(customer.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);
                cp.ClickOnContactPersonTab();
                await WaitHelper.WaitForSeconds(1);

                #region Provide the values of contact person and click on save             
                foreach (var person in customer.Persons)
                {
                    cp.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);
                    cp.ClickOnPrefix();
                    CommonPageActions.SelectDropDownListOption(person.Prefix);
                    cp.ProvideFirstName(person.FirstName);
                    cp.ProvideLastName(person.LastName);
                    cp.ProvideJobTitle(person.JobTitle);

                    cp.ClickOnGender();
                    await WaitHelper.WaitForSeconds(1);
                    CommonPageActions.SelectDropDownListOption(person.Gender);

                    IWebElement emaiElement = _driver.FindElement(By.XPath("(//input[contains(@id, '_Email')])[2]"));
                    ScrollHelper.ScrollToElement(emaiElement);
                    cp.ProvideEmailAddress(person.Email);
                    cp.ProvideMobileNumber(person.Mobile);
                    cp.ProvideTelNumber(person.Telephone);

                    //IWebElement freezedElement = _driver.FindElement(By.XPath("(//div[contains(@id, '_Freezed')])"));
                    //scrollHelper.ScrollToElement(emaiElement);
                    //cp.ClickOnFreezed();

                    //cp.ClickOnDefault();
                    //cp.ClickOnPortalAccess();                    
                    cp.ClickOnSavePerson();
                    await WaitHelper.WaitForSeconds(2);

                    #region Validate the contact person name 
                    IWebElement personName = _driver.FindElement(By.XPath($"//div//h2[contains(text(),'{person.Prefix + " " + person.FirstName + " " + person.LastName}')]"));
                    string actualName = personName.Text;
                    ClassicAssert.AreEqual(person.Prefix + " " + person.FirstName + " " + person.LastName, actualName);
                    #endregion
                }
                #endregion

                cp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new customer with document details
        [Test, Category("Sales"), Order(5)]
        public async Task CreateCustomerWithDocumentDetail()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "multidocuments");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);
            //ScrollHelper scrollHelper = new ScrollHelper(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                //cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ProvideCustomerArabicName(customer.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);
                cp.ClickOnDocumentsTab();                 

                #region Provide the values of document and click on save             
                foreach (var document in customer.Documents)
                {
                    cp.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);                             
                    
                    CommonPageActions.clickOnDocumentType();
                    CommonPageActions.SelectDropDownOption(document.DocumentType);
                    CommonPageActions.provideDocumentNumber(document.DocumentNumber);
                    CommonPageActions.provideDateOfIssue(document.DateOfIssue);
                    CommonPageActions.providePlaceOfIssue(document.PlaceOfIssue);
                    CommonPageActions.provideDateOfExpiry(document.DateOfExpiry);

                    CommonPageActions.clickSaveDocument();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validating the document type and number added or not
                    IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.DocumentType +" ("+ document.DocumentNumber +")"}')]"));
                    string actualName = documentName.Text;
                    ClassicAssert.AreEqual(document.DocumentType + " (" + document.DocumentNumber + ")", actualName);
                    #endregion
                }
                #endregion

                cp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new customer with same name - not create
        [Test, Category("Sales"), Order(6)]
        public async Task ValidateCustomerWithSameNameOrCodeNotAllowed()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "duplicate");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ClickOnNewCustomer();

                cp.ProvideCustomerName(customer.Name);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the same name customer not create
                CommonPageActions.ValidateMessage("already exists");
                #endregion
                await WaitHelper.WaitForSeconds(3);

                cp.ProvideCustomerCode(customer.Code);
                cp.ProvideCustomerName(customer.Name);
                cp.ClickOnSaveCustomer();
                await WaitHelper.WaitForSeconds(1);
                
                #region Validate the same code customer not create
                CommonPageActions.ValidateMessage("already exists");
                #endregion

            }
        }
        #endregion

        #region Delete new customer
        [Test, Category("Sales"), Order(7)]
        public async Task DeleteCustomer()
        {
            #region MyRegion
           Login(ErpProduct);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "delete");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);

            foreach (var customer in customers)
            {
                sp.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnCustomer();
                clp.ProvideCustomerName(customer.Name);
                await WaitHelper.WaitForSeconds(2);
                clp.ClickOnSelectedCustomerName();
                await WaitHelper.WaitForSeconds(2);
                clp.clickOnContextMenuItem();
                clp.clickOnContextMenuDelete();
                await WaitHelper.WaitForSeconds(2);
                clp.clickOnConfirmOk();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the customer deleted message
                CommonPageActions.ValidateSucess("Customer deleted successfully");
                #endregion               
            }
        }
        #endregion
    }
}
