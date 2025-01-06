using Enfinity.Common.Test;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class CommonPageActions
    {
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
                if (actualValue.Equals(expectedValue))
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
                    
            if(result.Contains(value))
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

            //filterCell.SendKeys(value);
            Thread.Sleep(2000);           
            string employee = result.Text;
            Thread.Sleep(2000);
            if (employee.Contains(value))
            {
                result.Click();
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

        public static void ScrollDownWebPage()
        {
            // Cast driver to IJavaScriptExecutor
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)BaseTest._driver;

            // Scroll down by a specific number of pixels
            //jsExecutor.ExecuteScript("window.scrollBy(0, 50);");
            //Thread.Sleep(2000);

            // Scroll to the bottom of the page
            //jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //If you want to scroll to a specific element, you can use:
            //IWebElement element = driver.FindElement(By.Id("elementId"));
            //jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Initialize Actions class
            Actions actions = new Actions(BaseTest._driver);

            // Perform Page Down key press
            actions.SendKeys(Keys.PageDown).Perform();

            // Wait for a few seconds to see the scroll effect
            System.Threading.Thread.Sleep(2000);

            // Perform multiple Arrow Down key presses
            actions.SendKeys(Keys.ArrowDown).Perform();
            actions.SendKeys(Keys.ArrowDown).Perform();

            // Wait for a few seconds to see the scroll effect
            System.Threading.Thread.Sleep(2000);
        }

    }
}

