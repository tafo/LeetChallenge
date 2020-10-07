using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Challenge.Leet.Helper;
using FluentAssertions;
using Xunit;

namespace Challenge.Leet.August.PathSum
{
    [SuppressMessage("ReSharper", "TailRecursiveCall")]
    public class Solution
    {
        public int Process(TreeNode root, int sum)
        {
            var output = 0;
            if (root == null) return output;
            var paths = new HashSet<string>();
            Inherit(root, 0, "O", 0);
            return output;
            void Inherit(TreeNode node, int inheritance, string path, int generation)
            {
                var current = node.val + inheritance;
                if (!paths.Contains(path) && current == sum)
                {
                    output++;
                    paths.Add(path);
                }

                if (node.left != null)
                {
                    Inherit(node.left, current, $"{path}L", generation + 1);
                    Inherit(node.left, 0, $"{generation}L", generation + 1);
                }

                if (node.right != null)
                {
                    Inherit(node.right, current, $"{path}R", generation + 1);
                    Inherit(node.right, 0, $"{generation}R", generation + 1);
                }
            }
        }
    }

    public class Test
    {
        [Theory]
        [InlineData(new[] { 10, 5, -3, 3, 2, int.MaxValue, 11, 3, -2, int.MaxValue, 1 }, 8, 3)]
        [InlineData(new int[] { }, 1, 0)]
        [InlineData(new[] { 1, int.MaxValue, 2, int.MaxValue, 3 }, 3, 2)]
        [InlineData(new[] { 0, 1, 1 }, 1, 4)]
        [InlineData(new[] { 1, -2, -3, 1, 3, -2, int.MaxValue, -1 }, -2, 4)]
        public void Check(int[] values, int sum, int expectedOutput)
        {
            var root = TreeNodeHelper.Load(values);
            var solution = new Solution();
            solution.Process(root, sum).Should().Be(expectedOutput);
        }
    }
}