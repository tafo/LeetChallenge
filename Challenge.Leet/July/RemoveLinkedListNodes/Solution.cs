using Challenge.Leet.Common;

namespace Challenge.Leet.July.RemoveLinkedListNodes
{
    /** 
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

    /// <summary>
    ///
    /// TITLE
    ///
    ///     Remove Linked List Elements
    ///
    /// DESCRIPTION
    ///
    ///     Remove all elements from a linked list of integers that have value val.
    ///
    /// EXAMPLE
    ///
    ///     Input:  1->2->6->3->4->5->6, val = 6
    ///     Output: 1->2->3->4->5
    ///
    /// GIVEN NODE DEFINITION
    ///
    ///     public class ListNode {
    ///         public int val;
    ///         public ListNode next;
    ///         public ListNode(int val=0, ListNode next=null) {
    ///             this.val = val;
    ///             this.next = next;
    ///         }
    ///     }
    /// 
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// Runtime: 112 ms
        /// Memory Usage: 28.1 MB
        /// </summary>
        public ListNode RemoveElementsByDoWhile(ListNode head, int val)
        {
            if (head == null) return null;
            var node = head;
            ListNode previousNode = null;
            do
            {
                if (node.val == val)
                {
                    if (previousNode == null)
                    {
                        head = node = node.next;
                        continue;
                    }

                    previousNode.next = node.next; // Break = Delete
                }
                else
                {
                    previousNode = node;
                }

                node = node.next;
            } while (node != null);

            return head;
        }

        /// <summary>
        /// Runtime: 112 ms
        /// Memory Usage: 27.7 MB
        /// </summary>
        public ListNode RemoveElementsByWhile(ListNode head, int val)
        {
            var current = head;
            ListNode previous = null;
            while (current != null)
            {
                if (current.val == val)
                {
                    current = current.next;
                    if (previous == null)
                    {
                        head = current;
                    }
                    else
                    {
                        previous.next = current; // Break = Delete
                    }
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
            }

            return head;
        }

        public ListNode RemoveElementsByIgnoringHeads(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            if (head == null) return null;

            var previous = head;
            var node = head.next;

            while (node != null)
            {
                if (node.val == val)
                {
                    previous.next = node.next;
                }
                else
                {
                    previous = node;
                }
                node = node.next;
            }

            return head;
        }
    }
}