using System.Collections.Generic;

namespace CronParser.Core.Internal.Interfaces
{
    internal interface IWordsFinderHelper
    {
        ICollection<string> FindWords(string s);
    }
}
