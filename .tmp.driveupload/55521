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
    public class CustomerTest: BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public CustomerTest()
        {}
        #endregion

        #region Create new customer
        [Test, Category("Sales"), Order(1)]
        public async Task CreateCustomer()
        {
            #region MyRegion
            Login(Product);
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
        public async Task CreateNewCustomerWithKeyInfo()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "keyinfo");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);
            ScrollHelper scrollHelper = new ScrollHelper(_driver);

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
                scrollHelper.ScrollToElement(element);
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
                scrollHelper.ScrollToElement(saveElement);
                await WaitHelper.WaitForSeconds(2);
                cp.ClickOnSaveKeyInfo();

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
            }
        }
        #endregion

        #region Create new customer with address details
        [Test, Category("Sales"), Order(3)]
        public async Task CreateNewCustomerWithAddress()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "address");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);            

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
                cp.ProvideBillingZipCode(customer.BillingZipcode);
                cp.ProvideBillingContactPerson(customer.BillingContactPerson);
                cp.ClickOnSaveAddress();
                await WaitHelper.WaitForSeconds(1);
                #endregion

                #region Validate the Address updated sucessfully
                cp.Validate("Customer updated successfully.");
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
                cp.ProvideShippingZipCode(customer.ShippingZipcode);
                cp.ProvideShippingContactPerson(customer.ShippingContactPerson);
                cp.ClickOnSaveAddress();
                await WaitHelper.WaitForSeconds(1);
                #endregion

                #region Validate the Address updated sucessfully
                cp.Validate("Customer updated successfully.");
                #endregion 
            }
        }
        #endregion

        #region Create new customer with contact person details
        [Test, Category("Sales"), Order(4)]
        public async Task CreateNewCustomerWithContactPerson()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var customerFile = FileHelper.GetDataFile("Erp", "Sales", "Customer", "CustomerData");
            var customers = JsonHelper.ConvertJsonListDataModel<CustomerModel>(customerFile, "address");

            var sp = new SalesPage(_driver);
            var cp = new CustomerPage(_driver);
            var ssp = new SalesSetupPage(_driver);
            var clp = new CustomerListingPage(_driver);

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
                Thread.Sleep(5000);
            }
        }
        #endregion

        #region Delete new customer
        [Test, Category("Sales"), Order(5)]
        public async Task DeleteCustomer()
        {
            #region MyRegion
            Login(Product);
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
                cp.Validate("Customer deleted successfully");
                #endregion               
            }
        }
        #endregion
    }
}
