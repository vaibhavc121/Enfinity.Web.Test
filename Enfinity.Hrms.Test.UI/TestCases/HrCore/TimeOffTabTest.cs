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
    public class TimeOffTabTest: BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyTimeOffTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var timeOffInfo = JsonHelper.ConvertJsonListDataModel<TimeOffTabModel>(employeeFile, "timeOff");

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

                //timeOff tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var timeoff in timeOffInfo)
                {
                    ep.ClickTimeOff();
                    ep.ClickAssignLeaveType();
                    ep.ClickLeaveType();
                    ep.SelectLeaveType(timeoff.leaveType);
                    ep.LTProvideEffectiveFromDate(timeoff.LTeffectiveFromDate);
                    ep.LTClickSave();
                    //CommonPageActions.ClickSave();
                }               

            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
