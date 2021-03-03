using System.Collections.Generic;

namespace WordParser
{
    internal interface IFileReader
    {
        IReadOnlyCollection<string> ReadFileLines(string fileName);
    }
}
