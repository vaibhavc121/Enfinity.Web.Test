﻿using Enfinity.Common.Test;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class ItemPage
    {
        private readonly IWebDriver _driver;

        #region Constructor
        public ItemPage(IWebDriver driver)
        {
            _driver = driver;
        }
        #endregion

        #region Locators

        #region Commom
        private By dropdownselect = By.CssSelector(".dx-widget.dx-button-normal.dx-dropdowneditor-button");        
        private By dropdownOptions = By.CssSelector(".dx-item-content, .dx-list-item-content");        
        private By addButton = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])");
        //private By saveButton = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[4]");
        private By saveButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[2]");
        private By savepopupButton = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[3]");
        //IList<IWebElement> dropdownList = BaseTest._driver.FindElements(By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])"));
        #endregion

        #region Item Tabs
        private By KeyinfoTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Key Info']");
        private By bomTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Bill Of Material']");
        private By uomTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Unit Of Measures']");
        private By suppliersTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Suppliers']");
        private By pricelistsTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Price Lists']");
        private By warehouseTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Warehouses']");
        private By barcodesTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Barcodes']");
        private By documentsTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Documents']");
        private By setupTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Setup']");
        private By dimensionTab = By.XPath("//span[contains(@class, 'dx-tab-text') and text()='Dimensions']");
        #endregion

        #region Create New Item
        private By itemName = By.CssSelector("input[name='Name']");
        private By itemarabicName = By.CssSelector("input[name='NameL2']");
        //private By dropdownselectofUOM = By.CssSelector(".dx-widget.dx-dropdowneditor-button");
        private By dropdownofbaseUOM = By.XPath("(//input[contains(@id, '_BaseUnitOfMeasureId')])");
        //private By dropdownselectofType = By.XPath("(//div[contains(@class, 'dx-button-content')])[13]");
        private By dropdownofitemType = By.XPath("(//input[contains(@id, 'ItemType')])");
        //private By dropdownselectofTrackingMode = By.XPath("(//div[contains(@class, 'dx-button-content')])[14]");
        private By dropdownoftrackingMode = By.XPath("(//input[contains(@id, 'TrackingMode')])");
        //private By dropdownselectofCostingMethod = By.XPath("(//div[contains(@class, 'dx-button-content')])[15]");
        private By dropdownofcostingMethod = By.XPath("(//input[contains(@id, 'CostingMethod')])");
        private By salesPrice = By.XPath("(//input[contains(@id, 'SalesPrice')])");
        private By purchasePrice = By.XPath("(//input[contains(@id, 'PurchasePrice')])");
        private By enableSize = By.XPath("(//div[contains(@class, 'dx-switch-container')])[1]");
        private By enableColor = By.XPath("(//div[contains(@class, 'dx-switch-container')])[2]");
        private By saveItem = By.CssSelector("#MainMenu_DXI0_T, #MainMenu_DXI0_");
        #endregion

        #region Key Info Tab
        private By dropdownselectitemGroup = By.XPath("//input[contains(@id, 'ItemGroupId')]");
        private By dropdownselectitemCategory = By.XPath("//input[contains(@id, 'ItemCategoryId')]");
        private By dropdownselectBrand = By.XPath("//input[contains(@id, 'BrandId')]");
        //private By salesPrice = By.CssSelector("input[name='SalesPrice']");
        //private By purchasePrice = By.CssSelector("input[name='PurchasePrice']");
        private By description = By.XPath("//textarea[contains(@id, 'Description')]");
        //private By savekeyInfo = By.XPath("//div[contains(@class, 'dx-button-content')]//span[contains(@class, 'dx-button-text') and text()='Save']");
        private By savekeyInfo = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])");
        private By backBtn = By.Id("pre-Button");
        #endregion

        #region BOM Tab
        //private By dropdownselectbomItem = By.XPath("(//div[contains(@class, 'dx-texteditor-buttons-container')])[23]");
        private By dropdowncomponentItem = By.XPath("(//input[contains(@id, 'ComponentItemId')])");
        private By quantity = By.XPath("//input[contains(@id, 'ComponentBaseQtyPerAssembledUnit')]");
        #endregion

        #region Unit of Measures Tab
        private By adduomBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[2]");
        //private By adduomBtn = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Add a row'])[1]");
        private By dropdownselectUOM = By.XPath("(//input[contains(@id, 'UnitOfMeasureId')])[2]");
        private By conversionFactor = By.XPath("//input[contains(@id, 'ConversionFactor')]");
        private By reportingUOM = By.XPath("(//div[contains(@class, 'dx-switch-container')])[1]");
        private By salesDefault = By.XPath("(//div[contains(@class, 'dx-switch-container')])[2]");
        private By purchaseDefault = By.XPath("(//div[contains(@class, 'dx-switch-container')])[3]");        
        //private By dropdownselectUOM = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[6]");
        //private By saveuomButton = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[6]");
        private By saveuomButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[3]");
        #endregion

        #region Supplliers Tab
        private By addsupplierBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[3]");
        //private By dropdownselectSupplier = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[9]");
        private By dropdownselectSupplier = By.XPath("//input[contains(@id, 'SupplierId')]");
        //private By dropdownselectPurchaseRateCurrency = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[4]");
        private By dropdownpurchaserateCurrency = By.XPath("//input[contains(@id, 'PurchaseRateCurrencyId')]");
        private By dropdownpurchaseratecurrencyAll = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[10]");
        //private By dropdownselectUom = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[5]");
        private By dropdownselectUom = By.XPath("//input[contains(@id, 'PurchaseUnitOfMeasureId')]");
        private By dropdownselectuomAll = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-dropdowneditor-button')])[8]");
        private By purchaseUnitPrice = By.XPath("//input[contains(@id, 'PurchaseUnitPrice')]");
        //private By manufacturerPartNum = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[26]");
        private By manufacturerPartNum = By.XPath("(//input[contains(@id, '_ManufacturerPartNum')])[2]");
        private By manufacturerBarcode = By.XPath("//input[contains(@id, 'ManufacturerBarcode')]");
        private By preferredForPurchase = By.XPath("(//div[contains(@class, 'dx-switch-container')])[1]");
        private By preferredForpurchaseAll = By.XPath("(//div[contains(@class, 'dx-switch-container')])[2]");
        private By preferredForEstimation = By.XPath("(//div[contains(@class, 'dx-switch-container')])[2]");
        private By preferredForestimationAll = By.XPath("(//div[contains(@class, 'dx-switch-container')])[3]");
        private By freezed = By.XPath("(//div[contains(@class, 'dx-switch-container')])[3]");
        //private By savesupplierBtn = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[9]");
        private By savesupplierButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[4]");
        #endregion

        #region Price Lists Tab
        private By addpricelistBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[4]");
        //private By dropdownselectpriceList = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[14]");
        private By dropdownselectpriceList = By.XPath("(//input[contains(@id, 'PriceList')])");
        //private By dropdownselectofpricelistUom = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[4]");
        private By dropdownselectofpricelistUom = By.XPath("(//input[contains(@id, '_UnitOfMeasureId')])");
        private By dropdownselectpricelistuomAll = By.XPath("(//input[contains(@id, 'UnitOfMeasure')])[5]");
        private By pricelistunitPrice = By.XPath("//input[contains(@id, 'UnitPrice')]");
        private By pricelistunitPriceAll = By.XPath("(//input[contains(@id, 'UnitPrice')])[2]");
        private By pricelistminimumunitPrice = By.XPath("//input[contains(@id, 'MinimumUnitPrice')]");
        private By pricelistmaximumunitPrice = By.XPath("//input[contains(@id, 'MaximumUnitPrice')]");
        private By pricelistdefaultdiscountinPercent = By.XPath("//input[contains(@id, 'DefaultDiscountInPercent')]");
        private By pricelistmaximumdiscountinPercent = By.XPath("//input[contains(@id, 'MaximumDiscountInPercent')]");
        private By defaultField = By.XPath("(//div[contains(@class, 'dx-switch-container')])");        
        //private By savepricelistButton = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[12]");
        private By savepricelistButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[5]");
        #endregion

        #region Warehouses Tab
        private By addwarehouseBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[5]");
        //private By dropdownselectWarehouse = By.XPath("(//div[contains(@class, 'dx-dropdowneditor-button')])[15]");
        private By dropdownselectWarehouse = By.XPath("//input[contains(@id, '_WarehouseId')]");
        private By binLocation = By.XPath("//input[contains(@id, 'BinLocation')]");
        //private By maximumstockLevel = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[24]");
        private By maximumstockLevel = By.XPath("(//input[contains(@id, 'MaximumStockLevel')])[2]");
        //private By minimumstockLevel = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[25]");
        private By minimumstockLevel = By.XPath("(//input[contains(@id, 'MinimumStockLevel')])[2]");
        //private By reorderstockLevel = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[26]");
        private By reorderstockLevel = By.XPath("(//input[contains(@id, 'ReorderStockLevel')])[2]");
        //private By maximumReorder = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[27]");
        private By maximumReorder = By.XPath("(//input[contains(@id, 'MaximumReorder')])[2]");
        //private By minimumReorder = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[28]");
        private By minimumReorder = By.XPath("(//input[contains(@id, 'MinimumReorder')])[2]");
        private By warehouseFreezed = By.XPath("(//div[contains(@class, 'dx-switch-container')])");
        //private By savewareouseBtn = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[15]");
        private By savewarehouseButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[6]");
        #endregion

        #region Barcodes Tab
        private By addbarcodeButton = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[6]");
        //private By barcode = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[22]");
        private By barcode = By.XPath("(//input[contains(@id, '_Barcode')])");
        private By dropdownbarcodeUOM = By.XPath("(//input[contains(@id, '_UnitOfMeasureId')])[3]");
        private By barcodeFreezed = By.XPath("(//div[contains(@class, 'dx-switch-container')])");
        private By savebarcodeButton = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[7]");
        #endregion

        #region Documents Tab
        private By adddocumentBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[7]");
        //private By documentNumber = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[23]");
        private By documentNumber = By.XPath("(//input[contains(@id, 'DocumentNumber')])");
        //private By dateofIssue = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[24]");
        private By dateofIssue = By.XPath("(//input[contains(@id, 'DateOfIssue')])");
        //private By placeofIssue = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[25]");
        private By placeofIssue = By.XPath("(//input[contains(@id, 'PlaceOfIssue')])");
        //private By dateofExpiry = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[26]");
        private By dateofExpiry = By.XPath("(//input[contains(@id, 'DateOfExpiry')])");        
        #endregion

        #region Setups Tab
        private By dropdownselectofrevenueAccount = By.XPath("//input[contains(@id, 'RevenueMainAccountId')]");
        private By dropdownselectofinventoryAccount = By.XPath("//input[contains(@id, 'InventoryMainAccountId')]");
        private By dropdownselectofcostofgoodssoldAccount = By.XPath("//input[contains(@id, 'CogsMainAccountId')]");
        private By dropdownselectofadjustmentAccount = By.XPath("//input[contains(@id, 'AdjustmentMainAccountId')]");
        private By dropdownselectofexpenseAccount = By.XPath("//input[contains(@id, 'ExpenseMainAccountId')]");
        private By dropdownselectofinventorysuspenseAccount = By.XPath("//input[contains(@id, 'InventorySuspenseMainAccountId')]");
        private By dropdownselectofstoretostoretransferAccount = By.XPath("//input[contains(@id, 'StoreToStoreInTransitMainAccountId')]");
        private By dropdownselectofworkinprogressAccount = By.XPath("//input[contains(@id, 'WorkInProgressMainAccountId')]");
        private By saveAccount = By.Id("SetupSave");
        #endregion

        #region Dimensions Tab
        //private By colorCode = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[22]");
        private By colorCode = By.XPath("(//input[contains(@id, '_Code')])[2]");
        //private By colorName = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[23]");
        private By colorName = By.XPath("(//input[contains(@id, '_Name')])[3]");
        //private By colorarabicName = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[24]");
        private By colorarabicName = By.XPath("(//input[contains(@id, '_NameL2')])[2]");
        private By colorGenerate = (By.XPath("(//div[@aria-label='Generate'])[1]"));
        //private By sizeCode = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[25]");
        private By sizeCode = By.XPath("(//input[contains(@id, '_Code')])[3]");
        //private By sizeName = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[26]");
        private By sizeName = By.XPath("(//input[contains(@id, '_Name')])[5]");
        //private By sizearabicName = By.XPath("(//input[contains(@class, 'dx-texteditor-input')])[27]");
        private By sizearabicName = By.XPath("(//input[contains(@id, '_NameL2')])[3]");
        private By addsizeBtn = By.XPath("(//i[contains(@class, 'dx-icon-edit-button-addrow')])[2]");
        //private By savesizeBtn = By.XPath("(//div[contains(@class, 'dx-widget') and contains(@class, 'dx-button') and contains(@class, 'dx-button-mode-contained') and contains(@class, 'dx-button-normal') and contains(@class, 'dx-button-has-text')])[6]");
        private By savesizeBtn = By.XPath("(//span[@class='dx-button-text'][normalize-space()='Save'])[3]");
        private By sizeGenerate = (By.XPath("(//div[@aria-label='Generate'])[2]"));
        #endregion

        #endregion

        #region Action Methods

        #region Create New Item Action Methods
        public void provideItemName(string itemname, string arabicname)
        {
            _driver.FindElement(itemName).SendKeys(itemname);
            _driver.FindElement(itemarabicName).SendKeys(arabicname);
        }
        public void clickUOM()
        {
            _driver.FindElement(dropdownofbaseUOM).Click();
        }
        public void clickItemType()
        {
            _driver.FindElement(dropdownofitemType).Click();
        }
        public void clickTrackingMode()
        {
            _driver.FindElement(dropdownoftrackingMode).Click();
        }
        public void clickCostingMethod()
        {
            _driver.FindElement(dropdownofcostingMethod).Click();
        }
        public void clickEnableSize()
        {
            _driver.FindElement(enableSize).Click();
        }
        public void clickEnableColor()
        {
            _driver.FindElement(enableColor).Click();
        }
        public void clickSaveItem()
        {
            _driver.FindElement(saveItem).Click();
        }
        #endregion

        #region Key Info Action Methods
        public void clickOnKeyInfoTab()
        {
            _driver.FindElement(KeyinfoTab).Click();
        }
        public void clickItemGroup()
        {
            _driver.FindElement(dropdownselectitemGroup).Click();
        }
        public void clickItemCategory()
        {
            _driver.FindElement(dropdownselectitemCategory).Click();
        }
        public void clickBrand()
        {
            _driver.FindElement(dropdownselectBrand).Click();
        }
        public void provideSalesPrice(string price)
        {
            _driver.FindElement(salesPrice).SendKeys(price);
        }
        public void providePurchasePrice(string price)
        {
            _driver.FindElement(purchasePrice).SendKeys(price);
        }
        public void provideDescription(string desc)
        {
            _driver.FindElement(description).SendKeys(desc);
        }
        public void clickSaveKeyInfo()
        {
            _driver.FindElement(savekeyInfo).Click();
        }
        #endregion

        #region BOM Tab Action Methods
        public void provideQty(string qty)
        {
            _driver.FindElement(quantity).SendKeys(qty);
        }
        public void clickDropDownComponentItem()
        {
            _driver.FindElement(dropdowncomponentItem).Click();
        }
        #endregion

        #region Unit of Measure Action Methods
        public void clickOnAddUom()
        {
            //_driver.FindElement(adduomBtn).Click();
            IWebElement element = _driver.FindElement(adduomBtn);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);            
        }
        public void clickDropDownUOM()
        {
            _driver.FindElement(dropdownselectUOM).Click();
        }
        public void provideConversionFactor(string qty)
        {
            _driver.FindElement(conversionFactor).SendKeys(qty);
        }
        public void clickReportingUOM()
        {
            _driver.FindElement(reportingUOM).Click();
        }
        public void clickSalesDefault()
        {
            _driver.FindElement(salesDefault).Click();
        }
        public void clickPurchaseDefault()
        {
            _driver.FindElement(purchaseDefault).Click();
        }
        public void clickSaveUom()
        {
            _driver.FindElement(saveuomButton).Click();            
        }
        #endregion

        #region Suppliers Action Methods
        public void clickDropDownSupplier()
        {
            _driver.FindElement(dropdownselectSupplier).Click();
        }
        public void clickPurchaseRateCurrency()
        {
            _driver.FindElement(dropdownpurchaserateCurrency).Click();
        }
        public void clickSupplierUOM()
        {
            _driver.FindElement(dropdownselectUom).Click();
        }
        public void providePurchaseUnitPrice(string price)
        {
            _driver.FindElement(purchaseUnitPrice).SendKeys(price);
        }
        public void provideManufacturerPartNum(string num)
        {
            _driver.FindElement(manufacturerPartNum).SendKeys(num);
        }
        public void provideManufacturerBarcode(string barcode)
        {
            _driver.FindElement(manufacturerBarcode).SendKeys(barcode);
        }
        public void clickPreferredForPurchase()
        {
            _driver.FindElement(preferredForPurchase).Click();
        }
        public void clickPreferredForPurchaseAll()
        {
            _driver.FindElement(preferredForpurchaseAll).Click();
        }
        public void clickPreferredForEstimation()
        {
            _driver.FindElement(preferredForEstimation).Click();
        }
        public void clickPreferredForEstimationAll()
        {
            _driver.FindElement(preferredForestimationAll).Click();
        }
        public void clickFreezed()
        {
            _driver.FindElement(freezed).Click();
        }
        public void clickOnAddSupplier()
        {
            //_driver.FindElement(adduomBtn).Click();
            IWebElement element = _driver.FindElement(addsupplierBtn);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }
        public void clickDropDownPRCAll()
        {
            _driver.FindElement(dropdownpurchaseratecurrencyAll).Click();
        }
        public void clickDropDownUomAll()
        {
            _driver.FindElement(dropdownselectuomAll).Click();
        }
        public void clickDropDownSupplierUOM()
        {
            _driver.FindElement(dropdownselectUom).Click();
        }
        public void clickSaveSupplier()
        {            
           _driver.FindElement(savesupplierButton).Click();             
        }
        #endregion

        #region Price List Action Methods
        public void clickDropDownPriceList()
        {
            _driver.FindElement(dropdownselectpriceList).Click();
        }
        public void clickDropDownPriceListUomAll()
        {
            _driver.FindElement(dropdownselectpricelistuomAll).Click();
        }
        public void clickPriceListUOM()
        {
            _driver.FindElement(dropdownselectofpricelistUom).Click();
        }
        public void providePriceListUnitPrice(string unitprice)
        {
            _driver.FindElement(pricelistunitPrice).SendKeys(unitprice);
        }
        public void providePriceListUnitPriceAll(string unitprice)
        {
            _driver.FindElement(pricelistunitPriceAll).SendKeys(unitprice);
        }
        public void providePriceListMinimumUnitPrice(string unitprice)
        {
            _driver.FindElement(pricelistminimumunitPrice).SendKeys(unitprice);
        }
        public void providePriceListMaximumUnitPrice(string unitprice)
        {
            _driver.FindElement(pricelistmaximumunitPrice).SendKeys(unitprice);
        }
        public void providePriceListDefaultDiscountinPercent(string discount)
        {
            _driver.FindElement(pricelistdefaultdiscountinPercent).SendKeys(discount);
        }
        public void providePriceListMaximumDiscountinPercent(string discount)
        {
            _driver.FindElement(pricelistmaximumdiscountinPercent).SendKeys(discount);
        }
        public void clickOnAddPriceList()
        {
            _driver.FindElement(addpricelistBtn).Click();
        }
        public void clickSavePriceList()
        {
            _driver.FindElement(savepricelistButton).Click();
        }
        #endregion

        #region Warehouse Action Methods
        public void clickOnAddWarehouse()
        {
            _driver.FindElement(addwarehouseBtn).Click();
        }
        public void clickDropDownWarehouse()
        {
            _driver.FindElement(dropdownselectWarehouse).Click();
        }
        public void provideBinLocation(string location)
        {
            _driver.FindElement(binLocation).SendKeys(location);
        }
        public void provideMaximumStockLevel(string level)
        {
            _driver.FindElement(maximumstockLevel).SendKeys(level);
        }
        public void provideMinimumStockLevel(string level)
        {
            _driver.FindElement(minimumstockLevel).SendKeys(level);
        }
        public void provideReorderStockLevel(string level)
        {
            _driver.FindElement(reorderstockLevel).SendKeys(level);
        }
        public void provideMaximumReorder(string reorder)
        {
            _driver.FindElement(maximumReorder).SendKeys(reorder);
        }
        public void provideMinimumReorder(string reorder)
        {
            _driver.FindElement(minimumReorder).SendKeys(reorder);
        }
        public void clickWarehouseFreezed()
        {
            _driver.FindElement(warehouseFreezed).Click();
        }
        public void clickSaveWarehouse()
        {
            _driver.FindElement(savewarehouseButton).Click();
        }
        #endregion

        #region Barcode Action Methods
        public void clickOnAddBarcode()
        {
            _driver.FindElement(addbarcodeButton).Click();
        }
        public void clickDropDownBarcodeUOM()
        {
            _driver.FindElement(dropdownbarcodeUOM).Click();
        }
        public void provideBarcode(string barcodenum)
        {
            _driver.FindElement(barcode).SendKeys(barcodenum);
        }
        public void clickBarcodeFreezed()
        {
            _driver.FindElement(barcodeFreezed).Click();
        }
        public void clickSaveBarcode()
        {
            _driver.FindElement(savebarcodeButton).Click();
        }
        #endregion

        #region Documents Action Methods
        public void provideDocumentNumber(string documentnum)
        {
            _driver.FindElement(documentNumber).SendKeys(documentnum);
        }
        public void provideDateOfIssue(string date)
        {
            _driver.FindElement(dateofIssue).SendKeys(date);
        }
        public void provideDateOfExpiry(string date)
        {
            _driver.FindElement(dateofExpiry).SendKeys(date);
        }
        public void providePlaceOfIssue(string place)
        {
            _driver.FindElement(placeofIssue).SendKeys(place);
        }
        #endregion

        #region Setup Action Methods
        public void clickRevenueAccount()
        {
            _driver.FindElement(dropdownselectofrevenueAccount).Click();
        }
        public void clickInventoryAccount()
        {
            _driver.FindElement(dropdownselectofinventoryAccount).Click();
        }
        public void clickcostofgoodssoldAccount()
        {
            _driver.FindElement(dropdownselectofcostofgoodssoldAccount).Click();
        }
        public void clickadjustmentAccount()
        {
            _driver.FindElement(dropdownselectofadjustmentAccount).Click();
        }
        public void clickexpenseAccount()
        {
            _driver.FindElement(dropdownselectofexpenseAccount).Click();
        }
        public void clickinventorysuspenseAccount()
        {
            _driver.FindElement(dropdownselectofinventorysuspenseAccount).Click();
        }
        public void clickstoretostoretransferAccount()
        {
            _driver.FindElement(dropdownselectofstoretostoretransferAccount).Click();
        }
        public void clickworkinprogressAccount()
        {
            _driver.FindElement(dropdownselectofworkinprogressAccount).Click();
        }
        public void clickSaveAccountBtn()
        {
            _driver.FindElement(saveAccount).Click();
        }
        #endregion

        #region Dimensions Action Methods
        public void provideColorCode(string code)
        {
            _driver.FindElement(colorCode).SendKeys(code);
        }
        public void provideColorName(string name)
        {
            _driver.FindElement(colorName).SendKeys(name);
        }
        public void provideColorArabicName(string arabicname)
        {
            _driver.FindElement(colorarabicName).SendKeys(arabicname);
        }
        public void provideSizeCode(string code)
        {
            _driver.FindElement(sizeCode).SendKeys(code);
        }
        public void provideSizeName(string name)
        {
            _driver.FindElement(sizeName).SendKeys(name);
        }
        public void provideSizeArabicName(string arabicname)
        {
            _driver.FindElement(sizearabicName).SendKeys(arabicname);
        }
        public void clickOnAddSizeBtn()
        {
            _driver.FindElement(addsizeBtn).Click();
        }
        public void clickSaveSizeBtn()
        {
            _driver.FindElement(savesizeBtn).Click();
        }
        public void clickColorGenerate()
        {
            _driver.FindElement(colorGenerate).Click();
        }
        public void clickSizeGenerate()
        {
            _driver.FindElement(sizeGenerate).Click();
        }
        #endregion

        #region Tabs Action Methods
        public void clickOnBOMTab()
        {
            _driver.FindElement(bomTab).Click();
        }
        public void clickOnUOMTab()
        {
            _driver.FindElement(uomTab).Click();
        }
        public void clickOnSuppliersTab()
        {
            _driver.FindElement(suppliersTab).Click();
        }
        public void clickOnPriceListsTab()
        {
            _driver.FindElement(pricelistsTab).Click();
        }
        public void clickOnWarehouseTab()
        {
            _driver.FindElement(warehouseTab).Click();
        }
        public void clickOnBarcodesTab()
        {
            _driver.FindElement(barcodesTab).Click();
        }
        public void clickOnDocumentsTab()
        {
            _driver.FindElement(documentsTab).Click();
        }
        public void clickOnSetupTab()
        {
            _driver.FindElement(setupTab).Click();
        }
        public void clickOnDimensionTab()
        {
            _driver.FindElement(dimensionTab).Click();
        }
        #endregion

        #region Common Action Methods
        public void clickDropDown()
        {
            Thread.Sleep(1000);
            _driver.FindElement(dropdownselect).Click();
        }
        public void selectDropDownOption(string option)
        {
            Thread.Sleep(1000);
            var options = _driver.FindElements(dropdownOptions);

            foreach (var valueElement in options)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(option))
                {
                    valueElement.Click();
                    //Thread.Sleep(1000);
                    return;
                }
            }
        }
        public void selectDropDownOptions(string option)
        {
            Thread.Sleep(1000);
            // Find the list of dropdown elements
            IList<IWebElement> options = _driver.FindElements(By.CssSelector(".dx-item-content, .dx-list-item-content"));

            // Loop through each dropdown element            
            foreach (var valueElement in options)
            {
                string actualValue = valueElement.Text;

                // If the dropdown name matches the desired one, click it
                if (actualValue.Equals(option))
                {
                    valueElement.Click();
                    return;
                }
            }
        }
        public void clickBackButton()
        {
            _driver.FindElement(backBtn).Click();
        }
        public void clickOnAdd()
        {
            _driver.FindElement(addButton).Click();
        }        
        public void clickOnPopupSave()
        {
            _driver.FindElement(saveButton).Click();
        }
        public void clickOnSave()
        {
            _driver.FindElement(saveButton).Click();
        }
        public void clickDefault()
        {
            _driver.FindElement(defaultField).Click();
        }
        #endregion

        #endregion
    }
}