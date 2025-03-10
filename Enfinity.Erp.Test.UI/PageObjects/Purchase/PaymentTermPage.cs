using Bogus.DataSets;
using Enfinity.Common.Test;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Enfinity.Erp.Test.UI
{
    public class PaymentTermPage
    {
        private readonly IWebDriver _driver;
        public PaymentTermPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locators

        #region Payment Term Context Menu Locators 
        private By contextMenu = By.Id("MainMenu_DXI12_P");
        #endregion

        #region Payment Term Page Locators        
        private By dueDays = By.XPath("//input[contains(@id, 'DueDays_I')]");
        private By autoCustomer = By.Id("PaymentTerm.AutoInsertWhileCreatingCustomer_S_D");
        private By autoSupplier = By.Id("PaymentTerm.AutoInsertWhileCreatingSupplier_S_D");              
        private By link = By.XPath("//li//a[@class='form-title-link' and text()='Payment Term']");
        #endregion

        #endregion

        #region Action Methods

        #region Payment Term Contextmenu Action Methods
        public void clickOnContextMenu()
        {
            _driver.FindElement(contextMenu).Click();
            Thread.Sleep(500);
        }
        #endregion

        #region Payment Term Action Methods             
        public void ProvideDueDays(string data)
        {
            _driver.FindElement(dueDays).SendKeys(data);
        }
        public void ClickOnAutoInsertCustomer()
        {
            _driver.FindElement(autoCustomer).Click();
        }
        public void ClickOnAutoInsertSupplier()
        {
            _driver.FindElement(autoSupplier).Click();
        }
        public void ClickOnPaymentTerm()
        {
            _driver.FindElement(link).Click();
        }
        #endregion

        #endregion
    }
}
