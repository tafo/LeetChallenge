using System.Diagnostics.CodeAnalysis;
using Challenge.Leet.Common;

namespace Challenge.Leet.Twenty.October.InsertIntoBST
{
    /// <summary>
    /// https://leetcode.com/explore/featured/card/october-leetcoding-challenge/559/week-1-october-1st-october-7th/3485/
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Solution
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                root = new TreeNode(val);
                return root;
            }

            var node = root;
            while (node != null)
            {
                if (val < node.val)
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(val);
                        break;
                    }

                    node = node.left;
                }
                else
                {
                    if (node.right == null)
                    {
                        node.right = new TreeNode(val);
                        break;
                    }

                    node = node.right;
                }
            }
            return root;
        }
    }
}