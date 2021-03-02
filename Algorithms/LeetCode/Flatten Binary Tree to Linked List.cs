using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 114. Flatten Binary Tree to Linked List
     * 
     * Given a binary tree, flatten it to a linked list in-place.
     * 
     * For example, given the following tree:
     * 
     *     1
     *    / \
     *   2   5
     *  / \   \
     * 3   4   6
     * The flattened tree should look like:
     * 
     * 1
     *  \
     *   2
     *    \
     *     3
     *      \
     *       4
     *        \
     *         5
     *          \
     *           6
     */
    public class FlattenBinaryTreeToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            // We can see from the example above that
            //   2                       2
            //  / \     is flattened to   \
            // 3   4                       3
            //                              \
            //                               4
            // We can do this recursively. For example, when root is 1,
            // it puts its left subtree to its right, and puts its (original) right
            // subtree to the bottom.
            if (root != null) FlattenAndGetLeaf(root);
        }

        // Flattens and returns the "bottom leaf".
        private TreeNode FlattenAndGetLeaf(TreeNode root)
        {
            if (root.left == null && root.right == null) return root;
            if (root.left == null) return FlattenAndGetLeaf(root.right);
            if (root.right == null)
            {
                root.right = root.left;
                root.left = null;
                return FlattenAndGetLeaf(root.right);
            }
            TreeNode leftLeaf = FlattenAndGetLeaf(root.left);
            TreeNode rightLeaf = FlattenAndGetLeaf(root.right);
            leftLeaf.right = root.right;
            root.right = root.left;
            root.left = null;
            return rightLeaf;
        }
    }
}
