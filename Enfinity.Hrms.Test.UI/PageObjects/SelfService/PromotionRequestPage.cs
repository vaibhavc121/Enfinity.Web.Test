using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class PromotionRequestPage : BasePage
    {
        public PromotionRequestPage(IWebDriver driver) : base(driver)
        {
        }
        #region page objects
        private By profileUpdate = By.XPath("//a[@id='TxnInstanceView_I0i19_T']//span[@class='dx-vam'][normalize-space()='Profile Update']");
        private By promotionRequest = By.XPath("//a[@id='TxnInstanceView_I0i16_T']//span[@class='dx-vam'][normalize-space()='Promotion Request']");
        private By txnDate = By.XPath("//input[@id='EmployeePromotionRequest.TxnDate_I']");
        private By effectiveDate = By.XPath("//input[@id='EmployeePromotionRequest.EffectiveDate_I']");
        private By type = By.XPath("//input[@id='EmployeePromotionRequest.Type_I']");
        private By newDepartment = By.XPath("//input[@id='EmployeePromotionRequest.NewDepartmentIdLookup_I']");
        private By newDesignation = By.XPath("//input[@id='EmployeePromotionRequest.NewDesignationIdLookup_I']");
        private By newWorkLocation = By.XPath("//input[@id='EmployeePromotionRequest.NewWorkLocationIdLookup_I']");
        private By newProject = By.XPath("//input[@id='EmployeePromotionRequest.NewProjectIdLookup_I']");
        private By description = By.XPath("//textarea[@id='EmployeePromotionRequest.Description_I']");
        private By salariesSection = By.XPath("//img[@id='Line_CBImg']");
        //salaries section
        private By salaryComponent = By.XPath("//input[@id='EmployeePromotionRequestLine_SalaryComponentId_I']");
        private By incrementAmount = By.XPath("(//div[@class='dxgBCTC dx-ellipsis'][normalize-space()='0'])[2]");
        private By effectiveFromDate = By.XPath("/html[1]/body[1]/div[5]/div[2]/form[1]/div[1]/div[1]/div[3]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/table[1]/tbody[1]/tr[5]/td[6]/div[1]");
        private By effectiveToDate = By.XPath("/html[1]/body[1]/div[5]/div[2]/form[1]/div[1]/div[1]/div[3]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/table[1]/tbody[1]/tr[5]/td[7]/div[1]");

        #endregion

        #region action methods
        public void ScrollDownWebpage()
        {
            CommonPageActions.ScrollDownWebPage(profileUpdate);
        }
        public void ClickPromotionRequest()
        {
            Find(promotionRequest).Click();
        }
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideTxnDate(string value)
        {
            CommonPageActions.ClearAndProvide1(txnDate, value);
        }
        public void ProvideEffectiveDate(string value)
        {
            CommonPageActions.ClearAndProvide1(effectiveDate, value);
        }
        public void ProvideType(string value)
        {
            CommonPageActions.ClearAndProvide1(type, value);
        }
        public void ProvideNewDepartment(string value)
        {
            CommonPageActions.ClearAndProvide1(newDepartment, value);
        }
        public void ProvideNewDesignation(string value)
        {
            CommonPageActions.ClearAndProvide1(newDesignation, value);
        }
        public void ProvideNewWorkLocation(string value)
        {
            CommonPageActions.ClearAndProvide1(newWorkLocation, value);
        }
        public void ProvideNewProject(string value)
        {
            CommonPageActions.ClearAndProvide1(newProject, value);
        }
        public void ProvideDescription(string value)
        {
            CommonPageActions.ClearAndProvide1(description, value);
        }
        public void ClickSalariesSection()
        {
            Find(salariesSection).Click();
        }
        public void ClickSave()
        {
            CommonPageActions.ClickSave();
        }
        public void ClickPlusBtn()
        {
            CommonPageActions.ClickNewLine();
        }
        public void ProvideSalaryComponent(string value)
        {
            CommonPageActions.ClearAndProvide1(salaryComponent, value);
        }
        public void ProvideIncrementAmount(string value)
        {
            //CommonPageActions.ClearAndProvide1(incrementAmount, value);
            CommonPageActions.ClearAndProvide(incrementAmount, value);
        }
        public void ProvideEffectiveFromDate(string value)
        {
            CommonPageActions.ClearAndProvide1(effectiveFromDate, value);
        }
        public void ProvideEffectiveToDate(string value)
        {
            CommonPageActions.ClearAndProvide1(effectiveToDate,value);
        }
        #endregion

    }
}
