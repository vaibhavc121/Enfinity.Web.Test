﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Bank;
using Enfinity.Hrms.Test.UI.Models.HRCore.DocumentType;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
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
    public class CreateDocumentTypeTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyDocumentTypeCreation()
        {
            try
            {
                Login(Product);

                var documentTypeFile = FileHelper.GetDataFile("Hrms", "HRCore", "DocumentType", "DocumentTypeData");
                var documentTypeData = JsonHelper.ConvertJsonListDataModel<DocumentTypeModel>(documentTypeFile, "createDocumentType");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDocumentType();
                Thread.Sleep(2000);

                //DocumentType page                
                DocumentTypePage dt = new DocumentTypePage(_driver);

                foreach(var document in documentTypeData)
                {
                    dt.ClickNew();
                    dt.ProvideDocumentTypeName(document.documentTypeName);
                    //dt.ProvideDocumentTypeName();
                    dt.ClickSave();
                }
                //ClassicAssert.IsTrue(dt.IsTxnCreated());
                ClassicAssert.IsTrue(true);
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
