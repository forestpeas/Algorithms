using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1382. Balance a Binary Search Tree
     * 
     * Given a binary search tree, return a balanced binary search tree with the same node values.
     * 
     * A binary search tree is balanced if and only if the depth of the two subtrees of every node
     * never differ by more than 1.
     * 
     * If there is more than one answer, return any of them.
     * 
     * Example 1:
     * https://leetcode.com/problems/balance-a-binary-search-tree/
     * Input: root = [1,null,2,null,3,null,4,null,null]
     * Output: [2,1,3,null,null,null,4]
     * Explanation: This is not the only correct answer, [3,1,4,null,2,null,null] is also correct.
     */
    public class Balance_a_Binary_Search_Tree
    {
        public TreeNode BalanceBST(TreeNode root)
        {
            var asc = GetListFromTree(root);
            return BalanceBST(asc, 0, asc.Count - 1);
        }

        private TreeNode BalanceBST(IList<int> asc, int start, int end)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            var root = new TreeNode(asc[mid]);
            root.left = BalanceBST(asc, start, mid - 1);
            root.right = BalanceBST(asc, mid + 1, end);
            return root;
        }

        public IList<int> GetListFromTree(TreeNode root)
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
