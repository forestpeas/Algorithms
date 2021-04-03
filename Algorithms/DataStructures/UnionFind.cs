namespace Algorithms.DataStructures
{
    public class UnionFind
    {
        private readonly int[] _parent;

        public UnionFind(int count)
        {
            Count = count;
            _parent = new int[count];
            for (int i = 0; i < count; i++)
            {
                _parent[i] = i;
            }
        }

        public int Count { get; private set; } // Number of components.

        public bool Connected(int p, int q) => Find(p) == Find(q);

        public int Find(int p)
        {
            while (p != _parent[p]) p = _parent[p];
            return p;
        }

        public bool Union(int p, int q)
        {
            // Give p and q the same root.
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot) return false;
            _parent[pRoot] = qRoot;
            Count--;
            return true;
        }
    }

    public class BalancedUnionFind
    {
        private readonly int[] _parent;
        private readonly int[] _height;

        public BalancedUnionFind(int count)
        {
            _parent = new int[count];
            for (int i = 0; i < count; i++)
            {
                _parent[i] = i;
            }
            _height = new int[count];
        }

        public int Find(int p)
        {
            while (p != _parent[p]) p = _parent[p];
            return p;
        }

        public bool Union(int p, int q)
        {
            int pRoot = Find(p), qRoot = Find(q);
            if (pRoot == qRoot)
            {
                return false;
            }
            else if (_height[pRoot] < _height[qRoot])
            {
                _parent[pRoot] = qRoot;
            }
            else if (_height[pRoot] > _height[qRoot])
            {
                _parent[qRoot] = pRoot;
            }
            else
            {
                _parent[qRoot] = pRoot;
                _height[pRoot]++;
            }
            return true;
        }
    }
}
