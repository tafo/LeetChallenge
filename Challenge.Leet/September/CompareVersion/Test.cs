using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.September.CompareVersion
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
        public void Check(string version1, string version2, int expectedOutput)
        {
            var solution = new Solution();
            var timer = Stopwatch.StartNew();
            solution.CompareVersion(version1, version2).Should().Be(expectedOutput);
            timer.Stop();
            _outputHelper.WriteLine($"{timer.ElapsedTicks}");
        }

        public static IEnumerable<object[]> InputAndOutput()
        {
            return new List<object[]>
            {
                new object[]{"1.0", "1", 0},
                new object[]{"0.1", "1.1", -1},
                new object[]{"1.0.1", "1", 1},
                new object[]{"7.5.2.4", "7.5.3", -1},
                new object[]{"1.01", "1.001", 0},
                new object[]{"0.9.9.9.9.9.9.9.9.9.9.9.9", "1.0", -1},
                new object[]{
                    "19.8.3.17.5.01.0.0.4.0.0.0.0.0.0.0.0.0.0.0.0.0.00.0.0.0.0.0.0.0.0.0.0.0.0.0.000000.00.0.0.0.0.0.0.000000",
                    "19.8.3.17.5.01.0.0.4.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.00.0.0000.0.0.0.0.0.0.0.0.0.0.0.0.000000", 
                    0},
            };
        }
    }
}