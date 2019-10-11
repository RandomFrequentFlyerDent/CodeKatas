using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading file...");
            var list = LoadList();
            Console.WriteLine("Getting anagrams...");
            var begin = DateTime.Now.Ticks;
            var anagrams = Logic.GetAnagrams(list);
            var end = DateTime.Now.Ticks;
            TimeSpan elapsedTime = new TimeSpan(end - begin);
            Console.WriteLine($"Number of words: {anagrams.Keys.Count}");
            Console.WriteLine($"Duration: {elapsedTime.TotalSeconds:N2} seconds");
            Console.WriteLine($"Set of longest words: {Logic.GetLongestWords(anagrams)}");
            Console.WriteLine($"Set of most words: {Logic.GetMostWords(anagrams)}");
        }

        private static List<string> LoadList()
        {
            var list = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resource = "Anagrams.wordlist.txt";

            using (var stream = assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream, Encoding.UTF8 ))
            {
                while(reader.Peek() > 0)
                {
                    list.Add(reader.ReadLine());
                }
            }

            return list;
        }
    }
}
