using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 145. Binary Tree Postorder Traversal
     * 
     * Given a binary tree, return the postorder traversal of its nodes' values.
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
     * Output: [3,2,1]
     * 
     * Follow up: Recursive solution is trivial, could you do it iteratively?
     */
    public class BinaryTreePostorderTraversal
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            var stack = new Stack<TreeNode>();
            TreeNode node = root;
            while (true)
            {
                // We must first visit right and left, so save node on stack.
                if (node.left != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else if (node.right != null)
                {
                    stack.Push(node);
                    node = node.right;
                }
                else
                {
                    while (true)
                    {
                        // Three cases where node.val needs to be added to result: 
                        // 1.node is a leaf; 
                        // 2.node is popped out of the stack when its left has been traversed and node.right is null;
                        // 3.node is popped out of the stack when its right has been traversed. 
                        result.Add(node.val);
                        if (!stack.TryPeek(out var parent)) return result;
                        if (parent.left == node) // This is the case where parent's left has been traversed.
                        {
                            node = parent;
                            if (node.right != null) break; // Traverse right.
                            stack.Pop(); // right is null.
                        }
                        else // parent.right == root. This is the case where parent's right has been traversed.
                        {
                            node = stack.Pop(); // == parent
                        }
                    }
                    node = node.right; // Traverse right.
                }
            }
        }

        // Recursive solution
        public IList<int> PostorderTraversalRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root != null) TraverseCore(root);
            return result;

            void TraverseCore(TreeNode node)
            {
                if (node.left != null) TraverseCore(node.left);
                if (node.right != null) TraverseCore(node.right);
                result.Add(node.val);
            }
        }
    }
}
