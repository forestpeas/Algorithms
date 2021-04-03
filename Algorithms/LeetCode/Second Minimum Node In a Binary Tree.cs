using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 671. Second Minimum Node In a Binary Tree
     * 
     * https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/
     */
    public class Second_Minimum_Node_In_a_Binary_Tree
    {
        public int FindSecondMinimumValue(TreeNode root)
        {
            long res = Dfs(root);
            return res == long.MaxValue ? -1 : (int)res;

            long Dfs(TreeNode node)
            {
                if (node.left == null)
                {
                    return long.MaxValue;
                }
                if (node.left.val > node.val)
                {
                    return Math.Min(node.left.val, Dfs(node.right));
                }
                if (node.right.val > node.val)
                {
                    return Math.Min(node.right.val, Dfs(node.left));
                }
                return Math.Min(Dfs(node.left), Dfs(node.right));
            }
        }
    }
}
