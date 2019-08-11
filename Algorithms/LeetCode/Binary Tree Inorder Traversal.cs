using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 94. Binary Tree Inorder Traversal
     * 
     * Given a binary tree, return the inorder traversal of its nodes' values.
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
     * Output: [1,3,2]
     * 
     * Follow up: Recursive solution is trivial, could you do it iteratively?
     */
    public class BinaryTreeInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            var stack = new Stack<TreeNode>();
            while (true)
            {
                // First we traverse the left. So save the root on a stack for
                // future use (when we have traversed the left).
                if (root.left != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    // No more left child.
                    result.Add(root.val);

                    while (root.right == null) // And no right child, too.
                    {
                        // The current level(also the left of the root up a level) has been traversed, 
                        // so go up a level to a root we once saved on stack and now it's time to add
                        // this root to result.
                        if (!stack.TryPop(out root)) return result;
                        result.Add(root.val);
                    }
                    root = root.right; // Traverse the right.
                }
            }
        }

        // Recursive solution
        public IList<int> InorderTraversalRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root != null) TraverseCore(root);
            return result;

            void TraverseCore(TreeNode node)
            {
                if (node.left != null) TraverseCore(node.left);
                result.Add(node.val);
                if (node.right != null) TraverseCore(node.right);
            }
        }
    }
}
