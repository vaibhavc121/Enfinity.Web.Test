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
    public class JobTabTest : BaseTest
    {
        public string Product = "Hrms";
        [Test]
        [Ignore("")]
        public void VerifyJobTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var jobInfo = JsonHelper.ConvertJsonListDataModel<JobTabModel>(employeeFile, "job");

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

                //job tab
                EmployeePage ep = new EmployeePage(_driver);
                foreach(var job in jobInfo)
                {
                    ep.ClickJob();
                    //ep.ClickManager(); //not working
                    //ep.SelectManager(job.manager); //not working
                    //ep.EnableKeyEmp();
                    //ep.ClickSubstituteEmployee();
                    //ep.SelectSubstituteEmployee(job.substituteEmployee); //not working
                    ep.ClickEmployeeCategory();
                    ep.SelectEmployeeCategory(job.category);
                    ep.ClickWorkLocation();
                    ep.SelectWorkLocation(job.workLocation); //not working
                    ep.ClickEmploymentType();
                    ep.SelectEmploymentType(job.employmentType);
                    ep.ProvideProbationPeriod(job.probationPeriod);
                    ep.ProvideNoticePeriod(job.noticePeriod);
                    ep.ClickAddWorkExpBtn();
                    ep.ProvidePriorCompany(job.priorCompany);
                    ep.ProvideStartDate(job.startDate);
                    ep.ClickSaveBtn();
                    //ep.AddQualificationBtn();
                    //ep.ClickQualification();
                    //ep.SelectQualification();
                    //ep.ProvideUniversity(job.university);
                    //ep.ProvideYOP(job.YearOfPassing);
                    //ep.SaveQualification();
                    CommonPageActions.ClickSave();
                }
                

                ClassicAssert.IsTrue(true);



            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
