using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Common;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.October.MinimumDepthOfBinaryTree
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
        public void Check(TestCase testCase)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var actualOutput = solution.MinDepth(testCase.Root);
            timer.Stop();
            actualOutput.Should().Be(testCase.ExpectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{new TestCase(new int?[] { 3, 9, 20, null, null, 15, 7 }.ToTreeNode(), 2)},
                    new object[]{new TestCase(new int?[] { 2,null,3,null,4,null,5,null,6 }.ToTreeNode(), 5)},
                };
            }
        }

        public class TestCase
        {
            public TreeNode Root;
            public int ExpectedOutput;

            public TestCase(TreeNode root, int expectedOutput)
            {
                Root = root;
                ExpectedOutput = expectedOutput;
            }

            public override string ToString()
            {
                return ExpectedOutput.ToString();
            }
        }
    }
}