using System;
using System.Collections.Generic;
using System.Linq;

namespace WordParser
{
    internal class FrequentWordCounter
    {
        private readonly IFileReader _fileReader;
        private readonly IStringScrubber _iStringScrubber;
        private readonly IStopWordService _stopWordService;
        private readonly IPorterStemmer _porterStemmer;
        
        public FrequentWordCounter(IFileReader fileReader, IStringScrubber iStringScrubber, IStopWordService stopWordService, IPorterStemmer porterStemmer)
        {
            _fileReader = fileReader;
            _iStringScrubber = iStringScrubber;
            _stopWordService = stopWordService;
            _porterStemmer = porterStemmer;
        }
        public void Run(string fileName)
        {
            var stopWords = _stopWordService.GetStopWords();
            var lines = _fileReader.ReadFileLines(fileName);

            if (lines.Count == 0)
            {
                Console.WriteLine($"File {fileName} does not exist.");
                return;
            }

            var frequentWords = GetFrequentWords(lines, stopWords, 20);
            PrintFrequentWords(frequentWords);
        }

        private IEnumerable<KeyValuePair<string, int>> GetFrequentWords(IReadOnlyCollection<string> lines, HashSet<string> stopWords, int count)
        {
            var wordCountLookup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                var scrubbedInput = _iStringScrubber.CleanInput(line, stopWords);

                foreach (var word in scrubbedInput)
                {
                    var stemmedWord = _porterStemmer.StemWord(word);

                    if (wordCountLookup.ContainsKey(stemmedWord))
                        wordCountLookup[stemmedWord] = wordCountLookup[stemmedWord] + 1;
                    else
                        wordCountLookup[stemmedWord] = 1;
                }
            }

            return wordCountLookup.OrderByDescending(kvp => kvp.Value).Take(count);
        }

        private static void PrintFrequentWords(IEnumerable<KeyValuePair<string, int>> frequentWords)
        {
            foreach (var kvp in frequentWords) 
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }
    }
}
