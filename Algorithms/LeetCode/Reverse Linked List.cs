using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 206. Reverse Linked List
     * 
     * Reverse a singly linked list.
     * 
     * Example:
     * 
     * Input: 1->2->3->4->5->NULL
     * Output: 5->4->3->2->1->NULL
     * 
     * Follow up:
     * 
     * A linked list can be reversed either iteratively or recursively. Could you implement both?
     */
    public class ReverseLinkedList
    {
        // Iterative
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        // Recursive
        public ListNode ReverseListRecursive(ListNode head)
        {
            if (head == null) return null;
            return ReverseListCore(head);
        }

        private ListNode ReverseListCore(ListNode head)
        {
            if (head.next == null) return head;
            ListNode tail = ReverseListCore(head.next);
            head.next.next = head;
            head.next = null;
            return tail;
        }
    }
}
