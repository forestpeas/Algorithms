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
            var stack = new Stack<TreeNode>();
            while (true)
            {
                // First we traverse the left. So save the root on a stack for
                // future visit (when we have traversed the left).
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                // No more left child. So go up a level to a root we once saved and
                // now it's time to add this root to result.
                if (!stack.TryPop(out root)) return result;
                result.Add(root.val);
                root = root.right; // Traverse the right.
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

        // Morris Traversal, O(1) extra space. From "Approach 3: Morris Traversal" of https://leetcode.com/articles/binary-tree-inorder-traversal/.
        public IList<int> InorderTraversalMorris(TreeNode root)
        {
            List<int> res = new List<int>();
            TreeNode curr = root;
            TreeNode pre;
            while (curr != null)
            {
                if (curr.left == null)
                {
                    res.Add(curr.val);
                    curr = curr.right; // move to next right node
                }
                else
                {
                    // has a left subtree
                    pre = curr.left;
                    while (pre.right != null) // find rightmost
                    {
                        pre = pre.right;
                    }
                    pre.right = curr; // put cur after the pre node
                    TreeNode temp = curr; // store cur node
                    curr = curr.left; // move cur to the top of the new tree
                    temp.left = null; // original cur left be null, avoid infinite loops
                }
            }
            return res;
        }
    }
}
