using FluentAssertions;
using Xunit;

namespace Challenge.Leet.Twenty.August.Palindrome
{
    public class Test
    {
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData("ab", false)]
        [InlineData("aba", true)]
        public void Check(string s, bool result)
        {
            var solution = new TheSolution();
            solution.IsPalindrome(s).Should().Be(result);
        }
    }
}