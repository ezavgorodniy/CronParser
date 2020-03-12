using CronParser.Core.Internal.Helpers;
using Xunit;

namespace CronParser.Tests.Unit.Helpers
{
    public class DigitsHelperTests
    {
        private readonly DigitsHelper _digitsHelper;

        public DigitsHelperTests()
        {
            _digitsHelper = new DigitsHelper();
        }

        [Theory]
        [InlineData('0', true)]
        [InlineData('1', true)]
        [InlineData('2', true)]
        [InlineData('3', true)]
        [InlineData('4', true)]
        [InlineData('5', true)]
        [InlineData('6', true)]
        [InlineData('7', true)]
        [InlineData('8', true)]
        [InlineData('9', true)]
        [InlineData('a', false)]
        [InlineData('-', false)]
        [InlineData('x', false)]
        [InlineData('A', false)]
        public void IsDigitTest(char c, bool expectedResult)
        {
            var actualResult = _digitsHelper.IsDigit(c);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("0", true)]
        [InlineData("01", true)]
        [InlineData("13", true)]
        [InlineData("-13", false)] // TODO: change when method will support minuses parsers
        public void IsNumberTest(string s, bool expectedResult)
        {
            var actualResult = _digitsHelper.IsNumber(s);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
