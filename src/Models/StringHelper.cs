﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QA_Scanner.Models
{
    public static class StringHelper
    {
        private static readonly string[] extraChars = { Convert.ToChar(160).ToString(), " ", ",", ".", "!", "?", Environment.NewLine, "_", "-" };

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
    }
}