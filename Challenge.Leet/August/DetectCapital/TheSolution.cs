namespace Challenge.Leet.August.DetectCapital
{
    public class TheSolution
    {
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;
            if (word[0] <= 'Z' && word[1] <= 'Z')
            {
                for (var i = 1; i < word.Length; i++)
                {
                    if (word[i] <= 'Z') continue;
                    return false;
                }
            }
            else
            {
                if (word[1] <= 'Z') return false;

                for (var i = 1; i < word.Length; i++)
                {
                    if (word[i] >= 'a') continue;
                    return false;
                }
            }

            return true;
        }
    }
}