using System;
using System.Collections.Generic;
using System.Diagnostics;
using Challenge.Leet.Helper;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.October.RotateRight
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
        public void Check(int[] inputValues, int rotateValue, int[] expectedOutput)
        {
            var head = ListNodeHelper.Load(inputValues);
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            var newHead = solution.RotateRight(head, rotateValue);
            timer.Stop();
            ListNodeHelper.Unload(newHead).Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[] {new[] {1, 2, 3, 4, 5}, 2, new[] {4, 5, 1, 2, 3}},
            new object[] {new[] {0, 1, 2}, 4, new[] {2, 0, 1}},
            new object[] {new[] {0, 1, 2}, 7, new[] {2, 0, 1}},
            new object[] {new[] {1, 2}, 1, new[] {2, 1}},
            new object[] {new[] {1, 2}, 2, new[] {1, 2}},
            new object[] {new[] {1}, 0, new[] {1}},
            new object[] {new[] {1}, 1, new[] {1}},
            new object[] {Array.Empty<int>(), 0, Array.Empty<int>()}
        };
    }
}