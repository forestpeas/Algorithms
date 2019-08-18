using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 173. Binary Search Tree Iterator
     * 
     * Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
     * Calling next() will return the next smallest number in the BST.
     * 
     * Note:
     * next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
     * You may assume that next() call will always be valid, that is, there will be at least a next smallest number
     * in the BST when next() is called.
     */
    public class BSTIterator
    {
        // Just like the iterative approach of binary tree inorder traversal.

        private readonly Stack<TreeNode> _stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
            TreeNode node = root;
            while (node != null)
            {
                _stack.Push(node);
                node = node.left;
            }
        }

        /** @return the next smallest number */
        public int Next()
        {
            TreeNode next = _stack.Pop();
            TreeNode node = next.right;
            while (node != null)
            {
                _stack.Push(node);
                node = node.left;
            }
            return next.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return _stack.Count != 0;
        }
    }
}
