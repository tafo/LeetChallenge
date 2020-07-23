using System.Collections.Generic;
using System.Linq;

namespace Challenge.Leet.July.ZigZagLevelOrder
{
    public class TestCase
    {
        public int?[] NodeValues;
        public TreeNode Root;
        public IList<IList<int>> Expectation;

        public TestCase(int?[] nodeValues)
        {
            NodeValues = nodeValues;
            Root = nodeValues.ToTreeNode();
            Expectation = new List<IList<int>>();
            var counter = 0;
            var level = 1;
            var reverse = 0;
            while (counter < nodeValues.Length)
            {
                var values = nodeValues
                    .Skip(level - 1)
                    .Take(level)
                    .Where(x => x.HasValue)
                    .Select(x => x.Value);
                Expectation.Add((reverse++ & 1) == 1 ? values.Reverse().ToList() : values.ToList());
                counter += level;
                level *= 2;
            }
        }

        public override string ToString()
        {
            return NodeValues.ToText();
        }
    }
}