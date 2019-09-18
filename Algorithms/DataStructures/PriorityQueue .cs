using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class PriorityQueue<T>
    {
        private readonly List<T> _heap = new List<T>() { default }; // _heap[0] is not used.
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Default is max priority queue.
        /// </summary>
        public PriorityQueue()
        {
            _comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public bool IsEmpty => _heap.Count == 1;

        public int Count => _heap.Count - 1;

        public void Add(T item)
        {
            _heap.Add(item);
            Swim(_heap.Count - 1);
        }

        /// <summary>
        /// Delete max when this is a max priority queue, or
        /// delete min when this is a min priority queue.
        /// </summary>
        public T DeleteTop()
        {
            T max = _heap[1];
            Swap(1, _heap.Count - 1);
            _heap.RemoveAt(_heap.Count - 1);
            Sink(1);
            return max;
        }

        public T PeekTop()
        {
            return _heap[1];
        }

        private void Swim(int k)
        {
            while (k > 1 && _comparer.Compare(_heap[k], _heap[k / 2]) > 0)
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k < _heap.Count)
            {
                int i = 2 * k;
                int j = 2 * k + 1;
                if (j < _heap.Count && _comparer.Compare(_heap[j], _heap[i]) > 0) i = j;
                // i now points to the bigger child.
                if (_comparer.Compare(_heap[k], _heap[i]) >= 0) break;
                Swap(k, i);
                k = i;
            }
        }

        private void Swap(int i, int j)
        {
            T tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }
    }
}
