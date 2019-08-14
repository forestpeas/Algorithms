using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 108. Convert Sorted Array to Binary Search Tree
     * 
     * Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
     * For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of
     * the two subtrees of every node never differ by more than 1.
     * 
     * Example:
     * 
     * Given the sorted array: [-10,-3,0,5,9],
     * 
     * One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
     * 
     *       0
     *      / \
     *    -3   9
     *    /   /
     *  -10  5
     */
    public class ConvertSortedArrayToBinarySearchTree
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;
            return SortedArrayToBST(0, nums.Length - 1);

            TreeNode SortedArrayToBST(int start, int end)
            {
                if (start == end) return new TreeNode(nums[start]);
                // "mid" as root, so that the left and right parts are same in height.
                int mid = (start + end) / 2;
                TreeNode root = new TreeNode(nums[mid]);
                if (mid - 1 >= start) root.left = SortedArrayToBST(start, mid - 1);
                if (mid + 1 <= end) root.right = SortedArrayToBST(mid + 1, end);
                return root;
            }
        }
    }
}
