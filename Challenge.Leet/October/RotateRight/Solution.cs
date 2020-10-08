using System.Collections.Generic;
using Challenge.Leet.Common;

namespace Challenge.Leet.October.RotateRight
{
    public class Solution
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;
            if (head.next == null || k == 0) return head;

            var nodeList = new List<ListNode>();
            var node = head;
            while (node != null)
            {
                nodeList.Add(node);
                node = node.next;
            }

            if (k >= nodeList.Count)
            {
                k %= nodeList.Count;
            }

            if (k == 0) return head;

            nodeList[^1].next = head;
            nodeList[^(k + 1)].next = null;

            return nodeList[^k];
        }
    }
}