using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 515. Find Largest Value in Each Tree Row
     * 
     * Given the root of a binary tree, return an array of the largest value in each row of the tree.
     * https://leetcode.com/problems/find-largest-value-in-each-tree-row/
     */
    public class Find_Largest_Value_in_Each_Tree_Row
    {
        public IList<int> LargestValues(TreeNode root)
        {
            if (root == null) return new int[0];
            var res = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int max = int.MinValue;
                for (int i = queue.Count; i > 0; i--)
                {
                    var node = queue.Dequeue();
                    max = Math.Max(max, node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                res.Add(max);
            }
            return res;
        }
    }
}
