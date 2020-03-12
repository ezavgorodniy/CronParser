using System.Linq;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Helpers
{
    internal class DigitsHelper : IDigitsHelper
    {
        public bool IsDigit(char c)
        {
            return '0' <= c && c <= '9';
        }

        public bool IsNumber(string s)
        {
            // TODO: check minuses as well (consider regular expression instead of method)

            return !string.IsNullOrEmpty(s) && s.All(IsDigit);
        }
    }
}
