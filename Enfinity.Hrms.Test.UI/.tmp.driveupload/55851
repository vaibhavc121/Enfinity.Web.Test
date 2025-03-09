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

        //[Test]
        [Ignore("")]
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
                    foreach(var KRA in performance.KRA)
                    {
                        ep.AddKRABtn();
                        ep.ClickKeyResultAreaName();
                        ep.SelectResultAreaName(KRA.KeyResultAreaName);
                        ep.ProvideWeightage(KRA.weightage);
                        ep.ClickKRAsave();
                    }
                    foreach(var competencies in performance.Competencies)
                    {
                        ep.ClickAddCompetencies();
                        ep.ClickCompetencyName();
                        ep.SelectCompetencyName(competencies.competencyName);
                        ep.ProvideCompetenciesWeightage(competencies.competenciesWeightage);
                        ep.ClickCompetenciesSave();
                    }

                    foreach(var skillset in performance.SkillSets)
                    {
                        ep.ClickaddSkillSetBtn();
                        ep.ClickSkillSetName();
                        ep.SelectSkillSetName(skillset.skillSetName);
                        ep.ClickLevel();
                        ep.SelectLevel(skillset.level);
                        ep.ProvideSkillSetWeightage(skillset.skillSetWeightage);
                        ep.ClickskillSetsave();
                    }
                    
                    foreach(var goal in performance.Goals)
                    {
                        ep.ClickaddGoalsBtn();
                        ep.ProvideGoalName(goal.goalName);
                        ep.ProvideGoalsStartDate(goal.startDate);
                        ep.ProvideGoalsDueDate(goal.dueDate);
                        ep.ClickPriority();
                        ep.SelectPriority(goal.priority);
                        ep.ProvideGoalsWeightage(goal.goalsWeightage);
                        ep.ClickGoalSave();
                    }
                    
                    
                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
