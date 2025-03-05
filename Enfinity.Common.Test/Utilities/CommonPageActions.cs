using Enfinity.Common.Test;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class CommonPageActions
    {
        #region Common Action Methods for ERP
        public static void ClickOnHome()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Home']")).Click();
        }
        public static void ClickOnCustomer()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Customer']")).Click();
        }
        public static void ClickOnSupplier()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Supplier']")).Click();
        }
        public static void ClickOnItem()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Item']")).Click();
        }
        public static void ClickOnReports()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Reports']")).Click();
        }
        public static void ClickOnAnalytics()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Analytics']")).Click();
        }
        public static void ClickOnPeriodicProcess()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Periodic Process']")).Click();
        }
        public static void ClickOnSetups()
        {
            BaseTest._driver.FindElement(By.CssSelector("li[title='Setups']")).Click();
        }
        public static void ClickOnDelete()
        {
            BaseTest._driver.FindElement(By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Delete']")).Click();
            Thread.Sleep(1000);
        }
        public static void ClickOnOk()
        {
            BaseTest._driver.FindElement(By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Ok']")).Click();
            Thread.Sleep(1000);
        }
        public static void ClickOnCancel()
        {
            BaseTest._driver.FindElement(By.XPath("//span[contains(@class, 'dx-button-text') and normalize-space(text())='Cancel']")).Click();
        }
        public static void ClickOnNew()
        {
            BaseTest._driver.FindElement(By.XPath("//div//span[contains(@class, 'dx-vam') and text()='New']")).Click();
        }
        public static void ClickOnView()
        {
            BaseTest._driver.FindElement(By.XPath("//div//span[contains(@class, 'dx-vam') and text()='View']")).Click();
        }
        public static void ClickOnEdit()
        {
            BaseTest._driver.FindElement(By.XPath("//div//span[contains(@class, 'dx-vam') and text()='Edit']")).Click();
        }
        public static void ProvideNameOnListing(string name)
        {
            BaseTest._driver.FindElement(By.XPath("//input[@aria-describedby='dx-col-3']")).SendKeys(name);
            Thread.Sleep(2000);
        }
        public static void ClickOnSelectedName()
        {
            //_driver.FindElement(itemSelect).Click();
            IWebElement element = BaseTest._driver.FindElement(By.XPath("(//td[@aria-describedby='dx-col-3' and @role='gridcell' and @aria-colindex='2'])[2]"));
            ((IJavaScriptExecutor)BaseTest._driver).ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(1000);
        }
        public static void SelectDropDownOption(string option)
        {
            Thread.Sleep(1000);
            var options = BaseTest._driver.FindElements(By.CssSelector(".dx-item-content, .dx-list-item-content"));

            foreach (var valueElement in options)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(option))
                {
                    valueElement.Click();
                    //Thread.Sleep(1000);
                    return;
                }
            }
        }
        public static void ValidateSucess(string expectedMessage)
        {
            IWebElement element = BaseTest._driver.FindElement(By.ClassName("dx-toast-success"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
        }
        public static void Validate(string expectedMessage)
        {
            IWebElement element = BaseTest._driver.FindElement(By.ClassName("dx-toast-message"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
        }
        public static void ValidateSummary(string expectedMessage)
        {
            IWebElement element = BaseTest._driver.FindElement(By.Id("ValidationSummary"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
        }
        public static void ClearAndProvideValue(By locator, string value)
        {
            var element = BaseTest._driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(BaseTest._driver);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            element.SendKeys(value);
        }
        #endregion

        #region ERP Documents Action Methods         
        public static void clickOnDocumentType()
        {
            BaseTest._driver.FindElement(By.XPath("(//input[contains(@id, 'DocumentTypeId')])")).Click();
        }
        public static void provideDocumentNumber(string documentnum)
        {
            //_driver.FindElement(documentNumber).SendKeys(documentnum);
            ClearAndProvide(By.XPath("(//input[contains(@id, 'DocumentNumber')])"), documentnum);
        }
        public static void provideDateOfIssue(string date)
        {
            BaseTest._driver.FindElement(By.XPath("(//input[contains(@id, 'DateOfIssue')])")).SendKeys(date);
        }
        public static void provideDateOfExpiry(string date)
        {
            BaseTest._driver.FindElement(By.XPath("(//input[contains(@id, 'DateOfExpiry')])")).SendKeys(date);
        }
        public static void providePlaceOfIssue(string place)
        {
            BaseTest._driver.FindElement(By.XPath("(//input[contains(@id, 'PlaceOfIssue')])")).SendKeys(place);
        }
        public static void clickSaveDocument()
        {
            BaseTest._driver.FindElement(By.XPath("(//span[normalize-space()='Save'])[2]")).Click();
        }
        #endregion

        #region ERP Module related Action Methods
        public static void ClickOnAccountingModule()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Accounting']")).Click();
        }
        public static void ClickOnSalesModule()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Sales']")).Click();
        }
        public static void ClickOnPurchaseModule()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Purchase']")).Click();
        }
        public static void ClickOnInventoryModule()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Inventory']")).Click();
        }
        #endregion

        #region listing filter result (Absolute xpath)
        public static String Result5()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[5]")).Text;
            return result;
        }
        public static string Result6()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[6]"))
                .Text;
            return result;
        }

        public static string Result7()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[7]"))
                .Text;
            return result;
        }

        public static string Result8()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[8]/div[1]/div[1]"))
                .Text;
            return result;
        }

        public static string Result9()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[9]"))
                .Text;
            return result;
        }

        public static string Result10()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[10]/span[1]/a[1]"))
                .Text;
            return result;
        }


        #endregion

        #region listing filter result (Relative xpath)
        public static String Result55()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                    "(//td[@aria-describedby='dx-col-4' and @role='gridcell' and @aria-colindex='1'])[2]")).Text;
            return result;
        }
        public static string Result66()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-9' and @role='gridcell' and @aria-colindex='2'])[2]"))
                .Text;
            return result;
        }

        public static string Result77()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-10' and @role='gridcell' and @aria-colindex='3'])[2]"))
                .Text;
            return result;
        }

        public static string Result88()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-19' and @role='gridcell' and @aria-colindex='4'])[2]"))
                .Text;
            return result;
        }

        public static string Result99()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-38' and @role='gridcell' and @aria-colindex='5'])[2]"))
                .Text;
            return result;
        }

        public static string Result100()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-47' and @role='gridcell' and @aria-colindex='6'])[2]"))
                .Text;
            return result;
        }
        #endregion
        // Method to click on Save
        public static void ClickSave()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Save']")).Click();
        }
        public static void ClickSaveAndBack()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Save']")).Click();
            BaseTest._driver.Navigate().Back();
        }

        // Method to click on View
        public static void ClickView()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='View']")).Click();
        }

        // Method to click on Approve and navigate back
        public static void ClickApprove()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='Approve']")).Click();
            BaseTest._driver.Navigate().Back();
        }

        // Method to click on New
        public static void ClickNew()
        {
            BaseTest._driver.FindElement(By.XPath("//span[normalize-space()='New']")).Click();
        }

        // Method to set the dropdown value with a specific value
        public static void SelectDropdownOption(string expectedValue)
        {
            // Find the list of dropdown elements
            IList<IWebElement> dropdownList = BaseTest._driver.FindElements(By.XPath("//div[@class='dx-item dx-list-item']"));

            // Loop through each dropdown element
            foreach (var dropdownElement in dropdownList)
            {
                string actualValue = dropdownElement.Text;

                // If the dropdown name matches the desired one, click it
                if (actualValue.Contains(expectedValue))
                {
                    dropdownElement.Click();
                    break;
                }
            }
        }

        // Method to set the dropdown value with a specific value
        public static void SelectDropdownValue(string value)
        {
            while (true)
            {
                // Finding all the elements in the dropdown
                IList<IWebElement> valuesList = BaseTest._driver.FindElements(By.XPath("//div[@class='grid-row-template']"));

                foreach (var valueElement in valuesList)
                {
                    string actualValue = valueElement.Text;
                    if (actualValue.Contains(value))
                    {
                        valueElement.Click();
                        return;
                    }
                }

                // Click on the next icon to load more items in the dropdown
                BaseTest._driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-next-icon']")).Click();
                Thread.Sleep(3000);  // Wait for 3 seconds for next page to load
            }
        }

        // Method to set dropdown value for Office 365
        public static void SelectDropdownValueOffice365(string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = BaseTest._driver.FindElements(By.XPath("//tr[@class='dxeListBoxItemRow_Office365']"));

            foreach (var valueElement in valuesList)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(value))
                {
                    valueElement.Click();
                    break;
                }
            }
        }
        public static bool IsValuePresent(By locator, string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = BaseTest._driver.FindElements(locator);

            foreach (var valueElement in valuesList)
            {
                string actualValue = valueElement.Text;
                if (actualValue.Contains(value))
                {
                    return true;                    
                }
            }
            return false;
        }

        #region Common Actions for HRMS
        //written for employee listing

        public static void FilterEmployee(string value)
        {
            BaseTest._driver.FindElement(By.Id("//input[@aria-describedby='dx-col-4']")).SendKeys(value);
        }
        public static string ResultEmployee()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]"))
                    .Text;
            return result;
        }

        public static string Result()
        {
            string result = BaseTest._driver.FindElement(By.XPath(
                    "//td[@class='list-hyperlink dx-cell-focus-disabled']"))
                    .Text;
            return result;
        }
        public static void ClickResult(string value)
        {
            IWebElement employee = BaseTest._driver.FindElement(By.XPath(
                    "//td[@class='list-hyperlink dx-cell-focus-disabled']"));
            string result = employee.Text;

            if (result.Contains(value))
            {
                employee.Click();
            }
        }

        public static void NavigateToEmployee(string value)
        {
            BaseTest._driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[6]/div[1]/table[1]/tbody[1]/tr[2]/td[1]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]")).SendKeys(value);
            Thread.Sleep(2000);
            IWebElement result = BaseTest._driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]"));

            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest._driver;

            //filterCell.SendKeys(value);
            Thread.Sleep(2000);
            string employee = result.Text;
            Thread.Sleep(2000);
            if (employee.Contains(value))
            {
                result.Click();
                //jsExecutor.ExecuteScript("arguments[0].click();", result);
                Thread.Sleep(2000);
            }

        }

        public static void SwitchTab()
        {
            string originalWindow = BaseTest._driver.CurrentWindowHandle;
            // Get all window handles
            var allWindows = BaseTest._driver.WindowHandles;
            // Iterate through the window handles
            foreach (var windowHandle in allWindows)
            {
                if (windowHandle != originalWindow)
                {
                    // Switch to the new window
                    BaseTest._driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }

        public static void CloseTab()
        {
            string originalWindow = BaseTest._driver.CurrentWindowHandle;
            // Get all window handles
            var allWindows = BaseTest._driver.WindowHandles;
            // Iterate through the window handles
            foreach (var windowHandle in allWindows)
            {
                if (windowHandle != originalWindow)
                {
                    // Switch to the new window
                    BaseTest._driver.SwitchTo().Window(windowHandle);
                    BaseTest._driver.Close();
                    break;
                }
            }
        }

        #endregion



        public static bool IsTxnCreated()
        {
            string message = BaseTest._driver.FindElement(By.XPath("//div[@class='dx-toast-message']")).Text;
            //return message;            
            if (message.Contains("created successfully"))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public static bool IsEmployeeDeleted()
        {
            string message = BaseTest._driver.FindElement(By.XPath("//div[@class='dx-toast-message']")).Text;
            //return message;
            if (message.Contains("deleted successfully"))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public static void ScrollDownWebPageSample()
        {
            //Cast driver to IJavaScriptExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest._driver;

            // Scroll down by a specific number of pixels
            //jsExecutor.ExecuteScript("window.scrollBy(0, 50);");
            //Thread.Sleep(2000);

            // Scroll to the bottom of the page
            //jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //If you want to scroll to a specific element, you can use:
            //IWebElement element = driver.FindElement(By.Id("elementId"));
            //jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Initialize Actions class
            //Actions actions = new Actions(BaseTest._driver);

            // Perform Page Down key press
            //actions.SendKeys(Keys.PageDown).Perform();

            // Wait for a few seconds to see the scroll effect
            //System.Threading.Thread.Sleep(2000);

            // Perform multiple Arrow Down key presses
            //actions.SendKeys(Keys.ArrowDown).Perform();
            //actions.SendKeys(Keys.ArrowDown).Perform();

            // Wait for a few seconds to see the scroll effect
            //System.Threading.Thread.Sleep(2000);

            IWebElement element = BaseTest._driver.FindElement(By.XPath("//input[contains(@id,'OldContractSalary')]"));             
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ClearAndProvide(By locator, string value)
        {
            BaseTest._driver.FindElement(locator).Click();
            BaseTest._driver.FindElement(locator).Clear();
            BaseTest._driver.FindElement(locator).SendKeys(value);

        }
        public static void ClearAndProvide1(By locator, string value)
        {
            var element = BaseTest._driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(BaseTest._driver);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            element.SendKeys(value);
        }
        public static void ProvideAndEnter(By locator, string value)
        {
            var element = BaseTest._driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(BaseTest._driver);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            element.SendKeys(value);
            Thread.Sleep(2000);

            element.SendKeys(Keys.Enter);
        }

        public static void ScrollDownWebPage(By locator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest._driver;
            IWebElement element = BaseTest._driver.FindElement(locator);
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void ProvideValue(By locator, string value)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest._driver;
            IWebElement element = BaseTest._driver.FindElement(locator);
            //js.ExecuteScript("arguments[0].value='Test Value';", inputField);
            jsExecutor.ExecuteScript($"arguments[0].value='{value}';", element);
        }

        public static void ClickNewLine()
        {
            BaseTest._driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-new-icon']")).Click();
        }

        public static void HoverAndClick(By locator, By locator1)
        {

            IWebElement elementToHover = BaseTest._driver.FindElement(locator);
            Actions actions = new Actions(BaseTest._driver);
            actions.MoveToElement(elementToHover).Perform();
            BaseTest._driver.FindElement(locator1).Click();
            //Find(deleteBasicSalBtn).Click();
            //Thread.Sleep(2000);
            //Find(deleteBasicSalaryComponent).Click();
        }

        public static void PressTab()
        {
            Actions actions = new Actions(BaseTest._driver);             
            actions.SendKeys(Keys.Tab).Perform();
        }
    }
}

