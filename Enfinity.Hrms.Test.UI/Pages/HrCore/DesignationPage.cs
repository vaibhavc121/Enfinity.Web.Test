
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.HrCore
{
    public class DesignationPage : BasePage
    {
        public DesignationPage(IWebDriver driver) : base(driver)
        {
        }
       
        By newBtnCss = By.CssSelector("#MainMenu_DXI0_Img");
        By newBtnXpath = By.XPath("//span[normalize-space()='New']");
        By code = By.Name("Code");
        By desgName = By.Name("Name");
        By clickGrade = By.XPath("//input[contains(@id,'GradeId')]");
        By selectGrade = By.XPath("//div[contains(text(),'Contributor')]");
        By jobDescription = By.XPath("//div[@aria-label='Editor content']");
        By save = By.XPath("//span[normalize-space()='Save']");
        By filterCell = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[5]/div[1]/table[1]/tbody[1]/tr[2]/td[2]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]");
        By result = By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[2]/span[1]/a[1]");        

        public void ClickNewButton()
        {
            ClickOnNew();
        }
        
        public void SetDesignationCode()            
        {
            Find(code).SendKeys(RandomNumber());
        }

        public void SetDesignation(string value)
        {
            Find(desgName).SendKeys(value);
        }

        public void ClickGrade()
        {
            Find(clickGrade).Click();
        }

        public void SelectGrade()
        {
            Find(selectGrade).Click();
        }

        public void SetJobDescription()
        {
            Find(jobDescription).SendKeys(RandomString());
        }

        public void ClickSaveBack()
        {
            ClickSaveAndBack();
        }



    }
}
