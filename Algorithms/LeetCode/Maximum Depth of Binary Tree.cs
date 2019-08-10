using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 104. Maximum Depth of Binary Tree
     * 
     * Given a binary tree, find its maximum depth.
     * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
     * 
     * Note: A leaf is a node with no children.
     * 
     * Example:
     * 
     * Given binary tree [3,9,20,null,null,15,7],
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * return its depth = 3.
     */
    public class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            // Almost the same as "Problem 102. Binary Tree Level Order Traversal".
            if (root == null) return 0;
            int result = 0;
            var level = new List<TreeNode>() { root };
            while (level.Count != 0)
            {
                result++;
                var newLevel = new List<TreeNode>();
                foreach (var node in level)
                {
                    if (node.left != null) newLevel.Add(node.left);
                    if (node.right != null) newLevel.Add(node.right);
                }
                level = newLevel;
            }
            return result;
        }

        public int MaxDepthWithQueue(TreeNode root)
        {
            if (root == null) return 0;
            int result = 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                result++;
                int length = queue.Count;
                while (length-- > 0)
                {
                    var node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return result;
        }
    }

    public class MaximumDepthOfBinaryTreeRecursive
    {
        // Recursive solution.
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }
}
