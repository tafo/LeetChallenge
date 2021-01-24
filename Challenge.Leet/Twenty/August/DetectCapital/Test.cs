using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.August.DetectCapital
{
    public class Test
    {
        private static ITestOutputHelper _testOutput;
        public static readonly Random Random = new Random();
        private static readonly string Letters = "".PadRight(short.MaxValue, (char)Random.Next(97, 123));
        private static readonly string CapitalLetters = "".PadRight(short.MaxValue, (char)Random.Next(65, 91));

        public static IEnumerable<object[]> Words()
        {
            yield return new object[] { "A", true };
            yield return new object[] { "a", true };
            yield return new object[] { "aA", false };
            yield return new object[] { $"A{Letters}", true };
            yield return new object[] { $"A{Letters}A{Letters}", false };
            yield return new object[] { $"A{CapitalLetters}", true };
            yield return new object[] { $"a{Letters}", true };
            yield return new object[] { $"a{CapitalLetters}", false };
            yield return new object[] { $"a{Letters}A{Letters}", false };
        }

        public Test(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [MemberData(nameof(Words))]
        public void Check_Solution(string word, bool result)
        {
            new TheSolution().DetectCapitalUse(word).Should().Be(result);
        }

        [Theory]
        [MemberData(nameof(Words))]
        public void Check_AnotherSolution(string word, bool result)
        {
            new AnotherSolution().DetectCapitalUse(word).Should().Be(result);
        }

        [Fact]
        public void Test_Solution()
        {
            var solution = new TheSolution();
            var words = Words().Select(x => x[0].ToString()).ToArray();
            var timer = Stopwatch.StartNew();
            Array.ForEach(words, word => solution.DetectCapitalUse(word));
            timer.Stop();
            _testOutput.WriteLine($"{timer.ElapsedTicks} ticks");
        }

        [Fact]
        public void Test_ThatSolution()
        {
            var solution = new AnotherSolution();
            var words = Words().Select(x => x[0].ToString()).ToArray();
            var timer = Stopwatch.StartNew();
            Array.ForEach(words, word => solution.DetectCapitalUse(word));
            timer.Stop();
            _testOutput.WriteLine($"{timer.ElapsedTicks} ticks");
        }
    }
}