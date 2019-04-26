using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 24. Swap Nodes in Pairs
     * 
     * Given a linked list, swap every two adjacent nodes and return its head.
     * You may not modify the values in the list's nodes, only nodes itself may be changed.
     * 
     * Example:
     * 
     * Given 1->2->3->4, you should return the list as 2->1->4->3.
     */
    public class SwapNodesInPairs
    {
        // Your runtime beats 57.05 % of csharp submissions.
        // Your memory usage beats 27.96 % of csharp submissions.
        public ListNode SwapPairs(ListNode head)
        {
            // The only difficulty of the problem is to carefully change the
            // "next" of each node. It's not easy to write it right the 
            // first time, so some tests are preferred.
            if (head == null) return null;
            ListNode ret = head.next ?? head;
            ListNode current = head;
            ListNode last = new ListNode(-1);
            while (current != null)
            {
                ListNode p = current;
                ListNode q = current.next;
                if (q == null) break;
                ListNode tmp = q.next;
                q.next = p;
                p.next = tmp;
                last.next = q;
                last = current;
                current = p.next;
            }
            return ret;
        }
    }
}
