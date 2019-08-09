using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 103. Binary Tree Zigzag Level Order Traversal
     * 
     * Given a binary tree, return the zigzag level order traversal of its nodes' values.
     * (ie, from left to right, then right to left for the next level and alternate between).
     * 
     * For example:
     * Given binary tree [3,9,20,null,null,15,7],
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * return its zigzag level order traversal as:
     * [
     *   [3],
     *   [20,9],
     *   [15,7]
     * ]
     */
    public class BinaryTreeZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            // Almost the same as "Problem 102. Binary Tree Level Order Traversal".
            if (root == null) return new int[0][];
            var result = new List<IList<int>>();
            var level = new List<TreeNode>() { root };
            bool reverse = false;
            while (level.Count != 0)
            {
                // The only difference is here.
                var array = level.Select(n => n.val).ToArray();
                if (reverse) Array.Reverse(array);
                reverse = !reverse;
                result.Add(array);

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
    }
}
