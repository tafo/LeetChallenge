using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Common;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.September.SumRootToLeaf
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
        public void Check(TreeNode root, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            solution.SumRootToLeaf(root).Should().Be(expectedOutput);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new int?[]{ 1, 0, 1}.ToTreeNode(),
                    5
                },
                new object[]
                {
                    new int?[]{ 1, 0, 1, 0, 1, 0, 1 }.ToTreeNode(),
                    22
                },
            };
        }
    }
}