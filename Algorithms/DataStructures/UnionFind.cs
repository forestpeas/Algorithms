namespace Algorithms.DataStructures
{
    public class UnionFind
    {
        private readonly int[] _id;

        public UnionFind(int count)
        {
            Count = count;
            _id = new int[count];
            for (int i = 0; i < count; i++)
            {
                _id[i] = i;
            }
        }

        public int Count { get; private set; } // Number of components.

        public bool Connected(int p, int q) => Find(p) == Find(q);

        public int Find(int p)
        {
            while (p != _id[p]) p = _id[p];
            return p;
        }

        public bool Union(int p, int q)
        {
            // Give p and q the same root.
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot) return false;
            _id[pRoot] = qRoot;
            Count--;
            return true;
        }
    }
}
