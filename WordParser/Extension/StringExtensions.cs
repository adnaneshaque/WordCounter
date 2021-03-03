using System;
using System.Text.RegularExpressions;

namespace WordParser.Extension
{
    internal static class StringExtensions
    {
        private static readonly Regex LeadingNonAlphabetCharacterRegex = new Regex("^[^a-zA-Z]+");
        private static readonly Regex TrailingNonAlphabetCharacterRegex = new Regex("[^a-zA-Z]+$");
        private static readonly Regex RemoveNonAlphabetCharacterRegex = new Regex("[^a-zA-Z]");

        public static string TrimLeadingAndTrailingNonAlphabetCharacters(this String str)
        {
            return LeadingNonAlphabetCharacterRegex.Replace(TrailingNonAlphabetCharacterRegex.Replace(str, ""), "");
        }

        public static string RemoveNonAlphabetCharacters(this String str)
        {
            return RemoveNonAlphabetCharacterRegex.Replace(str, "");
        }
    }
}
