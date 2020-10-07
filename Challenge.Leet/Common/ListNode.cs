using System.Diagnostics.CodeAnalysis;

namespace Challenge.Leet.Common
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