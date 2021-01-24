using System.Collections.Generic;
using System.Linq;
using Challenge.Leet.Common;

namespace Challenge.Leet.Twenty.July.ZigZagLevelOrder
{
    /// <summary>
    /// TITLE
    ///
    ///     Binary Tree Zigzag Level Order Traversal
    ///
    /// DETAIL
    ///
    ///     Given a binary tree, return the zigzag level order traversal of its nodes' values
    ///         (ie, from left to right, then right to left for the next level and alternate between)
    ///
    /// EXAMPLES
    ///
    ///     Given binary tree [3,9,20,null,null,15,7],
    ///         
    ///             3
    ///            / \
    ///           9  20
    ///             /  \
    ///            15   7
    /// 
    ///     return its zigzag level order traversal as
    ///     [
    ///         [3],
    ///         [20,9],
    ///         [15,7]
    ///     ]
    /// 
    /// GIVEN
    ///
    ///     public class TreeNode
    ///     {
    ///         public int val;
    ///         public TreeNode left;
    ///         public TreeNode right;
    ///         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
    ///         {
    ///             this.val = val;
    ///             this.left = left;
    ///             this.right = right;
    ///         }
    ///     }
    ///     
    /// </summary>
    public class Prehistoric
    {
        public IList<IList<int>> Run(TreeNode root)
        {
            var output = new List<IList<int>>();

            if (root == null) return output;

            var values = new List<int> { root.val };
            var parentNodes = new List<TreeNode> { root };
            var reverse = 0;
            while (parentNodes.Count > 0)
            {
                if ((reverse++ & 1) == 1) values.Reverse();
                output.Add(values);
                values = new List<int>();
                var parents = parentNodes.ToList();
                parentNodes = new List<TreeNode>();
                foreach (var parent in parents)
                {
                    if (parent.left != null)
                    {
                        values.Add(parent.left.val);
                        parentNodes.Add(parent.left);
                    }

                    if (parent.right == null) continue;

                    values.Add(parent.right.val);
                    parentNodes.Add(parent.right);
                }
            }

            return output;
        }
    }
}