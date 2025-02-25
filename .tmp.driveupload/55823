using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Bank;
using Enfinity.Hrms.Test.UI.Models.HRCore.Qualification;
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
    public class CreateQualificationTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyQualificationCreation()
        {
            try
            {
                Login(Product);

                var qualificationFile = FileHelper.GetDataFile("Hrms", "HRCore", "Qualification", "QualificationData");
                var qualificationData = JsonHelper.ConvertJsonListDataModel<QualificationModel>(qualificationFile, "createQualification");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickQualification();
                Thread.Sleep(2000);

                //qualification page                
                QualificationPage qp = new QualificationPage(_driver);

                foreach(var qualification in qualificationData)
                {
                    qp.ClickNew();
                    //qp.ProvideQualificationName(qualification.qualificationName);
                    qp.ProvideQualificationName();
                    qp.ClickSave();
                }
                ClassicAssert.IsTrue(qp.IsTxnCreated());
            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
