using System;
using CronParser.Core;
using Xunit;

namespace CronParser.Tests.Unit
{
    public class ColumnResultViewerTests
    {
        private readonly string _expectedResultFormat;
        private readonly ColumnResultViewer _resultViewer;

        public ColumnResultViewerTests()
        {
            _resultViewer = new ColumnResultViewer();
            _expectedResultFormat =
                "minute        {0}" + Environment.NewLine +
                "hour          {1}" + Environment.NewLine +
                "day of month  {2}" + Environment.NewLine +
                "month         {3}" + Environment.NewLine +
                "day of week   {4}" + Environment.NewLine +
                "command       {5}";
        }

        [Fact]
        public void ResultNullExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _resultViewer.Output(null));
        }

        [Fact]
        public void SampleTest()
        {
            var result = new Result
            {
                ExpectedMinutes = new[] {0, 15, 30, 45},
                ExpectedHours = new[] {0},
                ExpectedDaysOfMonth = new[] {1, 15},
                ExpectedMonths = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
                ExpectedDaysOfWeek = new[] {1, 2, 3, 4, 5},
                CommandName = "/usr/bin/find"
            };

            var output = _resultViewer.Output(result);

            var expectedResult = string.Format(_expectedResultFormat,
                "0 15 30 45",
                "0",
                "1 15",
                "1 2 3 4 5 6 7 8 9 10 11 12",
                "1 2 3 4 5",
                "/usr/bin/find");

            Assert.Equal(expectedResult, output);
        }

        [Fact]
        public void EmptyValuesTest()
        {
            const string expectedCommandName = "cmd";
            var result = new Result
            {
                ExpectedMinutes = new int[0],
                ExpectedHours = new int[0],
                ExpectedDaysOfMonth = new int[0],
                ExpectedMonths = new int[0],
                ExpectedDaysOfWeek = new int[0],
                CommandName = expectedCommandName
            };

            var output = _resultViewer.Output(result);

            var expectedResult = string.Format(_expectedResultFormat,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                expectedCommandName);

            Assert.Equal(expectedResult, output);
        }
    }
}
