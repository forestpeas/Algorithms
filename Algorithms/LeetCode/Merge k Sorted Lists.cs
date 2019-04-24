using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    public class MergeKSortedLists
    {
        private ListNode[] pq; // heap-ordered complete binary tree
        private int N = 0; // in pq[1..N] with pq[0] unused

        private void Exch(int a, int b)
        {
            var tmp = pq[a];
            pq[a] = pq[b];
            pq[b] = tmp;
        }

        private void Swim(int k)
        {
            while (k > 1 && pq[k / 2].val > pq[k].val)
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
                if (j < N && pq[j].val > pq[j + 1].val) j++;
                if (pq[k].val < pq[j].val) break;
                Exch(k, j);
                k = j;
            }
        }

        private void Insert(ListNode v)
        {
            pq[++N] = v;
            Swim(N);
        }

        private ListNode DelMin()
        {
            ListNode min = pq[1]; // Retrieve min key from top.
            Exch(1, N--); // Exchange with last item.
            pq[N + 1] = null; // Avoid loitering.
            Sink(1); // Restore heap property.
            return min;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            pq = new ListNode[lists.Length + 1];
            N = 0;
            foreach (ListNode list in lists)
            {
                if (list != null) Insert(list);
            }
            if (N == 0) return null;

            ListNode mergedList = DelMin();
            ListNode currentNode = mergedList;
            while (N > 0)
            {
                if (currentNode.next != null)
                {
                    Insert(currentNode.next);
                }
                currentNode.next = DelMin();
                currentNode = currentNode.next;
            }

            return mergedList;
        }
    }
}
