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
        public int MaxPathSum(TreeNode root)
        {
            int result = int.MinValue;
            MaxPathSumCore(root);
            return result;

            // Returns the maximum path sum of paths that must end or start with "node".
            int MaxPathSumCore(TreeNode node)
            {
                // Search all possible paths except those that can be excluded.
                int leftMax = 0;
                int rightMax = 0;
                if (node.left != null)
                {
                    leftMax = MaxPathSumCore(node.left);
                    result = Math.Max(result, leftMax + node.val);
                }
                if (node.right != null)
                {
                    rightMax = MaxPathSumCore(node.right);
                    result = Math.Max(result, rightMax + node.val);
                }

                result = Math.Max(result, node.val);
                result = Math.Max(result, leftMax + node.val + rightMax);
                return Math.Max(node.val, Math.Max(leftMax + node.val, rightMax + node.val));
            }
        }
    }
}
