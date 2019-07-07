using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 82. Remove Duplicates from Sorted List II
     * 
     * Given a sorted linked list, delete all nodes that have duplicate numbers,
     * leaving only distinct numbers from the original list.
     * 
     * Example 1:
     * 
     * Input: 1->2->3->3->4->4->5
     * Output: 1->2->5
     * 
     * Example 2:
     * 
     * Input: 1->1->1->2->3
     * Output: 2->3
     */
    public class RemoveDuplicatesFromSortedListII
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            // Similar to "83. Remove Duplicates from Sorted List".
            // "i" is the slow-runner and "j" is the fast-runner.
            if (head == null) return head;
            bool remove = false;
            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode i = dummyHead;
            for (ListNode j = head; ; j = j.next)
            {
                if (j.next == null) break;
                if (j.next.val == j.val)
                {
                    remove = true;
                }
                else
                {
                    if (remove)
                    {
                        i.next = j.next;
                    }
                    else
                    {
                        i = j;
                    }
                    remove = false;
                }
            }
            if (remove) i.next = null; // For example: Input: 1->3->3->3->3
            return dummyHead.next;
        }
    }
}
