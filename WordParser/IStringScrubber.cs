using System.Collections.Generic;

namespace WordParser
{
    public interface IStringScrubber
    {
        IEnumerable<string> CleanInput(string input, HashSet<string> stopWords);
    }
}
