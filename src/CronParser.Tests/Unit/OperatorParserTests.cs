using System;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal;
using Xunit;

namespace CronParser.Tests.Unit
{
    public class OperatorParserTests
    {
        private const int ExpectedMinRange = 1;
        private const int ExpectedMaxRange = 5;
        private readonly OperatorParser _operatorParser;

        public OperatorParserTests()
        {
            _operatorParser = new OperatorParser(ExpectedMinRange, ExpectedMaxRange);
        }

        [Fact]
        public void MaxRangeMoreThanMinRangeCtorExpectArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new OperatorParser(ExpectedMaxRange, ExpectedMinRange));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ParseAllowedValueNullOrEmptyStringExpectArgumentNullException(string s)
        {
            Assert.Throws<ArgumentNullException>(() => _operatorParser.ParseAllowedValues(s));
        }

        [Fact]
        public void UnableToParseOperationExpectParserExceptionThrown()
        {
            Assert.Throws<ParserException>(() => _operatorParser.ParseAllowedValues("INVALIDOPERATOR"));
        }

        [Fact]
        public void TestEverythingOperation()
        {
            Assert.Throws<NotImplementedException>(() => _operatorParser.ParseAllowedValues("*"));
        }
    }
}
