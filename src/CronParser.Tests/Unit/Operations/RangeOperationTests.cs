using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Operations;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class RangeOperationTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private readonly RangeOperation _rangeOperation = new RangeOperation();

        [Theory]
        [InlineData("1-2-3")]
        [InlineData("1")]
        public void InvalidRangeFormExpectFormatException(string invalidRangeOperation)
        {
            Assert.Throws<FormatException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    invalidRangeOperation);
            });
        }

        [Fact]
        public void UnableToParseMinRangeExpectFormatException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    "INVALID-2");
            });
        }

        [Fact]
        public void UnableToParseMaxRangeExpectFormatException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    "2-INVALID");
            });
        }

        [Fact]
        public void MinRangeGreaterThanMaxRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    "2-1");
            });
        }

        [Fact]
        public void MinRangeLessExpectedMinRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    $"{ExpectedMinRange - 1}-4");
            });
        }

        [Fact]
        public void MaxRangeGreaterExpectedMaxRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    $"{ExpectedMinRange}-{ExpectedMaxRange + 1}");
            });
        }

        [Fact]
        public void RangeOperationTest()
        {
            const int expectedMinRange = 2;
            const int expectedMaxRange = 4;

            var allowedValues = new Dictionary<int, bool>();

            _rangeOperation.Apply(allowedValues, ExpectedMinRange, ExpectedMaxRange, $"{expectedMinRange}-{expectedMaxRange}");

            for (int i = expectedMinRange; i <= expectedMaxRange; i++)
            {
                Assert.True(allowedValues[i]);
            }
        }
    }
}
