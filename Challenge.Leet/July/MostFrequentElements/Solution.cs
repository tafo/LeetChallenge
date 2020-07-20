using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.July.MostFrequentElements
{
    /// <summary>
    /// 
    /// TITLE
    ///
    ///     Top K Frequent Elements
    /// 
    /// DESCRIPTION
    ///
    ///     Given a non-empty array of integers, return the k most frequent elements
    ///
    /// EXAMPLE
    ///
    ///     Example 1
    ///     Input: nums = [1,1,1,2,2,3], k = 2
    ///     Output: [1,2]
    ///
    ///     Example 2
    ///     Input: nums = [1], k = 1
    ///     Output: [1]
    ///
    ///  NOTE
    /// 
    ///     You may assume k is always valid, 1 ≤ k ≤ number of unique elements
    ///     Your algorithm's time complexity must be better than O(n log n), where n is the array's size
    ///     It's guaranteed that the answer is unique
    ///     You can return the answer in any order
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Solution
    {
        /// <summary>
        /// ToDo: Optimize
        /// </summary>
        public int[] TopKFrequent(int[] nums, int k)
        {
            var set = new SortedList<int, int>();
            foreach (var num in nums)
            {
                if (!set.TryAdd(num, 1))
                {
                    set[num]++;
                }
            }

            var numbers = new int[set.Count];
            var counts = new int[set.Count];
            set.Keys.CopyTo(numbers, 0);
            set.Values.CopyTo(counts, 0);
            Array.Sort(counts, numbers);
            var result = new int[k];
            for (var i = 0; i < k; i++)
            {
                result[i] = numbers[numbers.Length - 1 - i];
            }

            return result;
        }
    }
}

