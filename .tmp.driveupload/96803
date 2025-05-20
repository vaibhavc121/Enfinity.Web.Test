using Enfinity.Common.Test;
using NUnit.Framework;
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
    public class JournalTest: BaseTest
    {
        #region Constructor
        public JournalTest()
        { }
        #endregion

        #region Create New Journal
        [Test, Category("Accounting"), Order(1)]
        public async Task CreateNewJournal()
        {
            try
            {
                #region MyRegion
                Login(ErpProduct);
                #endregion

                var journalFile = FileHelper.GetDataFile("Erp", "Accounting", "Journal", "JournalData");
                var journalDM = JsonHelper.ConvertJsonListDataModel<JournalModel>(journalFile, "new");
                var headerDM = JsonHelper.ConvertJsonListDataModel<JournalModel>(journalFile, "header");

                var jp = new JournalPage(_driver);

                CommonPageActions.ClickOnAccountingModule();
                await WaitHelper.WaitForSeconds(2);

                jp.ClickOnJournal();                
                CommonPageActions.ClickOnNew();

                foreach (var header in headerDM)
                {
                    jp.ProvideReference(header.Reference);
                    jp.ProvideRemarks(header.Remarks);
                }

                CommonPageActions.ClickOnSave();
                await WaitHelper.WaitForSeconds(2);

                foreach (var journal in journalDM)
                {
                    jp.ClickOnAccount();
                    CommonPageActions.SelectDropDownOptionValue(journal.Account);
                    await WaitHelper.WaitForSeconds(2);
                    jp.ClickOnDrCr();
                    jp.SelectDebitCreditValue(journal.Debit);
                    await WaitHelper.WaitForSeconds(2);
                    jp.ProvideEnteredAmount(journal.EnteredAmount);
                    
                    CommonPageActions.ClickOnSave();
                    await WaitHelper.WaitForSeconds(1);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Test case failed : CreateNewJournal ", ex);
            }
        }

        #endregion
    }
}
