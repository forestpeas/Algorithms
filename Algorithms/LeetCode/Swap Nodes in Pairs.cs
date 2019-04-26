using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    public class SwapNodesInPairs
    {
        // Your runtime beats 57.05 % of csharp submissions.
        // Your memory usage beats 27.96 % of csharp submissions.
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null) return null;
            ListNode ret = head.next == null ? head : head.next;
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
