using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 1339. Maximum Product of Splitted Binary Tree
     * 
     * Given a binary tree root. Split the binary tree into two subtrees by removing 1 edge such that
     * the product of the sums of the subtrees are maximized.
     * 
     * https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/
     */
    public class Maximum_Product_of_Splitted_Binary_Tree
    {
        public int MaxProduct(TreeNode root)
        {
            long total = 0;
            long result = 0;
            Dfs1(root); // Get total sum.
            Dfs2(root); // Get the result.
            return (int)(result % 1000000007);

            void Dfs1(TreeNode node)
            {
                if (node == null) return;
                total += node.val;
                Dfs1(node.left);
                Dfs1(node.right);
            }

            long Dfs2(TreeNode node)
            {
                if (node == null) return 0;
                // Remove the edge above this node, except when the node is root, which gives us 0.
                long sum = node.val + Dfs2(node.left) + Dfs2(node.right);
                result = Math.Max(result, sum * (total - sum));
                return sum;
            }
        }
    }
}
