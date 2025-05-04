using Enfinity.Common.Test;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class PriceListTest : BaseTest
    {
        #region Constructor
        public PriceListTest()
        { }
        #endregion

        #region Create New Price List
        [Test, Category("Sales"), Order(1)]
        public async Task CreatePriceList()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var priceListFile = FileHelper.GetDataFile("Erp", "Sales", "PriceList", "PriceListData");
                var priceListDM = JsonHelper.ConvertJsonListDataModel<PriceListModel>(priceListFile, "new");

                var ssp = new SalesSetupPage(_driver);
                var plp = new PriceListPage(_driver);

                foreach (var priceList in priceListDM)
                {
                    CommonPageActions.ClickOnSalesModule();
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnSetups();
                    ssp.ClickOnPriceList();
                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(priceList.Code);
                    CommonPageActions.ProvideName(priceList.Name);
                    CommonPageActions.ProvideArabicName(priceList.ArabicName);
                    CommonPageActions.ProvideDescription(priceList.Description);
                    
                    await WaitHelper.WaitForSeconds(1);

                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate the created price list name
                    IWebElement priceListNameElement = _driver.FindElement(By.CssSelector("input[name='Name']"));
                    string actualName = priceListNameElement.GetAttribute("value");
                    //ClassicAssert.IsTrue(false);
                    StringAssert.Contains(priceList.Name, actualName);
                    #endregion

                    plp.ClickOnPriceList();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : CreatePriceList", ex);
            }
        }
        #endregion

        #region Create New Price List With MarkUp
        [Test, Category("Sales"), Order(2)]
        public async Task CreatePriceListWithMarkup()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var priceListFile = FileHelper.GetDataFile("Erp", "Sales", "PriceList", "PriceListData");
                var priceListDM = JsonHelper.ConvertJsonListDataModel<PriceListModel>(priceListFile, "markup");

                var ssp = new SalesSetupPage(_driver);
                var plp = new PriceListPage(_driver);

                foreach (var priceList in priceListDM)
                {
                    CommonPageActions.ClickOnSalesModule();
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnSetups();
                    ssp.ClickOnPriceList();
                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(priceList.Code);
                    CommonPageActions.ProvideName(priceList.Name);
                    CommonPageActions.ProvideArabicName(priceList.ArabicName);
                    CommonPageActions.ProvideDescription(priceList.Description);
                    await WaitHelper.WaitForSeconds(1);

                    plp.ClickOnPercentageType();
                    CommonPageActions.SelectDropDownOption(priceList.Markup);
                    plp.ProvidePercentage(priceList.Percentage);

                    plp.ClickOnApplyMinMaxLimit();
                    plp.ProvideMinUnitPricePercent(priceList.MinUnitPricePercent);
                    plp.ProvideMaxUnitPricePercent(priceList.MaxUnitPricePercent);

                    plp.ClickOnApplyDiscountPercent();
                    plp.ProvideDefaultDiscountPercent(priceList.DefaultDiscountPercent);
                    plp.ProvideMaxDiscountPrecent(priceList.MaxDiscountPrecent);

                    #region All Items (Including multi UOM)
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(3);
                    #endregion

                    //#region Items with Base UOM
                    //plp.ClickOnAllItemsWithBaseUom();
                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected group
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemGroup1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemGroup2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected category
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnByItemCategory();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemCategory1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemCategory2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected brand
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnByBrand();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemBrand1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemBrand2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    #region Validate the created price list name
                    IWebElement priceListNameElement = _driver.FindElement(By.CssSelector("input[name='Name']"));
                    string actualName = priceListNameElement.GetAttribute("value");
                    StringAssert.Contains(priceList.Name, actualName);
                    #endregion

                    plp.ClickOnPriceList();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : CreatePriceListWithMarkup", ex);
            }
        }
        #endregion

        #region Create New Price List With MarkDown
        [Test, Category("Sales"), Order(2)]
        public async Task CreatePriceListWithMarkdown()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var priceListFile = FileHelper.GetDataFile("Erp", "Sales", "PriceList", "PriceListData");
                var priceListDM = JsonHelper.ConvertJsonListDataModel<PriceListModel>(priceListFile, "markdown");

                var ssp = new SalesSetupPage(_driver);
                var plp = new PriceListPage(_driver);

                foreach (var priceList in priceListDM)
                {
                    CommonPageActions.ClickOnSalesModule();
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnSetups();
                    ssp.ClickOnPriceList();
                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(priceList.Code);
                    CommonPageActions.ProvideName(priceList.Name);
                    CommonPageActions.ProvideArabicName(priceList.ArabicName);
                    CommonPageActions.ProvideDescription(priceList.Description);
                    await WaitHelper.WaitForSeconds(1);

                    plp.ClickOnPercentageType();
                    CommonPageActions.SelectDropDownOption(priceList.Markdown);
                    plp.ProvidePercentage(priceList.Percentage);

                    plp.ClickOnApplyMinMaxLimit();
                    plp.ProvideMinUnitPricePercent(priceList.MinUnitPricePercent);
                    plp.ProvideMaxUnitPricePercent(priceList.MaxUnitPricePercent);

                    plp.ClickOnApplyDiscountPercent();
                    plp.ProvideDefaultDiscountPercent(priceList.DefaultDiscountPercent);
                    plp.ProvideMaxDiscountPrecent(priceList.MaxDiscountPrecent);

                    #region All Items (Including multi UOM)
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(3);
                    #endregion

                    //#region Items with Base UOM
                    //plp.ClickOnAllItemsWithBaseUom();
                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected group
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemGroup1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemGroup2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected category
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnByItemCategory();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemCategory1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemCategory2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    //#region Items with selected brand
                    //plp.ClickOnSelectedItems();
                    //plp.ClickOnByBrand();
                    //plp.ClickOnSelectedBox();
                    //await WaitHelper.WaitForSeconds(1);
                    //plp.ClickOnSelectAll();
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemBrand1);
                    ////CommonPageActions.SelectDropDownOption(priceList.ItemBrand2);

                    //CommonPageActions.ClickOnSave();
                    //await WaitHelper.WaitForSeconds(3);
                    //#endregion

                    #region Validate the created price list name
                    IWebElement priceListNameElement = _driver.FindElement(By.CssSelector("input[name='Name']"));
                    string actualName = priceListNameElement.GetAttribute("value");
                    StringAssert.Contains(priceList.Name, actualName);
                    #endregion

                    plp.ClickOnPriceList();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed : CreatePriceListWithMarkdown", ex);
            }
        }
        #endregion

        #region Delete Price List
        [Test, Category("Sales"), Order(3)]
        public async Task DeletePriceList()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var priceListFile = FileHelper.GetDataFile("Erp", "Sales", "PriceList", "PriceListData");
                var priceListDM = JsonHelper.ConvertJsonListDataModel<PriceListModel>(priceListFile, "delete");

                var ssp = new SalesSetupPage(_driver);
                var plp = new PriceListPage(_driver);

                foreach (var priceList in priceListDM)
                {
                    CommonPageActions.ClickOnSalesModule();                 
                    CommonPageActions.ClickOnSetups();
                    ssp.ClickOnPriceList();

                    CommonPageActions.ProvideNameOnListing(priceList.Name);
                    CommonPageActions.ClickOnSelectedName();
                    CommonPageActions.ClickOnContextMenu();
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
                throw new Exception($"Test case failed : DeletePriceList", ex);
            }
        }
        #endregion
    }
}
