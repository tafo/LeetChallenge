namespace Challenge.Leet.September.SumRootToLeaf
{
    public class Solution
    {
        public int SumRootToLeaf(TreeNode root)
        {
            return FindTotal(root, 0);

            static int FindTotal(TreeNode node, int total)
            {
                if (node == null) return 0;
                total = total * 2 + node.val;
                if (node.left == null && node.right == null)
                {
                    return total;
                }

                return FindTotal(node.left, total) + FindTotal(node.right, total);
            }
        }
    }
}