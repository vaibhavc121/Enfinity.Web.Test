using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI;
using Enfinity.Hrms.Test.UI.Models.Employee;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;


namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class CreatePayrollEmployeeTest : BaseTest
    {
        public string Product = "Hrms";
        [Test]
        //[Ignore("")]
        
        public void VerifyPayrollEmployeeCreation()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var employeeInfo = JsonHelper.ConvertJsonListDataModel<NewEmployeeModel>(employeeFile, "newEmployee");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //PayrollEmployee page
                EmployeePage pe = new EmployeePage(_driver);

                foreach (var employee in employeeInfo)
                {
                    pe.ClickNewBtn();
                    pe.ProvideWorkEmail(employee.email);
                    pe.ProvideName();
                    pe.ClickMgrDropdown();
                    pe.SelectMgr();
                    pe.ProvideMobileNumber(employee.mobile);
                    pe.ProvideDOJ(employee.DOJ);
                    pe.ClickDepartment();
                    pe.SelectDepartment(employee.department);
                    pe.ClickDesignation();
                    pe.SelectDesignation(employee.designation);
                    //pe.ClearPayrollSet();
                    pe.ClickPayrollSet();
                    pe.SelectPayrollSet(employee.payrollSet);
                    pe.ClickCalendar();
                    pe.SelectCalendar(employee.calendar);
                    pe.ClickIndemnity();
                    pe.SelectIndemnity(employee.indemnity);
                    pe.ClickGrade();
                    pe.SelectGrade(employee.grade);
                    pe.ClickGender();
                    pe.SelectGender(employee.gender);
                    pe.ClickReligion();
                    pe.SelectReligion(employee.religion);
                    pe.ClickMaritalStatus();
                    pe.SelectMaritalStatus(employee.maritalStatus);
                    pe.ClickSave();
                }
                

                //ClassicAssert.IsTrue(pe.IsEmployeeCreated(name));

            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }

        }
    }
}
