using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 95. Unique Binary Search Trees II
     * 
     * Given an integer n, generate all structurally unique BST's (binary search trees) that store values 1 ... n.
     * 
     * Example:
     * 
     * Input: 3
     * Output:
     * 
     *    1         3     3      2      1
     *     \       /     /      / \      \
     *      3     2     1      1   3      2
     *     /     /       \                 \
     *    2     1         2                 3
     */
    public class UniqueBinarySearchTreesII
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            // Recursion. For example: n = 5. 
            // foreach(i in n)
            // let i be the root.
            // its left node should be all possible results of GenerateTrees(0, i - 1).
            // its right node should be all possible results of GenerateTrees(i + 1, n).
            return GenerateTrees(1, n);
        }

        // This method returns all possible BST's that store values [start...end].
        private IList<TreeNode> GenerateTrees(int start, int end)
        {
            if (start == end) return new TreeNode[] { new TreeNode(start) };
            var results = new List<TreeNode>();
            for (int i = start; i <= end; i++)
            {
                IList<TreeNode> leftResults;
                if (i == start)
                {
                    leftResults = new TreeNode[] { null };
                }
                else
                {
                    leftResults = GenerateTrees(start, i - 1);
                }

                IList<TreeNode> rightResults;
                if (i == end)
                {
                    rightResults = new TreeNode[] { null };
                }
                else
                {
                    rightResults = GenerateTrees(i + 1, end);
                }

                foreach (var leftResult in leftResults)
                {
                    foreach (var rightResult in rightResults)
                    {
                        results.Add(new TreeNode(i) { left = leftResult, right = rightResult });
                    }
                }
            }

            return results;
        }
    }
}
