namespace CronParser.Core.Internal.Interfaces
{
    internal interface IDigitsHelper
    {
        bool IsDigit(char c);

        bool IsNumber(string s);
    }
}
