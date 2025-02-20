﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Calendar;
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
    public class CreateReligionTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyReligionCreation()
        {
            try
            {
                Login(Product);

                var ReligionFile = FileHelper.GetDataFile("Hrms", "HRCore", "Religion", "ReligionData");
                var ReligionData = JsonHelper.ConvertJsonListDataModel<ReligionModel>(ReligionFile, "createReligion");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickReligion();
                Thread.Sleep(2000);

                //religion page                
                ReligionPage rp = new ReligionPage(_driver);
                foreach(var religion in ReligionData)
                {
                    rp.ClickNew();
                    //rp.ProvideReligionName(religion.religionName);
                    rp.ProvideReligionName();
                    rp.ClickSave();
                }
                ClassicAssert.IsTrue(CommonPageActions.IsTxnCreated());

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }

    }
}
