using System;
using System.Collections.Generic;
using System.Text;

namespace CronParser.Core.Internal.Interfaces
{
    internal interface IOperatorParser
    {
        int[] ParseAllowedValues(string s);
    }
}
