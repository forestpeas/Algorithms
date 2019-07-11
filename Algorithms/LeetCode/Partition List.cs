using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 86. Partition List
     * 
     * Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
     * You should preserve the original relative order of the nodes in each of the two partitions.
     * 
     * Example:
     * 
     * Input: head = 1->4->3->2->5->2, x = 3
     * Output: 1->2->2->4->3->5
     */
    public class PartitionList
    {
        public ListNode Partition(ListNode head, int x)
        {
            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode firstGreaterNode = null;
            // "i" is the slow runner that points to the rightmost node of the left smaller part of the list.
            // "j" is the fast runner that points to the rightmost node of the right greater part of the list.
            ListNode i = dummyHead;
            ListNode j = null;
            ListNode node = head;
            for (; node != null; node = node.next)
            {
                if (node.val >= x)
                {
                    firstGreaterNode = node;
                    break;
                }
                i = node;
            }
            if (node == null) return head;
            j = node;
            node = node.next;
            for (; node != null; node = node.next)
            {
                if (node.val < x)
                {
                    i.next = node;
                    i = node;
                    j.next = node.next;
                }
                else
                {
                    j = node;
                }
            }
            i.next = firstGreaterNode;
            return dummyHead.next;
        }
    }
}
