using System;
using System.Collections.Generic;
using CronParser.Core.Exceptions;
using CronParser.Core.Interfaces;
using CronParser.Core.Internal;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core
{
    public class Parser : IParser
    {
        private readonly IWordsFinderHelper _wordsFinderHelper;
        private readonly IDigitsHelper _digitsHelper;

        public Parser() : this(new WordsFinderHelper(new DigitsHelper()), new DigitsHelper())
        {

        }

        internal Parser(IWordsFinderHelper wordsFinderHelper, IDigitsHelper digitsHelper)
        {
            _wordsFinderHelper = wordsFinderHelper;
            _digitsHelper = digitsHelper;
        }

        public Result Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(nameof(s));
            }

            var operators = s.Split(' ');
            if (operators.Length != 6)
            {
                throw new ParserException("Not expected amount of operators. Expected 6 operators: <minutes> <hours> <daysOfMonth> <months> <daysOfWeek> <operation>");
            }

            var minutesParser = CreateParser(0, 59);
            var hoursParser = CreateParser(0, 23);
            var dayOfMonthsParser = CreateParser(1, 31);
            var monthParser = CreateParser(1, 12, new Dictionary<string, int>
            {
                { "JAN", 1 },
                { "FEB", 2 },
                { "MAR", 3 },
                { "APR", 4 },
                { "MAY", 5 },
                { "JUN", 6 },
                { "JUL", 7 },
                { "AUG", 8 },
                { "SEP", 9 },
                { "OCT", 10 },
                { "NOV", 11 },
                { "DEC", 12 }
            });
            var dayOfWeekParser = CreateParser(1, 31, new Dictionary<string, int>
            {
                { "SUN", 1},
                { "MON", 2},
                { "TUE", 3},
                { "WED", 4},
                { "THU", 5},
                { "FRI", 6},
                { "SAT", 7},
                { "L", 7}
            });

            return new Result
            {
                ExpectedMinutes = minutesParser.ParseAllowedValues(operators[0]),
                ExpectedHours = hoursParser.ParseAllowedValues(operators[1]),
                ExpectedDaysOfMonth = dayOfMonthsParser.ParseAllowedValues(operators[2]),
                ExpectedMonths = monthParser.ParseAllowedValues(operators[3]),
                ExpectedDaysOfWeek = dayOfWeekParser.ParseAllowedValues(operators[4]),
                CommandName = operators[5]
            };
        }

        private IOperatorParser CreateParser(int minRange, int maxRange, Dictionary<string, int> dictionary = null)
        {
            return new OperatorParser(_wordsFinderHelper, _digitsHelper, minRange, maxRange, dictionary);
        }
    }
}
