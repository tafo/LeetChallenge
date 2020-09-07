using System;

namespace Challenge.Leet.August.DetectCapital
{
    public class AnotherSolution
    {
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;

            Func<char, bool> condition;

            if (word[0] <= 'Z' && word[1] <= 'Z')
                condition = c => c <= 'Z';
            else
                condition = c => c >= 'a';

            for (var i = 1; i < word.Length; i++)
            {
                if (condition(word[i])) continue;
                return false;
            }

            return true;
        }
    }
}