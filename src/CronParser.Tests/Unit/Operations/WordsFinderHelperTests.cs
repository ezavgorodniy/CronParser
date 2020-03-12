using System;
using System.Linq;
using CronParser.Core.Internal.Helpers;
using Xunit;

namespace CronParser.Tests.Unit.Operations
{
    public class WordsFinderHelperTests
    {
        private readonly WordsFinderHelper _wordsFinderHelper;

        public WordsFinderHelperTests()
        {
            _wordsFinderHelper = new WordsFinderHelper();
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
    }
}
