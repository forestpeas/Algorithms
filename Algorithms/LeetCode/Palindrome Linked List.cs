using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 234. Palindrome Linked List
     * 
     * Given a singly linked list, determine if it is a palindrome.
     * 
     * Example 1:
     * 
     * Input: 1->2
     * Output: false
     * 
     * Example 2:
     * 
     * Input: 1->2->2->1
     * Output: true
     * 
     * Follow up:
     * Could you do it in O(n) time and O(1) space?
     */
    public class PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            // Find middle.
            ListNode slow = head;
            ListNode fast = head?.next;
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }

            // Reverse the right half.
            ListNode prev = null;
            ListNode curr = slow;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            ListNode start = head;
            ListNode end = prev; // tail
            while (end != null)
            {
                if (start.val != end.val) return false;
                start = start.next;
                end = end.next;
            }
            return true;
        }
    }
}
