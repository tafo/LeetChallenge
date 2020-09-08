﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.September.GetAllElements
{
    [SuppressMessage("ReSharper", "ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator")]
    public class Solution
    {
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var output = new List<int>();
            AddNodeValuesToOutput(root1);
            AddNodeValuesToOutput(root2);
            output.Sort();
            return output;

            void AddNodeValuesToOutput(TreeNode root)
            {
                var currentNodes = new List<TreeNode> {root};
                var nextNodes = new List<TreeNode>();
                while (currentNodes.Count > 0)
                {
                    foreach (var currentNode in currentNodes)
                    {
                        if (currentNode == null) continue;
                        output.Add(currentNode.val);
                        if (currentNode.left != null)
                        {
                            nextNodes.Add(currentNode.left);
                        }

                        if (currentNode.right != null)
                        {
                            nextNodes.Add(currentNode.right);
                        }
                    }

                    currentNodes = new List<TreeNode>();
                    if (nextNodes.Count == 0) continue;

                    currentNodes = nextNodes;
                    nextNodes = new List<TreeNode>();
                }
            }
        }
    }
}