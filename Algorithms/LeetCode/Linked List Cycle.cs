using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 141. Linked List Cycle
     * 
     * Given a linked list, determine if it has a cycle in it.
     * For more illustration, refer to https://leetcode.com/problems/linked-list-cycle/
     */
    public class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            // The fast-runner will always catch up with
            // the slow-runner if there is a cycle.
            if (head == null) return false;
            var slow = head;
            var fast = head;
            do
            {
                slow = slow.next;
                fast = fast.next?.next;
                if (fast == null) return false;
            } while (slow != fast);
            return true;
        }
    }
}
