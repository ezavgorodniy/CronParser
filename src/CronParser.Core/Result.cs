namespace CronParser.Core
{
    public class Result
    {
        public int[] ExpectedMinutes { get; set; } 

        public int[] ExpectedHours { get; set; }

        public int[] ExpectedDaysOfMonth { get; set; }

        public int[] ExpectedMonths { get; set; }

        public int[] ExpectedDaysOfWeek { get; set; }

        public string CommandName { get; set; }
    }
}
