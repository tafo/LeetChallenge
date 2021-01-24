using System.Collections.Generic;

namespace Challenge.Leet.Twenty.August.FindDuplicates
{
    public class TheSolution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            var output = new List<int>();
            var set = new TheHashSet();
            foreach (var number in nums)
            {
                if (set.Contains(number))
                {
                    output.Add(number);
                }
                else
                {
                    set.Add(number);
                }
            }

            return output;
        }
    }
}