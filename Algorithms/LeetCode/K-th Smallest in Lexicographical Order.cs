using System;

namespace Algorithms.LeetCode
{
    /* 440. K-th Smallest in Lexicographical Order
     * 
     * Given integers n and k, find the lexicographically k-th smallest integer in the range from 1 to n.
     * 
     * Note: 1 ≤ k ≤ n ≤ 109.
     * 
     * Example:
     * 
     * Input:
     * n: 13   k: 2
     * 
     * Output:
     * 10
     * 
     * Explanation:
     * The lexicographical order is [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9], so the second smallest number is 10.
     */
    public class K_th_Smallest_in_Lexicographical_Order
    {
        public int FindKthNumber(int n, int k)
        {
            // Inspired by https://leetcode.com/problems/k-th-smallest-in-lexicographical-order/discuss/92242/ConciseEasy-to-understand-Java-5ms-solution-with-Explaination
            // Find the k-th node in the preorder traversal of a 10-nary tree.
            // Loop ends when k = 1, i.e. the first node of tree "node".
            int node = 1;
            while (k > 1)
            {
                int total = GetTotalNumberOfNode(n, node);
                if (total < k)
                {
                    node += 1;
                    k -= total;
                }
                else
                {
                    node *= 10;
                    k -= 1;
                }
            }
            return node;
        }

        private int GetTotalNumberOfNode(int n, long node)
        {
            long steps = 1, level = 1;
            node *= 10;
            while (node <= n)
            {
                level *= 10;
                steps += Math.Min(level, n - node + 1);
                node *= 10;
            }
            return (int)steps;
        }
    }
}
