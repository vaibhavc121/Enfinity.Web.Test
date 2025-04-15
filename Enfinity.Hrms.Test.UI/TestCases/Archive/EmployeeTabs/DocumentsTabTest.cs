
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Models.Employee;
using Enfinity.Hrms.Test.UI.Utilities;
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
    public class DocumentsTabTest: BaseTest
    {
        public string Product = "Hrms";

        //[Test]
        //[Ignore("")]
        public void VerifyDocumentsTab()
        {
            try
            {
                

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var documentsInfo = JsonUtils.ConvertJsonListDataModel<DocumentsTabModel>(employeeFile, "documents");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                BasePage.NavigateToEmployee("188");
                BasePage.SwitchTab();

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
                    //ep.AddAttachment();
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
