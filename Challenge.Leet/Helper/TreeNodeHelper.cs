using System.Collections.Generic;

namespace Challenge.Leet.Helper
{
    public class TreeNodeHelper
    {
        public static TreeNode Load(int[] values)
        {
            if (values.Length == 0) return null;
            var i = 0;
            var root = new TreeNode(values[i]);
            var currentGeneration = new List<TreeNode> {root};
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

        public static int[] Unload(TreeNode root)
        {
            var outputList = new List<int>();
            PopValue(root);
            void PopValue(TreeNode node)
            {
                if (node == null) return;
                outputList.Add(node.val);
                if (node.left != null)
                {
                    PopValue(node.left);
                }

                if (node.right != null)
                {
                    PopValue(node.right);
                }
            }

            return outputList.ToArray();
        }
    }
}