using System;
using System.Linq;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;
using Moq;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class WordsFinderHelperTests
    {
        private readonly Mock<IDigitsHelper> _mockDigitsHelper;
        private readonly WordsFinderHelper _wordsFinderHelper;

        public WordsFinderHelperTests()
        {
            _mockDigitsHelper = new Mock<IDigitsHelper>();

            _wordsFinderHelper = new WordsFinderHelper(_mockDigitsHelper.Object);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmptyStringExpectArgumentNullException(string s)
        {
            Assert.Throws<ArgumentNullException>(() => _wordsFinderHelper.FindWords(s));
        }

        [Theory]
        [InlineData(',')]
        [InlineData('/')]
        [InlineData('-')]
        public void ParseByCommaTest(char separator)
        {
            const string word1 = "word1";
            const string word2 = "word2";

            var words = _wordsFinderHelper.FindWords($"{word1}{separator}{word2}").ToArray();

            Assert.Equal(2, words.Length);
            Assert.Equal(word1, words[0]);
            Assert.Equal(word2, words[1]);
        }

        [Theory]
        [InlineData(',')]
        [InlineData('/')]
        [InlineData('-')]
        public void IgnoreAsteriksTest(char separator)
        {
            const string word1 = "word1";
            const string word2 = "word2";

            var words = _wordsFinderHelper.FindWords($"{word1}{separator}{word2}{separator}*").ToArray();

            Assert.Equal(2, words.Length);
            Assert.Equal(word1, words[0]);
            Assert.Equal(word2, words[1]);
        }

        [Theory]
        [InlineData(',')]
        [InlineData('/')]
        [InlineData('-')]
        public void IgnoreNumbersTest(char separator)
        {
            const string word1 = "word1";
            const string word2 = "word2";
            const int expectedNumber = 77;
            _mockDigitsHelper.Setup(helper => helper.IsNumber(expectedNumber.ToString())).Returns(true);

            var words = _wordsFinderHelper.FindWords($"{word1}{separator}{word2}{separator}{expectedNumber}").ToArray();

            Assert.Equal(2, words.Length);
            Assert.Equal(word1, words[0]);
            Assert.Equal(word2, words[1]);
        }
    }
}
