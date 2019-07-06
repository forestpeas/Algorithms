using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 83. Remove Duplicates from Sorted List
     * 
     * Given a sorted linked list, delete all duplicates such that each element appear only once.
     * 
     * Example 1:
     * 
     * Input: 1->1->2
     * Output: 1->2
     * 
     * Example 2:
     * 
     * Input: 1->1->2->3->3
     * Output: 1->2->3
     */
    public class RemoveDuplicatesFromSortedList
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            // Similar to "26. Remove Duplicates from Sorted Array".
            // "i" is the slow-runner and "j" is the fast-runner.
            if (head == null) return head;
            ListNode i = head;
            for (ListNode j = head.next; j != null; j = j.next)
            {
                if (i.val != j.val)
                {
                    i.next = j;
                    i = j;
                }
            }
            i.next = null; // For example: Input: 1->3->3->3->3
            return head;
        }
    }
}
