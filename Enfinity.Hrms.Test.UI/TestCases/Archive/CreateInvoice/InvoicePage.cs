//using Enfinity.Common.Test;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Enfinity.Erp.Test.UI.PageObjects.Sales
//{
//    public class InvoicePage : BasePage
//    {
//        public InvoicePage(IWebDriver driver) : base(driver)
//        {
//        }

//        #region page objects
//        private By sales = By.XPath("//span[normalize-space()='Sales']");
//        private By invoice = By.XPath("//span[normalize-space()='Invoice']");
//        private By customer = By.XPath("//input[contains(@id,'CustomerId')]");
//        private By item = By.XPath("//input[contains(@id,'ItemId')]");
//        //private By unitPrice = By.XPath("//span[normalize-space()='Unit Price']");
//        private By UOM = By.XPath("//span[normalize-space()='UOM']");
//        private By add = By.XPath("//span[normalize-space()='Add']");
//        private By unitPrice = By.XPath("//input[contains(@id,'UnitPrice')]");


//        #endregion

//        #region action methods
//        public void ClickSales()
//        {
//            Find(sales).Click();
//        }
//        public void ClickInvoice()
//        {
//            Find(invoice).Click();
//        }
//        public void ClickNew()
//        {
//            //BasePage.ClickNew();
//        }
//        public void ProvideCustomer(string value)
//        {
//            //BasePage.ProvideAndEnter(customer, value);
//        }
//        public void ProvideItem(string value)
//        {
//            //BasePage.ProvideAndEnter(item, value);
//        }
//        public void PressTabFourTimes()
//        {
//            Actions actions = new Actions(BaseTest._driver);
//            actions.SendKeys(Keys.Tab)
//                   .SendKeys(Keys.Tab)
//                   .SendKeys(Keys.Tab)
//                   .SendKeys(Keys.Tab)
//                   .Perform();
//        }
//        public void ScrollDownPage()
//        {
//            //BasePage.ScrollDownWebPage(UOM);
//        }
        
//        public void ClickAdd()
//        {
//            Find(add).Click();
//        }
//        public void ProvideUnitPrice(string value)
//        {
//            //BasePage.ClearAndProvideValue(unitPrice, value);
//        }
//        public bool CheckUnitPrice()
//        {
//            string price = Find(unitPrice).GetAttribute("aria-valuenow");
//            if (price.Equals("0"))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//        /*public void a()
//        {

//        }
//        public void a()
//        {

//        }
//        public void a()
//        {

//        }
//        public void a()
//        {

//        }
//        public void a()
//        {

//        }
//        public void a()
//        {

//        }*/
//        #endregion
//    }
//}
