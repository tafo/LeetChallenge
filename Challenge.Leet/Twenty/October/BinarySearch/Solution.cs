namespace Challenge.Leet.Twenty.October.BinarySearch
{
    public class Solution
    {
        public int BinarySearch(int[] nums, int target)
        {
            var leftIndex = 0;
            var rightIndex = nums.Length - 1;
            while (leftIndex <= rightIndex)
            {
                var index = (leftIndex + rightIndex) / 2;
                var value = nums[index];
                if (value < target)
                {
                    leftIndex = index + 1;
                }
                else if (value > target)
                {
                    rightIndex = index - 1;
                }
                else
                {
                    return index;
                }
            }

            return -1;
        }
    }
}