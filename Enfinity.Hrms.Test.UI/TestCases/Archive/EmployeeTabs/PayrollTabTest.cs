﻿using Enfinity.Common.Test;
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
    public class PayrollTabTest: BaseTest
    {
        public string Product = "Hrms";
        [Test]
        [Ignore("")]
        public void VerifyPayrollTab()
        {
            try
            {
                Login(Product);

                var employeeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var payrollInfo = JsonHelper.ConvertJsonListDataModel<PayrollTabModel>(employeeFile, "payroll");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickEmployee();
                Thread.Sleep(2000);

                //navigate to desired employee
                CommonPageActions.NavigateToEmployee("213");
                CommonPageActions.SwitchTab();

                //payroll tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach (var payroll in payrollInfo)
                {
                    ep.ClickPayroll();
                    ep.ClickPaymentMode();
                    ep.SelectPaymentMode(payroll.paymentMode);
                    ep.ClickEmpBank();
                    ep.SelectEmpBank(payroll.employeebank);
                    ep.ProvideBankAcNo();
                    ep.ProvideIBANNo();
                    ep.ClickBankAcType();
                    ep.SelectBankAcType(payroll.bankAccountType);
                    ep.ClickGovtLicense();
                    ep.SelectGovtLicense(payroll.govtRecruitmentContractLicense);
                    ep.DeleteBasicSalaryComponent();
                    //ep.EditBasicSalaryComponent(payroll.basicSalary);
                    foreach(var component in payroll.salaryComponents)
                    {
                        ep.ClickAddSalaryComponentBtn();
                        ep.ClickSalaryComponent();
                        ep.SelectSalComponent(component.salaryComponent);
                        ep.ProvideAmt(component.amount);
                        ep.ProvideEffectiveFromDate(component.effectiveFromDate);
                        ep.SaveSalComponent();
                    }

                    foreach (var overtime in payroll.overtimeTypes)
                    {
                        //commented bcos 3 overtime is already gets added for new employee

                        //ep.ClickOvertimeTypesBtn();
                        //ep.ClickOvertimeType();
                        //ep.SelectOvertimeType(overtime.overtimeType);
                        //ep.SaveOvertimeType();
                    }
                    ep.ScrollDownWebPageTicket();
                    ep.AddTicketBtn();
                    ep.clickRelationshipType();
                    ep.SelectRelationshipType(payroll.relationshipType);
                    ep.ProvideDesc(payroll.description);
                    ep.ClickTicketAccrual();
                    ep.SelectTicketAccrual(payroll.ticketAccrual);
                    ep.ClickTicketDestination();
                    ep.SelectTicketDestination(payroll.ticketDestination);
                    ep.ProvideTicketEffectiveFromDate(payroll.ticketEffectiveFromDate);
                    ep.ClickSaveTicket();
                    //ep.ClickAddMiscellaneousAccrualEarnings();
                    //ep.ClickAccrualType();
                    //ep.SelectAccrualType(payroll.accrualType);
                    //ep.ClickResetAvailedDaysMethod();
                    //ep.SelectResetAvailedDaysMethod(payroll.resetAvailedDaysMethod);
                    //ep.SaveMiscellaneousAccrual();
                    //ep.ClickBenefitSchemes();
                    //ep.ClickRelationshipType();
                    //ep.BSSelectRelationshipType(payroll.BSrelationshipType);
                    //ep.ClickBenefitScheme();
                    //ep.SelectBenefitScheme(payroll.benefitScheme);
                    //ep.ProvideBSEffectiveFromDate(payroll.BSeffectiveFromDate);
                    //ep.ProvideBSEffectiveToDate(payroll.BSeffectiveToDate);
                    //ep.BSSave();

                }
                

                //ClassicAssert.IsTrue(true);


            }
            catch(Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}