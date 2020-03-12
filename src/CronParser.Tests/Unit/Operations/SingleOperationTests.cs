using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Operations;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class SingleOperationTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private readonly SingleOperation _singleOperation = new SingleOperation();

        [Fact]
        public void BelowMinRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _singleOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, $"{ExpectedMinRange - 1}");
            });
        }

        [Fact]
        public void AboveMaxRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _singleOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, $"{ExpectedMaxRange + 1}");
            });
        }

        [Fact]
        public void InvalidNumberExpectFormatException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _singleOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, "abc");
            });
        }

        [Fact]
        public void SingleOperationTest()
        {
            const int expectedAllowedValue = 1;

            var allowedValues = new Dictionary<int, bool>();

                _singleOperation.Apply(allowedValues, ExpectedMinRange, ExpectedMaxRange, $"{expectedAllowedValue}");

                Assert.True(allowedValues[expectedAllowedValue]);
        }
    }
}
