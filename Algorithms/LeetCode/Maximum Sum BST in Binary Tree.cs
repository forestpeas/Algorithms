using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 1373. Maximum Sum BST in Binary Tree
     * 
     * Given a binary tree root, the task is to return the maximum sum of all keys of any sub-tree which is also
     * a Binary Search Tree (BST).
     * 
     * Assume a BST is defined as follows:
     * The left subtree of a node contains only nodes with keys less than the node's key.
     * The right subtree of a node contains only nodes with keys greater than the node's key.
     * Both the left and right subtrees must also be binary search trees.
     * 
     * Example 1:
     * https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/
     * Input: root = [1,4,3,2,4,2,5,null,null,null,null,null,null,4,6]
     * Output: 20
     * Explanation: Maximum sum in a valid Binary search tree is obtained in root node with key equal to 3.
     * Example 2:
     * 
     * Input: root = [4,3,null,1,2]
     * Output: 2
     * Explanation: Maximum sum in a valid Binary search tree is obtained in a single root node with key equal to 2.
     * 
     * Example 3:
     * 
     * Input: root = [-4,-2,-5]
     * Output: 0
     * Explanation: All values are negatives. Return an empty BST.
     * 
     * Example 4:
     * 
     * Input: root = [2,1,3]
     * Output: 6
     * 
     * Example 5:
     * 
     * Input: root = [5,4,8,3,null,6,3]
     * Output: 7
     * 
     * Constraints:
     * 
     * Each tree has at most 40000 nodes..
     * Each node's value is between [-4 * 10^4 , 4 * 10^4].
     */
    public class Maximum_Sum_BST_in_Binary_Tree
    {
        public int MaxSumBST(TreeNode root)
        {
            int result = 0;
            Dfs(root);
            return result;

            (bool isBST, int min, int max, int sum) Dfs(TreeNode node)
            {
                if (node == null)
                {
                    return (true, int.MaxValue, int.MinValue, 0); // auxiliary values to save more checks
                }

                var left = Dfs(node.left);
                var right = Dfs(node.right);
                if (!left.isBST || !right.isBST || node.val <= left.max || node.val >= right.min)
                {
                    return (false, 0, 0, 0); // If it's not a BST, other values don't matter.
                }

                int sum = left.sum + right.sum + node.val;
                result = Math.Max(result, sum);

                // If left.min > left.max, the left node is null. Same for the right node.
                int min = left.min <= left.max ? left.min : node.val;
                int max = right.min <= right.max ? right.max : node.val;
                return (true, min, max, sum);
            }
        }
    }
}
