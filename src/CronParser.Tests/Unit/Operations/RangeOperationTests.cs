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

        [Fact]
        public void ExpectNotImplementedYetException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _rangeOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, $"{ExpectedMinRange}-{ExpectedMaxRange}");
            });
        }
    }
}
