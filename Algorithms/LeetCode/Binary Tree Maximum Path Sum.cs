using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 124. Binary Tree Maximum Path Sum
     * 
     * Given a non-empty binary tree, find the maximum path sum.
     * 
     * For this problem, a path is defined as any sequence of nodes from some starting node
     * to any node in the tree along the parent-child connections. The path must contain at
     * least one node and does not need to go through the root.
     * 
     * Example 1:
     * 
     * Input: [1,2,3]
     * 
     *        1
     *       / \
     *      2   3
     * 
     * Output: 6
     * 
     * Example 2:
     * 
     * Input: [-10,9,20,null,null,15,7]
     * 
     *    -10
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * 
     * Output: 42
     */
    public class BinaryTreeMaximumPathSum
    {
        private int _result = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            if (root == null) return int.MinValue;
            MaxPathSumCore(root);
            return _result;
        }

        // Returns the maximum path sum of paths that must end or start with "root", within a tree with "root" as root.
        public int MaxPathSumCore(TreeNode root)
        {
            // Search all possible paths except those that can be excluded.
            int leftMax = 0;
            int rightMax = 0;
            if (root.left != null)
            {
                leftMax = MaxPathSumCore(root.left);
                _result = Math.Max(_result, leftMax + root.val);
            }
            if (root.right != null)
            {
                rightMax = MaxPathSumCore(root.right);
                _result = Math.Max(_result, rightMax + root.val);
            }

            _result = Math.Max(_result, root.val);
            _result = Math.Max(_result, leftMax + root.val + rightMax);
            return Math.Max(root.val, Math.Max(leftMax + root.val, rightMax + root.val));
        }
    }
}
