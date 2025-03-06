using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SuccessionPlanning
{
    public class SuccessionPlanPage : BasePage
    {
        public SuccessionPlanPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects

        #endregion

        #region action methods
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        #endregion
    }
}
