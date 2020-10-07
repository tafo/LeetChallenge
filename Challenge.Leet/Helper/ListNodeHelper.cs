using System;
using System.Collections.Generic;
using System.Linq;
using Challenge.Leet.Common;

namespace Challenge.Leet.Helper
{
    public class ListNodeHelper
    {
        public static ListNode Load(int[] values)
        {
            if (values.Length == 0) return null;
            var head = new ListNode(values.First());
            var previous = head;
            foreach (var value in values.Skip(1))
            {
                var current = new ListNode(value);
                previous.next = current;
                previous = current;
            }

            return head;
        }

        public static int[] Unload(ListNode head)
        {
            if (head == null) return Array.Empty<int>();

            var values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }

            return values.ToArray();
        }
    }
}