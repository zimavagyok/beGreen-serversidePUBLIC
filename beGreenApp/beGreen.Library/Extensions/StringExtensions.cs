using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beGreen.Library.Extensions
{
    public static class StringExtensions
    {
        public static string MakeItOriginal(this string value)
        {
            if (value == null)
            {
                return null;
            }

            char[] charArray = value.ToCharArray();
            int lenght = value.Length - 1;

            for (int i = 0; i < lenght; i++, lenght--)
            {
                charArray[i] ^= charArray[lenght];
                charArray[lenght] ^= charArray[i];
                charArray[i] ^= charArray[lenght];
            }

            return new string(charArray);
        }

        public static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList.TrimEnd(',')
                                       .Split(',')
                                       .AsEnumerable<string>()
                                       .Select(s => s.Trim())
                                       .ToList();
        }

        public static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}
