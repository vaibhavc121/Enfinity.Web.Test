
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
    public class TimeOffTabTest: BaseTest
    {
        public string Product = "Hrms";

        //[Test]
        [Ignore("")]
        public void VerifyTimeOffTab()
        {
            try
            {
                

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var timeOffInfo = JsonUtils.ConvertJsonListDataModel<TimeOffTabModel>(employeeFile, "timeOff");

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

                //timeOff tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var timeoff in timeOffInfo)
                {
                    foreach(var leave in timeoff.leaveTypes)
                    {
                        ep.ClickTimeOff();
                        ep.ClickAssignLeaveType();
                        ep.ClickLeaveType();
                        ep.SelectLeaveType(leave.leaveType);
                        ep.LTProvideEffectiveFromDate(leave.LTeffectiveFromDate);
                        ep.LTClickSave();
                    }
                    
                    //BasePage.ClickSave();
                }               

            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
