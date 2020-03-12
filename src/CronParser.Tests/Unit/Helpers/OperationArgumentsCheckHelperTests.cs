using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Helpers;
using Xunit;

namespace CronParser.Tests.Unit.Helpers
{
    public class OperationArgumentsCheckHelperTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private const string ExpectedOperation = "someOperation";

        [Fact]
        public void AllowedValuesNullExpectArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                OperationArgumentsCheckHelper.CheckOperationArguments(null, ExpectedMinRange, ExpectedMaxRange,
                    ExpectedOperation);
            });
        }

        [Fact]
        public void MaxRangeLessThanMinRangeExpectArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                OperationArgumentsCheckHelper.CheckOperationArguments(new Dictionary<int, bool>(), ExpectedMaxRange, ExpectedMinRange,
                    ExpectedOperation);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void OperationNullOrEmptyExpectArgumentNullException(string operation)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                OperationArgumentsCheckHelper.CheckOperationArguments(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    operation);
            });
        }
    }
}
