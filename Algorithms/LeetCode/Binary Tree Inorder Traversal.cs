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
        // Iterative solution based on the recursive solution below.
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;
            var stack = new Stack<TreeNode>();
            var node = root;
            while (true)
            {
                if (node.left != null)
                {
                    stack.Push(node);
                    // set "node.left" to null so that the next time this node is visited (via a pop),
                    // we will go to the "else branch" blow.
                    var tmp = node.left;
                    node.left = null;
                    node = tmp;
                }
                else
                {
                    result.Add(node.val);
                    if (node.right != null)
                    {
                        // No need to save "node" on stack because this node won't be needed any more.
                        node = node.right;
                    }
                    else
                    {
                        if (!stack.TryPop(out node)) break;
                    }
                }
            }
            return result;
        }

        // Recursive solution
        public IList<int> RecursiveInorderTraversal(TreeNode root)
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
