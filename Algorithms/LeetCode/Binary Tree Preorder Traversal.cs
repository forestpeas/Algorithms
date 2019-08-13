using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 144. Binary Tree Preorder Traversal
     * 
     * Given a binary tree, return the preorder traversal of its nodes' values.
     * 
     * Example:
     * 
     * Input: [1,null,2,3]
     *    1
     *     \
     *      2
     *     /
     *    3
     * 
     * Output: [1,2,3]
     * 
     * Follow up: Recursive solution is trivial, could you do it iteratively?
     */
    public class BinaryTreePreorderTraversal
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            // Similar to "Problem 94. Binary Tree Inorder Traversal".
            var result = new List<int>();
            if (root == null) return result;
            var stack = new Stack<TreeNode>();
            while (true)
            {
                result.Add(root.val); // Visit root first.
                if (root.left != null)
                {
                    stack.Push(root); // Save root so that we can visit its right in the future.
                    root = root.left; // Visit left.
                }
                else
                {
                    while (root.right == null)
                    {
                        // If there is no more right child, go up a level to a root we once saved.
                        if (!stack.TryPop(out root)) return result;
                    }
                    root = root.right; // Visit right.
                }
            }
        }

        // Recursive solution
        public IList<int> PreorderTraversalRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root != null) TraverseCore(root);
            return result;

            void TraverseCore(TreeNode node)
            {
                result.Add(node.val);
                if (node.left != null) TraverseCore(node.left);
                if (node.right != null) TraverseCore(node.right);
            }
        }
    }
}
