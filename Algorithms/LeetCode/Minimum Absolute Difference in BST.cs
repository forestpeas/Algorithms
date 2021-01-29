using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 530. Minimum Absolute Difference in BST
     * 
     * Given a binary search tree with non-negative values, find the minimum absolute
     * difference between values of any two nodes.
     * 
     * Example:
     * 
     * Input:
     * 
     *    1
     *     \
     *      3
     *     /
     *    2
     * 
     * Output:
     * 1
     * 
     * Explanation:
     * The minimum absolute difference is 1, which is the difference between 2 and 1
     * (or between 2 and 3).
     * 
     * Note:
     * 
     * There are at least two nodes in this BST.
     */
    public class Minimum_Absolute_Difference_in_BST
    {
        public int GetMinimumDifference(TreeNode root)
        {
            int res = int.MaxValue;
            TreeNode prev = null;
            Dfs(root);
            return res;

            void Dfs(TreeNode node)
            {
                if (node == null) return;
                Dfs(node.left);
                if (prev != null) res = Math.Min(res, node.val - prev.val);
                prev = node;
                Dfs(node.right);
            }
        }
    }
}
