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
    }
}