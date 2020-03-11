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
        public void ExpectNotImplementedYetException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _singleOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, $"{ExpectedMinRange}");
            });
        }
    }
}
