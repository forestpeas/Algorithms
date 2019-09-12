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
            var stack = new Stack<TreeNode>();
            while (true)
            {
                while (root != null)
                {
                    // Push twice so that the first time it is popped, we know its left has been traversed,
                    // and the second time it is popped, we know its right has been traversed.
                    stack.Push(root);
                    stack.Push(root);
                    root = root.left;
                }
                // Can't go any deeper, so go up a level to a root we once saved.
                if (!stack.TryPop(out root)) return result;
                if (stack.TryPeek(out var parent) && parent == root)
                {
                    // This is the case where root's left has been traversed, but right has not.
                    // So traverse right.
                    root = root.right;
                }
                else
                {
                    // This is the case where root's left and right has both been traversed.
                    result.Add(root.val);
                    root = null; // We are done with root, don't push it any more.
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
