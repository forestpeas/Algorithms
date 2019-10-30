using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 543. Diameter of Binary Tree
     * 
     * Given a binary tree, you need to compute the length of the diameter of the tree. The diameter
     * of a binary tree is the length of the longest path between any two nodes in a tree. This path
     * may or may not pass through the root.
     * 
     * Example:
     * Given a binary tree
     *           1
     *          / \
     *         2   3
     *        / \     
     *       4   5    
     * Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].
     * 
     * Note: The length of path between two nodes is represented by the number of edges between them.
     */
    public class DiameterOfBinaryTreeSolution
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            // DFS the tree and check every node's left subtree's depth + its right subtree's depth
            // (which is a potential longest path).
            int result = 0;
            MaxDepth(root);
            return result;

            // Returns the number of nodes of a path from node to a bottom node.
            int MaxDepth(TreeNode node)
            {
                if (node == null) return 0;

                int left = MaxDepth(node.left);
                int right = MaxDepth(node.right);
                result = Math.Max(result, left + right); // The number of edges is the number of nodes - 1.
                                                         // (1 + left + right) - 1, 1 represents the current node.
                return 1 + Math.Max(left, right);
            }
        }
    }
}
