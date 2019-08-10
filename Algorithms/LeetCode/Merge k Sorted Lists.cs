using Algorithms.DataStructures;

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
            var pq = new MinPriorityQueue(lists.Length);
            foreach (ListNode list in lists)
            {
                if (list != null) pq.Insert(list);
            }
            if (pq.IsEmpty) return null;

            ListNode mergedList = pq.DelMin();
            ListNode currentNode = mergedList;
            while (!pq.IsEmpty)
            {
                if (currentNode.next != null)
                {
                    pq.Insert(currentNode.next);
                }
                currentNode.next = pq.DelMin();
                currentNode = currentNode.next;
            }

            return mergedList;
        }

        private class MinPriorityQueue
        {
            // heap-ordered complete binary tree in _pq[1..N] with pq[0] unused
            private readonly ListNode[] _pq;
            private int N;

            public MinPriorityQueue(int capacity)
            {
                _pq = new ListNode[capacity + 1];
            }

            public bool IsEmpty => N == 0;

            private void Exch(int a, int b)
            {
                var tmp = _pq[a];
                _pq[a] = _pq[b];
                _pq[b] = tmp;
            }

            private void Swim(int k)
            {
                while (k > 1 && _pq[k / 2].val.CompareTo(_pq[k].val) > 0)
                {
                    Exch(k / 2, k);
                    k = k / 2;
                }
            }

            private void Sink(int k)
            {
                while (2 * k <= N)
                {
                    int j = 2 * k;
                    if (j < N && _pq[j].val.CompareTo(_pq[j + 1].val) > 0) j++;
                    if (_pq[k].val.CompareTo(_pq[j].val) < 0) break;
                    Exch(k, j);
                    k = j;
                }
            }

            public void Insert(ListNode v)
            {
                _pq[++N] = v;
                Swim(N);
            }

            public ListNode DelMin()
            {
                ListNode min = _pq[1]; // Retrieve min key from top.
                Exch(1, N--); // Exchange with last item.
                _pq[N + 1] = null; // Avoid loitering.
                Sink(1); // Restore heap property.
                return min;
            }
        }
    }
}
