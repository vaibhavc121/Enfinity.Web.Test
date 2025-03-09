using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.PageObjects.SelfService
{
    public class TravelRequestPage : BasePage
    {
        public TravelRequestPage(IWebDriver driver) : base(driver)
        {
        }

        #region page objects
        private By profileUpdate = By.XPath("//a[@id='TxnInstanceView_I0i19_T']//span[@class='dx-vam'][normalize-space()='Profile Update']");
        private By travelRequest = By.XPath("//span[normalize-space()='Travel Request']");
        private By fromDate = By.XPath("//input[@id='TravelRequest.FromDate_I']");
        private By uptoDate = By.XPath("//input[@id='TravelRequest.UptoDate_I']");
        private By category = By.XPath("//input[@id='TravelRequest.Category_I']");
        private By ToCountry = By.XPath("//input[@id='TravelRequest.ToCountryIdLookup_I']");
        private By city = By.XPath("//input[@id='TravelRequest.City_I']");
        private By hotelBookedByEmp = By.XPath("//span[@id='TravelRequest.HotelBookedByEmployee_S_D']//span[@class='dxSwitcher dx-not-acc']");
        private By ticketDestination = By.XPath("//input[@id='TravelRequest.TicketDestinationIdLookup_I']");
        private By ticketAmount = By.XPath("//input[@id='TravelRequest.TicketAmount_I']");
        private By purpose = By.XPath("//input[@id='TravelRequest.Purpose_I']");
        private By paymentType = By.XPath("//input[@id='TravelRequest.PaymentType_I']");
        private By remarks = By.XPath("//textarea[@id='TravelRequest.Description_I']");

        #endregion

        #region action methods
        public void ScrollDownWebpage()
        {
            CommonPageActions.ScrollDownWebPage(profileUpdate);
        }
        public void ClickTravelRequest()
        {
            Find(travelRequest).Click();
        }
        public void ClickNew()
        {
            CommonPageActions.ClickNew();
        }
        public void ProvideFromDate(string value)
        {
            CommonPageActions.ClearAndProvide1(fromDate, value);
        }
        public void ProvideUptoDate(string value)
        {
            CommonPageActions.ClearAndProvide1(uptoDate, value);
        }
        public void ClickCategoryDD()
        {
            Find(category).Click();
        }
        public void SelectCategory(string value)
        {
            CommonPageActions.SelectDropdownValueOffice365(value);
        }
        public void ProvideCategory(string value)
        {
            CommonPageActions.ClearAndProvide1(category, value);
        }
        public void ProvideToCountry(string value)
        {
            CommonPageActions.ClearAndProvide1(ToCountry, value);
        }
        public void ProvideCity(string value)
        {
            Find(city).SendKeys(value);
        }
        public void ClickHotelBookedByEmpBtn()
        {
            Find(hotelBookedByEmp).Click();
        }
        public void ProvideTicketDestination(string value)
        {
            CommonPageActions.ClearAndProvide1(ticketDestination, value);
        }
        public void ProvideTicketAmt(string value)
        {
            Find(ticketAmount).SendKeys(value);
        }
        public void ProvidePurpose(string value)
        {
            CommonPageActions.ClearAndProvide1(purpose, value);
        }
        public void ProvidePaymentType(string value)
        {
            CommonPageActions.ClearAndProvide1(paymentType, value);
        }
        public void ProvideRemarks(string value)
        {
            Find(remarks).SendKeys(value);
        }
        public void ClickSave()
        {
            CommonPageActions.ClickSaveAndBack();               
        }
        public bool IsTxnCreated(string emp, string country)
        {
            if (CommonPageActions.Result5().Contains(emp) && CommonPageActions.Result7().Contains(country))
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
