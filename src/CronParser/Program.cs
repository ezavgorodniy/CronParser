using System;
using CronParser.Core;

namespace CronParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(args[0]);
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
