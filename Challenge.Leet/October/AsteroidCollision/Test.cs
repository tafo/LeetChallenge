using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.October.AsteroidCollision
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
        public void Check(int[] asteroids, int[] expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.AsteroidCollision(asteroids);
            timer.Stop();
            actualOutput.Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[] {new[] {5, 10, -5}, new[] {5, 10}},
            new object[] {new[] {8, -8}, new int[] { }},
            new object[] {new[] {10, 2, -5}, new[] {10}},
            new object[] {new[] {-2, -1, 1, 2}, new[] {-2, -1, 1, 2}},
            new object[] {new[] {-2, -2, 1, -2}, new[] {-2, -2, -2}},
            new object[] {new[] {-2,1,1,-1}, new[] {-2,1}}
        };
    }
}