using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enfinity.Hrms.Test.UI.Utilities
{
    public static class DataUtils
    {
        #region for random data generation
        public static Random random = new Random();

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
