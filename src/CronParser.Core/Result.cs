using System.Collections.Generic;

namespace CronParser.Core
{
    public class Result
    {
        public ICollection<int> ExpectedMinutes { get; set; } 

        public ICollection<int> ExpectedHours { get; set; }

        public ICollection<int> ExpectedDaysOfMonth { get; set; }

        public ICollection<int> ExpectedMonths { get; set; }

        public ICollection<int> ExpectedDaysOfWeek { get; set; }

        public string CommandName { get; set; }
    }
}
