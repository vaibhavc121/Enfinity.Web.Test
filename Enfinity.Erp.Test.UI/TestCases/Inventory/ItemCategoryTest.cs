using Enfinity.Common.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class ItemCategoryTest:BaseTest
    {
        #region Constructor
        public ItemCategoryTest()
        { }
        #endregion

        #region Create new Item Category
        [Test, Category("Inventory"), Order(1)]
        public async Task CreateItemCategory()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemCategoryFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemCategory", "ItemCategoryData");
                var itemCategoryDM = JsonHelper.ConvertJsonListDataModel<ItemCategoryModel>(itemCategoryFile, "new");

                var nbp = new NavigationBarPage(_driver);
                var icp = new ItemCategoryPage(_driver);

                foreach (var itemcategory in itemCategoryDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itemcategory.SearchText);
                    CommonPageActions.SelectDropDownListOption(itemcategory.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(itemcategory.Code);
                    CommonPageActions.ProvideName(itemcategory.Name);
                    CommonPageActions.ProvideArabicName(itemcategory.ArabicName);
                    CommonPageActions.ProvideDescription(itemcategory.Description);
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate the item category created message
                    CommonPageActions.ValidateMessage("Item Category created successfully!");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed: CreateItemCategory ", ex);
            }
        }
        #endregion

        #region Delete Item Category
        [Test, Category("Inventory"), Order(2)]
        public async Task DeleteItemCategory()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemCategoryFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemCategory", "ItemCategoryData");
                var itemCategoryDM = JsonHelper.ConvertJsonListDataModel<ItemCategoryModel>(itemCategoryFile, "delete");

                var nbp = new NavigationBarPage(_driver);
                var icp = new ItemCategoryPage(_driver);

                foreach (var itemcategory in itemCategoryDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itemcategory.SearchText);
                    CommonPageActions.SelectDropDownListOption(itemcategory.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    icp.ProvideNameOnListing(itemcategory.Name);                    
                    icp.ClickOnSelectedName();
                    icp.ClickOnContextMenu();
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
                throw new Exception($"Test case failed : DeleteItemCategory", ex);
            }
        }
        #endregion
    }
}
