using System.Collections.Generic;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal.Operations;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class EverythingOperationTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private readonly EverythingOperation _everythingOperation = new EverythingOperation();

        [Fact]
        public void ExpectEverythingAllowedInRange()
        {
            var allowedValues = new Dictionary<int, bool>();
            _everythingOperation.Apply(allowedValues, ExpectedMinRange, ExpectedMaxRange, "*");


            for (int i = ExpectedMinRange; i <= ExpectedMaxRange; i++)
            {
                Assert.True(allowedValues[i]);
            }
        }

        [Fact]
        public void ExpectExceptionOnNonStarString()
        {
            Assert.Throws<ParserException>(() =>
                _everythingOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, "*****"));
        }
    }
}
