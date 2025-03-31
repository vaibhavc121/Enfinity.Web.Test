using Bogus;
using Enfinity.Hrms.Test.UI.Base;
using Enfinity.Hrms.Test.UI.Utilities;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
     public class BasePage
    {
        public static IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Find(By locator) => _driver.FindElement(locator);

        #region For fake data generation
        public Faker faker = new Faker();
        #endregion

        #region For Random data generation
        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Range(0, 6).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        public static string RandomNumber()
        {
            const string digits = "0123456789";
            return new string(Enumerable.Range(0, 4).Select(_ => digits[random.Next(digits.Length)]).ToArray());
        }

        public static string RandomAlphaNumeric()
        {
            const string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, 10).Select(_ => alphanumericChars[random.Next(alphanumericChars.Length)]).ToArray());
        }

        public static string RandomEmail()
        {
            string generatedString = RandomString();
            string generatedNumber = RandomNumber();
            return $"{generatedString}{generatedNumber}@gmail.com";
        }

        public static string RandomMblNum()
        {
            const string digits = "0123456789";
            return new string(Enumerable.Range(0, 10).Select(_ => digits[random.Next(digits.Length)]).ToArray());
        }

        #endregion

        #region Listing filter result (Absolute xpath)
        public static String Result5()
        {
            string result = _driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[5]")).Text;
            return result;
        }
        public static string Result6()
        {
            string result = _driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[6]"))
                .Text;
            return result;
        }

        public static string Result7()
        {
            string result = _driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[7]"))
                .Text;
            return result;
        }

        public static string Result8()
        {
            string result = _driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[8]/div[1]/div[1]"))
                .Text;
            return result;
        }

        public static string Result9()
        {
            string result = _driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[9]"))
                .Text;
            return result;
        }

        public static string Result10()
        {
            string result = _driver.FindElement(By.XPath(
                "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[10]/span[1]/a[1]"))
                .Text;
            return result;
        }


        #endregion

        #region Listing Filters (Relative xpath)

        //I expect the index to change dynamically
        public static void FilterByIndex(int ColumnIndex, string value)
        {
            string xpath = $"(//input[@class='dx-texteditor-input'])[{ColumnIndex}]";
            _driver.FindElement(By.XPath(xpath)).Clear();
            _driver.FindElement(By.XPath(xpath)).SendKeys(value);
        }
        //other approach
        public static void FilterValue(int columnIndex, string value)
        {
            string xpath = $"(//tbody//tr)[11]//td[{columnIndex}]";
            _driver.FindElement(By.XPath(xpath)).SendKeys(value);
        }
        public static void filter1(string value)
        {
            _driver.FindElement(By.XPath(
                    "(//input[@class='dx-texteditor-input'])[1]")).SendKeys(value);

        }
        public static void filter2(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[2]"))
                .SendKeys(value);

        }

        public static void filter3(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[3]"))
                .SendKeys(value);

        }

        public static void filter4(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[4]"))
                .SendKeys(value);

        }

        public static void filter5(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[5]"))
                .SendKeys(value);

        }

        public static void filter6(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[6]"))
                .SendKeys(value);

        }
        public static void filter7(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[7]"))
                .SendKeys(value);

        }
        public static void filter8(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[8]"))
                .SendKeys(value);

        }
        public static void filter9(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[9]"))
                .SendKeys(value);

        }
        public static void filter10(string value)
        {
            _driver.FindElement(By.XPath(
                "(//input[@class='dx-texteditor-input'])[10]"))
               .SendKeys(value);

        }
        #endregion

        #region Listing result (Relative xpath)
        public static void SelectRow()
        {
            _driver.FindElement(By.XPath("(//tr)[12]//td[2]")).Click();
        }
        public static string ResultValue(int columnIndex)
        {
            //string result = _driver.FindElement(By.XPath("(//tbody//tr)[12]//td[2]")).Text;
            //return result;
            string xpath = $"(//tbody//tr)[12]//td[{columnIndex}]";
            string result = _driver.FindElement(By.XPath(xpath)).Text;
            return result;
        }
        public static String Result55()
        {
            string result = _driver.FindElement(By.XPath(
                    "(//td[@aria-describedby='dx-col-4' and @role='gridcell' and @aria-colindex='1'])[2]")).Text;
            return result;
        }
        public static string Result66()
        {
            string result = _driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-9' and @role='gridcell' and @aria-colindex='2'])[2]"))
                .Text;
            return result;
        }

        public static string Result77()
        {
            string result = _driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-10' and @role='gridcell' and @aria-colindex='3'])[2]"))
                .Text;
            return result;
        }

        public static string Result88()
        {
            string result = _driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-19' and @role='gridcell' and @aria-colindex='4'])[2]"))
                .Text;
            return result;
        }

        public static string Result99()
        {
            string result = _driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-38' and @role='gridcell' and @aria-colindex='5'])[2]"))
                .Text;
            return result;
        }

        public static string Result100()
        {
            string result = _driver.FindElement(By.XPath(
                "(//td[@aria-describedby='dx-col-47' and @role='gridcell' and @aria-colindex='6'])[2]"))
                .Text;
            return result;
        }
        #endregion

        #region Transaction form related Action Methods

        public static void ClickSave()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Save']")).Click();
        }
        public static void ClickSaveAndBack()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Save']")).Click();
            _driver.Navigate().Back();
        }
        public static void ClickView()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='View']")).Click();
        }
        public static void ClickViewAndBack()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='View']")).Click();
            Thread.Sleep(2000);
            ClickEdit();
            ClickView();
            _driver.Navigate().Back();
        }
        public static void ClickEdit()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Edit']")).Click();
        }
        public static void ClickApprove()
        {
            _driver.FindElement(By.XPath("//span[normalize-space()='Approve']")).Click();
            _driver.Navigate().Back();
        }
        public static void ClickNew()
        {
            _driver .FindElement(By.XPath("//span[normalize-space()='New']")).Click();
        }
        public static void SelectDropdownOption(string expectedValue)
        {
            // Find the list of dropdown elements
            IList<IWebElement> dropdownList = _driver.FindElements(By.XPath("//div[@class='dx-item dx-list-item']"));

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
        public static void SelectDropdownValue(string value)
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
        public static void SelectDropdownValueOffice365(string value)
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
        public static void ClearAndProvide(By locator, string value)
        {
            _driver.FindElement(locator).Click();
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(value);

        }
        public static void ClearAndProvide1(By locator, string value)
        {
            var element = _driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(_driver);
            Thread.Sleep(1000);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            Thread.Sleep(1000);
            element.SendKeys(value);
        }
        public static void ProvideAndEnter(By locator, string value)
        {
            var element = _driver.FindElement(locator);
            element.Click();
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
            element.SendKeys(value);
            Thread.Sleep(2000);

            element.SendKeys(Keys.Enter);
        }
        public static void ProvideValue(By locator, string value)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            IWebElement element = _driver.FindElement(locator);
            //js.ExecuteScript("arguments[0].value='Test Value';", inputField);
            jsExecutor.ExecuteScript($"arguments[0].value='{value}';", element);
        }
        public static void GlobalSearch(string value)
        {
            _driver.FindElement(By.Id("GlobalSearch")).Click();
            _driver.FindElement(By.XPath("//input[@role='combobox']")).SendKeys(value);
            Thread.Sleep(2000);
            SelectDropdownOption(value);
        }
        public static void ScrollDownWebPageSample()
        {
            //Cast driver to IJavaScriptExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

            // Scroll down by a specific number of pixels
            //jsExecutor.ExecuteScript("window.scrollBy(0, 50);");
            //Thread.Sleep(2000);

            // Scroll to the bottom of the page
            //jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

            //If you want to scroll to a specific element, you can use:
            //IWebElement element = driver.FindElement(By.Id("elementId"));
            //jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Initialize Actions class
            //Actions actions = new Actions(_driver);

            // Perform Page Down key press
            //actions.SendKeys(Keys.PageDown).Perform();

            // Wait for a few seconds to see the scroll effect
            //System.Threading.Thread.Sleep(2000);

            // Perform multiple Arrow Down key presses
            //actions.SendKeys(Keys.ArrowDown).Perform();
            //actions.SendKeys(Keys.ArrowDown).Perform();

            // Wait for a few seconds to see the scroll effect
            //System.Threading.Thread.Sleep(2000);

            IWebElement element = _driver.FindElement(By.XPath("//input[contains(@id,'OldContractSalary')]"));
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void ScrollDownWebPage(By locator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            IWebElement element = _driver.FindElement(locator);
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void ClickNewLine()
        {
            _driver.FindElement(By.XPath("//i[@class='dx-icon dx-icon-new-icon']")).Click();
        }
        public static void HoverAndClick(By locator, By locator1)
        {

            IWebElement elementToHover = _driver.FindElement(locator);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elementToHover).Perform();
            _driver.FindElement(locator1).Click();
            //Find(deleteBasicSalBtn).Click();
            //Thread.Sleep(2000);
            //Find(deleteBasicSalaryComponent).Click();
        }
        public static void DeleteTxn(int index, string value)
        {
            FilterByIndex(index, value);
            //IWebElement status= _driver.FindElement(By.XPath("(//tr)[11]//td[8]"));
            //status.Click();
            //status.SendKeys("active");
            //_driver.FindElement(By.XPath("/html[1]/body[1]/div[6]/div[2]/div[1]/div[1]/div[1]/div[6]/div[1]/table[1]/tbody[1]/tr[2]/td[8]/div[1]/div[2]/div[1]/div[1]/div[1]/input[1]")).SendKeys("active");
            //_driver.FindElement(By.XPath("(//input[@class='dx-texteditor-input'])[8]")).SendKeys("active");

            Thread.Sleep(2000);
            try
            {
                //need to select row to click on view
                _driver.FindElement(By.XPath("(//tr)[12]//td[2]")).Click();
            }
            catch (Exception)
            {
                ClassicAssert.Fail("Vaibhav- There is no active records..");
                //Console.WriteLine("There is no active records: " + e);
                Environment.Exit(1);  // Exits the application with a non-zero status
            }

            ClickView();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("(//img[@class='dxWeb_mAdaptiveMenu_Office365 dxm-pImage'])[8]")).Click();
            _driver.FindElement(By.XPath("//span[normalize-space()='Delete']")).Click();
            Thread.Sleep(1000);

            PressKey("enter");


        }
        public static void DeleteHrCoreTxn(int ColumnIndex, string value)
        {
            FilterByIndex(ColumnIndex, value);
            Thread.Sleep(2000);
            try
            {
                //added this condition bcos there is only single column on bank listing
                if (ColumnIndex == 2)
                {
                    _driver.FindElement(By.XPath("(//tr)[12]//td[1]")).Click();
                }
                else
                {
                    _driver.FindElement(By.XPath("(//tr)[12]//td[2]")).Click();
                }

            }
            catch (Exception)
            {
                ClassicAssert.Fail("Vaibhav- There is no active records..");
                //Console.WriteLine("There is no active records: " + e);
                Environment.Exit(1);  // Exits the application with a non-zero status
            }
            try
            {
                ClickView();
            }
            catch (Exception)
            {
                ClickEdit();
            }

            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("(//img[@class='dxWeb_mAdaptiveMenu_Office365 dxm-pImage'])[8]")).Click();
            _driver.FindElement(By.XPath("//span[normalize-space()='Delete']")).Click();
            Thread.Sleep(1000);

            PressKey("enter");
            _driver.Navigate().Back();
        }

        #endregion

        #region Written for employee listing

        public static void FilterEmployee(string value)
        {
            _driver.FindElement(By.Id("//input[@aria-describedby='dx-col-4']")).SendKeys(value);
        }
        public static string ResultEmployee()
        {
            string result = _driver.FindElement(By.XPath(
                    "/html[1]/body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[1]/td[1]/div[2]/p[1]/span[1]/a[1]"))
                    .Text;
            return result;
        }
        public static string Result()
        {
            string result = _driver.FindElement(By.XPath(
                    "//td[@class='list-hyperlink dx-cell-focus-disabled']"))
                    .Text;
            return result;
        }
        public static void ClickResult(string value)
        {
            IWebElement employee = _driver.FindElement(By.XPath(
                    "//td[@class='list-hyperlink dx-cell-focus-disabled']"));
            string result = employee.Text;

            if (result.Contains(value))
            {
                employee.Click();
            }
        }
        public static void NavigateToEmployee(string value)
        {
            FilterByIndex(2, value);
            Thread.Sleep(2000);

            string employee = ResultValue(1);
            //Thread.Sleep(2000);
            if (employee.Contains(value))
            {
                SelectRow();
                ClickView();
            }
            else
            {
                throw new Exception("VRC- No matching record found");
            }

        }
        public static void SwitchTab()
        {
            string originalWindow = _driver.CurrentWindowHandle;
            // Get all window handles
            var allWindows = _driver.WindowHandles;
            // Iterate through the window handles
            foreach (var windowHandle in allWindows)
            {
                if (windowHandle != originalWindow)
                {
                    // Switch to the new window
                    _driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }
        public static void CloseTab()
        {
            string originalWindow = _driver.CurrentWindowHandle;
            // Get all window handles
            var allWindows = _driver.WindowHandles;
            // Iterate through the window handles
            foreach (var windowHandle in allWindows)
            {
                if (windowHandle != originalWindow)
                {
                    // Switch to the new window
                    _driver.SwitchTo().Window(windowHandle);
                    _driver.Close();
                    break;
                }
            }
        }

        #endregion

        #region Keyboard Actions
        public static void PressKey(string key)
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(GetKeyFromString(key)).Perform();
        }
        private static string GetKeyFromString(string key)
        {
            switch (key.ToLower())  // Traditional switch to avoid "recursive pattern" error
            {
                case "enter": return Keys.Enter;
                case "tab": return Keys.Tab;
                case "control": return Keys.Control;
                case "shift": return Keys.Shift;
                case "alt": return Keys.Alt;
                case "escape": return Keys.Escape;
                case "backspace": return Keys.Backspace;
                case "delete": return Keys.Delete;
                case "space": return Keys.Space;
                default: throw new ArgumentException("Invalid key name");
            }
        }
        public static void PressTab()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Tab).Perform();
        }
        public static void PressEnter()
        {
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.Enter).Perform();
        }
        #endregion

        #region Waits

        public static void WaitUntil(By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(10), // Maximum wait time
                PollingInterval = TimeSpan.FromMilliseconds(500) // Poll every 500ms
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            IWebElement element = fluentWait.Until(driver =>
            {
                IWebElement el = driver.FindElement(locator);
                return (el.Displayed && el.Enabled) ? el : null; // Ensures visibility & clickability
            });

            element.Click(); // Click after ensuring element is ready
        }

        public static async Task Wait(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }

        public static void WaitTS(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        #endregion

        #region Validations
        public static bool IsValuePresent(By locator, string value)
        {
            // Find all values in the Office 365 dropdown
            IList<IWebElement> valuesList = _driver.FindElements(locator);

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
        public static bool IsTxnCreated()
        {
            string message = _driver.FindElement(By.XPath("//div[@class='dx-toast-message']")).Text;
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
            string message = _driver.FindElement(By.XPath("//div[@class='dx-toast-message']")).Text;
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
        public static void Validation(string expectedMessage)
        {
            IWebElement element = _driver.FindElement(By.ClassName("dx-toast-message"));
            string actualMessage = element.Text;
            StringAssert.Contains(expectedMessage, actualMessage);
        }
        public static bool ValidateListing(string value, int filterIndex, int resultIndex)
        {
            FilterByIndex(filterIndex, value);
            Thread.Sleep(2000);

            string employee = ResultValue(resultIndex);
            //Thread.Sleep(2000);
            if (employee.Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region Alert Handling
        public void AcceptAlert(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public string GetAlertText(IWebDriver driver)
        {
            return driver.SwitchTo().Alert().Text;
        }

        public void SendKeysToAlert(IWebDriver driver, string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
        }

        #endregion

        #region Dropdown Handling


        #endregion

        #region Textbox Handling


        #endregion

        #region JavaScript Executor
        public void ExecuteScript(IWebDriver driver, string script, params object[] args)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(script, args);
        }

        public object ExecuteScriptWithReturn(IWebDriver driver, string script, params object[] args)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return jsExecutor.ExecuteScript(script, args);
        }

        public void ScrollToBottom(IWebDriver driver)
        {
            ExecuteScript(driver, "window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ScrollToTop(IWebDriver driver)
        {
            ExecuteScript(driver, "window.scrollTo(0, 0);");
        }

        public void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].scrollIntoView(true);", element);
        }

        public void ClickElementByJavaScript(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].click();", element);
        }

        public void SetAttribute(IWebDriver driver, IWebElement element, string attributeName, string attributeValue)
        {
            ExecuteScript(driver, $"arguments[0].setAttribute('{attributeName}', '{attributeValue}');", element);
        }

        public string GetAttribute(IWebDriver driver, IWebElement element, string attributeName)
        {
            return (string)ExecuteScriptWithReturn(driver, $"return arguments[0].getAttribute('{attributeName}');", element);
        }

        public void HighlightElement(IWebDriver driver, IWebElement element)
        {
            ExecuteScript(driver, "arguments[0].style.border='3px solid red'", element);
        }

        public void RefreshBrowserUsingJS(IWebDriver driver)
        {
            ExecuteScript(driver, "history.go(0);");
        }

        public void OpenNewTabUsingJS(IWebDriver driver)
        {
            ExecuteScript(driver, "window.open();");
        }

        #endregion

        #region Frame Handling
        public void SwitchToFrameByIndex(IWebDriver driver, int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public void SwitchToFrameByNameOrId(IWebDriver driver, string nameOrId)
        {
            driver.SwitchTo().Frame(nameOrId);
        }

        public void SwitchToFrameByElement(IWebDriver driver, By locator)
        {
            IWebElement frameElement = driver.FindElement(locator);
            driver.SwitchTo().Frame(frameElement);
        }

        public void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public void SwitchToParentFrame(IWebDriver driver)
        {
            driver.SwitchTo().ParentFrame();
        }

        #endregion

        #region Mouse Actions 
        public void HoverOverElement(By locator)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(Find(locator)).Perform();
        }
        public void DragAndDrop(By sourceLocator, By targetLocator)
        {
            Actions actions = new Actions(_driver);
            actions.DragAndDrop(Find(sourceLocator), Find(targetLocator)).Perform();
        }
        public static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public static void ClickAndHold(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.ClickAndHold(element).Perform();
        }

        public static void Release(IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.Release().Perform();
        }

        public static void DoubleClick(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.DoubleClick(element).Perform();
        }

        public static void ContextClick(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.ContextClick(element).Perform();
        }

        public static void DragAndDrop(IWebDriver driver, IWebElement source, IWebElement target)
        {
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, target).Perform();
        }

        public static void DragAndDropByOffset(IWebDriver driver, IWebElement element, int xOffset, int yOffset)
        {
            Actions actions = new Actions(driver);
            actions.DragAndDropToOffset(element, xOffset, yOffset).Perform();
        }

        #endregion

        #region File Upload
        public void UploadFile(By locator, string filePath)
        {
            Find(locator).SendKeys(filePath);
        }
        #endregion

        #region Element Interaction Methods

        #endregion


    }
}
