using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 160. Intersection of Two Linked Lists
     * 
     * Refer to https://leetcode.com/problems/intersection-of-two-linked-lists/.
     */
    public class IntersectionOfTwoLinkedLists
    {
        // Inspired by https://leetcode.com/problems/intersection-of-two-linked-lists/discuss/49785/Java-solution-without-knowing-the-difference-in-len!/165648.
        // The key is that, for example, when the pointer of A reaches the end, then redirect it to the head of B, util pA meets pB.
        public ListNode GetIntersectionNodeTwoPointers(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;
            ListNode tailA = null;
            ListNode tailB = null;
            while (a != b)
            {
                if (a.next == null)
                {
                    tailA = a;
                    if (tailB != null && tailA != tailB) return null;
                    a = headB;
                }
                else
                {
                    a = a.next;
                }
                if (b.next == null)
                {
                    tailB = b;
                    if (tailA != null && tailA != tailB) return null;
                    b = headA;
                }
                else
                {
                    b = b.next;
                }
            }

            return a;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            // First traverse the the two linked lists and count the lengths of them.
            // For example, lengthA = 5, lengthB = 6.
            // Then traverse them again, but this time headB will start from headB.next, because 6-5=1.
            // I think this solution is essentially the same to "Approach 3: Two Pointers" of https://leetcode.com/articles/intersection-of-two-linked-lists/.
            // But this solution needs two traversals in all cases, while the two pointers solution only needs one traversal in some cases.
            if (headA == null || headB == null) return null;
            int lengthA = 1;
            var nodeA = headA;
            for (; nodeA.next != null; nodeA = nodeA.next)
            {
                lengthA++;
            }
            int lengthB = 1;
            var nodeB = headB;
            for (; nodeB.next != null; nodeB = nodeB.next)
            {
                lengthB++;
            }
            if (nodeA != nodeB) return null;

            nodeA = headA;
            nodeB = headB;
            if (lengthA > lengthB)
            {
                for (int i = 0; i < lengthA - lengthB; i++)
                {
                    nodeA = nodeA.next;
                }
            }
            else
            {
                for (int i = 0; i < lengthB - lengthA; i++)
                {
                    nodeB = nodeB.next;
                }
            }
            for (; nodeA != null; nodeA = nodeA.next, nodeB = nodeB.next)
            {
                if (nodeA == nodeB) return nodeA;
            }
            throw new InvalidOperationException("Can't happen.");
        }
    }
}
