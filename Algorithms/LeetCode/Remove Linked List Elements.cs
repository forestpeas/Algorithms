using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 203. Remove Linked List Elements
     * 
     * Remove all elements from a linked list of integers that have value val.
     * 
     * Example:
     * 
     * Input:  1->2->6->3->4->5->6, val = 6
     * Output: 1->2->3->4->5
     */
    public class RemoveLinkedListElements
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode prev = dummyHead;
            ListNode curr = dummyHead.next;
            while (curr != null)
            {
                if (curr.val == val)
                {
                    prev.next = curr.next;
                }
                else
                {
                    prev = curr;
                }

                curr = curr.next;
            }
            return dummyHead.next;
        }
    }
}
