using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 105. Construct Binary Tree from Preorder and Inorder Traversal
     * 
     * Given preorder and inorder traversal of a tree, construct the binary tree.
     * 
     * Note:
     * You may assume that duplicates do not exist in the tree.
     * 
     * For example, given
     * preorder = [3,9,20,15,7]
     * inorder = [9,3,15,20,7]
     * Return the following binary tree:
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     */
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            // The first element in preorder must be the root. Find this root in inorder.
            // Cut inorder in two by this root, the length of the leftPart correspond to
            // the same length in preorderStart after root. So do the right part.
            // For example: 
            // preorder = [3,9,20,15,7]
            // inorder =  [9,3,15,20,7]
            // 3 splits inorder into: [9] and [15,20,7]
            // And these two parts correspond to [9] and [20,15,7] in preorder.
            return BuildTree(0, 0, inorder.Length);

            TreeNode BuildTree(int preorderStart, int inorderStart, int length)
            {
                if (length == 0) return null;
                TreeNode root = new TreeNode(preorder[preorderStart]);
                // Find root in inorder. Can be optimized using a dictionary.
                int rootIndex = inorderStart;
                while (root.val != inorder[rootIndex])
                {
                    rootIndex++;
                }
                // Cut inorder in two by rootIndex.
                int leftLength = rootIndex - inorderStart;
                int rightLength = length - 1 - leftLength;
                root.left = BuildTree(preorderStart + 1, inorderStart, leftLength);
                root.right = BuildTree(preorderStart + 1 + leftLength, inorderStart + leftLength + 1, rightLength);
                return root;
            }
        }
    }

    public class ConstructBinaryTreeFromPreorderAndInorderTraversalSolution2
    {
        // Inspired by https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/discuss/34543/Simple-O(n)-without-map.
        // No need for the search of "preorder[first]" in inorder.
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int preorderIndex = 0;
            int inorderIndex = 0;
            return Build(int.MinValue);

            // "stop" is boundary in inorder. For example:
            // preorder: [1, 2, 4, 5, 3, 6]
            //  inorder: [4, 2, 5, 1, 6, 3]
            //      1
            //    /   \
            //   2     3
            //  / \   /
            // 4   5 6
            // When we come to "2", root = new TreeNode(2).
            // "2"'s left subtree is bounded by "2":
            // [4, 2, 5, 1, 6, 3]
            //     ↑
            //    boundary, stop!
            // "2"'s right subtree is bounded by "1"(Because "2" is "1"'s left part, "1" limits its whole left part to [4,2,5]):
            // [4, 2, 5, 1, 6, 3]
            //           ↑
            //          boundary, stop!
            TreeNode Build(int stop)
            {
                if (preorderIndex >= preorder.Length) return null;
                if (inorder[inorderIndex] == stop)
                {
                    inorderIndex++;
                    return null;
                }
                TreeNode node = new TreeNode(preorder[preorderIndex++]);
                node.left = Build(node.val);
                node.right = Build(stop);
                return node;
            }
        }
    }
}
