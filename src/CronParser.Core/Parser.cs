using System;
using System.Collections.Generic;
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

            return new Result
            {
                ExpectedMinutes = new List<int>(),
                ExpectedHours = new List<int>(),
                ExpectedMonths = new List<int>(),
                ExpectedDaysOfWeek = new List<int>(),
                ExpectedDaysOfMonth = new List<int>(),
                CommandName = "Command"
            };
        }
    }
}
