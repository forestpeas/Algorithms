﻿using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 328. Odd Even Linked List
     * 
     * Given a singly linked list, group all odd nodes together followed by the even nodes.
     * Please note here we are talking about the node number and not the value in the nodes.
     * 
     * You should try to do it in place. The program should run in O(1) space complexity and
     * O(nodes) time complexity.
     * 
     * Example 1:
     * 
     * Input: 1->2->3->4->5->NULL
     * Output: 1->3->5->2->4->NULL
     * 
     * Example 2:
     * 
     * Input: 2->1->3->5->6->4->7->NULL
     * Output: 2->3->6->7->1->5->4->NULL
     * 
     * Note:
     * The relative order inside both the even and odd groups should remain as it was in the input.
     * The first node is considered odd, the second node even and so on ...
     */
    public class Odd_Even_Linked_List
    {
        public ListNode OddEvenList(ListNode head)
        {
            ListNode oddHead = new ListNode(0);
            ListNode evenHead = new ListNode(0);
            ListNode odd = oddHead;
            ListNode even = evenHead;
            bool isOdd = true;
            for (ListNode node = head; node != null; node = node.next)
            {
                if (isOdd)
                {
                    odd.next = node;
                    odd = node;
                }
                else
                {
                    even.next = node;
                    even = node;
                }

                isOdd = !isOdd;
            }

            even.next = null; // Don't forget this, otherwise there will be a cycle.
            odd.next = evenHead.next;
            return oddHead.next;
        }
    }
}
