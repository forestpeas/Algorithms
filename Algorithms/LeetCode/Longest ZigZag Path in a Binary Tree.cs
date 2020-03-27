using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 1372. Longest ZigZag Path in a Binary Tree
     * 
     * Given a binary tree root, a ZigZag path for a binary tree is defined as follow:
     * 
     * Choose any node in the binary tree and a direction (right or left).
     * If the current direction is right then move to the right child of the current node otherwise move
     * to the left child.
     * Change the direction from right to left or right to left.
     * Repeat the second and third step until you can't move in the tree.
     * Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).
     * 
     * Return the longest ZigZag path contained in that tree.
     * 
     * Example 1:
     * https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree/
     * Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1,null,1]
     * Output: 3
     * Explanation: Longest ZigZag path in blue nodes (right -> left -> right).
     * 
     * Example 2:
     * 
     * Input: root = [1,1,1,null,1,null,null,1,1,null,1]
     * Output: 4
     * Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).
     * 
     * Example 3:
     * 
     * Input: root = [1]
     * Output: 0
     */
    public class Longest_ZigZag_Path_in_a_Binary_Tree
    {
        public int LongestZigZag(TreeNode root)
        {
            int res = 0;
            Dfs(root, true, 0);
            return res;

            // "length" is the maximum zigzag path that ends with "node".
            // "goLeft = true" means we should go left to continue the zigzag path.
            void Dfs(TreeNode node, bool goLeft, int length)
            {
                if (node == null) return;
                res = Math.Max(res, length);

                Dfs(node.left, false, goLeft ? length + 1 : 1);
                Dfs(node.right, true, !goLeft ? length + 1 : 1);
            }
        }
    }
}
