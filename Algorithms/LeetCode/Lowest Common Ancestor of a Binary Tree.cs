using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 236. Lowest Common Ancestor of a Binary Tree
     * 
     * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
     * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two
     * nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to
     * be a descendant of itself).”
     * 
     * Illustrations and examples: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
     * 
     * Note:
     * 
     * All of the nodes' values will be unique.
     * p and q are different and both values will exist in the binary tree.
     */
    public class LowestCommonAncestorOfBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Short clean code inspired by https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/discuss/65225/4-lines-C%2B%2BJavaPythonRuby
            // If we find p or q, just stop going deeper and return. If another p or q is in the deeper unsearched area, we won't find anything in other area.
            if (root == null || root == p || root == q) return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left == null && right == null) return null;
            if (left != null && right != null) return root;
            return left ?? right;
        }

        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode result = null;
            bool foundOne = false;
            Search(root);
            return result;

            // If node contains p or q , return true.
            bool Search(TreeNode node)
            {
                if (node == null) return false;
                bool currentNode = p == node || q == node;
                if (currentNode)
                {
                    if (foundOne) return true;
                    foundOne = true;
                }
                bool left = Search(node.left);
                if (result != null) return false; // No need to search right.
                if (currentNode && left)
                {
                    result = node;
                    return false;
                }
                bool right = Search(node.right);
                if (currentNode && right)
                {
                    result = node;
                    return false;
                }
                if (left && right)
                {
                    result = node;
                    return false;
                }
                if (left || right || currentNode) return true;
                return false;
            }
        }
    }
}
