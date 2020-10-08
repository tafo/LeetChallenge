using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.October.BinarySearch
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
        public void Check(int[] values, int target, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.BinarySearch(values, target);
            timer.Stop();
            actualOutput.Should().Be(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]{new []{-1,0,3,5,9,12}, 9, 4},
            new object[]{new []{-1,0,3,5,9,12}, 2, -1},
        };
    }
}