using System;
using System.Collections.Generic;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Operations
{
    internal class SingleOperation : IOperation
    {
        public void Apply(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation)
        {
            OperationArgumentsCheckHelper.CheckOperationArguments(allowedValues, minRange, maxRange, operation);

            if (!int.TryParse(operation, out var allowValue))
            {
                throw new FormatException("Unable to parse number");
            }

            if (allowValue < minRange || allowValue > maxRange)
            {
                throw new IndexOutOfRangeException("Value is out of expected range for single operation");
            }

            allowedValues[allowValue] = true;
        }
    }
}
