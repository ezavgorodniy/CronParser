namespace CronParser.Core.Internal.Interfaces
{
    internal interface IOperatorParser
    {
        int[] ParseAllowedValues(string s);
    }
}
