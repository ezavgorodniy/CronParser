using System;
using System.Collections.Generic;

namespace CronParser.Core.Internal.Helpers
{
    public static class OperationArgumentsCheckHelper
    {
        public static void CheckOperationArguments(Dictionary<int, bool> allowedValues, int minRange, int maxRange, string operation)
        {
            if (allowedValues == null)
            {
                throw new ArgumentNullException(nameof(allowedValues));
            }

            if (minRange > maxRange)
            {
                throw new ArgumentException("maxRange should be greater than minRange", nameof(maxRange));
            }

            if (string.IsNullOrEmpty(operation))
            {
                throw new ArgumentNullException(nameof(operation));
            }
        }
    }
}
