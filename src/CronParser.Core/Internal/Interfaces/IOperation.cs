using System.Collections.Generic;

namespace CronParser.Core.Internal.Interfaces
{
    internal interface IOperation
    {
        void Apply(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation);
    }
}
