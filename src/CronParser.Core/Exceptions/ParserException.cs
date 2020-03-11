using System;
using System.Diagnostics.CodeAnalysis;

namespace CronParser.Core.Exceptions
{
    // just a wrapper around sytem exception
    [ExcludeFromCodeCoverage]
    public class ParserException : Exception
    {
        public ParserException(string message) : base(message)
        {
        }
    }
}
