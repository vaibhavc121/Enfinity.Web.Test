
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
    //[TestFixture]
    public class DependentsTabTest:BaseTest
    {
        public string Product = "Hrms";

        //[Test]
        [Ignore("")]
        public void VerifyDependentsTab()
        {
            try
            {
                

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var dependentsInfo = JsonUtils.ConvertJsonListDataModel<DependentsTabModel>(employeeFile, "dependents");

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

                //Dependents tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var dependents in dependentsInfo)
                {
                    ep.ClickDependents();
                    ep.ClickAddSpousesBtn();
                    ep.ProvideSpouseName(dependents.spouseName);
                    ep.ProvideSpouseBirthDate(dependents.birthDate);
                    ep.ProvideSpouseMarriageDate(dependents.marriageDate);
                    ep.ClickAddChildrensBtn();
                    ep.ProvideChildrenName(dependents.childrenName);
                    ep.ProvidechildrenBirthDate(dependents.childrenBirthDate);
                    ep.ClickChildrenSave();
                    ep.ClickAddOthersBtn();
                    ep.ProvideDependentName(dependents.dependentName);
                    ep.ProvideDependentBirthDate(dependents.dependentBirthDate);
                    ep.ClickOtherSave();
                }

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
