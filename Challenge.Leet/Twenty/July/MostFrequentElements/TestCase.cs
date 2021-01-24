using System.Linq;

namespace Challenge.Leet.Twenty.July.MostFrequentElements
{
    public class TestCase
    {
        public TestCase(int[] numbers, int size)
        {
            Numbers = numbers;
            Size = size;
            Expectation = numbers
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Take(size)
                .Select(x => x.Key)
                .ToArray();
        }

        public int[] Numbers { get; set; }
        public int Size { get; set; }
        public int[] Expectation { get; set; }
    }
}