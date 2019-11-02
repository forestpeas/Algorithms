using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 382. Linked List Random Node
     * 
     * Given a singly linked list, return a random node's value from the linked list. Each node must
     * have the same probability of being chosen.
     * 
     * Follow up:
     * What if the linked list is extremely large and its length is unknown to you? Could you solve
     * this efficiently without using extra space?
     * 
     * Example:
     * 
     * // Init a singly linked list [1,2,3].
     * ListNode head = new ListNode(1);
     * head.next = new ListNode(2);
     * head.next.next = new ListNode(3);
     * Solution solution = new Solution(head);
     * 
     * // getRandom() should return either 1, 2, or 3 randomly. Each element should have equal probability of returning.
     * solution.getRandom();
     * 
     */
    public class Linked_List_Random_Node
    {
        public class Solution
        {
            private readonly ListNode _head;
            private readonly Random _random = new Random();

            public Solution(ListNode head)
            {
                _head = head;
            }

            public int GetRandom()
            {
                // Reservoir Sampling. https://www.cnblogs.com/snowInPluto/p/5996269.html
                int result = 0;
                ListNode node = _head;
                for (int i = 1; node != null; i++)
                {
                    if (_random.Next(i) == 0) result = node.val;
                    node = node.next;
                }

                return result;
            }
        }
    }
}
