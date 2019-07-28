using System;
using System.Text.RegularExpressions;

namespace QA_Scanner.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] extraChars = {
            Convert.ToChar(160).ToString(),
            Environment.NewLine,
            " ", ",", ".", "!", "?", ":", "_", "-"
        };

        public static string RemoverStrs(this string str, string[] removeStrs)
        {
            foreach (var removeStr in removeStrs)
            {
                str = str.Replace(removeStr, "");
            }            
            
            return str;
        }

        public static string ParseQA(this string questionOrAnswerString)
        {
            questionOrAnswerString = questionOrAnswerString.RemoverStrs(extraChars);
            questionOrAnswerString = questionOrAnswerString.ToLower();
            questionOrAnswerString = questionOrAnswerString.Trim();

            return questionOrAnswerString;
        }

        public static string RemoveStartingDigits(this string str)
        {
            if (Regex.IsMatch(str, @"^\d+"))
            {
                int numlength = Regex.Match(str, @"^\d+").Length;
                str = str.Remove(0, numlength);
            }

            return str;
        }

        public static bool IsStartingWithDigits(this string str)
        {
            return Regex.IsMatch(str, @"^\d+");
        }
    }
}
