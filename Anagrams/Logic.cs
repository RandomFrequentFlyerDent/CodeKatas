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
                var tempDict = words
                    .GroupBy(w => String.Concat(w.OrderBy(c => c)))
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var word in words)
                {
                    var tempWord = String.Concat(word.OrderBy(c => c));
                    var tempList = tempDict.GetValueOrDefault(tempWord).ToList();
                    tempList.Remove(word);
                    anagrams.Add(word, tempList);
                }
            }

            return anagrams;
        }

        public static string GetMostWords(Dictionary<string, List<string>> anagrams)
        {
            var mostWordsEntry = anagrams.OrderByDescending(a => a.Value.Count).First();
            var list = mostWordsEntry.Value.ToList();
            list.Add(mostWordsEntry.Key);
            return String.Join(" ", list.ToArray());
        }

        public static string GetLongestWords(Dictionary<string, List<string>> anagrams)
        {
            var longestWordEntry = anagrams.OrderByDescending(a => a.Key.Length).First();
            var list = longestWordEntry.Value.ToList();
            list.Add(longestWordEntry.Key);
            return String.Join(" ", list.ToArray());
        }
    }
}
