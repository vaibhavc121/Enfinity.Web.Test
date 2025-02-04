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

        #region create new item
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.SelectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.SelectDropDownOption(item.CostingMethod);
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

        #region Create new item with KeyInfo Details
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.SelectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.SelectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);

                itemPage.clickItemGroup();
                itemPage.SelectDropDownOption(item.ItemGroup);
                itemPage.clickItemCategory();
                itemPage.SelectDropDownOption(item.ItemCategory);
                itemPage.clickBrand();
                itemPage.SelectDropDownOption(item.Brand);
                itemPage.provideSalesPrice(item.SalesPrice);
                itemPage.providePurchasePrice(item.PurchasePrice);
                itemPage.provideDescription(item.Description);

                itemPage.provideManufacturerNameKey(item.ManufacturerName);
                itemPage.provideManufacturerPartNumKey(item.ManufacturerPartNum);
                itemPage.provideMaximumStockLevelKey(item.MaximumStockLevel);
                itemPage.provideMinimumStockLevelKey(item.MinimumStockLevel);
                itemPage.provideReorderStockLevelKey(item.ReorderStockLevel);
                itemPage.provideMaximumReorderKey(item.MaximumReorder);
                itemPage.provideMinimumReorderKey(item.MinimumReorder);

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

        #region Create new item with Multiple BOM Details  
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickTrackingMode();
                itemPage.SelectDropDownOption(item.TrackingMode);
                itemPage.clickCostingMethod();
                itemPage.SelectDropDownOption(item.CostingMethod);
                itemPage.clickSaveItem();
                itemPage.clickOnBOMTab();

                foreach (var subItem in item.SubItems)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    //itemPage.clickDropDown();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.SelectDropDownOption(subItem.SubItem);
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

        #region Create new item with Multiple UOM Details 
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnUOMTab();

                foreach (var uom in item.ItemUoms)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(uom.Uom);
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

        #region Create new item with Multiple Suppliers Details 
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnSuppliersTab();

                foreach (var supplier in item.Suppliers)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(supplier.Supplier);
                    itemPage.clickPurchaseRateCurrency();
                    itemPage.SelectDropDownOption(supplier.PurchaseRateCurrency);
                    itemPage.clickSupplierUOM();
                    itemPage.SelectDropDownOption(supplier.Uom);
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

        #region Create new item with Multiple PriceLists Details 
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnPriceListsTab();

                foreach (var pricelist in item.itemPriceLists)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(pricelist.PriceList);
                    itemPage.clickPriceListUOM();
                    itemPage.SelectDropDownOption(pricelist.Uom);
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

        #region Create new item with Multiple Warehouses Details 
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnWarehouseTab();

                foreach (var warehouse in item.Warehouses)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(warehouse.Warehouse);
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

        #region Create new item with Multiple Barcodes Details 
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnBarcodesTab();

                foreach (var barcode in item.Barcodes)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.provideBarcode(barcode.Barcode);
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(barcode.Uom);
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

        #region Create new item with Multiple Documents Details
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnDocumentsTab();

                foreach (var document in item.Documents)
                {
                    Thread.Sleep(1000);
                    itemPage.clickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(document.DocumentType);
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

        #region Create new item with Account Setup Details
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.clickOnSetupTab();
                itemPage.clickRevenueAccount();
                itemPage.SelectDropDownOption(item.RevenueAccount);
                itemPage.clickInventoryAccount();
                itemPage.SelectDropDownOption(item.InventoryAccount);
                itemPage.clickcostofgoodssoldAccount();
                itemPage.SelectDropDownOption(item.CostofGoodsSoldAccount);
                itemPage.clickadjustmentAccount();
                itemPage.SelectDropDownOption(item.AdjustmentAccount);
                itemPage.clickexpenseAccount();
                itemPage.SelectDropDownOption(item.ExpenseAccount);
                itemPage.clickinventorysuspenseAccount();
                itemPage.SelectDropDownOption(item.InventorySuspenseAccount);
                itemPage.clickstoretostoretransferAccount();
                itemPage.SelectDropDownOption(item.StoretoStoreTransferAccount);
                itemPage.clickworkinprogressAccount();
                itemPage.SelectDropDownOption(item.WorkinProgressAccount);
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

        #region Create new item with Dimensions Details
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
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
                    itemPage.provideColorCode(color.ColorCode);
                    itemPage.provideColorName(color.ColorName);
                    itemPage.provideColorArabicName(color.ColorArabicName);
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
                    itemPage.clickOnAddSize();
                    itemPage.provideSizeCode(size.SizeCode);
                    itemPage.provideSizeName(size.SizeName);
                    itemPage.provideSizeArabicName(size.SizeArabicName);
                    itemPage.clickSaveSize();

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

        #region Create new item with All Tabs Details
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
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                //itemPage.clickTrackingMode();
                //itemPage.selectDropDownOption(item.TrackingMode);
                //itemPage.clickCostingMethod();
                //itemPage.selectDropDownOption(item.CostingMethod);
                itemPage.clickEnableSize();
                Thread.Sleep(2000);
                itemPage.clickEnableColor();
                Thread.Sleep(2000);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);
                itemPage.clickOnKeyInfoTab();

                #region Key Info Tab
                itemPage.clickItemGroup();
                itemPage.SelectDropDownOption(item.ItemGroup);
                itemPage.clickItemCategory();
                itemPage.SelectDropDownOption(item.ItemCategory);
                itemPage.clickBrand();
                itemPage.SelectDropDownOption(item.Brand);
                itemPage.provideSalesPrice(item.SalesPrice);
                itemPage.providePurchasePrice(item.PurchasePrice);
                itemPage.provideDescription(item.Description);
                Thread.Sleep(1000);
                itemPage.provideManufacturerNameKey(item.ManufacturerName);
                itemPage.provideManufacturerPartNumKey(item.ManufacturerPartNum);
                itemPage.provideMaximumStockLevelKey(item.MaximumStockLevel);
                itemPage.provideMinimumStockLevelKey(item.MinimumStockLevel);
                itemPage.provideReorderStockLevelKey(item.ReorderStockLevel);
                itemPage.provideMaximumReorderKey(item.MaximumReorder);
                itemPage.provideMinimumReorderKey(item.MinimumReorder);
                itemPage.clickSaveKeyInfo();
                #endregion 

                Thread.Sleep(1000);
                itemPage.clickOnBOMTab();
                Thread.Sleep(2000);

                foreach (var componentItem in item.SubItems)
                {
                    //Thread.Sleep(2000);
                    itemPage.clickOnAdd();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.SelectDropDownOption(componentItem.SubItem);
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
                    itemPage.SelectDropDownOption(uom.Uom);
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
                    itemPage.SelectDropDownOption(supplier.Supplier);
                    //itemPage.clickDropDownPRCAll();
                    itemPage.clickPurchaseRateCurrency();
                    itemPage.SelectDropDownOption(supplier.PurchaseRateCurrency);
                    //itemPage.clickDropDownUomAll();
                    itemPage.clickDropDownSupplierUOM();
                    itemPage.SelectDropDownOption(supplier.Uom);
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
                    itemPage.SelectDropDownOption(pricelist.PriceList);
                    itemPage.clickDropDownPriceListUomAll();
                    itemPage.SelectDropDownOption(pricelist.Uom);
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
                    itemPage.SelectDropDownOption(warehouse.Warehouse);
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
                    itemPage.SelectDropDownOption(barcode.Uom);
                    //itemPage.clickBarcodeFreezed();                                      
                    itemPage.clickSaveBarcode();

                    #region Validating the barcode added or not
                    IWebElement barcodeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{barcode.ExpectedName}')]"));
                    string expectedName = barcodeName.Text;
                    ClassicAssert.AreEqual(expectedName, barcode.Barcode);
                    #endregion
                }
                itemPage.clickOnDocumentsTab();
                Thread.Sleep(2000);

                foreach (var document in item.Documents)
                {
                    itemPage.clickOnAddDocument();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownDocumentType();
                    itemPage.SelectDropDownOption(document.DocumentType);
                    itemPage.provideDocumentNumber(document.DocumentNumber);
                    itemPage.provideDateOfIssue(document.DateOfIssue);
                    itemPage.providePlaceOfIssue(document.PlaceOfIssue);
                    itemPage.provideDateOfExpiry(document.DateOfExpiry);
                    Thread.Sleep(1000);
                    itemPage.clickSaveDocument();

                    #region Validating the document type and number added or not
                    IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.ExpectedName}')]"));
                    string expectedName = documentName.Text;
                    ClassicAssert.AreEqual(expectedName, document.ActualName);
                    #endregion                 
                }
                itemPage.clickOnSetupTab();

                #region Account Setup Tab

                itemPage.clickRevenueAccount();
                itemPage.SelectDropDownOption(item.RevenueAccount);
                itemPage.clickInventoryAccount();
                itemPage.SelectDropDownOption(item.InventoryAccount);
                itemPage.clickcostofgoodssoldAccount();
                itemPage.SelectDropDownOption(item.CostofGoodsSoldAccount);
                itemPage.clickadjustmentAccount();
                itemPage.SelectDropDownOption(item.AdjustmentAccount);
                itemPage.clickexpenseAccount();
                itemPage.SelectDropDownOption(item.ExpenseAccount);
                itemPage.clickinventorysuspenseAccount();
                itemPage.SelectDropDownOption(item.InventorySuspenseAccount);
                itemPage.clickstoretostoretransferAccount();
                itemPage.SelectDropDownOption(item.StoretoStoreTransferAccount);
                itemPage.clickworkinprogressAccount();
                itemPage.SelectDropDownOption(item.WorkinProgressAccount);
                itemPage.clickSaveAccountBtn();
                Thread.Sleep(1000);

                #endregion 

                itemPage.clickOnDimensionTab();

                foreach (var color in item.Colors)
                {
                    //Thread.Sleep(1000);
                    //itemPage.clickColorGenerate();
                    Thread.Sleep(1000);
                    itemPage.clickOnAddColor();
                    itemPage.provideColorCode(color.ColorCode);
                    itemPage.provideColorName(color.ColorName);
                    itemPage.provideColorArabicName(color.ColorArabicName);
                    itemPage.clickSaveColor();

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
                    itemPage.clickOnAddSizeAll();
                    itemPage.provideSizeCode(size.SizeCode);
                    itemPage.provideSizeName(size.SizeName);
                    itemPage.provideSizeArabicName(size.SizeArabicName);
                    itemPage.clickSaveSizeAll();

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

        #region Delete items
        [Test, Category("Inventory"), Order(12) ]
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
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();

                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                Thread.Sleep(2000);
                inventoryItemListingPage.clickOnContextMenuItem();
                inventoryItemListingPage.clickOnContextMenuItemDelete();
                Thread.Sleep(2000);
                inventoryItemListingPage.clickOnConfirmOk();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Update an item with Key Info Details
        [Test, Category("Inventory"), Order(14)]
        public void UpdateItemKeyInfoDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {        
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                itemPage.clickOnKeyInfoTab();

                #region Key Info Tab
                itemPage.ProvideItemArabicName(item.ArabicName);
                itemPage.clickItemGroup();
                itemPage.SelectDropDownOption(item.ItemGroup);
                itemPage.clickItemCategory();
                itemPage.SelectDropDownOption(item.ItemCategory);
                itemPage.clickBrand();
                itemPage.SelectDropDownOption(item.Brand);
                itemPage.provideSalesPrice(item.SalesPrice);
                itemPage.providePurchasePrice(item.PurchasePrice);
                itemPage.provideDescription(item.Description);
                Thread.Sleep(1000);
                itemPage.provideManufacturerNameKey(item.ManufacturerName);
                itemPage.provideManufacturerPartNumKey(item.ManufacturerPartNum);
                itemPage.provideMaximumStockLevelKey(item.MaximumStockLevel);
                itemPage.provideMinimumStockLevelKey(item.MinimumStockLevel);
                itemPage.provideReorderStockLevelKey(item.ReorderStockLevel);
                itemPage.provideMaximumReorderKey(item.MaximumReorder);
                itemPage.provideMinimumReorderKey(item.MinimumReorder);
                itemPage.clickSaveKeyInfo();

                #region Validate the Brand is updated or not
                IWebElement itemBrandElement = _driver.FindElement(By.XPath("//input[contains(@id, 'BrandId')]"));
                string itemBrandActualName = itemBrandElement.GetDomProperty("value");
                ClassicAssert.AreEqual(item.Brand, itemBrandActualName);
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with BOM Details
        [Test, Category("Inventory"), Order(15)]
        public void UpdateItemBOMDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update BOM Tab
                itemPage.clickOnBOMTab();
                itemPage.UpdateFirstComponentItem();                
                //itemPage.clickDropDownComponentItem();
                //itemPage.selectDropDownOption(item.SubItem);  
                itemPage.provideQty(item.Qty);
                itemPage.clickOnSave();

                #region Validating the qty updated or not
                IWebElement qtyElemennt = _driver.FindElement(By.XPath($"//span[contains(text(), '{item.Qty} Each')]"));
                string actualQty = qtyElemennt.Text;
                ClassicAssert.AreEqual(item.ExpectedQty, actualQty);
                #endregion

                itemPage.DeleteSecondComponentItem();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Component Item Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item bill of material deleted", successMessage);
                itemPage.ValidateDeletion("Item bill of material deleted");
                #endregion

                #endregion                
            }
        }
        #endregion

        #region Update an item with UOM Details
        [Test, Category("Inventory"), Order(16)]
        public void UpdateItemUOMDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);               
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update UOM Tab
                itemPage.clickOnUOMTab();

                itemPage.UpdateSecondUom();
                itemPage.provideConversionFactor(item.ConversionFactor);
                itemPage.clickSalesDefault();
                itemPage.clickPurchaseDefault();
                itemPage.clickOnSave();

                #region Validating the sales default or not
                IWebElement salesDefaultElement = _driver.FindElement(By.XPath("//div[@class='tag-maroon']"));
                string salesDefault = salesDefaultElement.Text;
                ClassicAssert.AreEqual("Sales Default", salesDefault);
                #endregion

                #region Validating the purchase default or not
                IWebElement purchasesDefaultElement = _driver.FindElement(By.XPath("//div[@class='tag-blue']"));
                string purchaseDefault = purchasesDefaultElement.Text;
                ClassicAssert.AreEqual("Purchase Default", purchaseDefault);
                #endregion

                itemPage.DeleteThirdUom();                
                itemPage.ClickOnOk();

                #region Validating the UOM Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item unit of measures deleted", successMessage);
                itemPage.ValidateDeletion("Item unit of measures deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Supplier Details
        [Test, Category("Inventory"), Order(17)]
        public void UpdateItemSupplierDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Supplier Tab
                itemPage.clickOnSuppliersTab();

                itemPage.DeleteSecondSupplier();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Supllier Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item supplier deleted", successMessage);
                itemPage.ValidateDeletion("Item supplier deleted");
                #endregion

                itemPage.UpdateFirstSupplier();
                itemPage.ClickDropDown();
                itemPage.SelectDropDownOption(item.Supplier);
                itemPage.clickPurchaseRateCurrency();
                itemPage.SelectDropDownOption(item.PurchaseRateCurrency);
                //itemPage.clickSupplierUOM();
                //itemPage.selectDropDownOption(item.Uom);
                itemPage.providePurchaseUnitPrice(item.PurchaseUnitPrice);
                //itemPage.provideManufacturerPartNum(item.ManufacturerPartNum);
                //itemPage.provideManufacturerBarcode(item.ManufacturerBarcode);
                //itemPage.clickPreferredForPurchase();
                //itemPage.clickPreferredForEstimation();
                itemPage.clickOnSave();
                Thread.Sleep(2000);

                #region Validating the supplier name updated or not
                IWebElement supplierNameElement = _driver.FindElement(By.ClassName("Item-Supplier-title"));
                string supplierName = supplierNameElement.Text;
                ClassicAssert.AreEqual(item.Supplier + " A004", supplierName);
                #endregion
                
                #endregion              
            }
        }
        #endregion

        #region Update an item with Price Lists Details
        [Test, Category("Inventory"), Order(18)]
        public void UpdateItemPriceListDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Price Lists Tab
                itemPage.clickOnPriceListsTab();
                itemPage.UpdateFirstPriceList();
                itemPage.providePriceListUnitPrice(item.UnitPrice);
                itemPage.clickOnSave();

                #region Validating the price list unit price updated or not
                IWebElement priceListElement = _driver.FindElement(By.XPath("//div[span[contains(text(),'Unit Price')]]"));
                string unitPriceActual = priceListElement.Text.Trim();
                ClassicAssert.AreEqual("Unit Price " + item.UnitPrice + " @ EA", unitPriceActual);
                #endregion

                itemPage.DeleteSecondPriceList();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Price List Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item price list deleted", successMessage);
                itemPage.ValidateDeletion("Item price list deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Warehouse Details
        [Test, Category("Inventory"), Order(19)]
        public void UpdateItemWarehouseDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Warehouse Tab
                itemPage.clickOnWarehouseTab();
                itemPage.UpdateFirstWarehouse();
                itemPage.provideBinLocation(item.BinLocation);
                //itemPage.provideMaximumStockLevel(item.MaximumStockLevel);
                //itemPage.provideMinimumStockLevel(item.MinimumStockLevel);
                //itemPage.provideReorderStockLevel(item.ReorderStockLevel);
                //itemPage.provideMaximumReorder(item.MaximumReorder);
                //itemPage.provideMinimumReorder(item.MinimumReorder);
                itemPage.clickOnSave();

                #region Validating the bin location name updated or not
                IWebElement binLocationElement = _driver.FindElement(By.XPath("//p[@class='Item-Warehouse-detail']"));
                string binLocationActualName = binLocationElement.Text.Trim();
                ClassicAssert.AreEqual(item.BinLocation, binLocationActualName);
                #endregion

                itemPage.DeleteSecondWarehouse();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Supllier Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item warehouse deleted", successMessage);
                itemPage.ValidateDeletion("Item warehouse deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Barcode Details
        [Test, Category("Inventory"), Order(20)]
        public void UpdateItemBarcodeDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Barcode Tab
                itemPage.clickOnBarcodesTab();
                itemPage.UpdateFirstBarcode();
                itemPage.provideBarcode(item.Barcode);
                itemPage.clickOnSave();

                #region Validating the barcode updated or not
                IWebElement barcodeElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Barcode-Card-content')]//p"));
                string barcodeActualCode = barcodeElement.Text.Trim();
                ClassicAssert.AreEqual(item.Barcode, barcodeActualCode);
                #endregion

                itemPage.DeleteSecondBarcode();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Barcode Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item Barcode deleted", successMessage);
                itemPage.ValidateDeletion("Item Barcode deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with Document Details
        [Test, Category("Inventory"), Order(21)]
        public void UpdateItemDocumentDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Documents Tab
                itemPage.clickOnDocumentsTab();
                itemPage.UpdateFirstDocument();
                itemPage.provideDocumentNumber(item.DocumentNumber);
                itemPage.clickOnSave();

                #region Validating the document number updated or not
                IWebElement documentNumberElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Document-Card-content')]//p/strong"));
                string documentNumberActaulCode = documentNumberElement.Text.Trim();
                ClassicAssert.AreEqual("Civil Id (" + item.DocumentNumber + ")", documentNumberActaulCode);
                #endregion

                itemPage.DeleteSecondDocument();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                Thread.Sleep(2000);
                #region Validating the Document Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item Document deleted", successMessage);
                itemPage.ValidateDeletion("Item Document deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with Account Setup Details
        [Test, Category("Inventory"), Order(22)]
        public void UpdateItemAccountSetupDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Account Setup  Tab
                itemPage.clickOnSetupTab();
                itemPage.clickRevenueAccount();
                itemPage.SelectDropDownOption(item.RevenueAccount);
                itemPage.clickInventoryAccount();
                itemPage.SelectDropDownOption(item.InventoryAccount);
                itemPage.clickcostofgoodssoldAccount();
                itemPage.SelectDropDownOption(item.CostofGoodsSoldAccount);
                itemPage.clickadjustmentAccount();
                itemPage.SelectDropDownOption(item.AdjustmentAccount);
                itemPage.clickexpenseAccount();
                itemPage.SelectDropDownOption(item.ExpenseAccount);
                itemPage.clickinventorysuspenseAccount();
                itemPage.SelectDropDownOption(item.InventorySuspenseAccount);
                itemPage.clickstoretostoretransferAccount();
                itemPage.SelectDropDownOption(item.StoretoStoreTransferAccount);
                itemPage.clickworkinprogressAccount();
                itemPage.SelectDropDownOption(item.WorkinProgressAccount);
                itemPage.clickSaveAccountBtn();

                #region Validate the accounts added or not 
                IWebElement accountName = _driver.FindElement(By.XPath("//input[contains(@id, 'RevenueMainAccountId')]"));
                string accountActualName = accountName.GetDomProperty("value");
                ClassicAssert.AreEqual(item.RevenueAccount, accountActualName);
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Dimension Details
        [Test, Category("Inventory"), Order(23)]
        public void UpdateItemDimensionDetails()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "update");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Dimensions Tab
                itemPage.clickOnDimensionTab();
                itemPage.UpdateFirstDimension();
                itemPage.provideColorCode(item.ColorCode);
                itemPage.provideColorName(item.ColorName);
                itemPage.clickOnSave();

                #region Validating the color code and name updated or not
                IWebElement colorElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Color-Card-content')]//p"));
                string actualColorCodeName = colorElement.Text.Trim();
                ClassicAssert.AreEqual(item.ColorName +" "+ item.ColorCode, actualColorCodeName);
                #endregion

                itemPage.DeleteSecondDimension();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the color Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item color deleted", successMessage);
                itemPage.ValidateDeletion("Item color deleted");
                #endregion

                itemPage.UpdateThirdDimension();
                itemPage.provideSizeCode(item.SizeCode);
                itemPage.provideSizeName(item.SizeName);
                itemPage.clickSaveSize();

                #region Validating the color code and name updated or not
                IWebElement sizeElement = _driver.FindElement(By.XPath("(//div[contains(@class,'Item-Color-Card-content')]//p)[3]"));
                string actualSizeCodeName = sizeElement.Text.Trim();
                ClassicAssert.AreEqual(item.SizeName + " " + item.SizeCode, actualSizeCodeName);
                #endregion

                itemPage.DeleteForthDimension();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                Thread.Sleep(2000);
                #region Validating the Size Deleted or not
                //IWebElement deleteSizeElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successSizeMessage = deleteSizeElemennt.Text;
                //ClassicAssert.AreEqual("Item size deleted", successSizeMessage);
                itemPage.ValidateDeletion("Item size deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region create new item without Base UOM
        [Test, Category("Inventory"), Order(24)]
        public void createNewItemWithoutBaseUOM()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "validate");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                inventoryPage.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);                 
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickSaveItem();               

                #region Validate the base unit of measure is required while creating new item
                itemPage.Validate("Item base unit of measure is required!");
                #endregion



            }
        }
        #endregion
    }
}