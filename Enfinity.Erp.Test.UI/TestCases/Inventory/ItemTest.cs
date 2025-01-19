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
    public class ItemTest : BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public ItemTest()
        {

        }
        #endregion

        #region createNewItem
        [Test, Category("Inventory"), Order(1)]
        public void createNewItem()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "new");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.selectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.selectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);

                #region
                IWebElement itemName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string expectedName = itemName.GetDomProperty("value");
                ClassicAssert.AreEqual(expectedName, item.Name);
                #endregion

                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithKeyInfoDetails
        [Test, Category("Inventory"), Order(2)]
        public void CreateNewItemWithKeyInfoDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "keyinfo");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.selectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.selectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);

                itemPage.clickItemGroup();
                itemPage.selectDropDownOption(item.ItemGroup);
                itemPage.clickItemCategory();
                itemPage.selectDropDownOption(item.ItemCategory);
                itemPage.clickBrand();
                itemPage.selectDropDownOption(item.Brand);
                itemPage.provideSalesPrice(item.SalesPrice);
                itemPage.providePurchasePrice(item.PurchasePrice);
                itemPage.provideDescription(item.Description);
                itemPage.clickSaveKeyInfo();
                Thread.Sleep(2000);

                #region
                IWebElement itemName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string expectedName = itemName.GetDomProperty("value");
                ClassicAssert.AreEqual(expectedName, item.Name);
                #endregion

                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithBOMComponent 
        [Test, Category("Inventory"), Order(3)]
        public void CreateNewItemWithBOMComponent()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "newbom");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.selectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.selectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                itemPage.clickOnBOMTab();

                foreach (var subItem in item.SubItems)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    //itemPage.clickDropDown();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.selectDropDownOption(subItem.SubItem);
                    itemPage.provideQty(subItem.Qty);
                    itemPage.clickOnSave();

                    #region Validating the subItems added or not
                    IWebElement subItemName = _driver.FindElement(By.CssSelector($"p[title='{subItem.ExpectedName}']"));
                    string expectedName = subItemName.Text;
                    ClassicAssert.AreEqual(expectedName, subItem.ActualName);
                    #endregion

                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithMultipleUOM
        [Test, Category("Inventory"), Order(4)]
        public void CreateNewItemWithMultipleUOM()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multiuom");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnUOMTab();

                foreach (var uom in item.ItemUoms)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(uom.Uom);
                    itemPage.provideConversionFactor(uom.ConversionFactor);
                    //itemPage.clickReportingUOM();
                    //itemPage.clickSalesDefault();
                    //itemPage.clickPurchaseDefault();
                    itemPage.clickOnSave();

                    #region Validation
                    IWebElement uomName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{uom.ExpectedName}')]"));
                    string expectedName = uomName.Text;
                    ClassicAssert.AreEqual(expectedName, uom.ActualName);
                    #endregion
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }

        }
        #endregion

        #region CreateNewItemWithMultipleSuppliers
        [Test, Category("Inventory"), Order(5)]
        public void CreateNewItemWithMultipleSuppliers()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multisupplier");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnSuppliersTab();

                foreach (var supplier in item.Suppliers)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(supplier.Supplier);
                    itemPage.clickPurchaseRateCurrency();
                    itemPage.selectDropDownOption(supplier.PurchaseRateCurrency);
                    itemPage.clickSupplierUOM();
                    itemPage.selectDropDownOption(supplier.Uom);
                    itemPage.providePurchaseUnitPrice(supplier.PurchaseUnitPrice);
                    itemPage.provideManufacturerPartNum(supplier.ManufacturerPartNum);
                    itemPage.provideManufacturerBarcode(supplier.ManufacturerBarcode);
                    itemPage.clickPreferredForPurchase();
                    itemPage.clickPreferredForEstimation();                    
                    //itemPage.clickFreezed();
                    Thread.Sleep(2000);
                    itemPage.clickOnSave();

                    #region Validating the supplier name added or not
                    IWebElement supplierName = _driver.FindElement(By.XPath($"//div//p//span[contains(text(),'{supplier.ExpectedName}')]"));
                    string expectedName = supplierName.Text;
                    ClassicAssert.AreEqual(expectedName, supplier.ActualName);
                    #endregion
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithMultiplePriceLists
        [Test, Category("Inventory"), Order(6)]
        public void CreateNewItemWithMultiplePriceLists()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multipricelists");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnPriceListsTab();

                foreach (var pricelist in item.itemPriceLists)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(pricelist.PriceList);
                    itemPage.clickPriceListUOM();
                    itemPage.selectDropDownOption(pricelist.Uom);
                    itemPage.providePriceListUnitPrice(pricelist.UnitPrice);
                    itemPage.providePriceListMinimumUnitPrice(pricelist.MinimumUnitPrice);
                    itemPage.providePriceListMaximumUnitPrice(pricelist.MaximumUnitPrice);
                    itemPage.providePriceListDefaultDiscountinPercent(pricelist.DefaultDiscountInPercent);
                    itemPage.providePriceListMaximumDiscountinPercent(pricelist.MaximumDiscountInPercent);                   
                    //itemPage.clickDefault();
                    Thread.Sleep(1000);
                    itemPage.clickOnSave();

                    #region Validating the price list added or not
                    IWebElement pricelistName = _driver.FindElement(By.XPath($"//div//span[contains(text(),'{pricelist.ExpectedName}')]"));
                    string expectedName = pricelistName.Text;
                    ClassicAssert.AreEqual(expectedName, pricelist.ActualName);
                    #endregion
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithMultipleWarehouses
        [Test, Category("Inventory"), Order(7)]
        public void CreateNewItemWithMultipleWarehouses()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multiwarehouses");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);               
                itemPage.clickSaveItem();
                itemPage.clickOnWarehouseTab();

                foreach (var warehouse in item.Warehouses)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(warehouse.Warehouse);
                    itemPage.provideBinLocation(warehouse.BinLocation);
                    itemPage.provideMaximumStockLevel(warehouse.MaximumStockLevel);
                    itemPage.provideMinimumStockLevel(warehouse.MinimumStockLevel);
                    itemPage.provideReorderStockLevel(warehouse.ReorderStockLevel);
                    itemPage.provideMaximumReorder(warehouse.MaximumReorder);
                    itemPage.provideMinimumReorder(warehouse.MinimumReorder);                    
                    //itemPage.clickWarehouseFreezed();
                    Thread.Sleep(1000);
                    itemPage.clickOnSave();

                    #region Validating the warehouse name added or not
                    IWebElement warehouseName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{warehouse.ExpectedName}')]"));
                    string expectedName = warehouseName.Text;
                    ClassicAssert.AreEqual(expectedName, warehouse.ActualName);
                    #endregion

                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithMultipleBarcodes
        [Test, Category("Inventory"), Order(8)]
        public void CreateNewItemWithMultipleBarcodes()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multibarcodes");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnBarcodesTab();

                foreach (var barcode in item.Barcodes)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.provideBarcode(barcode.Barcode);
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(barcode.Uom);
                    //itemPage.clickBarcodeFreezed();
                    Thread.Sleep(1000);
                    itemPage.clickOnSave();

                    #region Validating the barcode added or not
                    IWebElement barcodeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{barcode.ExpectedName}')]"));
                    string expectedName = barcodeName.Text;
                    ClassicAssert.AreEqual(expectedName, barcode.Barcode);
                    #endregion
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithMultipleDocuments
        [Test, Category("Inventory"), Order(9)]
        public void CreateNewItemWithMultipleDocuments()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "multidocuments");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnDocumentsTab();

                foreach (var document in item.Documents)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.clickDropDown();
                    itemPage.selectDropDownOption(document.DocumentType);
                    itemPage.provideDocumentNumber(document.DocumentNumber);
                    itemPage.provideDateOfIssue(document.DateOfIssue);
                    itemPage.providePlaceOfIssue(document.PlaceOfIssue);
                    itemPage.provideDateOfExpiry(document.DateOfExpiry);
                    Thread.Sleep(1000);
                    itemPage.clickOnSave();

                    #region Validating the document type and number added or not
                    IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.ExpectedName}')]"));
                    string expectedName = documentName.Text;
                    ClassicAssert.AreEqual(expectedName, document.ActualName);
                    #endregion                 
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithAccountSetup
        [Test, Category("Inventory"), Order(10)]
        public void CreateNewItemWithAccountSetup()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "accountsetup");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);


            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnSetupTab();
                itemPage.clickRevenueAccount();
                itemPage.selectDropDownOption(item.RevenueAccount);
                itemPage.clickInventoryAccount();
                itemPage.selectDropDownOption(item.InventoryAccount);
                itemPage.clickcostofgoodssoldAccount();
                itemPage.selectDropDownOption(item.CostofGoodsSoldAccount);
                itemPage.clickadjustmentAccount();
                itemPage.selectDropDownOption(item.AdjustmentAccount);
                itemPage.clickexpenseAccount();
                itemPage.selectDropDownOption(item.ExpenseAccount);
                itemPage.clickinventorysuspenseAccount();
                itemPage.selectDropDownOption(item.InventorySuspenseAccount);
                itemPage.clickstoretostoretransferAccount();
                itemPage.selectDropDownOption(item.StoretoStoreTransferAccount);
                itemPage.clickworkinprogressAccount();
                itemPage.selectDropDownOption(item.WorkinProgressAccount);
                itemPage.clickSaveAccountBtn();
                Thread.Sleep(1000);

                #region Validate the accounts added or not 
                IWebElement accountName = _driver.FindElement(By.XPath("//input[contains(@id, 'RevenueMainAccountId')]"));
                string expectedName = accountName.GetDomProperty("value");
                ClassicAssert.AreEqual(expectedName, item.RevenueAccount);
                #endregion

                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region CreateNewItemWithDimensions
        [Test, Category("Inventory"), Order(11)]
        public void CreateNewItemWithDimensions()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "dimensions");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();

                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                itemPage.clickEnableSize();
                Thread.Sleep(2000);
                itemPage.clickEnableColor();
                Thread.Sleep(2000);
                itemPage.clickSaveItem();
                itemPage.clickOnDimensionTab();

                foreach (var color in item.Colors)
                {
                    //Thread.Sleep(1000);
                    //itemPage.clickColorGenerate();
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.provideColorCode(color.Code);
                    itemPage.provideColorName(color.Name);
                    itemPage.provideColorArabicName(color.ArabicName);
                    itemPage.clickOnSave();

                    #region Validating the color added or not
                    IWebElement colorName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{color.ExpectedName}')]"));
                    string expectedName = colorName.Text;
                    ClassicAssert.AreEqual(expectedName, color.ActualName);
                    #endregion
                }
                foreach (var size in item.Sizes)
                {
                    //Thread.Sleep(1000);
                    //itemPage.clickSizeGenerate();
                    Thread.Sleep(1000);
                    itemPage.clickOnAddSizeBtn();
                    itemPage.provideSizeCode(size.Code);                    
                    itemPage.provideSizeName(size.Name);                    
                    itemPage.provideSizeArabicName(size.ArabicName);
                    itemPage.clickSaveSizeBtn();

                    #region Validating the size added or not
                    IWebElement sizeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{size.ExpectedName}')]"));
                    string expectedName = sizeName.Text;
                    ClassicAssert.AreEqual(expectedName, size.ActualName);
                    #endregion
                }
                itemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Delete an Item
        [Test, Category("Inventory"), Order(12)]
        public void DeleteItem()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "delete");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();                
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();

                inventoryItemListingPage.provideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.clickOnSelectedItemName();
                Thread.Sleep(2000);
                inventoryItemListingPage.clickOnContextMenuItem();
                inventoryItemListingPage.clickOnContextMenuItemDelete();
                Thread.Sleep(2000);
                inventoryItemListingPage.clickOnConfirmOk();                
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region New Item with All Tabs Info
        [Test, Category("Inventory"), Order(13)]
        public void CreateItemWithAllTab()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "item");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.clickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.clickOnSetups();
                inventorySetupPage.clickOnItem();
                inventoryItemListingPage.clickOnNew();
                itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.selectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.selectDropDownOption(item.Type);
                //itemPage.clickTrackingMode();
                //itemPage.selectDropDownOption(item.TrackingMode);
                //itemPage.clickCostingMethod();
                //itemPage.selectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);
                itemPage.clickOnKeyInfoTab();
                itemPage.clickItemGroup();
                itemPage.selectDropDownOption(item.ItemGroup);
                itemPage.clickItemCategory();
                itemPage.selectDropDownOption(item.ItemCategory);
                itemPage.clickBrand();
                itemPage.selectDropDownOption(item.Brand);
                itemPage.provideSalesPrice(item.SalesPrice);
                itemPage.providePurchasePrice(item.PurchasePrice);
                itemPage.provideDescription(item.Description);
                itemPage.clickSaveKeyInfo();
                itemPage.clickOnBOMTab();
                Thread.Sleep(2000);

                foreach (var componentItem in item.SubItems)
                {
                    //Thread.Sleep(2000);
                    itemPage.clickOnAdd();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.selectDropDownOption(componentItem.SubItem);
                    itemPage.provideQty(componentItem.Qty);
                    itemPage.clickOnSave();

                    #region Validating the subItems added or not
                    IWebElement subItemName = _driver.FindElement(By.CssSelector($"p[title='{componentItem.ExpectedName}']"));
                    string expectedName = subItemName.Text;
                    ClassicAssert.AreEqual(expectedName, componentItem.ActualName);
                    #endregion
                }
                itemPage.clickOnUOMTab();
                Thread.Sleep(2000);

                foreach (var uom in item.ItemUoms)
                {
                    //Thread.Sleep(2000);
                    itemPage.clickOnAddUom();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownUOM();
                    itemPage.selectDropDownOption(uom.Uom);
                    itemPage.provideConversionFactor(uom.ConversionFactor);
                    //itemPage.clickReportingUOM();
                    //itemPage.clickSalesDefault();
                    //itemPage.clickPurchaseDefault();                    
                    itemPage.clickSaveUom();

                    #region Validation
                    IWebElement uomName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{uom.ExpectedName}')]"));
                    string expectedName = uomName.Text;
                    ClassicAssert.AreEqual(expectedName, uom.ActualName);
                    #endregion
                }
                itemPage.clickOnSuppliersTab();
                Thread.Sleep(2000);

                foreach (var supplier in item.Suppliers)
                {
                    itemPage.clickOnAddSupplier();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownSupplier();
                    itemPage.selectDropDownOption(supplier.Supplier);
                    //itemPage.clickDropDownPRCAll();
                    itemPage.clickPurchaseRateCurrency();
                    itemPage.selectDropDownOption(supplier.PurchaseRateCurrency);
                    //itemPage.clickDropDownUomAll();
                    itemPage.clickDropDownSupplierUOM();
                    itemPage.selectDropDownOption(supplier.Uom);
                    itemPage.providePurchaseUnitPrice(supplier.PurchaseUnitPrice);
                    itemPage.provideManufacturerPartNum(supplier.ManufacturerPartNum);
                    itemPage.provideManufacturerBarcode(supplier.ManufacturerBarcode);
                    //itemPage.clickPreferredForPurchaseAll();
                    //itemPage.clickPreferredForEstimationAll();
                    //itemPage.clickFreezed();                 
                    itemPage.clickSaveSupplier();

                    #region Validating the supplier name added or not
                    IWebElement supplierName = _driver.FindElement(By.XPath($"//div//p//span[contains(text(),'{supplier.ExpectedName}')]"));
                    string expectedName = supplierName.Text;
                    ClassicAssert.AreEqual(expectedName, supplier.ActualName);
                    #endregion
                }
                itemPage.clickOnPriceListsTab();
                Thread.Sleep(2000);

                foreach (var pricelist in item.itemPriceLists)
                {
                    itemPage.clickOnAddPriceList();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownPriceList();
                    itemPage.selectDropDownOption(pricelist.PriceList);
                    itemPage.clickDropDownPriceListUomAll();                    
                    itemPage.selectDropDownOption(pricelist.Uom);
                    itemPage.providePriceListUnitPriceAll(pricelist.UnitPrice);
                    itemPage.providePriceListMinimumUnitPrice(pricelist.MinimumUnitPrice);
                    itemPage.providePriceListMaximumUnitPrice(pricelist.MaximumUnitPrice);
                    itemPage.providePriceListDefaultDiscountinPercent(pricelist.DefaultDiscountInPercent);
                    itemPage.providePriceListMaximumDiscountinPercent(pricelist.MaximumDiscountInPercent);
                    //Thread.Sleep(2000);
                    //itemPage.clickDefault();                               
                    itemPage.clickSavePriceList();

                    #region Validating the price list added or not
                    IWebElement pricelistName = _driver.FindElement(By.XPath($"//div//span[contains(text(),'{pricelist.ExpectedName}')]"));
                    string expectedName = pricelistName.Text;
                    ClassicAssert.AreEqual(expectedName, pricelist.ActualName);
                    #endregion
                }
                itemPage.clickOnWarehouseTab();
                Thread.Sleep(2000);

                foreach (var warehouse in item.Warehouses)
                {
                    itemPage.clickOnAddWarehouse();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownWarehouse();
                    itemPage.selectDropDownOption(warehouse.Warehouse);
                    itemPage.provideBinLocation(warehouse.BinLocation);
                    itemPage.provideMaximumStockLevel(warehouse.MaximumStockLevel);
                    itemPage.provideMinimumStockLevel(warehouse.MinimumStockLevel);
                    itemPage.provideReorderStockLevel(warehouse.ReorderStockLevel);
                    itemPage.provideMaximumReorder(warehouse.MaximumReorder);
                    itemPage.provideMinimumReorder(warehouse.MinimumReorder);
                    //itemPage.clickWarehouseFreezed();                                      
                    itemPage.clickSaveWarehouse();

                    #region Validating the warehouse name added or not
                    IWebElement warehouseName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{warehouse.ExpectedName}')]"));
                    string expectedName = warehouseName.Text;
                    ClassicAssert.AreEqual(expectedName, warehouse.ActualName);
                    #endregion
                }
                itemPage.clickOnBarcodesTab();
                Thread.Sleep(2000);

                foreach (var barcode in item.Barcodes)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAddBarcode();                    
                    itemPage.provideBarcode(barcode.Barcode);
                    //itemPage.clickDropDown();                    
                    itemPage.clickDropDownBarcodeUOM();
                    itemPage.selectDropDownOption(barcode.Uom);
                    //itemPage.clickBarcodeFreezed();                                      
                    itemPage.clickSaveBarcode();

                    #region Validating the barcode added or not
                    IWebElement barcodeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{barcode.ExpectedName}')]"));
                    string expectedName = barcodeName.Text;
                    ClassicAssert.AreEqual(expectedName, barcode.Barcode);
                    #endregion
                }
            }
        }
        #endregion
    }
}