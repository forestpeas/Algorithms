using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 429. N-ary Tree Level Order Traversal
     * 
     * https://leetcode.com/problems/n-ary-tree-level-order-traversal/
     */
    public class N_ary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            var result = new List<IList<int>>();
            var queue = new Queue<Node>();
            if (root != null) queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int size = queue.Count;
                var level = new List<int>();
                result.Add(level);
                while (size-- > 0)
                {
                    var node = queue.Dequeue();
                    level.Add(node.val);
                    foreach (Node child in node.children) queue.Enqueue(child);
                }
            }

            return result;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}
