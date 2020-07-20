using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Challenge.July.MostFrequentElements
{
    public class Test
    {
        private Solution Solution { get; }
        public List<TestCase> TestCases { get; set; }

        public Test()
        {
            Solution = new Solution();
            TestCases = new List<TestCase>
            {
                new TestCase(Enumerable.Range(-11, 22).SelectMany(Enumerable.Repeat).Mix().ToArray(), 10),
                new TestCase(Enumerable.Range(-101, 202).SelectMany(Enumerable.Repeat).Mix().ToArray(), 10),
                new TestCase(Enumerable.Range(-1001, 2002).SelectMany(Enumerable.Repeat).Mix().ToArray(), 10),
            };
        }

        [Fact]
        public void TestTopKFrequent()
        {
            foreach (var test in TestCases)
            {
                test.Size.Should().BeGreaterOrEqualTo(0);
            }

            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < 10; i++)
            {
                foreach (var test in TestCases)
                {
                    RunLinq(test.Numbers, test.Size).Should().BeEquivalentTo(test.Expectation);
                }
            }

            timer.Stop();
            Debug.WriteLine($"Linq = {timer.ElapsedTicks}");

            timer.Reset();
            timer.Start();
            for (var i = 0; i < 10; i++)
            {
                foreach (var test in TestCases)
                {
                    Solution.TopKFrequent(test.Numbers, test.Size).Should().BeEquivalentTo(test.Expectation);
                }
            }

            timer.Stop();
            Debug.WriteLine($"Code = {timer.ElapsedTicks}");
        }

        public int[] RunLinq(int[] nums, int k)
        {
            return nums.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(k).Select(x => x.Key).ToArray();
        }
    }
}