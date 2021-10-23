using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MapReduce_CountWords
{
    public class Mapper
    {
        public Dictionary<string, int> MapPhrase(string phrase)
        {
            var words = phrase.Split(' ', ',', '.', ';', ':', '?', '!', '#', '/')
                .Select(word => Regex.Replace(word, @"\.|;|:|,|[0-9]|\[|\]|\(|\)|'|", ""))
                .Where(word => !string.IsNullOrEmpty(word));
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word]++;
                }
            }

            return dictionary;
        }
    }
}