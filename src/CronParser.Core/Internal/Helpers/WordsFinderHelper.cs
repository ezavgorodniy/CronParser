using System;
using System.Collections.Generic;
using System.Text;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Helpers
{
    internal class WordsFinderHelper : IWordsFinderHelper
    {
        private readonly IDigitsHelper _digitsHelper;

        public WordsFinderHelper(IDigitsHelper digitsHelper)
        {
            _digitsHelper = digitsHelper;
        }

        public ICollection<string> FindWords(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(nameof(s));
            }

            var result = new List<string>();
            var i = 0;
            while (i < s.Length)
            {
                var currentString = new StringBuilder();
                while (i < s.Length && !IsDelimiter(s[i]))
                {
                    currentString.Append(s[i]);
                    i++;
                }

                var addedString = currentString.ToString();
                if (addedString != "*" && !_digitsHelper.IsNumber(addedString))
                {
                    result.Add(currentString.ToString());
                }

                i++;
            }

            return result;
        }

        private static bool IsDelimiter(char c)
        {
            return c == ',' || c == '-' || c == '/';
        }
    }
}
