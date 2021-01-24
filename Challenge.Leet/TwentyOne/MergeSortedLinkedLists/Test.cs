using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Common;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.TwentyOne.MergeSortedLinkedLists
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
        public void Check(ListNode[] nodes, IEnumerable<int> expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.MergeKLists(nodes);
            timer.Stop();
            actualOutput.ToList().Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[] {new[] {-5, 10, 15}.CreateLinkedList()},
                new List<int>() {-5, 10, 15}
            },
            new object[]
            {
                new[] {new[] {-5, 10, 15}.CreateLinkedList(), new[] {1, 2, 20}.CreateLinkedList()},
                new List<int> {-5, 1, 2, 10, 15, 20}
            },
            new object[] {new ListNode[] { }, null}
        };
    }
}