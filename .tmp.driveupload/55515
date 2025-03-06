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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class ItemTest : BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public ItemTest()
        {}
        #endregion

        #region create new item
        [Test, Category("Inventory"), Order(1)]
        public void CreateItem()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
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

                #region Validate the newly created item name
                IWebElement itemName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string actualName = itemName.GetDomProperty("value");
                StringAssert.Contains(item.Name, actualName);
                #endregion

                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with KeyInfo Details
        [Test, Category("Inventory"), Order(2)]
        public void CreateItemWithKeyInfoDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
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

                #region Validate Item updated message 
                //IWebElement itemName = _driver.FindElement(By.CssSelector("input[name='Name']"));
                //string actualName = itemName.GetDomProperty("value");
                //ClassicAssert.AreEqual(item.Name, actualName);
                CommonPageActions.Validate("Item updated successfully.");
                #endregion

                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple BOM Details  
        [Test, Category("Inventory"), Order(3)]
        public void CreateItemWithBOMDetail()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "bom");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
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
                itemPage.ClickOnBOMTab();

                foreach (var subItem in item.SubItems)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
                    //itemPage.clickDropDown();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.SelectDropDownOption(subItem.SubItem);
                    itemPage.provideQty(subItem.Qty);
                    itemPage.ClickOnSave();

                    #region Validating the subItems added or not
                    IWebElement subItemName = _driver.FindElement(By.CssSelector($"p[title='{subItem.SubItem}']"));
                    string actualName = subItemName.Text;                    
                    StringAssert.Contains(subItem.SubItem, actualName);
                    #endregion

                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple UOM Details 
        [Test, Category("Inventory"), Order(4)]
        public void CreateItemWithUOMDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnUOMTab();

                foreach (var uom in item.ItemUoms)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(uom.Uom);
                    itemPage.provideConversionFactor(uom.ConversionFactor);
                    //itemPage.clickReportingUOM();
                    //itemPage.clickSalesDefault();
                    //itemPage.clickPurchaseDefault();
                    itemPage.ClickOnSave();

                    #region Validated added uom name
                    IWebElement uomName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{uom.Uom}')]"));
                    string actualName = uomName.Text;
                    StringAssert.Contains(uom.Uom, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }

        }
        #endregion

        #region Create new item with Multiple Suppliers Details 
        [Test, Category("Inventory"), Order(5)]
        public void CreateItemWithSupplierDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnSuppliersTab();

                foreach (var supplier in item.Suppliers)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
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
                    itemPage.ClickOnSave();

                    #region Validating the supplier name added or not
                    IWebElement supplierName = _driver.FindElement(By.XPath($"//p[@class='Item-Supplier-title' and contains(., '{supplier.Supplier}')]"));
                    string actualName = supplierName.Text;
                    StringAssert.Contains(supplier.Supplier, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple PriceLists Details 
        [Test, Category("Inventory"), Order(6)]
        public void CreateItemWithPriceListDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnPriceListsTab();

                foreach (var pricelist in item.itemPriceLists)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
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
                    itemPage.ClickOnSave();

                    #region Validating the price list added or not
                    IWebElement pricelistName = _driver.FindElement(By.XPath($"//div//span[contains(text(),'{pricelist.PriceList}')]"));
                    string actualName = pricelistName.Text;
                    StringAssert.Contains(pricelist.PriceList, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple Warehouses Details 
        [Test, Category("Inventory"), Order(7)]
        public void CreateItemWithWarehouseDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnWarehouseTab();

                foreach (var warehouse in item.Warehouses)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
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
                    itemPage.ClickOnSave();

                    #region Validating the warehouse name added or not
                    IWebElement warehouseName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{warehouse.Warehouse}')]"));
                    string actualName = warehouseName.Text;
                    StringAssert.Contains(warehouse.Warehouse, actualName);
                    #endregion

                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple Barcodes Details 
        [Test, Category("Inventory"), Order(8)]
        public void CreateItemWithBarcodeDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnBarcodesTab();

                foreach (var barcode in item.Barcodes)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
                    itemPage.provideBarcode(barcode.Barcode);
                    itemPage.ClickDropDown();
                    itemPage.SelectDropDownOption(barcode.Uom);
                    //itemPage.clickBarcodeFreezed();
                    Thread.Sleep(1000);
                    itemPage.ClickOnSave();

                    #region Validating the barcode added or not
                    IWebElement barcodeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{barcode.Barcode}')]"));
                    string actualName = barcodeName.Text;
                    StringAssert.Contains(barcode.Barcode, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Multiple Documents Details
        [Test, Category("Inventory"), Order(9)]
        public void CreateItemWithDocumentDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnDocumentsTab();

                foreach (var document in item.Documents)
                {
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
                    itemPage.ClickDropDown();
                    CommonPageActions.SelectDropDownOption(document.DocumentType);                    
                    CommonPageActions.provideDocumentNumber(document.DocumentNumber);                    
                    CommonPageActions.provideDateOfIssue(document.DateOfIssue);
                    CommonPageActions.providePlaceOfIssue(document.PlaceOfIssue);
                    CommonPageActions.provideDateOfExpiry(document.DateOfExpiry);
                    Thread.Sleep(1000);
                    itemPage.ClickOnSave();

                    //#region Validating the document type and number added or not
                    //IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.DocumentType + " (" + document.DocumentNumber + ")"}')]"));
                    //string actualName = documentName.Text;
                    //ClassicAssert.AreEqual(document.DocumentType + " (" + document.DocumentNumber + ")", actualName);
                    //#endregion

                    #region Validate the document created sucessfully message
                    CommonPageActions.ValidateSucess("Document created successfully");
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Account Setup Details
        [Test, Category("Inventory"), Order(10)]
        public void CreateItemWithAccountSetupDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
                itemPage.ProvideItemName(item.Name);
                itemPage.ProvideItemArabicName(item.ArabicName);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickUOM();
                itemPage.SelectDropDownOption(item.Uom);
                itemPage.clickItemType();
                itemPage.SelectDropDownOption(item.Type);
                itemPage.clickSaveItem();
                itemPage.ClickOnSetupTab();
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
                string actualName = accountName.GetDomProperty("value");
                StringAssert.Contains(item.RevenueAccount, actualName);
                #endregion

                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with Dimensions Details
        [Test, Category("Inventory"), Order(11)]
        public void CreateItemWithDimensionDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
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
                itemPage.ClickOnDimensionTab();

                foreach (var color in item.Colors)
                {
                    //Thread.Sleep(1000);
                    //itemPage.clickColorGenerate();
                    Thread.Sleep(1000);
                    itemPage.ClickOnAdd();
                    itemPage.provideColorCode(color.ColorCode);
                    itemPage.provideColorName(color.ColorName);
                    itemPage.provideColorArabicName(color.ColorArabicName);
                    itemPage.ClickOnSave();

                    #region Validating the color added or not
                    IWebElement colorName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{color.ColorName}')]"));
                    string actualName = colorName.Text;
                    StringAssert.Contains(color.ColorName, actualName);
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
                    IWebElement sizeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{size.SizeName}')]"));
                    string actualName = sizeName.Text;
                    StringAssert.Contains(size.SizeName, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Create new item with All Tabs Details
        [Test, Category("Inventory"), Order(12)]
        public void CreateItemWithAllTabDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                //itemPage.ProvideItemCode(item.Code);
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
                itemPage.ClickOnBOMTab();
                Thread.Sleep(2000);

                foreach (var SubItem in item.SubItems)
                {
                    //Thread.Sleep(2000);
                    itemPage.ClickOnAdd();
                    Thread.Sleep(1000);
                    itemPage.clickDropDownComponentItem();
                    itemPage.SelectDropDownOption(SubItem.SubItem);
                    itemPage.provideQty(SubItem.Qty);
                    itemPage.ClickOnSave();
                    
                    #region Validating the subItems added or not
                    IWebElement subItemName = _driver.FindElement(By.CssSelector($"p[title='{SubItem.SubItem}']"));
                    string actualName = subItemName.Text;
                    StringAssert.Contains(SubItem.SubItem, actualName);
                    #endregion
                }
                itemPage.ClickOnUOMTab();
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

                    #region Validated added uom name
                    IWebElement uomName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{uom.Uom}')]"));
                    string actualName = uomName.Text;
                    StringAssert.Contains(uom.Uom, actualName);
                    #endregion

                }
                itemPage.ClickOnSuppliersTab();
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
                    IWebElement supplierName = _driver.FindElement(By.XPath($"//p[@class='Item-Supplier-title' and contains(., '{supplier.Supplier}')]"));
                    string actualName = supplierName.Text;
                    StringAssert.Contains(supplier.Supplier, actualName);
                    #endregion
                }
                itemPage.ClickOnPriceListsTab();
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
                    IWebElement pricelistName = _driver.FindElement(By.XPath($"//div//span[contains(text(),'{pricelist.PriceList}')]"));
                    string actualName = pricelistName.Text;
                    StringAssert.Contains(pricelist.PriceList, actualName);
                    #endregion
                }
                itemPage.ClickOnWarehouseTab();
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
                    IWebElement warehouseName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{warehouse.Warehouse}')]"));
                    string actualName = warehouseName.Text;
                    StringAssert.Contains(warehouse.Warehouse, actualName);
                    #endregion
                }
                itemPage.ClickOnBarcodesTab();
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
                    IWebElement barcodeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{barcode.Barcode}')]"));
                    string actualName = barcodeName.Text;
                    StringAssert.Contains(barcode.Barcode, actualName);
                    #endregion

                }
                itemPage.ClickOnDocumentsTab();
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
                    IWebElement documentName = _driver.FindElement(By.XPath($"//div//p//strong[contains(text(),'{document.DocumentType + " (" + document.DocumentNumber + ")"}')]"));
                    string actualName = documentName.Text;
                    ClassicAssert.AreEqual(document.DocumentType + " (" + document.DocumentNumber + ")", actualName);
                    #endregion

                }
                itemPage.ClickOnSetupTab();

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

                itemPage.ClickOnDimensionTab();

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
                    IWebElement colorName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{color.ColorName}')]"));
                    string actualName = colorName.Text;
                    StringAssert.Contains(color.ColorName, actualName);
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
                    IWebElement sizeName = _driver.FindElement(By.XPath($"//div//p[contains(text(),'{size.SizeName}')]"));
                    string actualName = sizeName.Text;
                    StringAssert.Contains(size.SizeName, actualName);
                    #endregion
                }
                itemPage.ClickOnBack();
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Update an item with Key Info Details
        [Test, Category("Inventory"), Order(13)]
        public void UpdateItemWithKeyInfoDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
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
                Thread.Sleep(1000);

                //#region Validate the Brand is updated or not
                //IWebElement itemBrandElement = _driver.FindElement(By.XPath("//input[contains(@id, 'BrandId')]"));
                //string actualName = itemBrandElement.GetDomProperty("value");
                //ClassicAssert.AreEqual(item.Brand, actualName);
                //#endregion

                #region Validate updated message
                CommonPageActions.Validate("Item updated successfully.");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with BOM Details
        [Test, Category("Inventory"), Order(14)]
        public void UpdateItemWithBOMDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update BOM Tab
                itemPage.ClickOnBOMTab();
                itemPage.UpdateFirstComponentItem();
                //itemPage.clickDropDownComponentItem();
                //itemPage.selectDropDownOption(item.SubItem);  
                itemPage.provideQty(item.Qty);
                itemPage.ClickOnSave();

                #region Validating the qty updated or not
                IWebElement qtyElemennt = _driver.FindElement(By.XPath($"//span[contains(text(), '{item.Qty}')]"));
                string actualQty = qtyElemennt.Text;
                StringAssert.Contains(item.Qty, actualQty);
                #endregion

                itemPage.DeleteSecondComponentItem();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Component Item Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item bill of material deleted", successMessage);
                CommonPageActions.ValidateSucess("Item bill of material deleted");
                #endregion

                #endregion                
            }
        }
        #endregion

        #region Update an item with UOM Details
        [Test, Category("Inventory"), Order(15)]
        public void UpdateItemWithUOMDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update UOM Tab
                itemPage.ClickOnUOMTab();

                itemPage.UpdateSecondUom();
                itemPage.provideConversionFactor(item.ConversionFactor);
                itemPage.clickSalesDefault();
                itemPage.clickPurchaseDefault();
                itemPage.ClickOnSave();

                #region Validating the sales default or not
                IWebElement salesDefaultElement = _driver.FindElement(By.XPath("//div[@class='tag-maroon']"));
                string salesDefault = salesDefaultElement.Text;
                StringAssert.Contains("Sales Default", salesDefault);
                #endregion

                #region Validating the purchase default or not
                IWebElement purchasesDefaultElement = _driver.FindElement(By.XPath("//div[@class='tag-blue']"));
                string purchaseDefault = purchasesDefaultElement.Text;
                StringAssert.Contains("Purchase Default", purchaseDefault);
                #endregion

                itemPage.DeleteThirdUom();
                itemPage.ClickOnOk();

                #region Validating the UOM Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item unit of measures deleted", successMessage);
                CommonPageActions.ValidateSucess("Item unit of measures deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Supplier Details
        [Test, Category("Inventory"), Order(16)]
        public void UpdateItemWithSupplierDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Supplier Tab
                itemPage.ClickOnSuppliersTab();

                itemPage.DeleteSecondSupplier();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Supllier Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item supplier deleted", successMessage);
                CommonPageActions.ValidateSucess("Item supplier deleted");
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
                itemPage.ClickOnSave();
                Thread.Sleep(2000);                

                #region Validating the supplier name added or not
                IWebElement supplierName = _driver.FindElement(By.XPath($"//p[@class='Item-Supplier-title' and contains(., '{item.Supplier}')]"));
                string actualName = supplierName.Text;
                StringAssert.Contains(item.Supplier, actualName);
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with Price Lists Details
        [Test, Category("Inventory"), Order(17)]
        public void UpdateItemWithPriceListDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Price Lists Tab
                itemPage.ClickOnPriceListsTab();
                itemPage.UpdateFirstPriceList();
                itemPage.providePriceListUnitPrice(item.UnitPrice);
                itemPage.ClickOnSave();

                #region Validating the price list unit price updated or not
                IWebElement priceListElement = _driver.FindElement(By.XPath("//div[span[contains(text(),'Unit Price')]]"));
                string unitPriceActual = priceListElement.Text.Trim();
                StringAssert.Contains(item.UnitPrice, unitPriceActual);
                #endregion

                itemPage.DeleteSecondPriceList();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Price List Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item price list deleted", successMessage);
                CommonPageActions.ValidateSucess("Item price list deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Warehouse Details
        [Test, Category("Inventory"), Order(18)]
        public void UpdateItemWithWarehouseDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Warehouse Tab
                itemPage.ClickOnWarehouseTab();
                itemPage.UpdateFirstWarehouse();
                itemPage.provideBinLocation(item.BinLocation);
                //itemPage.provideMaximumStockLevel(item.MaximumStockLevel);
                //itemPage.provideMinimumStockLevel(item.MinimumStockLevel);
                //itemPage.provideReorderStockLevel(item.ReorderStockLevel);
                //itemPage.provideMaximumReorder(item.MaximumReorder);
                //itemPage.provideMinimumReorder(item.MinimumReorder);
                itemPage.ClickOnSave();

                #region Validating the bin location name updated or not
                IWebElement binLocationElement = _driver.FindElement(By.XPath("//p[@class='Item-Warehouse-detail']"));
                string binLocationActualName = binLocationElement.Text.Trim();
                StringAssert.Contains(item.BinLocation, binLocationActualName);
                #endregion

                itemPage.DeleteSecondWarehouse();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Supllier Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item warehouse deleted", successMessage);
                CommonPageActions.ValidateSucess("Item warehouse deleted");
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Barcode Details
        [Test, Category("Inventory"), Order(19)]
        public void UpdateItemWithBarcodeDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Barcode Tab
                itemPage.ClickOnBarcodesTab();
                itemPage.UpdateFirstBarcode();
                itemPage.provideBarcode(item.Barcode);
                itemPage.ClickOnSave();

                #region Validating the barcode updated or not
                IWebElement barcodeElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Barcode-Card-content')]//p"));
                string barcodeActualCode = barcodeElement.Text.Trim();
                StringAssert.Contains(item.Barcode, barcodeActualCode);
                #endregion

                itemPage.DeleteSecondBarcode();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the Barcode Deleted or not
                CommonPageActions.ValidateSucess("Item Barcode deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with Document Details
        [Test, Category("Inventory"), Order(20)]
        public void UpdateItemWithDocumentDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Documents Tab
                itemPage.ClickOnDocumentsTab();
                itemPage.UpdateFirstDocument();
                itemPage.provideDocumentNumber(item.DocumentNumber);
                itemPage.ClickOnSave();

                //#region Validating the document number updated or not
                //IWebElement documentNumberElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Document-Card-content')]//p/strong"));
                //string documentNumberActaulCode = documentNumberElement.Text.Trim();
                //ClassicAssert.AreEqual("Civil Id (" + item.DocumentNumber + ")", documentNumberActaulCode);
                //#endregion

                #region Validate the document update message
                CommonPageActions.Validate("Document Updated Successfully");
                #endregion

                itemPage.DeleteSecondDocument();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                Thread.Sleep(2000);
                #region Validating the Document Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item Document deleted", successMessage);
                CommonPageActions.ValidateSucess("Item Document deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Update an item with Account Setup Details
        [Test, Category("Inventory"), Order(21)]
        public void UpdateItemWithAccountSetupDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Account Setup  Tab
                itemPage.ClickOnSetupTab();
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
                StringAssert.Contains(item.RevenueAccount, accountActualName);
                #endregion

                #endregion              
            }
        }
        #endregion

        #region Update an item with Dimension Details
        [Test, Category("Inventory"), Order(22)]
        public void UpdateItemWithDimensionDetail()
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ProvideItemName(item.Name);
                Thread.Sleep(2000);
                inventoryItemListingPage.ClickOnSelectedItemName();
                inventoryItemListingPage.ClickOnView();

                #region Update Dimensions Tab
                itemPage.ClickOnDimensionTab();
                itemPage.UpdateFirstDimension();
                itemPage.provideColorCode(item.ColorCode);
                itemPage.provideColorName(item.ColorName);
                itemPage.provideColorArabicName(item.ColorName);
                itemPage.ClickOnSave();

                #region Validating the color code and name updated or not
                IWebElement colorElement = _driver.FindElement(By.XPath("//div[contains(@class,'Item-Color-Card-content')]//p"));
                string actualColorCodeName = colorElement.Text.Trim();
                StringAssert.Contains(item.ColorName + " " + item.ColorCode, actualColorCodeName);
                #endregion

                itemPage.DeleteSecondDimension();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                #region Validating the color Deleted or not
                //IWebElement deleteElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successMessage = deleteElemennt.Text;
                //ClassicAssert.AreEqual("Item color deleted", successMessage);
                CommonPageActions.ValidateSucess("Item color deleted");
                #endregion

                itemPage.UpdateThirdDimension();
                itemPage.provideSizeCode(item.SizeCode);
                itemPage.provideSizeName(item.SizeName);
                itemPage.provideSizeArabicName(item.SizeName);
                itemPage.clickSaveSize();

                #region Validating the color code and name updated or not
                IWebElement sizeElement = _driver.FindElement(By.XPath("(//div[contains(@class,'Item-Color-Card-content')]//p)[3]"));
                string actualSizeCodeName = sizeElement.Text.Trim();
                StringAssert.Contains(item.SizeName + " " + item.SizeCode, actualSizeCodeName);
                #endregion

                itemPage.DeleteForthDimension();
                Thread.Sleep(1000);
                itemPage.ClickOnOk();

                Thread.Sleep(2000);
                #region Validating the Size Deleted or not
                //IWebElement deleteSizeElemennt = _driver.FindElement(By.ClassName("dx-toast-success"));
                //string successSizeMessage = deleteSizeElemennt.Text;
                //ClassicAssert.AreEqual("Item size deleted", successSizeMessage);
                CommonPageActions.ValidateSucess("Item size deleted");
                #endregion

                #endregion
            }
        }
        #endregion

        #region Delete items
        [Test, Category("Inventory"), Order(23)]
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
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
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

                #region Validate deleted message
                CommonPageActions.Validate("Item deleted successfully");
                #endregion
            }
        }
        #endregion

        #region create new item without Base UOM - Not allowed
        [Test, Category("Inventory"), Order(24)]
        public void createItemWithoutBaseUOM()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "Validate");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var inventorySetupPage = new InventorySetupPage(_driver);
            var inventoryItemListingPage = new InventoryItemListingPage(_driver);

            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                Thread.Sleep(1000);
                //inventoryPage.ClickOnSetups();
                CommonPageActions.ClickOnSetups();
                inventorySetupPage.ClickOnItem();
                inventoryItemListingPage.ClickOnNew();
                itemPage.ProvideItemName(item.Name);
                //itemPage.provideItemName(item.Name, item.ArabicName);
                itemPage.clickSaveItem();
                Thread.Sleep(1000);

                #region Validate the base unit of measure is required while creating new item
                CommonPageActions.Validate("Item base unit of measure is required!");
                #endregion
            }
        }
        #endregion

        #region Filter the data in Item Query
        [Test, Category("Inventory"), Order(25)]
        public async Task ApplyFiltersOnItemQuery()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.ConvertJsonListDataModel<ItemModel>(itemFile, "itemquery");
            var itemPage = new ItemPage(_driver);
            var inventoryPage = new InventoryPage(_driver);
            var itemQueryPage = new ItemQueryPage(_driver);


            foreach (var item in items)
            {
                inventoryPage.ClickOnInventoryModule();
                await WaitHelper.WaitForSeconds(3);
                CommonPageActions.ClickOnHome();
                //inventoryPage.ClickOnHome();
                inventoryPage.ClickOnItemQuery();
                //itemPage.ClickDropDown();
                //itemPage.SelectDropDownOption(item.Name);
                itemQueryPage.ClickOnAdvanceFilter();
                await WaitHelper.WaitForSeconds(3);

                //itemQueryPage.ProvideItemBrandName(item.Brand);
                //await WaitHelper.WaitForSeconds(3);

                //#region Validate the list of brand data                
                //bool isBrandValid = itemQueryPage.ValidateBrandColumnData(item.Brand);
                //ClassicAssert.IsTrue(isBrandValid, $"Brand validation failed for {item.Brand}");
                //#endregion

                //itemQueryPage.ClearItemBrandName();                
                //itemQueryPage.ProvideItemCategoryName(item.ItemCategory);
                //await WaitHelper.WaitForSeconds(3);

                //#region Validate the list of category data                          
                //bool isCategoryValid = itemQueryPage.ValidateCategoryColumnData(item.ItemCategory);
                //ClassicAssert.IsTrue(isCategoryValid, $"Category validation failed for {item.ItemCategory}");
                //#endregion

                //itemQueryPage.ClearItemCategoryName();
                //itemQueryPage.ProvideItemGroupName(item.ItemGroup);
                //await WaitHelper.WaitForSeconds(3);

                //#region Validate the list of group data
                //bool isGroupValid = itemQueryPage.ValidateGroupColumnData(item.ItemGroup);
                //ClassicAssert.IsTrue(isGroupValid, $"Group validation failed for {item.ItemGroup}");
                //#endregion

                //itemQueryPage.ClearItemGroupName();
                //itemQueryPage.ProvideItemName(item.Name);
                //await WaitHelper.WaitForSeconds(3);

                //#region Validate the list of name data
                //bool isNameValid = itemQueryPage.ValidateNameColumnData(item.Name);
                //ClassicAssert.IsTrue(isNameValid, $"Name validation failed for {item.Name}");
                //#endregion

                //itemQueryPage.ClearItemName();
                //itemQueryPage.ProvideItemCode(item.Code);
                //await WaitHelper.WaitForSeconds(5);                

                //#region Validate the list of code data
                //bool isCodeValid = itemQueryPage.ValidateCodeColumnData(item.Code);
                //ClassicAssert.IsTrue(isCodeValid, $"Code validation failed for {item.Code}");
                //#endregion

                itemQueryPage.ClearItemCode();
                itemQueryPage.ProvideSearch(item.Brand);
                await WaitHelper.WaitForSeconds(3);

                #region Validate the list of brand data                
                bool isBrandValid = itemQueryPage.ValidateSearchTextData(item.Brand);
                ClassicAssert.IsTrue(isBrandValid, $"Brand validation failed for {item.Brand}");
                #endregion

                itemQueryPage.ClearSearch();
                itemQueryPage.ProvideSearch(item.ItemCategory);
                await WaitHelper.WaitForSeconds(3);

                #region Validate the list of category data                          
                bool isCategoryValid = itemQueryPage.ValidateSearchTextData(item.ItemCategory);
                ClassicAssert.IsTrue(isCategoryValid, $"Category validation failed for {item.ItemCategory}");
                #endregion

                itemQueryPage.ClearSearch();
                itemQueryPage.ProvideSearch(item.ItemGroup);
                await WaitHelper.WaitForSeconds(3);

                #region Validate the list of group data
                bool isGroupValid = itemQueryPage.ValidateSearchTextData(item.ItemGroup);
                ClassicAssert.IsTrue(isGroupValid, $"Group validation failed for {item.ItemGroup}");
                #endregion

                itemQueryPage.ClearSearch();
                itemQueryPage.ProvideSearch(item.Name);
                await WaitHelper.WaitForSeconds(3);

                #region Validate the list of name data
                bool isNameValid = itemQueryPage.ValidateSearchTextData(item.Name);
                ClassicAssert.IsTrue(isNameValid, $"Name validation failed for {item.Name}");
                #endregion

                itemQueryPage.ClearSearch();
                itemQueryPage.ProvideSearch(item.Code);
                await WaitHelper.WaitForSeconds(3);

                #region Validate the list of code data
                bool isCodeValid = itemQueryPage.ValidateSearchTextData(item.Code);
                ClassicAssert.IsTrue(isCodeValid, $"Code validation failed for {item.Code}");
                #endregion
            }
        }
        #endregion
    }
}