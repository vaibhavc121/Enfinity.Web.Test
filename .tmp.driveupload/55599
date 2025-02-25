using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class TimeOffPage : BasePage
    {
        public TimeOffPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By permissionDate = By.Id("LatePermission.LateDate_I");
        private By permissionType = By.XPath("//input[@id='LatePermission.PermissionType_I']");
        private By fromTime = By.XPath("//input[@id='LatePermission.FromTime_I']");
        //private By uptoTime = By.XPath("//input[@id='LatePermission.UptoTime_I']");
        //private By uptoTime = By.XPath("/html[1]/body[1]/div[6]/div[2]/form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[1]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/input[1]");
        private By uptoTime = By.Name("LatePermission.UptoTime");

        private By timeOff = By.XPath("//a[@id='TxnInstanceView_I0i3_T']//span[@class='dx-vam'][normalize-space()='Time Sheet Entry']//following::span[@class='dx-vam'][normalize-space()='Time Off']");
        #endregion

        #region action methods
        public void ClickTimeOff()
        {
            Find(timeOff).Click();
        }
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }

        public void ProvidePermissonDate(string value)
        {
            CommonPageActions.ClearAndProvide(permissionDate, value);

        }

        public void ClickPermissionTypeDD()
        {
            Find(permissionType).Click();
        }

        public void SelectPermissionType(string value)
        {
            CommonPageActions.SelectDropdownValueOffice365(value);
        }

        public void ProvideFromTime(string value)
        {
            CommonPageActions.ClearAndProvide1(fromTime, value);
        }

        public void ProvideUptoTime(string value)
        {
            CommonPageActions.ClearAndProvide1(uptoTime, value);
        }

        public void ClickSave()
        {
            CommonPageActions.ClickSaveAndBack();
        }
       

        public bool IsTxnCreated(string value)
        {            
            if(CommonPageActions.Result7().Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        #endregion


    }
}
