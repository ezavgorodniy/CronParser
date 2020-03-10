using System;
using CronParser.Core;
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
    }
}
