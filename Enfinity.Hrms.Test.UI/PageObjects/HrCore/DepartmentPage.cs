using Bogus;
using Bogus.DataSets;
using Enfinity.Common.Test;
using Enfinity.Hrms.Test.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class DepartmentPage : BasePage
    {
        public DepartmentPage(IWebDriver driver) : base(driver)
        {
        }
        
        By deptName = By.XPath("//input[@id='Department.Name_I']");
        By selfService = By.XPath("//img[@id='EmployeeSelfService_CBImg']");
        By deptMgrDD = By.XPath("//img[@id='Department.ManagerEmployeeIdLookup_B-1Img']");
        By deptMgrName = By.XPath("//div[@class='lookup-text']");
        By save = By.XPath("//span[normalize-space()='Save']");
        By filterCell = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[5]/div[1]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");
        By result = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/span[1]/a[1]");
        
        

        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }

        public string deptNm = BasePage.RandomString();
        public void ProvideDepartmentName(string value)
        {            
            Find(deptName).SendKeys(value);               
        }

        public void SelfServiceDD()
        {
            Find(selfService).Click();
        }

        public void ClickDeptMgrDD()
        {
            Find(deptMgrDD).Click();
        }

        public void SelectDeptMgrName()
        {
            //Find(deptMgrDD).SendKeys("vaibhav chavan");
            CommonPageActions.SelectDropdownValue("Mary Kom");
        }

        public void SelectDeptMgr()
        {
            Find(deptMgrName).Click();
        }

        public void ClickSaveBack()
        {
            CommonPageActions.ClickSaveAndBack();
            //Find(save).Click();
        }       

        public bool IsDeptCreated()
        {
            if (CommonPageActions.ResultValue(2).Contains(deptNm))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}
    
