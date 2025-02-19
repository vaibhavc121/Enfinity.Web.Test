using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI.Models.HRCore.Bank;
using Enfinity.Hrms.Test.UI.Models.SelfService.TimeOff;
using Enfinity.Hrms.Test.UI.PageObjects.HrCore;
using Enfinity.Hrms.Test.UI.PageObjects.SelfService;
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
    public class CreateTimeOffTest:BaseTest
    {
        public string Product = "Hrms";

        [Test]
        public void VerifyTimeOffCreation()
        {
            try
            {
                Login(Product);

                var timeOffFile = FileHelper.GetDataFile("Hrms", "SelfService", "TimeOff", "TimeOffData");
                var timeOffData = JsonHelper.ConvertJsonListDataModel<TimeOffModel>(timeOffFile, "createTimeOff");

                //self service page
                SelfServicePage ss = new SelfServicePage(_driver);
                ss.ClickSelfService();
                ss.ClickTransactions();

                //time off page                
                TimeOffPage to = new TimeOffPage(_driver);

                foreach (var timeOff in timeOffData)
                {
                    to.ClickTimeOff();
                    to.ClickNew();
                    to.ProvidePermissonDate(timeOff.permisionDate);
                    to.ClickPermissionTypeDD();
                    to.SelectPermissionType(timeOff.permissionType);
                    to.ProvideFromTime(timeOff.fromTime);
                    to.ProvideUptoTime(timeOff.upToTime);
                    to.ClickSave();
                }               

                ClassicAssert.IsTrue(to.IsTxnCreated("60"));

            }
            catch (Exception e)
            {

                ClassicAssert.Fail("Test case failed: " + e);

            }
        }
    }
}
