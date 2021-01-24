using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Challenge.Leet.Twenty.August.FindDuplicates
{
    public class Test
    {
        private readonly ITestOutputHelper _testOutput;
        public Test(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(new[] {4, 3, 2, 7, 8, 2, 3, 1}, new[] {2, 3})]
        public void CheckTheSolution(int[] input, int[] output)
        {
            var timer = Stopwatch.StartNew();
            var solution = new TheSolution();
            solution.FindDuplicates(input).Should().BeEquivalentTo(output);
            timer.Stop();

            _testOutput.WriteLine($"{timer.ElapsedTicks}");
        }

        [Theory]
        [InlineData(new[] {4, 3, 2, 7, 8, 2, 3, 1}, new[] {2, 3})]
        public void CheckTidiSolution(int[] input, int[] output)
        {
            var timer = Stopwatch.StartNew();
            var solution = new TidiSolution();
            solution.FindDuplicates(input).Should().BeEquivalentTo(output);
            timer.Stop();

            _testOutput.WriteLine($"{timer.ElapsedTicks}");
        }
    }
}