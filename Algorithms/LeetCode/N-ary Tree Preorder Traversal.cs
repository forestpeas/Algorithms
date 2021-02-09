using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 589. N-ary Tree Preorder Traversal
     * 
     * Given an n-ary tree, return the preorder traversal of its nodes' values.
     * 
     * Follow up:
     * Recursive solution is trivial, could you do it iteratively?
     */
    public class N_ary_Tree_Preorder_Traversal
    {
        public IList<int> Preorder(Node root)
        {
            var res = new List<int>();
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.TryPop(out var node))
            {
                if (node == null) continue;
                res.Add(node.val);
                foreach (var child in node.children.Reverse())
                {
                    stack.Push(child);
                }
            }
            return res;
        }

        public IList<int> Preorder_Dfs(Node root)
        {
            var res = new List<int>();
            Dfs(root, res);
            return res;
        }

        private void Dfs(Node node, List<int> res)
        {
            if (node == null) return;
            res.Add(node.val);
            foreach (var child in node.children)
            {
                Dfs(child, res);
            }
        }
    }
}
