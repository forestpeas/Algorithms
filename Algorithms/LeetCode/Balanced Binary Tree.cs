using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 110. Balanced Binary Tree
     * 
     * Given a binary tree, determine if it is height-balanced.
     * For this problem, a height-balanced binary tree is defined as: 
     * a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
     * 
     * Example 1:
     * 
     * Given the following tree [3,9,20,null,null,15,7]:
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * Return true.
     * 
     * Example 2:
     * 
     * Given the following tree [1,2,2,3,3,null,null,4,4]:
     * 
     *        1
     *       / \
     *      2   2
     *     / \
     *    3   3
     *   / \
     *  4   4
     * Return false.
     */
    public class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            return GetHeight(root) != -1;
        }

        // Returning "-1" means we have found an invalid subtree.
        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;
            int leftHeight = GetHeight(root.left);
            if (leftHeight == -1) return -1;
            int rightHeight = GetHeight(root.right);
            if (rightHeight == -1) return -1;
            if (Math.Abs(leftHeight - rightHeight) <= 1)
            {
                return 1 + Math.Max(leftHeight, rightHeight);
            }
            else
            {
                return -1;
            }
        }
    }
}
