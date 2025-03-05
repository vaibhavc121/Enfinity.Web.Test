using Enfinity.Common.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class WarehouseTest:BaseTest
    {
        private string Product = "Erp";

        #region Constructor
        public WarehouseTest()
        { }
        #endregion

        #region Create new warehouse
        [Test, Category("Inventory"), Order(1)]
        public async Task CreateWarehouse()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var warehouseFile = FileHelper.GetDataFile("Erp", "Inventory", "Warehouse", "WarehouseData");
            var warehouses = JsonHelper.ConvertJsonListDataModel<WarehouseModel>(warehouseFile, "new");

            var isp = new InventorySetupPage(_driver);
            var wp = new WarehousePage(_driver);

            foreach (var warehouse in warehouses)
            {
                CommonPageActions.ClickOnInventoryModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                isp.ClickOnWarehouse();
                CommonPageActions.ClickOnNew();
                await WaitHelper.WaitForSeconds(1);

                wp.ProvideCode(warehouse.Code);
                wp.ProvideName(warehouse.Name);
                wp.ProvideArabicName(warehouse.ArabicName);
                wp.ClickOnSkipNegativeStockCheck();
                wp.ProvideDescription(warehouse.Description);
                wp.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate
                CommonPageActions.Validate("Warehouse created successfully!");
                #endregion

                wp.ClickOnWarehouse();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Delete warehouse
        [Test, Category("Inventory"), Order(2)]
        public async Task DeleteWarehouse()
        {
            #region MyRegion
            Login(Product);
            #endregion

            var warehouseFile = FileHelper.GetDataFile("Erp", "Inventory", "Warehouse", "WarehouseData");
            var warehouses = JsonHelper.ConvertJsonListDataModel<WarehouseModel>(warehouseFile, "delete");

            var isp = new InventorySetupPage(_driver);
            var wp = new WarehousePage(_driver);

            foreach (var warehouse in warehouses)
            {
                CommonPageActions.ClickOnInventoryModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                isp.ClickOnWarehouse();
                
                CommonPageActions.ProvideNameOnListing(warehouse.Name);
                CommonPageActions.ClickOnSelectedName();
                wp.clickOnContextMenu();
                CommonPageActions.ClickOnDelete();
                CommonPageActions.ClickOnOk();

                #region Validate
                CommonPageActions.Validate("Record deleted successfully!");
                #endregion                 
            }
        }
        #endregion
    }
}
