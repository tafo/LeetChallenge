using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Challenge.July.AddBinary
{
    public class Test
    {
        [Fact]
        public void TestCase_IsValid()
        {
            // The maximum length of an operand is 30.
            // Because the maximum length of the bits of an integer is 31.
            var test = new TestCase(30);
            var leftNumber = Convert.ToInt32(test.LeftOperand, 2);
            var rightNumber = Convert.ToInt32(test.RightOperand, 2);
            var sum = leftNumber + rightNumber;
            test.Expectation.Should().Be(Convert.ToString(sum, 2));
        }

        [Fact]
        public void AddBinaryByConvert()
        {
            var test = new TestCase();
            new Solution().AddBinaryByConvert(test.LeftOperand, test.RightOperand).Should().Be(test.Expectation);

            // Upper Limit
            var maxOperand = string.Concat(Enumerable.Repeat('1', 4000));
            new Solution().AddBinaryByConvert(maxOperand, maxOperand).Should().Be(maxOperand + '0');
        }
    }
}