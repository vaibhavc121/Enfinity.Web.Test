﻿using Bogus.DataSets;
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
    public class PersonalTabTest: BaseTest
    {
        public string Product = "Hrms";
        //[Test]
        [Ignore("")]
        public void VerifyPersonalTab()
        {
            try
            {
                

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

                var employeeFile = FileUtils.GetDataFile("Hrms", "HRCore", "Employee", "EmployeeData");
                var personalInfo = JsonUtils.ConvertJsonListDataModel<PersonalTabModel>(employeeFile, "personal");

                //personal tab
                EmployeePage ep = new EmployeePage(_driver);
                foreach (var personal in personalInfo)
                {
                    ep.ProvideNameL2(personal.nameL2);
                    ep.ProvideDisplayName(personal.displayName);
                    ep.ProvideDisplayNameL2(personal.displayNameL2);
                    ep.ProvideDOB(personal.DOB);
                    //ep.ClickNationality();
                    //ep.SelectNationality(personal.nationality);
                    ep.ClickBloodGroup();
                    ep.SelectBloodGroup(personal.bloodGroup);
                    ep.ClickPhotoVisibility();
                    ep.SelectPhotoVisibility(personal.photoVisibility);
                    ep.ClickMblNoVisibility();
                    ep.SelectMblNoVisibility(personal.mobileNumberVisibility);
                    ep.ClickEmailVisibility();
                    ep.SelectEmailVisibility(personal.emailVisibility);
                    BasePage.ClickOnSave();
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
