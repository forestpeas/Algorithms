namespace Algorithms.DataStructures
{
    // Fenwick tree is also called binary indexed tree.
    public class FenwickTree
    {
        private readonly int[] _a; // a[0] is not used.

        public FenwickTree(int n)
        {
            _a = new int[n + 1];
        }

        public FenwickTree(int[] a)
        {
            _a = new int[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                Add(i, a[i]);
            }
        }

        public void Add(int i, int delta)
        {
            i++;
            while (i < _a.Length)
            {
                _a[i] += delta;
                i += i & (-i);
            }
        }

        // sum of [0:i]
        public int PrefixSum(int i)
        {
            i++;
            int s = 0;
            while (i > 0)
            {
                s += _a[i];
                i -= i & (-i);
            }
            return s;
        }

        public int RangeSum(int i, int j)
        {
            return PrefixSum(j) - PrefixSum(i - 1);
        }
    }
}
