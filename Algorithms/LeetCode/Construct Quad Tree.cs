namespace Algorithms.LeetCode
{
    public class Construct_Quad_Tree
    {
        /* 427. Construct Quad Tree
         * 
         * https://leetcode.com/problems/construct-quad-tree/
         */
        public Node Construct(int[][] grid)
        {
            return Construct(new Point(0, 0), grid.Length);

            Node Construct(Point topLeft, int n)
            {
                // A n * n matrix whose top left point is "topLeft".
                if (n == 1) return new Node(grid[topLeft.y][topLeft.x] == 1 ? true : false, _isLeaf: true);

                n /= 2;
                var node = new Node(true, _isLeaf: false)
                {
                    topLeft = Construct(topLeft, n),
                    topRight = Construct(new Point(topLeft.x + n, topLeft.y), n),
                    bottomLeft = Construct(new Point(topLeft.x, topLeft.y + n), n),
                    bottomRight = Construct(new Point(topLeft.x + n, topLeft.y + n), n),
                };

                bool sameLeaves =
                    node.topLeft.isLeaf &&
                    node.topRight.isLeaf &&
                    node.bottomLeft.isLeaf &&
                    node.bottomRight.isLeaf &&
                    node.topLeft.val == node.topRight.val &&
                    node.topRight.val == node.bottomLeft.val &&
                    node.bottomLeft.val == node.bottomRight.val;

                if (sameLeaves)
                {
                    node.isLeaf = true;
                    node.val = node.topLeft.val;
                    node.topLeft = node.topRight = node.bottomLeft = node.bottomRight = null;
                }
                return node;
            }
        }

        private struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }
    }
}
