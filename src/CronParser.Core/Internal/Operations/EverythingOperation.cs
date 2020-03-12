using System;
using System.Collections.Generic;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal.Helpers;
using CronParser.Core.Internal.Interfaces;

namespace CronParser.Core.Internal.Operations
{
    internal class EverythingOperation : IOperation
    {
        public void Apply(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation)
        {
            OperationArgumentsCheckHelper.CheckOperationArguments(allowedValues, minRange, maxRange, operation);
            if (operation != "*")
            {
                throw new ParserException("Everything operation is invalid");
            }

            for (int i = minRange; i <= maxRange; i++)
            {
                allowedValues[i] = true;
            }
        }
    }
}
