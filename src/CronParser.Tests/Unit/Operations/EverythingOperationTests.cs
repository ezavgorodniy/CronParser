using System;
using System.Collections.Generic;
using System.Text;
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
        public void ExpectNotImplementedYetException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                _everythingOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange, "*");
            });
        }
    }
}
