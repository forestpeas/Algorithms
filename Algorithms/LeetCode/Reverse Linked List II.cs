using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 92. Reverse Linked List II
     * 
     * Reverse a linked list from position m to n. Do it in one-pass.
     * Note: 1 ≤ m ≤ n ≤ length of list.
     * 
     * Example:
     * 
     * Input: 1->2->3->4->5->NULL, m = 2, n = 4
     * Output: 1->4->3->2->5->NULL
     */
    public class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            var dummyHead = new ListNode(0) { next = head };
            var node = dummyHead;
            int position = 0;
            m--;
            while (position < m) // No need for null check because 1 ≤ m ≤ n ≤ length of list.
            {
                node = node.next;
                position++;
            }
            var beforeReversed = node;
            var prev = node;
            node = node.next; // node at position m
            position++;
            var reversedHead = node;
            while (position <= n)
            {
                var next = node.next;
                node.next = prev;
                prev = node;
                node = next;
                position++;
            }
            beforeReversed.next = prev;
            reversedHead.next = node;
            return dummyHead.next;
        }
    }
}
