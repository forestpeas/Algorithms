using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 590. N-ary Tree Postorder Traversal
     * 
     * Given an n-ary tree, return the postorder traversal of its nodes' values.
     * 
     * Follow up:
     * 
     * Recursive solution is trivial, could you do it iteratively?
     */
    public class N_ary_Tree_Postorder_Traversal
    {
        public IList<int> Postorder_Dfs(Node root)
        {
            var res = new List<int>();
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.TryPeek(out var node))
            {
                if (node == null)
                {
                    stack.Pop();
                    continue;
                }
                if (node.children == null)
                {
                    stack.Pop();
                    res.Add(node.val);
                }
                else
                {
                    foreach (var child in node.children.Reverse())
                    {
                        stack.Push(child);
                    }
                    node.children = null;
                }
            }
            return res;
        }

        public IList<int> Postorder(Node root)
        {
            var res = new List<int>();
            Dfs(root, res);
            return res;
        }

        private void Dfs(Node node, List<int> res)
        {
            if (node == null) return;
            foreach (var child in node.children)
            {
                Dfs(child, res);
            }
            res.Add(node.val);
        }
    }
}
