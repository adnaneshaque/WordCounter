using System.Collections.Generic;

namespace WordParser
{
    internal interface IStopWordService
    {
        HashSet<string> GetStopWords();
    }
}
