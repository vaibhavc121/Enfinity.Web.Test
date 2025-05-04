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
    public class ItemBrandTest : BaseTest
    {
        #region Constructor
        public ItemBrandTest()
        { }
        #endregion

        #region Create new Item Brand
        [Test, Category("Inventory"), Order(1)]
        public async Task CreateItemBrand()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemBrandFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemBrand", "ItemBrandData");
                var itemBrandDM = JsonHelper.ConvertJsonListDataModel<ItemBrandModel>(itemBrandFile, "new");

                var nbp = new NavigationBarPage(_driver);
                //var ibp = new ItemBrandPage(_driver);

                foreach (var itembrand in itemBrandDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itembrand.SearchText);
                    CommonPageActions.SelectDropDownListOption(itembrand.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    CommonPageActions.ProvideCode(itembrand.Code);
                    CommonPageActions.ProvideName(itembrand.Name);
                    CommonPageActions.ProvideArabicName(itembrand.ArabicName);                    
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate the item category created message
                    CommonPageActions.ValidateMessage("Brand created successfully!");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed: CreateItemBrand ", ex);
            }
        }
        #endregion

        #region Delete Item Brand
        [Test, Category("Inventory"), Order(2)]
        public async Task DeleteItemBrand()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemBrandFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemBrand", "ItemBrandData");
                var itemBrandDM = JsonHelper.ConvertJsonListDataModel<ItemBrandModel>(itemBrandFile, "delete");

                var nbp = new NavigationBarPage(_driver);
                var ibp = new ItemBrandPage(_driver);

                foreach (var itembrand in itemBrandDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itembrand.SearchText);
                    CommonPageActions.SelectDropDownListOption(itembrand.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ProvideNameOnListing(itembrand.Name);
                    CommonPageActions.ClickOnSelectedName();
                    ibp.ClickOnContextMenu();
                    CommonPageActions.ClickOnDelete();
                    CommonPageActions.ClickOnOk();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate deleted message
                    CommonPageActions.ValidateMessage("Record deleted successfully!");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : DeleteItemBrand", ex);
            }
        }
        #endregion
    }
}
