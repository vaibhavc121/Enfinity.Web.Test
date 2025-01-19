using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Employee;
using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class DeleteEmployeeTest:BaseTest
    {
        public string Product = "Hrms";
        [Test]
        //[Ignore("")]
        public void DeleteEmployee1()
        {
            try
            {
                for (int i = 1; i <= 1; i++) 
                {
                    Login(Product);

                    var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                    var deleteEmployee = JsonHelper.ConvertJsonListDataModel<DeleteEmpModel>(employeeFile, "deleteEmployee");

                    HRCorePage hc = new HRCorePage(_driver);
                    hc.ClickHRCore();
                    hc.ClickSetupForm();

                    SetupPage sp = new SetupPage(_driver);
                    sp.ClickEmployee();
                    Thread.Sleep(2000);

                    foreach (var delete in deleteEmployee)
                    {
                        CommonPageActions.NavigateToEmployee(delete.EMPID);
                        CommonPageActions.SwitchTab();                        

                        EmployeePage ep = new EmployeePage(_driver);
                        ep.ClickSettingButton();
                        ep.ClickDelete();
                        ep.ClickOk();
                        //ClassicAssert.IsTrue(CommonPageActions.IsEmployeeDeleted(), "Employee not deleted");
                        ep.ClickRightAreaMenu();
                        ep.ClicklogOff();
                        //CommonPageActions.CloseTab();
                       
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
