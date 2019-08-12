using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 106. Construct Binary Tree from Inorder and Postorder Traversal
     * 
     * Given inorder and postorder traversal of a tree, construct the binary tree.
     * 
     * Note:
     * You may assume that duplicates do not exist in the tree.
     * 
     * For example, given
     * inorder = [9,3,15,20,7]
     * postorder = [9,15,7,20,3]
     * Return the following binary tree:
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     */
    public class ConstructBinaryTreeFromInorderAndPostorderTraversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            // Similar to "Problem 105. Construct Binary Tree from Preorder and Inorder Traversal".
            // The last element in postorder must be the root. Find this root in inorder.
            // Cut inorder in two by this root, do it recursively with the left and right parts.
            return BuildTree(0, 0, inorder.Length);

            TreeNode BuildTree(int postorderStart, int inorderStart, int length)
            {
                if (length == 0) return null;
                TreeNode root = new TreeNode(postorder[postorderStart + length - 1]);
                // Find root in inorder. Can be optimized using a dictionary.
                int rootIndex = inorderStart;
                while (root.val != inorder[rootIndex])
                {
                    rootIndex++;
                }
                // Cut inorder in two by rootIndex.
                int leftLength = rootIndex - inorderStart;
                int rightLength = length - 1 - leftLength;
                root.left = BuildTree(postorderStart, inorderStart, leftLength);
                root.right = BuildTree(postorderStart + leftLength, inorderStart + leftLength + 1, rightLength);
                return root;
            }
        }
    }
}
