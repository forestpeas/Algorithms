using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 437. Path Sum III
     * 
     * You are given a binary tree in which each node contains an integer value.

     * Find the number of paths that sum to a given value.
     * 
     * The path does not need to start or end at the root or a leaf, but it must go downwards (traveling
     * only from parent nodes to child nodes).
     * 
     * The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.
     * 
     * Example:
     * 
     * root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8
     * 
     *       10
     *      /  \
     *     5   -3
     *    / \    \
     *   3   2   11
     *  / \   \
     * 3  -2   1
     * 
     * Return 3. The paths that sum to 8 are:
     * 
     * 1.  5 -> 3
     * 2.  5 -> 2 -> 1
     * 3. -3 -> 11
     */
    public class PathSumIII
    {
        public int PathSum(TreeNode root, int sum)
        {
            int result = 0;
            // Because a node may have a none-positive value, if we DFS the tree, for any given node,
            // we have to examine all the nodes of the path from root to this node bacause they are all
            // potential candidates that may satisfy the requirement.
            // So we let "preSums" contain the sum from root to each node.
            // Key is the sum, value is count of this sum, since there may be nodes with values of 0.
            // We initialize it with {0, 1} in case of root.val == sum.
            var preSums = new Dictionary<int, int>() { { 0, 1 } };
            PathSum(root, 0);
            return result;

            void PathSum(TreeNode node, int currSum)
            {
                if (node == null) return;

                // Check if there exists a condition-satisfying path that ends with the current node.
                // "currSum - sum" means the start of this path (if there exists one).
                currSum += node.val;
                result += preSums.GetValueOrDefault(currSum - sum);
                preSums[currSum] = preSums.GetValueOrDefault(currSum) + 1;

                PathSum(node.left, currSum);
                PathSum(node.right, currSum);

                // Don't forget to remove all the sums from nodes below. We do not necessarily need to
                // remove a sum, simply update its count to 0.
                preSums[currSum] = preSums[currSum] - 1;
            }
        }
    }
}
