using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 143. Reorder List
     * 
     * Given a singly linked list L: L0→L1→…→Ln-1→Ln,
     * reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…
     * 
     * You may not modify the values in the list's nodes, only nodes itself may be changed.
     * 
     * Example 1:
     * 
     * Given 1->2->3->4, reorder it to 1->4->2->3.
     * 
     * Example 2:
     * 
     * Given 1->2->3->4->5, reorder it to 1->5->2->4->3.
     */
    public class ReorderListSolution
    {
        public void ReorderList(ListNode head)
        {
            // This problem is just an exercise for manipulating linked lists.

            // Find the middle node:
            // 1->2->3->4->5->6
            //          ↑
            // Or: 1->2->3->4->5
            //           ↑
            ListNode slow = head;
            ListNode fast = head?.next;
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }

            // Reverse the right half:
            // 1->2->3->4->5->6
            // becomes
            // 1->2->3->4<-5<-6
            ListNode prev = null;
            ListNode node = slow;
            while (node != null)
            {
                ListNode next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }

            // Let "left" move towards tail and "right" move towards head.
            ListNode left = head;
            ListNode right = prev; // tail node
            ListNode rightPrev = new ListNode(0); // a dummy node
            while (left != null && right != null)
            {
                ListNode leftNext = left.next;
                rightPrev.next = left;
                left.next = right;
                rightPrev = right;
                right = right.next;
                left = leftNext;
            }
            rightPrev.next = null;
        }
    }
}
