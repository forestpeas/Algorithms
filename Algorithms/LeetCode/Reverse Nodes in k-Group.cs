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
        // Your runtime beats 59.09 % of csharp submissions.
        // Your memory usage beats 50.00 % of csharp submissions.
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
            ListNode prevLastAfterReversed = null; // the pprevious group's last node(after reversed)
            for (int swapTimes = length / k; swapTimes > 0; swapTimes--)
            {
                ListNode prev = null;
                ListNode curr = firstBeforeReversed;
                ListNode next = null;
                for (int i = 1; i <= k; i++) // handle every k-group
                {
                    if (i == k && prevLastAfterReversed != null) // if this is the last node of this group
                    {
                        prevLastAfterReversed.next = curr;
                    }
                    next = curr.next;
                    curr.next = prev;

                    prev = curr;
                    curr = next;
                }

                //if all groups are reversed，remember those remaining nodes at the end
                if (swapTimes == 1)
                {
                    firstBeforeReversed.next = next;
                }

                prevLastAfterReversed = firstBeforeReversed;
                firstBeforeReversed = next;
            }

            return ret;
        }
    }
}
