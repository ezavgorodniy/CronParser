using System;
using System.Collections.Generic;
using CronParser.Core.Exceptions;
using CronParser.Core.Internal.Interfaces;
using CronParser.Core.Internal.Operations;

namespace CronParser.Core.Internal
{
    internal class OperatorParser : IOperatorParser
    {
        private readonly IWordsFinderHelper _wordFinderHelper;
        private readonly IDigitsHelper _digitsHelper;
        private readonly int _minRange;
        private readonly int _maxRange;
        private readonly Dictionary<string, int> _valueDictionary;

        /// <summary>
        /// will contain values which allowed for this operator after parsing 
        /// </summary>
        private readonly Dictionary<int, bool> _allowedValues;

        public OperatorParser(IWordsFinderHelper wordsFinderHelper, IDigitsHelper digitsHelper, int minRange,
            int maxRange, Dictionary<string, int> valueDictionary = null)
        {
            _wordFinderHelper = wordsFinderHelper;
            _digitsHelper = digitsHelper;

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
                var operationWithReplacedWords = ApplyDictionary(s);
                var parsedOperation = ParseOperation(operationWithReplacedWords);
                if (parsedOperation != null)
                {
                    parsedOperation.Apply(_allowedValues, _minRange, _maxRange, operationWithReplacedWords);
                    continue;
                }

                throw new ParserException($"Unable to parse operation: {operation}");
            }

            throw new NotImplementedException();
        }

        private IOperation ParseOperation(string s)
        {
            if (s == "*")
            {
                return new EverythingOperation();
            }

            if (_digitsHelper.IsNumber(s))
            {
                return new SingleOperation();
            }

            // TODO: parse other operations
            return null;
        }

        private string ApplyDictionary(string s)
        {
            var result = s;
            var parsedWords = _wordFinderHelper.FindWords(s);
            foreach (var parsedWord in parsedWords)
            {
                if (_valueDictionary != null && _valueDictionary.ContainsKey(parsedWord))
                {
                    result = result.Replace(parsedWord, _valueDictionary[parsedWord].ToString());
                }
                else
                {
                    throw new ParserException($"Unknown word {parsedWord}");
                }
            }

            return result;
        }

    }
}
