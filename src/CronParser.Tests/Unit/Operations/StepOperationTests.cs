using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Operations;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class StepOperationTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private readonly StepOperation _stepOperation = new StepOperation();

        [Fact]
        public void ExpectNotImplementedYetException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, "*/1");
            });
        }
    }
}
