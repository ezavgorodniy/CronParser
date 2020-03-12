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

        [Theory]
        [InlineData("1/2/3")]
        [InlineData("1")]
        public void InvalidStepFormatExpectFormatException(string invalidStepOperation)
        {
            Assert.Throws<FormatException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    invalidStepOperation);
            });
        }

        [Fact]
        public void UnableToParseStartExpectFormatException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    "INVALID/2");
            });
        }

        [Fact]
        public void UnableToParseStepRangeExpectFormatException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    "2/INVALID");
            });
        }

        [Fact]
        public void StartLessExpectedMinRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    $"{ExpectedMinRange - 1}/4");
            });
        }

        [Fact]
        public void StartGreaterExpectedMaxRangeExpectIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                _stepOperation.Apply(new Dictionary<int, bool>(), ExpectedMinRange, ExpectedMaxRange,
                    $"{ExpectedMaxRange + 1}/4");
            });
        }

        [Fact]
        public void StepOperationTest()
        {
            const int expectedStart = 1;
            const int expectedStep = 2;

            var allowedValues = new Dictionary<int, bool>();

            _stepOperation.Apply(allowedValues, ExpectedMinRange, ExpectedMaxRange, $"{expectedStart}/{expectedStep}");

            for (int i = expectedStart; i <= ExpectedMaxRange; i += expectedStep)
            {
                Assert.True(allowedValues[i]);
            }
        }

        [Fact]
        public void StepOperationAsteriskTestExpectToStartWithMinRange()
        {
            const int expectedStart = ExpectedMinRange;
            const int expectedStep = 3;

            var allowedValues = new Dictionary<int, bool>();

            _stepOperation.Apply(allowedValues, ExpectedMinRange, ExpectedMaxRange, $"*/{expectedStep}");

            for (int i = expectedStart; i <= ExpectedMaxRange; i += expectedStep)
            {
                Assert.True(allowedValues[i]);
            }
        }
    }
}
