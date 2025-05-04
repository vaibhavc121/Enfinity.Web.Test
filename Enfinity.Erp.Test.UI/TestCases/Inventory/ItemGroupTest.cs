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
    public class ItemGroupTest : BaseTest
    {
        #region Constructor
        public ItemGroupTest()
        { }
        #endregion

        #region Create new Item Group
        [Test, Category("Inventory"), Order(1)]
        public async Task CreateItemGroup()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemGroupFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemGroup", "ItemGroupData");
                var itemGroupDM = JsonHelper.ConvertJsonListDataModel<ItemGroupModel>(itemGroupFile, "new");

                var nbp = new NavigationBarPage(_driver);
                var igp = new ItemGroupPage(_driver);

                foreach (var itemgroup in itemGroupDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itemgroup.SearchText);
                    CommonPageActions.SelectDropDownListOption(itemgroup.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(itemgroup.Code);
                    CommonPageActions.ProvideName(itemgroup.Name);
                    CommonPageActions.ProvideArabicName(itemgroup.ArabicName);
                    CommonPageActions.ProvideDescription(itemgroup.Description);
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate the item category created message
                    CommonPageActions.ValidateMessage("Item Group created successfully!");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed: CreateItemGroup ", ex);
            }
        }
        #endregion

        #region Delete Item Group
        [Test, Category("Inventory"), Order(2)]
        public async Task DeleteItemGroup()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var itemGroupFile = FileHelper.GetDataFile("Erp", "Inventory", "ItemGroup", "ItemGroupData");
                var itemGroupDM = JsonHelper.ConvertJsonListDataModel<ItemGroupModel>(itemGroupFile, "delete");

                var nbp = new NavigationBarPage(_driver);
                var igp = new ItemGroupPage(_driver);

                foreach (var itemgroup in itemGroupDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(itemgroup.SearchText);
                    CommonPageActions.SelectDropDownListOption(itemgroup.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    igp.ProvideNameOnListing(itemgroup.Name);
                    igp.ClickOnSelectedName();
                    igp.ClickOnContextMenu();
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
                throw new Exception($"Test case failed : DeleteItemGroup", ex);
            }
        }
        #endregion
    }
}
