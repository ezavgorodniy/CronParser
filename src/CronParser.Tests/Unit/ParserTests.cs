using System;
using CronParser.Core;
using CronParser.Core.Exceptions;
using CronParser.Core.Interfaces;
using Xunit;

namespace CronParser.Tests.Unit
{
    public class ParserTests
    {
        private readonly IParser _parser;

        public ParserTests()
        {
            _parser = new Parser();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NullOrEmptyStringParseExpectArgumentNullException(string s)
        {
            Assert.Throws<ArgumentNullException>(() => _parser.Parse(s));
        }

        [Fact]
        public void ParseInvalidAmountOfOperatorsExpectException()
        {
            Assert.Throws<ParserException>(() => _parser.Parse("12 12"));
        }

        [Fact]
        public void ParseCommandExpectCommandNameFromLastOperator()
        {
            const string expectedCommandName = "expectedCommandName";

            var result = _parser.Parse($"* * * * * {expectedCommandName}");

            Assert.Equal(expectedCommandName, result.CommandName);
        }

        // TODO: add tests for parser 
    }
}
