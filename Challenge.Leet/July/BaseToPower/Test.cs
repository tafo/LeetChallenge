using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.July.BaseToPower
{
    public class Test
    {
        public int MaxPower = int.MaxValue >> 1; // +(2 ^ 31) - 1
        public int MinPower = int.MinValue >> 1; // -(2 ^ 31)

        public const double MaxBase = 99;
        public const double MinBase = -99;

        public IEnumerable<TestCase> Tests { get; set; }

        public Test()
        {
            var bases = new List<double> { MaxBase, 1.9, 1, 0.5, 0, -0.5, -1, -1.9, MinBase };
            var powers = new List<int> { MaxPower, MaxPower - 1, 1, 0, -1, MinPower + 1, MinPower };
            Tests = from b in bases from p in powers select new TestCase(b, p);
        }

        [Fact]
        public void Power()
        {
            foreach (var test in Tests)
            {
                new Solution().Power(test.Base, test.Power).Round().Should().Be(test.Expectation.Round());
            }
        }
    }
}