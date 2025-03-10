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
    public class SalesmanTest : BaseTest
    {
        #region Constructor
        public SalesmanTest()
        { }
        #endregion

        #region Create new salesman
        [Test, Category("Sales"), Order(1)]
        public async Task CreateSalesman()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var salesmanFile = FileHelper.GetDataFile("Erp", "Sales", "Salesman", "SalesmanData");
            var salesmans = JsonHelper.ConvertJsonListDataModel<SalesmanModel>(salesmanFile, "new");

            var ssp = new SalesSetupPage(_driver);
            var sp = new SalesmanPage(_driver);

            foreach (var salesman in salesmans)
            {
                CommonPageActions.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnSalesman();
                CommonPageActions.ClickOnNew();
                await WaitHelper.WaitForSeconds(1);

                CommonPageActions.ProvideCode(salesman.Code);
                CommonPageActions.ProvideName(salesman.Name);
                CommonPageActions.ProvideArabicName(salesman.ArabicName);             
                CommonPageActions.ProvideDescription(salesman.Description);

                sp.ClickOnOtherGrid();
                await WaitHelper.WaitForSeconds(1);
                sp.ClickOnSalesmanType();
                await WaitHelper.WaitForSeconds(1);
                CommonPageActions.SelectDropDownValue(salesman.Type);
                sp.ProvideCommission(salesman.Commission);
                sp.ProvideTitle(salesman.Title);
                sp.ProvideEmail(salesman.Email);
                sp.ProvideExtension(salesman.Extension);
                sp.ProvideMobile(salesman.Mobile);

                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(1);

                #region Validate the payment term created message
                CommonPageActions.ValidateMessage("Salesman created successfully!");
                #endregion

                sp.ClickOnSalesman();
                await WaitHelper.WaitForSeconds(2);
            }
        }
        #endregion

        #region Delete Salesman
        [Test, Category("Sales"), Order(2)]
        public async Task DeleteSalesman()
        {
            #region MyRegion
            Login(ErpProduct);
            #endregion

            var salesmanFile = FileHelper.GetDataFile("Erp", "Sales", "Salesman", "SalesmanData");
            var salesmans = JsonHelper.ConvertJsonListDataModel<SalesmanModel>(salesmanFile, "delete");

            var ssp = new SalesSetupPage(_driver);
            var sp = new SalesmanPage(_driver);

            foreach (var salesman in salesmans)
            {
                CommonPageActions.ClickOnSalesModule();
                await WaitHelper.WaitForSeconds(2);

                CommonPageActions.ClickOnSetups();
                ssp.ClickOnSalesman();

                CommonPageActions.ProvideNameOnListing(salesman.Name);
                CommonPageActions.ClickOnSelectedName();
                sp.ClickOnContextMenu();
                CommonPageActions.ClickOnDelete();
                CommonPageActions.ClickOnOk();

                #region Validate payment term deleted message
                CommonPageActions.ValidateMessage("Record deleted successfully!");
                #endregion                 
            }
        }
        #endregion
    }
}
