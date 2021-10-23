using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MapReduce_CountWords
{
    internal class Program
    {
        private static readonly ConcurrentBag<Dictionary<string, int>> Dictionaries = new();

        public static void Main(string[] args)
        {
            if (args.Length == 0) return;
            
            var textFile = args[0];

            var mapper = new Mapper();
            
            var lines = File.ReadAllLines(textFile);
            Parallel.ForEach(lines, line =>
            {
                Dictionaries.Add(mapper.MapPhrase(line));
            });
            
            
            //Get all words
            var allDistinctWords = Dictionaries
                .SelectMany(dic => dic.Keys.ToList())
                .Distinct();

            var finalDictionary = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(allDistinctWords, word =>
            {
                var count = Dictionaries.Where(dic => dic.ContainsKey(word)).Sum(dic => dic[word]);
                finalDictionary.AddOrUpdate(word, count, (key, value)=>value);
            });

            var sorted = new SortedDictionary<string, int>();
            foreach (var (key, value) in finalDictionary)
            {
                sorted.Add(key, value);
            }

            var stringBuilder = new StringBuilder();
            foreach (var (key, value) in sorted)
            {
                stringBuilder.Append($"{key}: {value}\n");
            }
            File.WriteAllText($"result.txt", stringBuilder.ToString());
        }
    }
}