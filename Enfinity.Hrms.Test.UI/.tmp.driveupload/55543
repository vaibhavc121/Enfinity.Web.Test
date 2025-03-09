using Bogus;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI
{
    public class BasePage
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Find(By locator) => _driver.FindElement(locator);

        #region for fake data generation
        public Faker faker = new Faker();
        #endregion

        #region for random data generation
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

    }
}
