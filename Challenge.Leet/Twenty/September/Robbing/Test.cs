using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Challenge.Leet.Twenty.September.Robbing
{
    /// <summary>
    /// Example 1:
    /// 
    /// Input: nums = [1,2,3,1]
    /// Output: 4
    /// Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
    /// Total amount you can rob = 1 + 3 = 4.
    /// Example 2:
    /// 
    /// Input: nums = [2,7,9,3,1]
    /// Output: 12
    /// Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
    /// Total amount you can rob = 2 + 9 + 1 = 12.
    /// </summary>
    public class Test
    {
        //[Theory]
        //[MemberData(nameof(InputAndOutputList))]
        public void Check(int[] nums, int expectedOutput)
        {
            var solution = new Solution();
            var actualOutput = solution.Rob(nums);
            actualOutput.Should().Be(expectedOutput);
        }

        public static IEnumerable<object[]> InputAndOutputList()
        {
            return new List<object[]>
            {
                new object[] {Array.Empty<int>(), 0},
                new object[] {new[] {1}, 1},
                new object[] {new[] {2, 1, 1, 2}, 4},
                new object[] {new[] {1, 2, 3, 1}, 4},
                new object[] {new[] {2, 7, 9, 3, 1}, 12}
            };
        }
    }
}