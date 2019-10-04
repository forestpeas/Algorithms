using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 113. Path Sum II
     * 
     * Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
     * Note: A leaf is a node with no children.
     * 
     * Example:
     * 
     * Given the below binary tree and sum = 22,
     * 
     *       5
     *      / \
     *     4   8
     *    /   / \
     *   11  13  4
     *  /  \    / \
     * 7    2  5   1
     * Return:
     * 
     * [
     *    [5,4,11,2],
     *    [5,8,4,5]
     * ]
     */
    public class PathSumII
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            // Backtracking and DFS.
            var result = new List<IList<int>>();
            if (root == null) return result;
            PathSum(root, sum, new List<int>());
            return result;

            void PathSum(TreeNode node, int sumCurr, List<int> path)
            {
                path.Add(node.val);
                sumCurr = sumCurr - node.val;
                if (node.left == null && node.right == null)
                {
                    if (sumCurr == 0) result.Add(path.ToArray());
                }
                else
                {
                    if (node.left != null) PathSum(node.left, sumCurr, path);
                    if (node.right != null) PathSum(node.right, sumCurr, path);
                }
                path.RemoveAt(path.Count - 1); // Remove root.val
            }
        }
    }
}
