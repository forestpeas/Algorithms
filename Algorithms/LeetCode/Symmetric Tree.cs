using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 101. Symmetric Tree
     * 
     * Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
     * For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
     * 
     *     1
     *    / \
     *   2   2
     *  / \ / \
     * 3  4 4  3
     * 
     * But the following [1,2,2,null,3,null,3] is not:
     * 
     *     1
     *    / \
     *   2   2
     *    \   \
     *    3    3
     * 
     * Note:
     * Bonus points if you could solve it both recursively and iteratively.
     */
    public class SymmetricTree
    {
        // Iterative Solution
        public bool IsSymmetric(TreeNode root)
        {
            // Enqueue the nodes in a specific order:
            // queue.Enqueue(t1.left);
            // queue.Enqueue(t2.right);
            // queue.Enqueue(t1.right);
            // queue.Enqueue(t2.left);
            // In this way, if the tree is symmetric,
            // then two consecutive nodes in the queue are equal.
            if (root == null) return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);
            while (queue.Count != 0)
            {
                TreeNode t1 = queue.Dequeue();
                TreeNode t2 = queue.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.val != t2.val) return false;
                queue.Enqueue(t1.left);
                queue.Enqueue(t2.right);
                queue.Enqueue(t1.right);
                queue.Enqueue(t2.left);
            }
            return true;
        }

        // Recursive Solution
        public bool IsSymmetricRecursive(TreeNode root)
        {
            if (root == null) return true;
            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode t1, TreeNode t2)
        {
            if (t1 == null || t2 == null) return t1 == t2;
            if (t1.val != t2.val) return false;
            return IsSymmetric(t1.left, t2.right) && IsSymmetric(t1.right, t2.left);
        }
    }
}
