using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 142. Linked List Cycle II
     * 
     * Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
     * Note: Do not modify the linked list.
     * 
     * Follow-up:
     * Can you solve it without using extra space?
     * 
     * For more illustration, refer to https://leetcode.com/problems/linked-list-cycle-ii/
     */
    public class LinkedListCycleII
    {
        public ListNode DetectCycle(ListNode head)
        {
            // The first step is the same as "Problem 141. Linked List Cycle".
            // When slow meets fast, let x be the distance slow moved.
            // So the distance fast moved is 2x since fast takes two steps each time.
            // Let c be the "circumference" of the cycle, and c be the number of times fast moved around the cycle.
            // So fast moves n*c more than slow.
            // x = 2x - nc
            // x = nc
            // Which means when n = 1 the distance slow moved is equal to the circumference of the cycle.
            // So if slow started at the start of the cycle and move x, it will move exactly one time around the 
            // cycle and be back to the start of the cycle.
            // So letting slow start at the head means slow can't finish the "one-time-round-trip". The distance
            // left for slow to finish its trip is exactly the distance from head to the start of the cycle.
            // If n > 2, the idea is similar. Only this time let slow do a "n-time-round-trip" around the cycle.
            if (head == null) return null;
            var slow = head;
            var fast = head;
            do
            {
                slow = slow.next;
                fast = fast.next?.next;
                if (fast == null) return null;
            } while (slow != fast);

            var node = head;
            while (node != slow)
            {
                node = node.next;
                slow = slow.next;
            }
            return node;
        }
    }
}
