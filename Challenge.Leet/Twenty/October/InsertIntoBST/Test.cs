using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Helper;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.October.InsertIntoBST
{
    public class Test
    {
        private readonly ITestOutputHelper _outputHelper;

        public Test(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(TestInputAndOutput))]
        public void Check(int[] values, int value, int[] expectedOutput)
        {
            var root = TreeNodeHelper.Load(values);
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var output = solution.InsertIntoBST(root, value);
            timer.Stop();
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
            TreeNodeHelper.Unload(output).Should().BeEquivalentTo(expectedOutput);
        }

        public static IEnumerable<object[]> TestInputAndOutput => new List<object[]>
        {
            new object[] {new[] {4, 2, 7, 1, 3}, 5, new[] {4, 2, 7, 1, 3, 5}},
            new object[] {new[] {4, 2, 7, 1, 3, 100000000}, 1000, new[] {4, 2, 7, 1, 3, 100000000, 1000}},
            new object[] {new int[] { }, 5, new[] {5}}
        };
    }
}