﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore;
using Enfinity.Hrms.Test.UI.Models.HRCore.Religion;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
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
    public class CreateWorkLocationTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyWorkLocationCreation()
        {
            try
            {
                Login(Product);

                var workLocationFile = FileHelper.GetDataFile("Hrms", "HRCore", "WorkLocation", "WorkLocationData");
                var workLocationData = JsonHelper.ConvertJsonListDataModel<WorkLocationModel>(workLocationFile, "createWorkLocation");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickWorkLocation();
                Thread.Sleep(2000);

                //worklocation page                
                WorkLocationPage wl = new WorkLocationPage(_driver);
                foreach(var workLocation in workLocationData)
                {
                    wl.ClickNew();
                    //wl.ProvideWorkLocName(workLocation.workLocationName);
                    wl.ProvideWorkLocName();
                    wl.ClickSave();                    
                }
                ClassicAssert.IsTrue(wl.IsTxnCreated());


            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
