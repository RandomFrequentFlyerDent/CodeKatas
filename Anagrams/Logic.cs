using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
    public static class Logic
    {
        public static Dictionary<string, List<string>> GetAnagrams(List<string> words)
        {
            var anagrams = new Dictionary<string, List<string>>();

            if (words.Any())
            {
                foreach (var word in words)
                {
                    anagrams.Add(word, GetAnagrams(word, words));
                }
            }

            return anagrams;
        }

        private static List<string> GetAnagrams(string word, List<string> words)
        {
            var tempWords = words.ToList();
            tempWords.Remove(word);
            var tempWord = String.Concat(word.OrderBy(c => c));
            return tempWords.Where(w => String.Concat(w.OrderBy(c => c)).Equals(tempWord)).ToList();
        }
    }

}
