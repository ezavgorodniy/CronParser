using System;
using System.Collections.Generic;
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

        private static string GetCaption(string s, int captionColumnSize)
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

        private static string ShowOrderedValue(string captionColumn, IList<int> allowedValues)
        {
            var sb = new StringBuilder();
            sb.Append(GetCaption(captionColumn, CaptionColumnSize));

            if (allowedValues.Count == 0)
            {
                return sb.ToString();
            }

            sb.Append(allowedValues[0]);
            for (int i = 1; i < allowedValues.Count; i++)
            {
                sb.Append(" " + allowedValues[i]);
            }

            return sb.ToString();
        }

        private static string ShowCommand(string captionColumn, string commandName)
        {
            return GetCaption(captionColumn, CaptionColumnSize) + commandName;
        }
    }
}
