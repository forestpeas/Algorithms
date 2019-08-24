using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 111. Minimum Depth of Binary Tree
     * 
     * Given a binary tree, find its minimum depth.
     * The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
     * Note: A leaf is a node with no children.
     * 
     * Example:
     * 
     * Given binary tree [3,9,20,null,null,15,7],
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * return its minimum depth = 2.
     */
    public class MinimumDepthOfBinaryTree
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            return MinDepthCore(root);
        }

        private int MinDepthCore(TreeNode root)
        {
            // Be careful that if one of the two subtrees is null, we can't simply return 0 
            // according to the definition of minimum depth in the description.
            // And in some cases where the tree is quite unbalanced, code can be optimized
            // using BFS or checking whether root.left or root.right is a leaf.
            if (root.left == null && root.right == null) return 1;
            if (root.left == null) return 1 + MinDepth(root.right);
            if (root.right == null) return 1 + MinDepth(root.left);
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }
    }
}
