using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.September.WordPattern
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;
        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(InputAndOutput))]
        public void Check(string pattern, string terms, bool output)
        {
            var solution = new Solution();
            solution.WordPattern(pattern, terms).Should().Be(output);
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]{"", "", true},
                new object[]{"", "cat", false},
                new object[]{"a", "", false},
                new object[]{"ab", "cat cat", false},
                new object[]{"abba", "dog cat cat dog", true},
                new object[]{"abba", "dog cat cat fish", false},
                new object[]{"aaaa", "dog cat cat dog", false},
                new object[]{"abba", "dog dog dog dog", false}
            };
        }
    }
}