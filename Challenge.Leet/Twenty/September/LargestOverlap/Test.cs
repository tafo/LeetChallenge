using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.September.LargestOverlap
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
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void Check(int[][] A, int[][] B, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            solution.LargestOverlap(A, B).Should().Be(expectedOutput);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new[]
                    {
                        new[] {1, 1, 0},
                        new[] {0, 1, 0},
                        new[] {0, 1, 0}

                    },
                    new[]
                    {
                        new[] {0, 0, 0},
                        new[] {0, 1, 1},
                        new[] {0, 0, 1}
                    },
                    3
                },
                new object[]
                {
                    new[]
                    {
                        new[] {1, 1},
                        new[] {0, 0},
                    },
                    new[]
                    {
                        new[] {0, 0},
                        new[] {1, 1}
                    },
                    2
                },
            };
        }
    }
}