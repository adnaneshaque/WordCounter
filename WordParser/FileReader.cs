using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WordParser
{
    internal class FileReader : IFileReader
    {
        public IReadOnlyCollection<string> ReadFileLines(string fileName)
        {
            if (!File.Exists(fileName)) return new ReadOnlyCollection<string>(new List<string>());

            return File.ReadAllLines(fileName);
        }
    }
}