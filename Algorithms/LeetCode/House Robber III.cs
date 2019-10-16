using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 337. House Robber III
     * 
     * The thief has found himself a new place for his thievery again. There is only one entrance to
     * this area, called the "root." Besides the root, each house has one and only one parent house.
     * After a tour, the smart thief realized that "all houses in this place forms a binary tree".
     * It will automatically contact the police if two directly-linked houses were broken into on the
     * same night.
     * 
     * Determine the maximum amount of money the thief can rob tonight without alerting the police.
     * 
     * Example 1:
     * 
     * Input: [3,2,3,null,3,null,1]
     * 
     *      3
     *     / \
     *    2   3
     *     \   \ 
     *      3   1
     * 
     * Output: 7 
     * Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
     * 
     * Example 2:
     * 
     * Input: [3,4,5,1,3,null,1]
     * 
     *      3
     *     / \
     *    4   5
     *   / \   \ 
     *  1   3   1
     * 
     * Output: 9
     * Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.
     */
    public class HouseRobberIII
    {
        public int Rob(TreeNode root)
        {
            int[] res = Rob(root);
            return Math.Max(res[0], res[1]);

            // Assume the array returned by the following function is a.
            // a[0] means the maximum money from a tree with "node" as root, with the restriction of 
            // "node" NOT being included.
            // a[1], on the other hand, gives a similar meaning but with "node" being included.
            int[] Rob(TreeNode node)
            {
                if (node == null) return new int[2];

                int[] left = Rob(node.left);
                int[] right = Rob(node.right);
                int[] result = new int[2];

                result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
                result[1] = node.val + left[0] + right[0];

                return result;
            }
        }

        public int Rob2(TreeNode root)
        {
            // DFS with memoization.
            var mem = new Dictionary<TreeNode, int>();
            return Rob(root);

            // Returns the maximum money from a tree with "node" as root.
            int Rob(TreeNode node)
            {
                if (node == null) return 0;
                if (mem.TryGetValue(node, out int value)) return value;

                int candidate1 = node.val +
                    Rob(node.left?.left) +
                    Rob(node.left?.right) +
                    Rob(node.right?.left) +
                    Rob(node.right?.right);

                int candidate2 = Rob(node.left) + Rob(node.right);
                int result = Math.Max(candidate1, candidate2);
                mem.Add(node, result);
                return result;
            }
        }
    }
}
