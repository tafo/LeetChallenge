using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.September.WordPattern
{
    public class Solution
    {
        public bool WordPattern(string pattern, string str)
        {
            var terms = str.Trim().Split(' ').Where(x => x.Length > 0).ToArray();
            if (pattern.Length != terms.Length) return false;

            var output = true;

            var patternDictionary = new Dictionary<char, int>();
            var termSet = new HashSet<string>();
            for (var i = 0; i < pattern.Length; i++)
            {
                var character = pattern[i];
                var term = terms[i];
                if (patternDictionary.ContainsKey(character))
                {
                    var index = patternDictionary[character];
                    if (terms[index] == term)
                    {
                        patternDictionary[character] = i;
                    }
                    else
                    {
                        output = false;
                        break;
                    }
                }
                else
                {
                    patternDictionary.Add(character, i);
                    if (termSet.Contains(term))
                    {
                        output = false;
                        break;
                    }

                    termSet.Add(term);
                }
            }

            return output;
        }
    }
}