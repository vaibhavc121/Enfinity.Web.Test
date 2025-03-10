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
    public class ChargeTest : BaseTest
    {
        #region Constructor
        public ChargeTest()
        { }
        #endregion

        #region Create new Charge
        [Test, Category("Purchase"), Order(1)]
        public async Task CreateCharge()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var chargeFile = FileHelper.GetDataFile("Erp", "Purchase", "Charge", "ChargeData");
            var chargeData = JsonHelper.ConvertJsonListDataModel<ChargeModel>(chargeFile, "new");

            var psp = new PurchaseSetupPage(_driver);
            var cp = new ChargePage(_driver);

            foreach (var charge in chargeData)
            {
                CommonPageActions.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnCharge();
                CommonPageActions.ClickOnNew();
                await WaitHelper.WaitForSeconds(1);

                CommonPageActions.ProvideCode(charge.Code);
                CommonPageActions.ProvideName(charge.Name);
                CommonPageActions.ProvideArabicName(charge.ArabicName);
                //cp.ProvideDefaultValue(charge.DefaultValue);
                CommonPageActions.ProvideDescription(charge.Description);
                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the charge created message
                CommonPageActions.ValidateMessage("Charge created successfully!");
                #endregion

                cp.ClickOnCharge();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Delete Charge
        [Test, Category("Purchase"), Order(2)]
        public async Task DeleteCharge()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var chargeFile = FileHelper.GetDataFile("Erp", "Purchase", "Charge", "ChargeData");
            var chargeData = JsonHelper.ConvertJsonListDataModel<ChargeModel>(chargeFile, "delete");

            var psp = new PurchaseSetupPage(_driver);
            var cp = new ChargePage(_driver);

            foreach (var charge in chargeData)
            {
                CommonPageActions.ClickOnPurchaseModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                psp.ClickOnCharge();

                CommonPageActions.ProvideNameOnListing(charge.Name);
                CommonPageActions.ClickOnSelectedName();
                cp.ClickOnContextMenu();
                CommonPageActions.ClickOnDelete();
                CommonPageActions.ClickOnOk();

                #region Validate record deleted message
                CommonPageActions.ValidateMessage("Record deleted successfully!");
                #endregion                 
            }
        }
        #endregion
    }
}
