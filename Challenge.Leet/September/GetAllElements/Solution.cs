using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.September.GetAllElements
{
    [SuppressMessage("ReSharper", "ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator")]
    public class Solution
    {
        [SuppressMessage("ReSharper", "TailRecursiveCall")]
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            var output = new List<int>();
            AddToOutput(root1);
            AddToOutput(root2);
            output.Sort();
            return output;

            void AddToOutput(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                output.Add(node.val);
                if (node.left != null)
                {
                    AddToOutput(node.left);
                }

                if (node.right != null)
                {
                    AddToOutput(node.right);
                }
            }
        }
    }
}