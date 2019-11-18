using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 404. Sum of Left Leaves
     * 
     * Find the sum of all left leaves in a given binary tree.
     * 
     * Example:
     * 
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * 
     * There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.
     */
    public class Sum_of_Left_Leaves
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;

            int result = 0;
            if (root.left != null)
            {
                if (root.left.left == null && root.left.right == null) result += root.left.val;
                else result += SumOfLeftLeaves(root.left);
            }
            result += SumOfLeftLeaves(root.right);
            return result;
        }

        // From a parent's perspective, it doesn't know which of its children is a leaf.
        // From a child's perspective, it doesn't know whether it is a left child.

        public int SumOfLeftLeaves1(TreeNode root)
        {
            if (root == null) return 0;
            int result = 0;
            IsLeaf(root);
            return result;

            bool IsLeaf(TreeNode node)
            {
                if (node.left == null && node.right == null) return true;
                if (node.left != null && IsLeaf(node.left)) result += node.left.val;
                if (node.right != null) IsLeaf(node.right);
                return false;
            }
        }

        public int SumOfLeftLeaves2(TreeNode root)
        {
            if (root == null) return 0;
            return SumOfLeftLeaves(root, false);
        }

        private int SumOfLeftLeaves(TreeNode node, bool isLeft)
        {
            if (node.left == null && node.right == null) return isLeft ? node.val : 0;
            int sum = 0;
            if (node.left != null) sum += SumOfLeftLeaves(node.left, true);
            if (node.right != null) sum += SumOfLeftLeaves(node.right, false);
            return sum;
        }
    }
}
