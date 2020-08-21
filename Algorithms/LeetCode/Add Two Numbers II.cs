using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 445. Add Two Numbers II
     * 
     * You are given two non-empty linked lists representing two non-negative integers. The most significant
     * digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as
     * a linked list.
     * 
     * You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     * 
     * Follow up:
     * What if you cannot modify the input lists? In other words, reversing the lists is not allowed.
     * 
     * Example:
     * 
     * Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
     * Output: 7 -> 8 -> 0 -> 7
     */
    public class Add_Two_Numbers_II
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Similar to "2. Add Two Numbers".
            ListNode p = l1, q = l2;
            Stack<int> s1 = new Stack<int>(), s2 = new Stack<int>();
            while (p != null)
            {
                s1.Push(p.val);
                p = p.next;
            }
            while (q != null)
            {
                s2.Push(q.val);
                q = q.next;
            }

            ListNode next = null;
            int carry = 0;
            while (s1.Count != 0 || s2.Count != 0)
            {
                int sum = carry;
                if (s1.Count != 0) sum += s1.Pop();
                if (s2.Count != 0) sum += s2.Pop();
                carry = sum / 10;
                ListNode node = new ListNode(sum % 10, next);
                next = node;
            }

            if (carry > 0) return new ListNode(1, next);
            return next;
        }
    }
}
