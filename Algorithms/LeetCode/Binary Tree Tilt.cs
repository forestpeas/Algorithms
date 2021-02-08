using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 563. Binary Tree Tilt
     * 
     * Given the root of a binary tree, return the sum of every tree node's tilt.
     * 
     * The tilt of a tree node is the absolute difference between the sum of all
     * left subtree node values and all right subtree node values.
     */
    public class Binary_Tree_Tilt
    {
        public int FindTilt(TreeNode root)
        {
            int res = 0;
            Dfs(root);
            return res;

            int Dfs(TreeNode node)
            {
                if (node == null) return 0;
                int leftSum = Dfs(node.left);
                int rightSum = Dfs(node.right);
                res += Math.Abs(leftSum - rightSum);
                return leftSum + rightSum + node.val;
            }
        }
    }
}
