using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 454. 4Sum II
     * 
     * Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are
     * such that A[i] + B[j] + C[k] + D[l] is zero.
     * 
     * To make problem a bit easier, all A, B, C, D have same length of N where 0 ≤ N ≤ 500. All integers
     * are in the range of -228 to 228 - 1 and the result is guaranteed to be at most 231 - 1.
     * 
     * Example:
     * 
     * Input:
     * A = [ 1, 2]
     * B = [-2,-1]
     * C = [-1, 2]
     * D = [ 0, 2]
     * 
     * Output:
     * 2
     * 
     * Explanation:
     * The two tuples are:
     * 1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
     * 2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
     */
    public class FourSumII
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            // Brute-force is O(N^4), so we have to trade space for time.
            // First, store the sums of every combination of A[i] and B[j].
            // Then, for every combination of C[i] and D[j], if we can find
            // -(C[i] + D[j]) in the hash table, we have an answer.
            var sumCount = new Dictionary<int, int>(); // key is sum, value is frequency.
            foreach (int a in A)
            {
                foreach (int b in B)
                {
                    sumCount[a + b] = sumCount.GetValueOrDefault(a + b) + 1;
                }
            }

            int result = 0;
            foreach (int c in C)
            {
                foreach (int d in D)
                {
                    if (sumCount.TryGetValue(-c - d, out int count))
                    {
                        result += count;
                    }
                }
            }
            return result;
        }
    }
}
