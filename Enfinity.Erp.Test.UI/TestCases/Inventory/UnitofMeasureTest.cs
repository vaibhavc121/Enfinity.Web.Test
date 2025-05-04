using Enfinity.Common.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Enfinity.Erp.Test.UI
{
    [TestFixture]
    public class UnitofMeasureTest : BaseTest
    {
        #region Constructor
        public UnitofMeasureTest()
        { }
        #endregion

        #region Create new Unit of Measure
        [Test, Category("Inventory"), Order(1)]
        public async Task CreateUnitofMeasure()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var unitofMeasureFile = FileHelper.GetDataFile("Erp", "Inventory", "UnitofMeasure", "UnitofMeasureData");
                var unitofMeasureDM = JsonHelper.ConvertJsonListDataModel<UnitofMeasureModel>(unitofMeasureFile, "new");

                var nbp = new NavigationBarPage(_driver);
                var uom = new UnitofMeasurePage(_driver);

                foreach (var unitofmeasure in unitofMeasureDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(unitofmeasure.SearchText);
                    CommonPageActions.SelectDropDownListOption(unitofmeasure.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ClickOnNew();
                    await WaitHelper.WaitForSeconds(1);

                    //CommonPageActions.ProvideCode(unitofmeasure.Code);
                    CommonPageActions.ProvideName(unitofmeasure.Name);
                    CommonPageActions.ProvideArabicName(unitofmeasure.ArabicName);
                    CommonPageActions.ProvideDescription(unitofmeasure.Description);

                    //uom.ClickOnBase();
                    //uom.ClickOnDefault();

                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate the item category created message
                    CommonPageActions.ValidateMessage("Unit of Measure created successfully!");
                    #endregion

                    uom.ClickOnUnitofMeasure();
                    await WaitHelper.WaitForSeconds(2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed: CreateUnitofMeasure", ex);
            }
        }
        #endregion

        #region Delete unit of measure
        [Test, Category("Inventory"), Order(2)]
        public async Task DeleteUnitOfMeasure()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var unitofMeasureFile = FileHelper.GetDataFile("Erp", "Inventory", "UnitofMeasure", "UnitofMeasureData");
                var unitofMeasureDM = JsonHelper.ConvertJsonListDataModel<UnitofMeasureModel>(unitofMeasureFile, "delete");

                var nbp = new NavigationBarPage(_driver);
                var uom = new UnitofMeasurePage(_driver);

                foreach (var unitofmeasure in unitofMeasureDM)
                {
                    await WaitHelper.WaitForSeconds(2);
                    nbp.ClickOnGlobalSearch();

                    nbp.ProvideSearchText(unitofmeasure.SearchText);
                    CommonPageActions.SelectDropDownListOption(unitofmeasure.SearchText);
                    await WaitHelper.WaitForSeconds(2);

                    CommonPageActions.ProvideNameOnListing(unitofmeasure.Name);
                    CommonPageActions.ClickOnSelectedName();
                    uom.ClickOnContextMenu();
                    CommonPageActions.ClickOnDelete();
                    CommonPageActions.ClickOnOk();
                    await WaitHelper.WaitForSeconds(1);

                    #region Validate record deleted message
                    CommonPageActions.ValidateMessage("Record deleted successfully!");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Test case failed: DeleteUnitOfMeasure", ex);
            }
        }
        #endregion
    }
}
