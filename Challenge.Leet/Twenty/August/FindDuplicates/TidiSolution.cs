using System;
using System.Collections.Generic;

namespace Challenge.Leet.Twenty.August.FindDuplicates
{
    public class TidiSolution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var output = new List<int>();
            Array.Sort(nums);
            var previous = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == previous)
                {
                    output.Add(nums[i]);
                }

                previous = nums[i];
            }

            return output;
        }
    }
}