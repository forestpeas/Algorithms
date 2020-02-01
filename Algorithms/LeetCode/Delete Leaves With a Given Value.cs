using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1325. Delete Leaves With a Given Value
     * 
     * Given a binary tree root and an integer target, delete all the leaf nodes with value target.
     * 
     * https://leetcode.com/problems/delete-leaves-with-a-given-value/
     */
    public class Delete_Leaves_With_a_Given_Value
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            if (root == null) return null;
            TreeNode left = RemoveLeafNodes(root.left, target);
            TreeNode right = RemoveLeafNodes(root.right, target);
            if (left == null) root.left = null;
            if (right == null) root.right = null;
            if (left == null && right == null && root.val == target) return null;
            return root;
        }
    }
}
