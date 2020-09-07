namespace Challenge.Leet.August.Palindrome
{
    public class TheSolution
    {
        public bool IsPalindrome(string s)
        {
            s = s.ToLower();
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                    continue;
                }

                if (s[left] != s[right]) return false;

                left++;
                right--;
            }

            return true;
        }
    }
}