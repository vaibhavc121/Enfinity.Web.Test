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
using System.Reflection.Metadata;
using Bogus;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class SupplierTest: BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public SupplierTest()
        { }
        #endregion

        #region Create new supplier
        [Test, Category("Purchase"), Order(1)]
        public async Task CreateSupplier()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "new");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();
                
                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(customer.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the customer created name
                IWebElement customerName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string actualName = customerName.GetDomProperty("value");
                ClassicAssert.AreEqual(supplier.Name, actualName);
                #endregion

                sp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new supplier with keyinfo details
        [Test, Category("Purchase"), Order(2)]
        public async Task CreateSupplierWithKeyInfoDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "keyinfo");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);              

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(supplier.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);
                sp.ClickOnKeyInfoTab();

                sp.ClickOnSupplierGroup();
                CommonPageActions.SelectDropDownOption(supplier.Group);
                sp.ProvideContactPerson(supplier.ContactPerson);
                sp.ProvideMobile(supplier.Mobile);
                sp.ProvideEmail(supplier.Email);
                //sp.ClickOnRestrictPaymentTerm();
                sp.ClickOnPayableMainAccount();
                CommonPageActions.SelectDropDownOption(supplier.PayableAccount);
                sp.ProvideDescription(supplier.Description);
                
                sp.ClickOnEnableCreditControl();
                sp.ProvideCreditLimitAmount(supplier.CreditLimitAmount);
                sp.ProvideCreditLimitDays(supplier.CreditLimitDays);                  

                sp.ClickOnSetDefaults();                 
                sp.ClickOnPaymentTerm();
                CommonPageActions.SelectDropDownOption(supplier.PaymentTerm);                 
                sp.ClickOnShippingTerm();
                CommonPageActions.SelectDropDownOption(supplier.ShippingTerm);
                sp.ProvideLoadingPort(supplier.LoadingPort);
                sp.ProvideDestinationPort(supplier.DestinationPort);
                IWebElement shipMethodElement = _driver.FindElement(By.XPath("(//input[contains(@id, '_DefaultShippingMethod')])"));
                ScrollHelper.ScrollToElement(shipMethodElement);                 
                sp.ClickOnShippingMethod();
                CommonPageActions.SelectDropDownOption(supplier.ShippingMethod);
                sp.ClickOnShipmentPriority();
                CommonPageActions.SelectDropDownOption(supplier.ShipmentPriority);

                IWebElement saveElement = _driver.FindElement(By.Id("InfoSave"));
                ScrollHelper.ScrollToElement(saveElement);
                await WaitHelper.WaitForSeconds(1);

                sp.ClickOnSaveKeyInfo();
                await WaitHelper.WaitForSeconds(1);

                #region validate key info updated or not
                CommonPageActions.ValidateSucess("Supplier updated successfully.");
                #endregion

                //#region Validate the credit limit is added or not
                //IWebElement creditLimit = _driver.FindElement(By.XPath("(//input[contains(@id, '_CreditLimitAmount')])"));
                //string creditLimitAmount = creditLimit.GetDomProperty("value");
                //StringAssert.Contains(supplier.CreditLimitAmount, creditLimitAmount);
                //#endregion

                //#region Validate the email is added or not
                //IWebElement supplierEmail = _driver.FindElement(By.CssSelector("input[name='ContactPersonEmail']"));
                //string actualEmail = supplierEmail.GetDomProperty("value");
                //StringAssert.Contains(supplier.Email, actualEmail);
                //#endregion

                sp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new supplier with contact person details
        [Test, Category("Purchase"), Order(3)]
        public async Task CreateSupplierWithContactPersonDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "multipersons");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(supplier.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);
                sp.ClickOnContactPersonTab();

                foreach (var person in supplier.Persons)
                {
                    sp.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);

                    sp.ClickOnPrefix();
                    CommonPageActions.SelectDropdownOption(person.Prefix);

                    sp.ProvideFirstName(person.FirstName);
                    sp.ProvideMiddleName(person.MiddleName);
                    sp.ProvideLastName(person.LastName);
                    sp.ProvideJobTitle(person.JobTitle);

                    sp.ClickOnGender();
                    CommonPageActions.SelectDropDownOption(person.Gender);

                    sp.ProvideMobileNumber(person.Mobile);
                    sp.ProvideTelNumber(person.Telephone);
                    sp.ProvideFax(person.Fax);
                    sp.ProvideEmailAddress(person.Email);
                    //sp.ClickOnDefault();
                    //sp.ClickOnFreezed();
                    sp.ClickOnSavePerson();

                    #region Validate the contact person name 
                    IWebElement personName = _driver.FindElement(By.XPath($"//div//h2[contains(text(),'{person.Prefix + " " + person.FirstName + " " + person.MiddleName + " " +person.LastName}')]"));
                    string actualName = personName.Text;
                    StringAssert.Contains(person.Prefix + " " + person.FirstName + " " + person.MiddleName + " " + person.LastName, actualName);
                    #endregion

                    sp.ClickOnBack();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
        }
        #endregion

        #region Create new supplier with Address details
        [Test, Category("Purchase"), Order(4)]
        public async Task CreateSupplierWithAddressDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "multiaddress");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(supplier.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(2);
                sp.ClickOnAddressTab();

                foreach (var address in supplier.Addresses)
                {
                    await WaitHelper.WaitForSeconds(1);
                    sp.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);                 

                    sp.ProvideAddressDescription(address.Description);
                    sp.ProvideAddress1(address.Address1);
                    sp.ProvideAddress2(address.Address2);
                    sp.ProvideAddress3(address.Address3);
                    sp.ProvideAddress4(address.Address4);
                    sp.ProvideAddress5(address.Address5);
                    sp.ProvideCity(address.City);
                    sp.ProvideState(address.State);
                    sp.ProvideDialingCode(address.DialingCode);
                    sp.ProvideAddressZipCode(address.Zipcode);
                    sp.ProvideAddressContactPerson(address.ContactPerson);
                    sp.ProvideAddressEmail(address.Email);
                    sp.ProvideAddressMobileNumber(address.MobileNumber);
                    sp.ProvideAddressTelNumber(address.TelNumber);
                    sp.ProvideAddressFaxNumber(address.FaxNumber);

                    //sp.ClickOnDefault();
                    //sp.ClickOnFreezed();
                    sp.ClickOnSaveAddress();

                    #region Validate the address description
                    IWebElement addressDescElement = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{address.Description}')]"));
                    string actualName = addressDescElement.Text;
                    StringAssert.Contains(address.Description, actualName);
                    #endregion

                    sp.ClickOnBack();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
        }
        #endregion

        #region Create new supplier with Items details
        [Test, Category("Purchase"), Order(5)]
        public async Task CreateSupplierWithItemDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "multiitems");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(supplier.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(2);
                sp.ClickOnItemTab();

                foreach (var item in supplier.Items)
                {
                    await WaitHelper.WaitForSeconds(1);
                    sp.ClickOnAdd();
                    await WaitHelper.WaitForSeconds(1);

                    sp.ClickOnItem();
                    CommonPageActions.SelectDropDownOption(item.Item);
                    sp.ClickOnSaveItem();
                    await WaitHelper.WaitForSeconds(2);

                    //#region Validate the address description
                    IWebElement element = _driver.FindElement(By.XPath($"//div[@class='item-details']//div//p[contains(text(),'{item.Item}')]"));
                    string actualName = element.Text;
                    StringAssert.Contains(item.Item, actualName);
                    //#endregion
                }

                sp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Create new supplier with document details
        [Test, Category("Purchase"), Order(6)]
        public async Task CreateSupplierWithDocumentDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "multidocuments");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);             

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(3);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                //sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ProvideSupplierArabicName(supplier.ArabicName);
                //cp.ClickOnCurrency();
                //CommonPageActions.SelectDropdownOption(supplier.Currency);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);

                sp.ClickOnDocumentsTab();

                #region Provide the values of document and click on save             
                foreach (var document in supplier.Documents)
                {
                    sp.ClickOnAdd();
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
                    IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.DocumentType + " (" + document.DocumentNumber + ")"}')]"));
                    string actualName = documentName.Text;
                    ClassicAssert.AreEqual(document.DocumentType + " (" + document.DocumentNumber + ")", actualName);
                    #endregion
                }
                #endregion

                sp.ClickOnBack();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion      

        #region Create new supplier with same name - not create
        [Test, Category("Purchase"), Order(7)]
        public async Task ValidateSupplierWithSameNameOrCodeNotAllowed()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "duplicate");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);

            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ClickOnNewSupplier();

                sp.ProvideSupplierName(supplier.Name);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the same name customer not create
                CommonPageActions.Validate("already exists");
                #endregion
                await WaitHelper.WaitForSeconds(3);

                sp.ProvideSupplierCode(supplier.Code);
                sp.ProvideSupplierName(supplier.Name);
                sp.ClickOnSaveSupplier();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the same code customer not create
                CommonPageActions.Validate("already exists");
                #endregion
            }
        }
        #endregion

        #region Delete new supplier
        [Test, Category("Purchase"), Order(8)]
        public async Task DeleteSupplier()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var supplierFile = FileHelper.GetDataFile("Erp", "Purchase", "Supplier", "SupplierData");
            var suppliers = JsonHelper.ConvertJsonListDataModel<SupplierModel>(supplierFile, "delete");

            var pp = new PurchasePage(_driver);
            var sp = new SupplierPage(_driver);
            var psp = new PurchaseSetupPage(_driver);
            var slp = new SupplierListingPage(_driver);


            foreach (var supplier in suppliers)
            {
                pp.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnSupplier();
                slp.ProvideSupplierName(supplier.Name);
                //await WaitHelper.WaitForSeconds(2);
                slp.ClickOnSelectedSupplierName();
                //await WaitHelper.WaitForSeconds(2);
                slp.clickOnContextMenuItem();
                slp.clickOnContextMenuDelete();
                //await WaitHelper.WaitForSeconds(2);
                slp.clickOnConfirmOk();
                //await WaitHelper.WaitForSeconds(1);

                #region Validate the customer deleted message
                CommonPageActions.ValidateSucess("Supplier deleted successfully");
                #endregion               
            }
        }
        #endregion
    }
}
