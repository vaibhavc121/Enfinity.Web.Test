﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Pages.Global
{
    public class NotificationPage : BasePage
    {
        public NotificationPage(IWebDriver _driver) : base(_driver)
        {
        }

        #region Locators
        private By bellIcon = By.XPath("//i[@class='dx-icon bell-icon white-color-icon']");
        private By notificationSection = By.XPath("(//div[@class='dx-item-content dx-list-item-content'])[1]");      
        private By settingIcon = By.XPath("//i[@class='dx-icon dx-icon-ellipsis-icon']");
        private By open = By.XPath("//span[normalize-space()='Open']");

        #endregion

        #region Action Methods
        public void ClickBellIcon()
        {
            Find(bellIcon).Click();
        }
        public void IsLeaveDataCorrect(string expEmpName, string status)
        {
            string notificationData= driver.FindElement(By.XPath("//p[normalize-space()='002-Rohit Chavan']")).Text;
            if(notificationData.Contains(expEmpName))
            {
                Find(settingIcon).Click();
                Find(open).Click();
                BasePage.SwitchTab();

                switch (status)
                {
                    case "Approve":
                        BasePage.ClickApprove();
                        break;
                    case "Revise":
                        BasePage.ClickRevise();
                        break;
                    case "Reject":
                        BasePage.ClickReject();
                        break;
                    default:
                        throw new ArgumentException($"Invalid leave status: {status}");
                }

                BasePage.AcceptAlert(driver);
                //BasePage.CloseCurrentTab();
                //BasePage.CloseTab();                
            }
            else
            {
                throw new Exception("Leave data is not correct");
            }
        }
        //public void a()
        //{

        //}
        //public void a()
        //{

        //}
        //public void a()
        //{

        //}
        //public void a()
        //{

        //}
        #endregion
    }
}
