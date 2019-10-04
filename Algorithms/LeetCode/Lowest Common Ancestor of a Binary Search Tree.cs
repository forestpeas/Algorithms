using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 235. Lowest Common Ancestor of a Binary Search Tree
     * 
     * Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.
     * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two
     * nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to
     * be a descendant of itself).”
     * 
     * Illustrations and examples: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
     */
    public class LowestCommonAncestorOfBinarySearchTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Starting from root, let p and q compare with each node to decide which branch they should take next.
            // When they are about to separate, they are at their lowest common ancestor.
            TreeNode node = root;
            while (node != null)
            {
                if (p.val < node.val && q.val < node.val)
                {
                    node = node.left;
                }
                else if (p.val > node.val && q.val > node.val)
                {
                    node = node.right;
                }
                else return node;
            }

            return null; // invalid input
        }
    }
}
