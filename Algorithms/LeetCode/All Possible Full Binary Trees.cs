using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 894. All Possible Full Binary Trees
     * 
     * A full binary tree is a binary tree where each node has exactly 0 or 2 children.
     * Return a list of all possible full binary trees with N nodes.
     * Each element of the answer is the root node of one possible tree.
     * 
     * Each node of each tree in the answer must have node.val = 0.
     * You may return the final list of trees in any order.
     * 
     * For more illustration, refer to https://leetcode.com/problems/all-possible-full-binary-trees/.
     */
    public class AllPossibleFullBinaryTrees
    {
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            // Let n be the number of non-leaf nodes.
            // Every non-leaf node has 2 children, plus the root node. 
            // So 2n+1=N, and n=(N-1)/2. So N should be an odd number.
            // For each node in the non-leaf nodes, let node be root.
            // The solution is almost the same as "Problem 95. Unique Binary Search Trees II"
            // because they are all Catalan number problems.
            if (N == 1) return new TreeNode[] { new TreeNode(0) };
            if (N % 2 == 0) return new TreeNode[0]; // Even N is not a full binary tree.
            return AllPossibleFBT(1, (N - 1) / 2);
        }

        private IList<TreeNode> AllPossibleFBT(int start, int end)
        {
            if (start > end) return new TreeNode[] { new TreeNode(0) };

            var results = new List<TreeNode>();
            for (int i = start; i <= end; i++)
            {
                IList<TreeNode> leftResults = AllPossibleFBT(start, i - 1);
                IList<TreeNode> rightResults = AllPossibleFBT(i + 1, end);
                foreach (var leftResult in leftResults)
                {
                    foreach (var rightResult in rightResults)
                    {
                        results.Add(new TreeNode(0) { left = leftResult, right = rightResult });
                    }
                }
            }

            return results;
        }
    }
}
