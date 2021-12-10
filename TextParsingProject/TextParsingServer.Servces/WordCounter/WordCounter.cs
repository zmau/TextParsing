using System;

namespace TextParsingServer.Servces.WordCounter
{
    public class WordCounter : IWordCounter
    {
        private static char[] DELIMITERS =  { ' ', ',', ';', '.', '!', '"', '(', ')', '?' };
        public int getWordsCount(string text)
        {
            string[] words = text.Split(DELIMITERS, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
