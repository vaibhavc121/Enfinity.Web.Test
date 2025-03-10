using Enfinity.Common.Test;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class GlobalTest:BaseTest
    {
        //private string Product = "Erp";

        #region Constructor
        public GlobalTest()
        { }
        #endregion

        #region Create new unit of measure
        [Test, Category("Global"), Order(1)]
        public async Task CreateUnitOfMeasure()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var uomFile = FileHelper.GetDataFile("Erp", "Global", "UOM", "UOMData");
            var uoms = JsonHelper.ConvertJsonListDataModel<UOMModel>(uomFile, "new");

            var nbp = new NavigationBarPage(_driver);
            var ulp = new UOMListingPage(_driver);
            var up = new UOMPage(_driver);

            foreach (var uom in uoms)
            {
                await WaitHelper.WaitForSeconds(2);
                nbp.ClickOnGlobalSearch();
                
                nbp.ProvideSearchText(uom.SearchText);
                CommonPageActions.SelectDropDownListOption(uom.SearchText);
                await WaitHelper.WaitForSeconds(2);

                ulp.ClickOnNewUOM();
                await WaitHelper.WaitForSeconds(2);

                //up.ProvideUOMCode(uom.Code);
                up.ProvideUOMName(uom.Name);
                up.ProvideUOMArabicName(uom.ArabicName);
                up.ProvideDescription(uom.Description);

                //up.ClickOnBase();
                //up.ClickOnDefault();

                up.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the created successfully message
                CommonPageActions.ValidateSucess("Unit of Measure created successfully!");
                #endregion

                up.ClickOnLink();                 
            }
        }
        #endregion

        #region Create new unit of measure with same name and code
        [Test, Category("Global"), Order(1)]
        public async Task ValidateUOMSameNameOrCodeNotAllowed()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var uomFile = FileHelper.GetDataFile("Erp", "Global", "UOM", "UOMData");
            var uoms = JsonHelper.ConvertJsonListDataModel<UOMModel>(uomFile, "duplicate");

            var nbp = new NavigationBarPage(_driver);
            var ulp = new UOMListingPage(_driver);
            var up = new UOMPage(_driver);

            foreach (var uom in uoms)
            {
                await WaitHelper.WaitForSeconds(2);
                nbp.ClickOnGlobalSearch();

                nbp.ProvideSearchText(uom.SearchText);
                CommonPageActions.SelectDropDownListOption(uom.SearchText);
                await WaitHelper.WaitForSeconds(2);

                ulp.ClickOnNewUOM();
                await WaitHelper.WaitForSeconds(2);                
                up.ProvideUOMName(uom.Name);
                up.ClickOnSave();

                #region Validate summary
                CommonPageActions.ValidateSummary("already exists");
                #endregion

                await WaitHelper.WaitForSeconds(2);
                up.ProvideUOMCode(uom.Code);
                up.ProvideUOMName(uom.Name);
                up.ClickOnSave();

                #region Validate summary
                CommonPageActions.ValidateSummary("already exists");
                #endregion

                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Delete unit of measure
        [Test, Category("Global"), Order(2)]
        public async Task DeleteUnitOfMeasure()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var uomFile = FileHelper.GetDataFile("Erp", "Global", "UOM", "UOMData");
            var uoms = JsonHelper.ConvertJsonListDataModel<UOMModel>(uomFile, "delete");

            var nbp = new NavigationBarPage(_driver);
            var ulp = new UOMListingPage(_driver);
            var up = new UOMPage(_driver);

            foreach (var uom in uoms)
            {
                await WaitHelper.WaitForSeconds(2);
                nbp.ClickOnGlobalSearch();

                nbp.ProvideSearchText(uom.SearchText);
                CommonPageActions.SelectDropDownListOption(uom.SearchText);
                await WaitHelper.WaitForSeconds(2);

                ulp.ProvideUOMName(uom.Name);
                ulp.ClickOnSelectedUOM();

                ulp.ClickOnContextMenuItem();
                ulp.ClickOnContextMenuDelete();
                ulp.ClickOnConfirmOk();                                                                                         
                await WaitHelper.WaitForSeconds(1);

                #region Validate record deleted message
                CommonPageActions.ValidateMessage("Record deleted successfully!");
                #endregion
            }
        }
        #endregion
    }
}
