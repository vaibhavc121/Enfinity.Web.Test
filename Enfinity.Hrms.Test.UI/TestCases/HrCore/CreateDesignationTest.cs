using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Employee;
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
    public class CreateDesignationTest: BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyDesignationCreation()
        {
            try
            {
                Login(Product);

                var departmentFile = FileHelper.GetDataFile("Hrms", "HRCore", "Department", "DepartmentData");
                var departmentData = JsonHelper.ConvertJsonListDataModel<DepartmentModel>(departmentFile, "createDepartment");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                Thread.Sleep(5000);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickDesignation();
                Thread.Sleep(2000);

                //desg pg
                DesignationPage dp=new DesignationPage(_driver);
                dp.ClickNewButton();              
                dp.SetDesignationCode();                
                dp.SetDesignation(faker.Name.JobTitle());
                dp.ClickGrade();
                dp.SelectGrade();
                dp.SetJobDescription();
                dp.ClickSave();

                ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());
            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
        
    }
}
