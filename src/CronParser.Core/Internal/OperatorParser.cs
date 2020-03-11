using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal.Interfaces;
using CronParser.Core.Internal.Operations;

[assembly: InternalsVisibleTo("CronParser.Tests")]
namespace CronParser.Core.Internal
{
    internal class OperatorParser : IOperatorParser
    {
        private readonly int _minRange;
        private readonly int _maxRange;
        private readonly Dictionary<string, int> _valueDictionary;

        /// <summary>
        /// will contain values which allowed for this operator after parsing 
        /// </summary>
        private readonly Dictionary<int, bool> _allowedValues;

        public OperatorParser(int minRange, int maxRange, 
            Dictionary<string, int> valueDictionary = null)
        {
            _minRange = minRange;
            _maxRange = maxRange;

            if (_minRange > _maxRange)
            {
                throw new ArgumentException("MaxRange should be less than MinRange", nameof(maxRange));
            }

            _valueDictionary = valueDictionary;

            _allowedValues = new Dictionary<int, bool>();
        }

        public int[] ParseAllowedValues(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException(s);
            }

            var operations = s.Split(',');
            // TODO: double check if it's trimmed
            foreach (var operation in operations)
            {
                var parsedOperation = ParseOperation(operation);
                if (parsedOperation != null)
                {
                    parsedOperation.Apply(_allowedValues, _minRange, _maxRange, operation);
                    continue;
                }
                
                throw new ParserException($"Unable to parse operation: {operation}");
            }

            throw new NotImplementedException();
        }

        private static IOperation ParseOperation(string s)
        {
            if (s == "*")
            {
                return new EverythingOperation();
            }

            // TODO: parse other operations
            return null;
        }
    }
}
