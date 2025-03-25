using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.Payroll.Payroll;
using Enfinity.Hrms.Test.UI.PageObjects.Payroll;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    [TestFixture]
    public class PayrollModule:BaseTest
    {
        #region Create Benefit Scheme
        [Test, Order(1)]
        public void CreateBenefitScheme()
        {
        }
        #endregion

        #region Create Variable Salary
        [Test, Order(2)]
        public void CreateVariableSalary()
        {
        }
        #endregion

        #region Create Subledger Variable Salary
        [Test, Order(3)]
        public void CreateSubledgerVariableSalary()
        {
        }
        #endregion

        #region Create Leave
        [Test, Order(4)]
        public void CreateLeave()
        {
        }
        #endregion

        #region Create Leave Adjustment
        [Test, Order(5)]
        public void CreateLeaveAdjustment()
        {
        }
        #endregion

        #region Create Leave Encashment
        [Test, Order(6)]
        public void CreateLeaveEncashment()
        {
        }
        #endregion

        #region Create Leave Opening Balance
        [Test, Order(7)]
        public void CreateLeaveOpeningBalance()
        {
        }
        #endregion

        #region Create Timesheet
        [Test, Order(8)]
        public void CreateTimesheet()
        {
        }
        #endregion

        #region Create Indemnity Adjustment
        [Test, Order(9)]
        public void CreateIndemnityAdjustment()
        {
        }
        #endregion

        #region Create Benefit Scheme Encashment
        [Test, Order(10)]
        public void CreateBenefitSchemeEncashment()
        {
        }
        #endregion

        #region Create Ticket Encashment
        [Test, Order(11)]
        public void CreateTicketEncashment()
        {
        }
        #endregion

        #region Create Ticket Adjustment
        [Test, Order(12)]
        public void CreateTicketAdjustment()
        {
        }
        #endregion

        #region Create Overtime
        [Test, Order(13)]
        public void CreateOvertime()
        {
        }
        #endregion

        #region Create Loan
        [Test, Order(14)]
        public void CreateLoan()
        {
        }
        #endregion

        #region Create Promotion
        [Test, Order(15)]
        public void CreatePromotion()
        {
        }
        #endregion

        #region Create End Of Service
        [Test, Order(16)]
        public void CreateEndOfService()
        {
        }
        #endregion

        #region Create Penalty
        [Test, Order(17)]
        public void CreatePenalty()
        {
        }
        #endregion

        #region Create Suspend
        [Test, Order(18)]
        public void CreateSuspend()
        {
        }
        #endregion

        #region Create Rehire
        [Test, Order(19)]
        public void CreateRehire()
        {
        }
        #endregion

        #region Create Payroll Journal
        [Test, Order(20)]
        public void CreatePayrollJournal()
        {
            
        }

        [Test, Order(21)]
        public void RemoveDuplicateSalComponenet()
        {
            try
            {
                Login(HrmsProduct);

                var payrollFile = FileHelper.GetDataFile("Hrms", "Payroll", "Payroll", "PayrollData");
                var payrollData = JsonHelper.ConvertJsonListDataModel<PayrollModel>(payrollFile, "removeSalComponent");

                //payroll module
                PayrollPage pp = new PayrollPage(_driver);
                pp.ClickPayroll();
                pp.ClickSetups();

                //setup pg
                PayrollSetupPage sp = new PayrollSetupPage(_driver);
                sp.ClickSalaryComponent();

                //SalaryComponent PG
                SalaryComponentPage sc = new SalaryComponentPage(_driver);
                foreach (var salComponent in payrollData)
                {
                    sc.FilterCode(salComponent.code);
                    sc.SelectRow();
                    sc.ClickEdit();
                    sc.ClickGeneral();
                    sc.SelectRestrictToCompany("Grand Stream Solutions");
                    sc.ClickSaveAndBack();
                }

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
        #endregion


    }
}
