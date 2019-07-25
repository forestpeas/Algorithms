using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 98. Validate Binary Search Tree
     * 
     * Given a binary tree, determine if it is a valid binary search tree (BST).
     * 
     * Assume a BST is defined as follows: 
     * The left subtree of a node contains only nodes with keys less than the node's key.
     * The right subtree of a node contains only nodes with keys greater than the node's key.
     * Both the left and right subtrees must also be binary search trees.
     * 
     * Example 1:
     * 
     *     2
     *    / \
     *   1   3
     * 
     * Input: [2,1,3]
     * Output: true
     * 
     * Example 2:
     * 
     *     5
     *    / \
     *   1   4
     *      / \
     *     3   6
     * 
     * Input: [5,1,4,null,null,3,6]
     * Output: false
     * Explanation: The root node's value is 5 but its right child's value is 4.
     */
    public class ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root != null)
            {
                return RecursiveIsValidBST(root, out int _, out int _);
            }
            return true;
        }

        public bool RecursiveIsValidBST(TreeNode root, out int max, out int min)
        {
            max = root.val;
            min = root.val;
            bool leftValid = true;
            if (root.left != null)
            {
                if (root.left.val >= root.val)
                {
                    return false;
                }
                leftValid = RecursiveIsValidBST(root.left, out int leftMax, out min);
                if (leftMax >= root.val)
                {
                    return false;
                }
            }
            bool rightValid = true;
            if (root.right != null)
            {
                if (root.right.val <= root.val)
                {
                    return false;
                }
                rightValid = RecursiveIsValidBST(root.right, out max, out int rightMin);
                if (rightMin <= root.val)
                {
                    return false;
                }
            }
            return leftValid && rightValid;
        }
    }
}
