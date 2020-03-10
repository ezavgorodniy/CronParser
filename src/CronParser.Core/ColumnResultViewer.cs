using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CronParser.Core.Interfaces;

namespace CronParser.Core
{
    public class ColumnResultViewer : IResultViewer
    {
        private const int CaptionColumnSize = 14;

        public string Output(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return ShowOrderedValue("minute", result.ExpectedMinutes) + Environment.NewLine +
                   ShowOrderedValue("hour", result.ExpectedHours) + Environment.NewLine +
                   ShowOrderedValue("day of month", result.ExpectedDaysOfMonth) + Environment.NewLine +
                   ShowOrderedValue("month", result.ExpectedMonths) + Environment.NewLine +
                   ShowOrderedValue("day of week", result.ExpectedDaysOfWeek) + Environment.NewLine +
                   ShowCommand("command", result.CommandName);
        }

        private string GetCaption(string s, int captionColumnSize)
        {
            if (s.Length > captionColumnSize)
            {
                throw new Exception("String too huge for caption column.");
            }

            var res = new char[captionColumnSize];
            for (int i = 0; i < s.Length; i++)
            {
                res[i] = s[i];
            }

            for (int i = s.Length; i < captionColumnSize; i++)
            {
                res[i] = ' ';
            }

            return new string(res);
        }

        private string ShowOrderedValue(string captionColumn, ICollection<int> allowedValues)
        {
            var sb = new StringBuilder();
            sb.Append(GetCaption(captionColumn, CaptionColumnSize));

            if (allowedValues.Count == 0)
            {
                return sb.ToString();
            }

            var orderedByAllowedValue = allowedValues.OrderBy(val => val).ToArray();
            sb.Append(orderedByAllowedValue[0]);
            for (int i = 1; i < orderedByAllowedValue.Length; i++)
            {
                sb.Append(" " + orderedByAllowedValue[i]);
            }

            sb.AppendLine();
            return sb.ToString();
        }

        private string ShowCommand(string captionColumn, string commandName)
        {
            return GetCaption(captionColumn, CaptionColumnSize) + commandName;
        }
    }
}
