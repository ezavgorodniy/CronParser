using System;
using CronParser.Core;

namespace CronParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Expected format of running is: ");
                Console.WriteLine("CronParser.exe \"<your-cron-expression>\"");
                return;
            }

            try
            {
                var parser = new Parser();
                var parseResult = parser.Parse(args[0]);

                var columnResultViewer = new ColumnResultViewer();
                Console.Write(columnResultViewer.Output(parseResult));
            }
            catch (Exception exc)
            {
                // TODO: process exception in a better way
                Console.WriteLine(exc.Message);
            }
        }
    }
}
