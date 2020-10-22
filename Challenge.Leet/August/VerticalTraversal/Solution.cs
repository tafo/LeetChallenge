using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Challenge.Leet.Common;
using Challenge.Leet.Helper;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.August.VerticalTraversal
{
    public class Coordinate
    {
        public Coordinate(int vertical, int horizontal, int value)
        {
            Vertical = vertical;
            Horizontal = horizontal;
            Value = value;
        }
        public int Vertical;
        public int Horizontal;
        public int Value;
    }

    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Solution
    {
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public IList<IList<int>> Run(TreeNode root)
        {
            var coordinates = new List<Coordinate>{new Coordinate(0, 0, root.val)};
            Generation(new List<TreeNode>{root});
            var output = coordinates
                .GroupBy(x => x.Horizontal)
                .OrderBy(x => x.Key)
                .Select(g => g.OrderByDescending(x => x.Vertical).ThenBy(x => x.Value).Select(x => x.Value).ToList())
                .Cast<IList<int>>()
                .ToList();

            return output;

            void Generation(List<TreeNode> current)
            {
                var index = 0;
                while (current.Count > 0)
                {
                    var next = new List<TreeNode>();
                    foreach (var node in current)
                    {
                        var coordinate = coordinates[index++];
                        if (node.left != null)
                        {
                            next.Add(node.left);
                            coordinates.Add(new Coordinate(coordinate.Vertical - 1, coordinate.Horizontal -1, node.left.val));
                        }

                        if (node.right == null) continue;

                        next.Add(node.right);
                        coordinates.Add(new Coordinate(coordinate.Vertical - 1, coordinate.Horizontal + 1, node.right.val));
                    }

                    current = next;
                }
            }
        }
    }

    public class Test
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 },
            new[] { 4 },
            new[] { 2 },
            new[] { 1, 5, 6 },
            new[] { 3 },
            new[] { 7 }
            )]
        public void Check(int[] values, int[] a, int[] b, int[] c, int[] d, int[] e)
        {
            var expectedOutput = new List<IList<int>>
            {
                new List<int>(a),
                new List<int>(b),
                new List<int>(c),
                new List<int>(d),
                new List<int>(e)
            };
            var root = TreeNodeHelper.Load(values);
            var solution = new Solution();
            solution.Run(root).Should().BeEquivalentTo(expectedOutput);
        }
    }
}