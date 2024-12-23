using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Common.Test
{
    public static class CommonActions
    {
        public static WebDriver _driver;
        // Method to click on Save
        public static void clkSave()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Save']")).Click();
            _driver.Navigate().Back();
        }

        // Method to click on View
        public static void clkView()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='View']")).Click();
        }

        // Method to click on Approve and navigate back
        public static void clkApprove()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Approve']")).Click();
            _driver.Navigate().Back();
        }

        // Method to click on New
        public static void clkNew()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='New']")).Click();
        }

        // Method to set the dropdown value with a specific value
        public static void setDropdownValueEmp(string expectedValue)
        {
            // Find the list of dropdown elements
            IList<IWebElement> dropdownList = _driver.FindElements(By.XPath("//div[@class='dx-item dx-list-item']"));

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
        public static void setDropdownValue(string value)
        {
            while (true)
            {
                // Finding all the elements in the dropdown
                IList<IWebElement> valuesList = _driver.FindElements(By.XPath("//div[@class='grid-row-template']"));

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
                _driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-next-icon']")).Click();
                Thread.Sleep(3000);  // Wait for 3 seconds for next page to load
            }
        }

        // Method to set dropdown value for Office 365
        public static void setDropdownValueOffice365(string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = _driver.FindElements(By.XPath("//tr[@class='dxeListBoxItemRow_Office365']"));

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

        //written for employee listing
        public static string resultEmp()
        {
            string result = _driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]"))
                    .Text;
            return result;
        }

    }
}

