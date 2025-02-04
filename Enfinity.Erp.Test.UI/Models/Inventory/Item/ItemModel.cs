using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    public class ItemModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Uom { get; set; }
        public string Type { get; set; }
        public string TrackingMode { get; set; }
        public string CostingMethod { get; set; }
        public string ItemGroup { get; set; }
        public string ItemCategory { get; set; }
        public string Brand { get; set; }
        public string SalesPrice { get; set; }
        public string PurchasePrice { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerPartNum { get; set; }
        public string MaximumStockLevel { get; set; }
        public string MinimumStockLevel { get; set; }
        public string ReorderStockLevel { get; set; }
        public string MaximumReorder { get; set; }
        public string MinimumReorder { get; set; }
        public string BinLocation { get; set; }
        public string Barcode { get; set; }
        public string ConversionFactor { get; set; }
        public string Supplier { get; set; }
        public string PurchaseRateCurrency { get; set; }
        public string UnitPrice { get; set; }
        public string DocumentNumber { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
        public string ExpectedQty { get; set; }
        public string RevenueAccount { get; set; }
        public string InventoryAccount { get; set; }
        public string CostofGoodsSoldAccount { get; set; }
        public string AdjustmentAccount { get; set; }
        public string ExpenseAccount { get; set; }
        public string InventorySuspenseAccount { get; set; }
        public string StoretoStoreTransferAccount { get; set; }
        public string WorkinProgressAccount { get; set; }
        public string PurchaseUnitPrice { get; set; }
        public string ManufacturerBarcode { get; set; }
        public string SubItem { get; set; }
        public string Qty { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public List<SubItemModel> SubItems { get; set; }
        public List<ItemUOMModel> ItemUoms { get; set; }
        public List<ItemSupplierModel> Suppliers { get; set; }
        public List<ItemPriceListModel> itemPriceLists { get; set; }
        public List<ItemWarehouseModel> Warehouses { get; set; }
        public List<ItemBarcodeModel> Barcodes { get; set; }
        public List<ItemDocumentModel> Documents { get; set; }
        public List<ItemColorModel> Colors { get; set; }
        public List<ItemSizeModel> Sizes { get; set; }
    }
    public class SubItemModel
    {
        public string SubItem { get; set; }
        public string Qty { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemUOMModel
    {
        public string Uom { get; set; }
        public string ConversionFactor { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemSupplierModel
    {
        public string Supplier { get; set; }
        public string PurchaseRateCurrency { get; set; }
        public string Uom { get; set; }
        public string PurchaseUnitPrice { get; set; }
        public string ManufacturerPartNum { get; set; }
        public string ManufacturerBarcode { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemPriceListModel
    {
        public string PriceList { get; set; }
        public string Uom { get; set; }
        public string UnitPrice { get; set; }
        public string MinimumUnitPrice { get; set; }
        public string MaximumUnitPrice { get; set; }
        public string DefaultDiscountInPercent { get; set; }
        public string MaximumDiscountInPercent { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemWarehouseModel
    {
        public string Warehouse { get; set; }
        public string BinLocation { get; set; }
        public string MaximumStockLevel { get; set; }
        public string MinimumStockLevel { get; set; }
        public string ReorderStockLevel { get; set; }
        public string MaximumReorder { get; set; }
        public string MinimumReorder { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemBarcodeModel
    {
        public string Barcode { get; set; }
        public string Uom { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemDocumentModel
    {
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemColorModel
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorArabicName { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
    public class ItemSizeModel
    {
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string SizeArabicName { get; set; }
        public string ActualName { get; set; }
        public string ExpectedName { get; set; }
    }
}
