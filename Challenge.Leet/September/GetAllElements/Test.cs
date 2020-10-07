using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Common;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.September.GetAllElements
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
        public void CheckRecursive(TreeNode root1, TreeNode root2, List<int> expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            solution.GetAllElements(root1, root2).Should().BeEquivalentTo(expectedOutput);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new int?[] {2, 1, 4}.ToTreeNode(),
                    new int?[] {1, 0, 3}.ToTreeNode(),
                    new List<int> {0, 1, 1, 2, 3, 4},
                },
                new object[]
                {
                    new int?[] {0, -10, 10}.ToTreeNode(),
                    new int?[] {5, 1, 7, 0, 2}.ToTreeNode(),
                    new List<int> {-10, 0, 0, 1, 2, 5, 7, 10},
                },
                new object[]
                {
                    new int?[] { }.ToTreeNode(),
                    new int?[] {5, 1, 7, 0, 2}.ToTreeNode(),
                    new List<int> {0, 1, 2, 5, 7},
                },
                new object[]
                {
                    new int?[] { }.ToTreeNode(),
                    new int?[] {0, -10, 10}.ToTreeNode(),
                    new List<int> {-10, 0, 10},
                },
            };
        }
    }
}