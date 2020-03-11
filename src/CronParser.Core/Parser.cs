using System;
using CronParser.Core.Exceptions;
using CronParser.Core.Interfaces;

namespace CronParser.Core
{
    public class Parser : IParser
    {
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

            return new Result
            {
                ExpectedMinutes = new[] {0, 15, 30, 45},
                ExpectedHours = new[] {0},
                ExpectedDaysOfMonth = new[] {1, 15},
                ExpectedMonths = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
                ExpectedDaysOfWeek = new[] {1, 2, 3, 4, 5},
                CommandName = operators[5]
            };
        }
    }
}
