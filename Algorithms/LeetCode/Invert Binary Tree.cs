using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 226. Invert Binary Tree
     * 
     * Invert a binary tree.
     * 
     * Example:
     * 
     * Input:
     * 
     *      4
     *    /   \
     *   2     7
     *  / \   / \
     * 1   3 6   9
     * 
     * Output:
     * 
     *      4
     *    /   \
     *   7     2
     *  / \   / \
     * 9   6 3   1
     */
    public class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
    }
}
