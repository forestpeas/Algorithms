﻿using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    public class RemoveNthNodeFromEndOfList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode p = new ListNode(0)
            {
                next = head
            }, q = head;
            for (int i = 1; i < n; i++)
            {
                q = q.next;
            }

            while (q.next != null)
            {
                p = p.next;
                q = q.next;
            }
            if (p.next == head)
            {
                return head.next;
            }
            p.next = p.next.next;
            return head;
        }
    }
}
