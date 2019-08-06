using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 25. Reverse Nodes in k-Group
     * 
     * Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
     * k is a positive integer and is less than or equal to the length of the linked list. 
     * If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
     * 
     * Example:
     * 
     * Given this linked list: 1->2->3->4->5
     * 
     * For k = 2, you should return: 2->1->4->3->5
     * 
     * For k = 3, you should return: 3->2->1->4->5
     * 
     * Note:
     * 
     * Only constant extra memory is allowed.
     * You may not alter the values in the list's nodes, only nodes itself may be changed.
     */
    public class ReverseNodesInKGroup
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            // Similar to "24. Swap Nodes in Pairs" but a bit more complex and needs more careful considerations.
            if (k < 2) return head;

            ListNode ret = null;
            ListNode node = head;
            int length = 0; // total nodes
            while (node != null)
            {
                length++;
                if (length == k)
                {
                    ret = node;
                }
                node = node.next;
            }
            if (k > length)
            {
                return head;
            }

            ListNode firstBeforeReversed = head; // the current group's first node(before reversed)
            ListNode prevLastAfterReversed = new ListNode(-1); // the previous group's last node(after reversed)
            ListNode prev = null;
            ListNode curr = firstBeforeReversed;
            ListNode next = null;
            for (int swapTimes = length / k; swapTimes > 0; swapTimes--)
            {
                for (int i = 1; i <= k; i++) // handle every k-group
                {
                    next = curr.next;
                    curr.next = prev;

                    prev = curr;
                    curr = next;
                }

                // now "prev" is the last node of the group(before reversed)
                prevLastAfterReversed.next = prev;

                prevLastAfterReversed = firstBeforeReversed;
                firstBeforeReversed = next;
            }

            // When all groups are reversed，remember those remaining nodes at the end.
            prevLastAfterReversed.next = next;

            return ret;
        }
    }
}
