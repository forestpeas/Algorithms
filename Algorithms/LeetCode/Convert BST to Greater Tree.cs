using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 538. Convert BST to Greater Tree
     * 
     * Given the root of a Binary Search Tree (BST), convert it to a Greater Tree such that
     * every key of the original BST is changed to the original key plus sum of all keys
     * greater than the original key in BST.
     * 
     * https://leetcode.com/problems/convert-bst-to-greater-tree/
     */
    public class Convert_BST_to_Greater_Tree
    {
        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            Dfs(root);
            return root;

            void Dfs(TreeNode node)
            {
                if (node == null) return;
                Dfs(node.right);
                sum += node.val;
                node.val = sum;
                Dfs(node.left);
            }
        }
    }
}
