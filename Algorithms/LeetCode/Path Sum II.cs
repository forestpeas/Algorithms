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
        private readonly List<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            // Backtracking and DFS.
            if (root == null) return _result;
            PathSum(root, sum, new List<int>());
            return _result;
        }

        private void PathSum(TreeNode root, int sum, List<int> path)
        {
            path.Add(root.val);
            sum = sum - root.val;
            if (root.left == null && root.right == null)
            {
                if (sum == 0) _result.Add(path.ToArray());
            }
            else
            {
                if (root.left != null) PathSum(root.left, sum, path);
                if (root.right != null) PathSum(root.right, sum, path);
            }
            path.RemoveAt(path.Count - 1); // Remove root.val
        }
    }
}
