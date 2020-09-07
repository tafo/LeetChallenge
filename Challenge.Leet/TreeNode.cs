using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet
{
    /// <summary>
    ///
    ///     GIVEN
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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode Load(int[] values)
        {
            if (values.Length == 0) return null;
            var i = 0;
            var root = new TreeNode(values[i]);
            var currentGeneration = new List<TreeNode> { root };
            i++;
            while (currentGeneration.Count > 0)
            {
                var nextGeneration = new List<TreeNode>();
                foreach (var parentNode in currentGeneration)
                {
                    if (i == values.Length) break;
                    if (values[i] != int.MaxValue)
                    {
                        var leftNode = new TreeNode(values[i]);
                        parentNode.left = leftNode;
                        nextGeneration.Add(leftNode);
                    }
                    i++;

                    if (i == values.Length) break;
                    if (values[i] != int.MaxValue)
                    {
                        var rightNode = new TreeNode(values[i]);
                        parentNode.right = rightNode;
                        nextGeneration.Add(rightNode);
                    }
                    i++;
                }

                currentGeneration = nextGeneration;
            }

            return root;
        }
    }
}