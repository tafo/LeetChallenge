using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.July.ZigZagLevelOrder
{
    public class Test
    {
        public Prehistoric Prehistoric = new Prehistoric();

        public TestCase[] Tests =
        {
            new TestCase(new int?[] {3, 9, 20, null, null, 15, 7}),
            new TestCase(new int?[] { }),
            new TestCase(new int?[] {1}),
            new TestCase(new int?[] {1, 11}),
            new TestCase(new int?[] {1, 11, null}),
            new TestCase(new int?[] {1, null, 12}),
            new TestCase(new int?[] {1, 11, 12, 21, 22, 23, 24})
        };

        [Fact]
        public void CheckAll()
        {
            Array.ForEach(Tests, test => Prehistoric.Run(test.Root).Should().BeEqualTo(test.Expectation, $"{test}"));
        }

        [Fact]
        public void CheckThis()
        {
            var test = Tests[0];
            var expectation = new List<IList<int>>()
            {
                new List<int> {3},
                new List<int> {20, 9},
                new List<int> {15, 7}
            };
            Prehistoric.Run(test.Root).Should().BeEqualTo(expectation, $"{test}");
        }
    }
}