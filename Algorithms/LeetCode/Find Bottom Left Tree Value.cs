using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 513. Find Bottom Left Tree Value
     * 
     * Given the root of a binary tree, return the leftmost value in the last row of the tree.
     * https://leetcode.com/problems/find-bottom-left-tree-value/
     */
    public class Find_Bottom_Left_Tree_Value
    {
        public int FindBottomLeftValue(TreeNode root)
        {
            List<int> row = null;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                row = new List<int>();
                for (int i = queue.Count; i > 0; i--)
                {
                    var node = queue.Dequeue();
                    row.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return row[0];
        }

        public int FindBottomLeftValue2(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                root = queue.Dequeue();
                // from right to left
                if (root.right != null) queue.Enqueue(root.right);
                if (root.left != null) queue.Enqueue(root.left);
            }
            return root.val;
        }
    }
}
