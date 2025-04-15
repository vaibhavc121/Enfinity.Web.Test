
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
    public class ResidencyInfoTest:BaseTest
    {
        public string Product = "Hrms";
        //[Test]
        [Ignore("")]
        public void VerifyResidencyInfoTab()
        {
            try
            {
                

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var residencyInfo = JsonUtils.ConvertJsonListDataModel<ResidencyInfoTabModel>(employeeFile, "residencyInfo");

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

                //ResidencyInfo tab
                EmployeePage ep = new EmployeePage(_driver);

                foreach(var residency in residencyInfo)
                {
                    ep.ClickMetaballsMenu();
                    ep.ClickResidencyInfo();
                    ep.ProvideSecondName(residency.secondName);
                    ep.ProvidethirdName(residency.thirdName);
                    ep.ProvidefourthName(residency.fourthName);
                    ep.ProvidelastName(residency.lastName);
                    ep.ProvidebirthPlace(residency.birthPlace);
                    ep.ProvidedateOfEntry(residency.dateOfEntry);
                    ep.ProvideVisaNumber(residency.VisaNumber);
                    ep.ProvideWorkPermitNumber(residency.WorkPermitNumber);
                    ep.ProvideResidenceNumber(residency.ResidenceNumber);                    
                    ep.ClickContractQualification();
                    ep.SelectContractQualification(residency.ContractQualification);
                    ep.ClickNewResidencyPeriod();
                    ep.SelectNewResidencyPeriod(residency.NewResidencyPeriod);
                    ep.ClickNewGovtDesignation();
                    ep.SelectNewGovtDesignation(residency.NewGovtDesignation);
                    ep.ClickGovermenttLicense();
                    ep.SelectGovermenttLicense(residency.GovtLicense);
                    ep.ProvideNewContractSalary(residency.NewContractSalary);
                    ep.ScrollDownWebPageOldContract();
                    ep.ProvideOldContractSalary(residency.OldContractSalary);
                    ep.ProvideBlock(residency.Block);
                    ep.ProvideBuildingNumber(residency.BuildingNumber);
                    ep.ProvideFlatNumber(residency.FlatNumber);
                    ep.ProvideFloorNumber(residency.FloorNumber);
                    ep.ProvideLane(residency.Lane);
                    ep.ClickTypeOfBuilding();
                    ep.SelectTypeOfBuilding(residency.TypeOfBuilding);
                    ep.ProvideStreet(residency.Street);
                    ep.ProvideQasima(residency.Qasima);
                    ep.ProvideArea(residency.Area);
                    ep.ProvidePaciNumber(residency.PaciNumber);
                    ep.ProvidePreviousSponsorName(residency.PreviousSponsorName);
                    ep.ProvidePreviousCompanyAuthorizedSign(residency.PreviousCompanyAuthorizedSign);
                    ep.ProvidePreviousCompanyName(residency.PreviousCompanyName);
                    ep.ClickOldGovtDesignation(residency.OldGovtDesignation);
                    ep.SelectOldGovtDesignation(residency.OldFileNumber);
                    ep.ProvideOldGovernmentLicense(residency.OldGovernmentLicense);
                    //ep.SaveResidencyInfo();




                }
            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
