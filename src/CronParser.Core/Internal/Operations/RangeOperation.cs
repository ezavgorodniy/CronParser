using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Operations
{
    internal class RangeOperation : IOperation
    {
        public void Apply(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation)
        {
            OperationArgumentsCheckHelper.CheckOperationArguments(allowedValues, minRange, maxRange, operation);

            var ranges = operation.Split('-');
            if (ranges.Length != 2)
            {
                throw new FormatException("Invalid range");
            }
            if (!int.TryParse(ranges[0], out var minRangeToApply))
            {
                throw new FormatException("Unable to parse minRange");
            }
            if (!int.TryParse(ranges[1], out var maxRangeToApply))
            {
                throw new FormatException("Unable to parse minRange");
            }
            if (minRangeToApply > maxRangeToApply)
            {
                throw new IndexOutOfRangeException("minRange should be less than maxRange");
            }
            if (minRangeToApply < minRange)
            {
                throw new IndexOutOfRangeException("minRange to apply should be greater than overall minRange");
            }
            if (maxRangeToApply > maxRange)
            {
                throw new IndexOutOfRangeException("maxRange to apply should be less than maxRange");
            }

            for (int i = minRangeToApply; i <= maxRangeToApply; i++)
            {
                allowedValues[i] = true;
            }
        }
    }
}
