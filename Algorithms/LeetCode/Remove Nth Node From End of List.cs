using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 19. Remove Nth Node From End of List
     * Given a linked list, remove the n-th node from the end of list and return its head.
     * 
     * Example:
     * 
     * Given linked list: 1->2->3->4->5, and n = 2.
     * 
     * After removing the second node from the end, the linked list becomes 1->2->3->5.
     * Note:
     * 
     * Given n will always be valid.
     */
    public class RemoveNthNodeFromEndOfList
    {
        // Your runtime beats 13.38 % of csharp submissions.
        // Your memory usage beats 64.56 % of csharp submissions.
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0)
            {
                next = head
            };
            ListNode p = dummy;
            ListNode q = dummy;

            for (int i = 1; i < n + 1; i++)
            {
                q = q.next;
            }
            // Then distance bewteen p and q remains n
            while (q.next != null)
            {
                p = p.next;
                q = q.next;
            }
            p.next = p.next.next;
            return dummy.next;
        }
    }
}
