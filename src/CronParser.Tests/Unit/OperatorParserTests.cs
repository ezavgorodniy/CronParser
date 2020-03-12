﻿using System;
using System.Collections.Generic;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal;
using CronParser.Core.Internal.Interfaces;
using Moq;
using Xunit;

namespace CronParser.Tests.Unit
{
    public class OperatorParserTests
    {
        private const string ExpectedKnownWord = "ExpectedKnownWord";
        private const int ExpectedMinRange = 1;
        private const int ExpectedMatchedDictionaryValue = ExpectedMinRange;
        private const int ExpectedMaxRange = 5;
        private readonly OperatorParser _operatorParser;
        private readonly Mock<IWordsFinderHelper> _mockWordsFinderHelper;
        private readonly Mock<IDigitsHelper> _mockDigitsHelper;

        public OperatorParserTests()
        {
            _mockWordsFinderHelper = new Mock<IWordsFinderHelper>();
            _mockDigitsHelper = new Mock<IDigitsHelper>();
            _operatorParser = new OperatorParser(_mockWordsFinderHelper.Object, 
                _mockDigitsHelper.Object,
                ExpectedMinRange, 
                ExpectedMaxRange, new Dictionary<string, int>
                {
                    {ExpectedKnownWord, ExpectedMatchedDictionaryValue}
                });
        }

        [Fact]
        public void MaxRangeMoreThanMinRangeCtorExpectArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new OperatorParser(_mockWordsFinderHelper.Object,
                _mockDigitsHelper.Object, ExpectedMaxRange, ExpectedMinRange));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ParseAllowedValueNullOrEmptyStringExpectArgumentNullException(string s)
        {
            Assert.Throws<ArgumentNullException>(() => _operatorParser.ParseAllowedValues(s));
        }

        [Fact]
        public void NullDictionaryExpectThrowParserExceptionIfWordFound()
        {
            const string unknownWord = "UnknownWord";
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(unknownWord)).Returns(new[] {unknownWord});

            var localOperatorParser = new OperatorParser(_mockWordsFinderHelper.Object,
                _mockDigitsHelper.Object,
                ExpectedMinRange,
                ExpectedMaxRange);
            Assert.Throws<ParserException>(() => localOperatorParser.ParseAllowedValues(unknownWord));
        }

        [Fact]
        public void UnknownWordExpectParserExceptionThrown()
        {
            const string unknownWord = "UnknownWord";

            _mockWordsFinderHelper.Setup(helper => helper.FindWords(unknownWord)).Returns(new[] {unknownWord});

            Assert.Throws<ParserException>(() => _operatorParser.ParseAllowedValues(unknownWord));
        }

        [Fact]
        public void KnownWordExpectToBeParsed()
        {
            _mockDigitsHelper.Setup(helper => helper.IsNumber(ExpectedMatchedDictionaryValue.ToString())).Returns(true);
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(ExpectedKnownWord))
                .Returns(new[] {ExpectedKnownWord});

            var actualAllowedValues = _operatorParser.ParseAllowedValues(ExpectedKnownWord);

            Assert.Single(actualAllowedValues);
            Assert.Equal(ExpectedMatchedDictionaryValue, actualAllowedValues[0]);
        }

        [Fact]
        public void RangeOperationExpectToBeParsed()
        {
            const int expectedMinRange = 1;
            const int expectedMaxRange = 3;

            // TODO: uncomment it as soon as implemented
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(It.IsAny<string>())).Returns(new string[0]);
            
            var actualAllowedValues = _operatorParser.ParseAllowedValues($"{expectedMinRange}-{expectedMaxRange}");

            Assert.Equal(expectedMaxRange - expectedMinRange + 1, actualAllowedValues.Length);
            for (int i = 0; i < actualAllowedValues.Length; i++)
            {
                Assert.Equal(expectedMinRange + i, actualAllowedValues[i]);
            }
        }

        [Fact]
        public void StepOperationAsteriskExpectToBeParsed()
        {
            // TODO: uncomment it as soon as implemented
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(It.IsAny<string>())).Returns(new string[0]);
            Assert.Throws<ParserException>(() => _operatorParser.ParseAllowedValues("*/2"));
        }

        [Fact]
        public void StepOperationNumberExpectToBeParsed()
        {
            // TODO: uncomment it as soon as implemented
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(It.IsAny<string>())).Returns(new string[0]);
            Assert.Throws<ParserException>(() => _operatorParser.ParseAllowedValues("1/2"));
        }

        [Fact]
        public void TestEverythingOperation()
        {
            // TODO: uncomment it as soon as implemented
            _mockWordsFinderHelper.Setup(helper => helper.FindWords(It.IsAny<string>())).Returns(new string[0]);

            var actualAllowedValues = _operatorParser.ParseAllowedValues("*");

            Assert.Equal(ExpectedMaxRange - ExpectedMinRange + 1, actualAllowedValues.Length);
            for (int i = 0; i < actualAllowedValues.Length; i++)
            {
                Assert.Equal(i + 1, actualAllowedValues[i]);
            }
        }
    }
}
