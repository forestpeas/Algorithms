using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 23. Merge k Sorted Lists
     * 
     * Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
     * 
     * Example:
     * 
     * Input:
     * [
     *   1->4->5,
     *   1->3->4,
     *   2->6
     * ]
     * Output: 1->1->2->3->4->4->5->6
     */
    public class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            // Divide And Conquer.
            // Inspired by "Approach 5: Merge with Divide And Conquer" of https://leetcode.com/articles/merge-k-sorted-list/.
            if (lists.Length == 0) return null;
            for (int n = lists.Length; n > 1;) // n means the number of lists in the current step.
            {
                for (int i = 0; i < n / 2; i++)
                {
                    lists[i] = MergeTwoSortedLists.MergeTwoLists(lists[i], lists[i + n / 2]);
                }
                if (n % 2 != 0)
                {
                    lists[n / 2] = lists[n - 1];
                    n = n / 2 + 1;
                }
                else
                {
                    n = n / 2;
                }
            }
            return lists[0];
        }

        public ListNode MergeKListsPriorityQueue(ListNode[] lists)
        {
            // Solution based on priority queue.
            // Every pop and insertion to priority queue costs O(logk), and repeats N times.
            // So time complexity is O(Nlogk) where k is the number of linked lists.
            // The priority queue (implemented with heaps) costs O(k) space.
            // So Space complexity is O(k).
            if (lists == null || lists.Length == 0) return null;
            // A "min priority queue".
            var pq = new PriorityQueue<ListNode>(Comparer<ListNode>.Create((x, y) => y.val.CompareTo(x.val)));
            foreach (ListNode list in lists)
            {
                if (list != null) pq.Add(list);
            }
            if (pq.IsEmpty) return null;

            ListNode mergedList = pq.DeleteMax();
            ListNode currentNode = mergedList;
            while (!pq.IsEmpty)
            {
                if (currentNode.next != null)
                {
                    pq.Add(currentNode.next);
                }
                currentNode.next = pq.DeleteMax();
                currentNode = currentNode.next;
            }

            return mergedList;
        }
    }
}
