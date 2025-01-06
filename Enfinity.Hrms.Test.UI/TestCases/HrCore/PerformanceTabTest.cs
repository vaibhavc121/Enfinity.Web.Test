using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Employee;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class PerformanceTabTest: BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyPerformanceTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var performanceInfo = JsonHelper.ConvertJsonListDataModel<PerformanceTabModel>(employeeFile, "performance");

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

                //performance tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var performance in performanceInfo)
                {
                    ep.ClickPerformance();
                    ep.AddKRABtn();
                    ep.ClickKeyResultAreaName();
                    ep.SelectResultAreaName(performance.KeyResultAreaName);
                    ep.ProvideWeightage(performance.weightage);
                    ep.ClickKRAsave();
                    ep.ClickAddCompetencies();
                    ep.ClickCompetencyName();
                    ep.SelectCompetencyName(performance.competencyName);
                    ep.ProvideCompetenciesWeightage(performance.competenciesWeightage);
                    ep.ClickCompetenciesSave();
                    ep.ClickaddSkillSetBtn();
                    ep.ClickSkillSetName();
                    ep.SelectSkillSetName(performance.skillSetName);
                    ep.ClickLevel();
                    ep.SelectLevel(performance.level);
                    ep.ProvideSkillSetWeightage(performance.skillSetWeightage);
                    ep.ClickskillSetsave();
                    ep.ClickaddGoalsBtn();
                    ep.ProvideGoalName(performance.goalName);
                    ep.ProvideGoalsStartDate(performance.startDate);
                    ep.ProvideGoalsDueDate(performance.dueDate);
                    ep.ClickPriority();
                    ep.SelectPriority(performance.priority);
                    ep.ProvideGoalsWeightage(performance.goalsWeightage);
                    ep.ClickGoalSave();
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
