using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.September.WordPattern
{
    public class Solution
    {
        /// <summary>
        /// The fastest Solution in C#.
        /// </summary>
        public bool WordPattern(string pattern, string str)
        {
            var terms = str.Trim().Split(' ').Where(x => x.Length > 0).ToArray();
            if (pattern.Length != terms.Length) return false;

            var dictionary = new Dictionary<char, string>();
            for (var i = 0; i < pattern.Length; i++)
            {
                var character = pattern[i];
                var term = terms[i];
                if (dictionary.ContainsKey(character))
                {
                    if (dictionary[character] == term) continue;
                    return false;
                }

                if (dictionary.Values.Contains(term))
                {
                    return false;
                }

                dictionary.Add(character, term);
            }

            return true;
        }
    }
}