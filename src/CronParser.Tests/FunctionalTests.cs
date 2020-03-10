using System;
using CronParser.Core;
using Xunit;

namespace CronParser.Tests
{
    public class FunctionalTests
    {
        private readonly string _expectedResultFormat;

        public FunctionalTests()
        {
            _expectedResultFormat =
                "minute        {0}" + Environment.NewLine +
                "hour          {1}" + Environment.NewLine +
                "day of month  {2}" + Environment.NewLine +
                "month         {3}" + Environment.NewLine +
                "day of week   {4}" + Environment.NewLine +
                "command       {5}";
        }

        [Fact]
        public void SampleTest()
        {
            var parser = new Parser();
            var parseResult = parser.Parse("*/15 0 1,15 * 1-5 /usr/bin/find");
            
            var resultViewer = new ColumnResultViewer();
            var parseOutput = resultViewer.Output(parseResult);

            var expectedResult = string.Format(_expectedResultFormat,
                "0 15 30 45",
                "0",
                "1 15",
                "1 2 3 4 5 6 7 8 9 10 11 12",
                "1 2 3 4 5",
                "/usr/bin/find");

            Assert.Equal(expectedResult, parseOutput);
        }
    }
}
