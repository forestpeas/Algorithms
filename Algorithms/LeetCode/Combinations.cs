using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 77. Combinations
     * 
     * Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
     * 
     * Example:
     * 
     * Input: n = 4, k = 2
     * Output:
     * [
     *   [2,4],
     *   [3,4],
     *   [2,3],
     *   [1,2],
     *   [1,3],
     *   [1,4],
     * ]
     */
    public class Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var results = new List<IList<int>>();
            Combine(new int[k], 0, 1);
            return results;

            void Combine(int[] result, int i, int start)
            {
                if (i + 1 == k)
                {
                    for (int j = start; j <= n; j++)
                    {
                        result[i] = j;
                        results.Add((int[])result.Clone());
                    }
                }
                else
                {
                    for (int j = start; j <= i + 1 + (n - k); j++)
                    {
                        result[i] = j;
                        Combine(result, i + 1, j + 1);
                    }
                }
            }
        }
    }
}
