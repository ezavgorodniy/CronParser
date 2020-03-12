using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Operations
{
    internal class StepOperation : IOperation
    {
        public void Apply(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation)
        {
            OperationArgumentsCheckHelper.CheckOperationArguments(allowedValues, minRange, maxRange, operation);

            var ranges = operation.Split('/');
            if (ranges.Length != 2)
            {
                throw new FormatException("Invalid step");
            }

            int start;
            if (ranges[0] == "*")
            {
                start = minRange;
            }
            else if (!int.TryParse(ranges[0], out start))
            {
                throw new FormatException("Unable to parse start");
            }
            if (!int.TryParse(ranges[1], out var step))
            {
                throw new FormatException("Unable to parse step");
            }
            if (start < minRange)
            {
                throw new IndexOutOfRangeException("start should be greater than overall minRange");
            }
            if (start > maxRange)
            {
                throw new IndexOutOfRangeException("start should be less than maxRange");
            }

            for (int i = start; i <= maxRange; i += step)
            {
                allowedValues[i] = true;
            }
        }
    }
}
