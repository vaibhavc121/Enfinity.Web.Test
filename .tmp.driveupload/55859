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
    public class IntegrationTabTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        [Ignore("")]
        public void VerifyIntegrationTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var integrationInfo = JsonHelper.ConvertJsonListDataModel<IntegrationTabModel>(employeeFile, "integration");

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

                //Integration tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var integration in integrationInfo)
                {
                    ep.ClickIntegration();
                    ep.ClickFinancialIntegrationGroup();
                    ep.SelectFinancialIntegrationGroup(integration.financialIntegrationGroup);
                    ep.ProvideDivision(integration.division);
                    ep.ProvideDepartment(integration.department);
                    ep.ProvideProject(integration.project);
                    ep.ProvideSegmentWorkLocation(integration.segmentWorkLocation);
                    //ep.ClickDefaultCostAllocationBtn();
                    //ep.ClickFromPeriod();
                    //ep.SelectFromPeriod(integration.FromPeriod);
                    //ep.ClickToPeriod();
                    //ep.SelectToPeriod(integration.ToPeriod);
                    //ep.ClickAddRowBtn();
                    //ep.Providesdivision(integration.sdivision);
                    //ep.Providesdepartment(integration.sdepartment);
                    //ep.Providesproject(integration.sproject);
                    //ep.ProvidesWorkLocation(integration.sWorkLocation);
                    //ep.ClickCostAllocationsave();

                    foreach(var project in integration.Projects)
                    {
                        ep.ClickAddProjectsBtn();
                        ep.ClickProject();
                        ep.SelectProject(project.Project);
                        ep.ProvideProjectEffectiveFromDate(project.EffectiveFromDate);
                        ep.ProvideProjectEffectiveToDate(project.EffectiveToDate);
                        ep.ClickEmpProjectsave();
                    }
                    
                    //ep.SaveAllInfo();

                }
            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
