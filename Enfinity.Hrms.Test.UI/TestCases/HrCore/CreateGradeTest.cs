﻿using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Employee;
using Enfinity.Hrms.Test.UI.Models.HRCore.Grade;
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
    public class CreateGradeTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyGradeCreation()
        {
            try
            {
                Login(Product);

                var gradeFile = FileHelper.GetDataFile("Hrms", "HRCore", "Grade", "GradeData");
                var gradeData = JsonHelper.ConvertJsonListDataModel<GradeModel>(gradeFile, "createGrade");

                //hr core page
                HRCorePage hc = new HRCorePage(_driver);
                Thread.Sleep(5000);
                hc.ClickHRCore();
                hc.ClickSetupForm();

                //setup page
                SetupPage sp = new SetupPage(_driver);
                sp.ClickGrade();
                Thread.Sleep(2000);

                //grade pg
                GradePage gp = new GradePage(_driver);

                foreach(var grade in gradeData)
                {
                    gp.ClickNew();
                    gp.ProvideGradeName();
                    gp.ProvideMinSal(grade.minSal);
                    gp.ProvideMaxSal(grade.maxSal);
                    gp.ClickSave();
                }


            }
            catch (Exception e)
            {
                ClassicAssert.Fail("Test case failed: " + e);
            }
        }
    }
}
