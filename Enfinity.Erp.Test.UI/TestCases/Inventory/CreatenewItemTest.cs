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


namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class CreatenewItemTest : BaseTest
    {
        [Test, Category("Inventory"), Author("Baburao Adkane")]
        public void CreateNewItem()
        {
            var itemFile = FileHelper.GetDataFile("Erp","Inventory", "Item", "ItemData");
            var items = JsonHelper.LoadJsonData<ItemModel>(itemFile, "new");
            var createNewItemPage = new CreatenewItemPage(_driver);

            foreach(var item in items) {
                //createNewItemPage.selectModule();
                createNewItemPage.navigateToItem();
                createNewItemPage.clickNew();
                createNewItemPage.createNewItem(item.Name, item.ArabicName);
                createNewItemPage.clickUOM();
                createNewItemPage.SelectDropDownOption(item.UOM);
                createNewItemPage.clickType();
                createNewItemPage.SelectDropDownOption(item.Type);
                createNewItemPage.clickTrackingMode();
                createNewItemPage.SelectDropDownOption(item.TrackingMode);
                createNewItemPage.clickCostingMethod();
                createNewItemPage.SelectDropDownOption(item.CostingMethod);
                createNewItemPage.clickSaveItem();
                Thread.Sleep(1000);

                #region
                IWebElement actualNameElement = _driver.FindElement(By.CssSelector("input[name='Name']"));
                string actualName = actualNameElement.GetDomProperty("value");    
                ClassicAssert.AreEqual(item.Name, actualName);
                #endregion

                createNewItemPage.clickBackButton(); 
                Thread.Sleep(2000);
            }            
        }        
        [Test, Category("Inventory"), Author("Baburao Adkane")]
        public void CreateNewBOMItemWithComponent()
        {
            var itemFile = FileHelper.GetDataFile("Erp", "Inventory", "Item", "ItemData");
            var items = JsonHelper.LoadJsonData<ItemModel>(itemFile, "newbom");
            var createNewItemPage = new CreatenewItemPage(_driver);

            foreach (var item in items)
            {
                createNewItemPage.navigateToItem();
                createNewItemPage.clickNew();
                createNewItemPage.createNewItem(item.Name, item.ArabicName);
                createNewItemPage.clickUOM();
                createNewItemPage.SelectDropDownOption(item.UOM);
                createNewItemPage.clickType();
                createNewItemPage.SelectDropDownOption(item.Type);
                //createNewItemPage.clickTrackingMode();
                //createNewItemPage.handleDropDown(item.TrackingMode);
                //createNewItemPage.clickCostingMethod();
                //createNewItemPage.handleDropDown(item.CostingMethod);
                createNewItemPage.clickSaveItem();
                createNewItemPage.clickOnBOMTab();

                foreach (var subItem in item.SubItems)
                {
                    Thread.Sleep(1000);
                    createNewItemPage.clickOnAdd();
                    createNewItemPage.clickItem();
                    createNewItemPage.SelectDropDownOption(subItem.SubItem);
                    createNewItemPage.provideQty(subItem.Qty);
                    createNewItemPage.clickSavePopup();
                    // Validate the added sub-item
                    IWebElement subItemName = _driver.FindElement(By.CssSelector("p[title='test']"));
                    string actualName = subItemName.Text;
                    ClassicAssert.AreEqual(subItem.ExpectedName, actualName);
                }
                createNewItemPage.clickBackButton();
                Thread.Sleep(2000);
            }
        }
    }
}
