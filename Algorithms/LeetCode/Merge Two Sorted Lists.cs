using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 21. Merge Two Sorted Lists
     * 
     * Merge two sorted linked lists and return it as a new list.
     * The new list should be made by splicing together the nodes of the first two lists.
     * 
     * Example:
     * 
     * Input: 1->2->4, 1->3->4
     * Output: 1->1->2->3->4->4
     */
    public class MergeTwoSortedLists
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode p = l1;
            ListNode q = l2;
            ListNode merged = new ListNode(1);
            ListNode dummy = merged;
            while (p != null && q != null)
            {
                if (p.val < q.val)
                {
                    merged.next = p;
                    p = p.next;
                    merged = merged.next;
                }
                else
                {
                    merged.next = q;
                    q = q.next;
                    merged = merged.next;
                }
            }
            merged.next = q ?? p;

            return dummy.next;
        }
    }
}
