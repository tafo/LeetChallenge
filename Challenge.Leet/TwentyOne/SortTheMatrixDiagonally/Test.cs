using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.TwentyOne.SortTheMatrixDiagonally
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
        public void Check(int[][] matrix, int[][] expectedOutput)
        {
            var timer = Stopwatch.StartNew();
            var solution = new Solution();
            timer.Start();
            var actualOutput = solution.DiagonalSort(matrix);
            timer.Stop();
            actualOutput.Should().BeEqualTo(expectedOutput);
            _outputHelper.WriteLine($"Duration = {timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput => new List<object[]>
        {
            new object[]
            {
                new[]
                {
                    new[] {3, 3, 1, 1},
                    new[] {2, 2, 1, 2},
                    new[] {1, 1, 1, 2}
                },
                new[]
                {
                    new[] {1, 1, 1, 1},
                    new[] {1, 2, 2, 2},
                    new[] {1, 2, 3, 3}
                }
            }
        };
    }
}
