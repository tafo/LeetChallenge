using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.Secret.RemoveLinkedListNodes
{
    public class TestCase
    {
        public int Count;
        public int NumberToRemove;
        public IEnumerable<int> Numbers;
        public IEnumerable<int> ExpectedNumbers;
        public ListNode Head;

        public TestCase(int count, int numberToRemove)
        {
            Count = count;
            NumberToRemove = numberToRemove;
            Numbers = Enumerable.Range(0, 1000).Select(x => x % NumberToRemove + 1);
            ExpectedNumbers = Numbers.Where(x => x != NumberToRemove);
        }
    }
}