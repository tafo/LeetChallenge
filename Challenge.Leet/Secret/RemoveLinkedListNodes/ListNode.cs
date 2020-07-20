using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.Secret.RemoveLinkedListNodes
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}