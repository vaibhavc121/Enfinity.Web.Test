using Enfinity.Hrms.Test.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class SetupPage: BasePage
    {
        public SetupPage(IWebDriver driver) : base(driver)
        {
        }

        // Locators
        private readonly By Employee = By.XPath("//a[@class='dxnb-link']//span[@class='dx-vam'][normalize-space()='Employee']");
        By department = By.XPath("//span[text()='Department']");
        By designation = By.XPath("//span[normalize-space()='Designation']");
        By grade = By.XPath("//span[normalize-space()='Grade']");
        By calendar = By.XPath("//span[normalize-space()='Calendar']");
        By religion = By.XPath("//span[normalize-space()='Religion']");
        By workLocation = By.XPath("//span[normalize-space()='Work Location']");
        By bank = By.XPath("//span[normalize-space()='Bank']");
        By qualification = By.XPath("//span[normalize-space()='Qualification']");
        By documentType = By.XPath("//span[normalize-space()='Document Type']");
        By assetIssue = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[5]/ul[1]/li[1]/ul[1]/li[4]/span[1]");
        By delegation = By.XPath("//span[@class='dx-vam'][normalize-space()='Delegation']");
        By license = By.XPath("//span[normalize-space()='License']");
        



        public void ClickEmployee()
        {
            _driver.FindElement(Employee).Click();
        }

        public void ClickDepartment()
        {
            Find(department).Click();
        }
        public void ClickDesignation()
        {
            Find(designation).Click();
        }
        public void ClickGrade()
        {
            Find(grade).Click();
        }
        public void ClickCalendar()
        {
             Find(calendar).Click();
        }
        public void ClickReligion()
        {
             Find(religion).Click();
        }
        public void ClickWorkLocation()
        {
             Find(workLocation).Click();
        }
        public void ClickBank()
        {
             Find(bank).Click();
        }
        public void ClickQualification()
        {
              Find(qualification).Click();
        }
        public void ClickDocumentType()
        {
            Find(documentType).Click();
        }
        public void ClickAssetIssue()
        {
            Find(assetIssue).Click();
        }
        public void ClickDelegation()
        {
             Find(delegation).Click();
        }
        public void ClickLicense()
        {
            Find(license).Click();
        }
    }
}
