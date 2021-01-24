using System;
using Challenge.Leet.Common;

namespace Challenge.Leet.Twenty.October.MinimumDepthOfBinaryTree
{
    /// <summary>
    /// https://leetcode.com/explore/challenge/card/october-leetcoding-challenge/562/week-4-october-22nd-october-28th/3504/
    /// </summary>
    public class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null) return MinDepth(root.right) + 1;
            if (root.right == null) return MinDepth(root.left) + 1;
            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }
    }
}