using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Employee;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class DocumentsTabTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyDocumentsTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var documentsInfo = JsonHelper.ConvertJsonListDataModel<DocumentsTabModel>(employeeFile, "documents");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("188");
                CommonPageActions.SwitchTab();

                //documents tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var documents in documentsInfo)
                {
                    ep.ClickDocuments();
                    ep.AddDocuments();
                    ep.ClickDocType();
                    ep.SelectDocType(documents.documentType);
                    ep.ProvideDocNumber();
                    ep.ProvideDateOfExpiry(documents.dateOfExpiry);
                    ep.ClickPlaceOfDocument();
                    ep.SelectPlaceOfDocument(documents.placeOfDocument);
                    ep.EmpDocClickSave();

                }

            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
    }
}
