using System;

namespace Algorithms.LeetCode
{
    /* 1292. Maximum Side Length of a Square with Sum Less than or Equal to Threshold
     * 
     * Given a m x n matrix mat and an integer threshold. Return the maximum side-length of a
     * square with a sum less than or equal to threshold or return 0 if there is no such square.
     * 
     * 0 <= mat[i][j] <= 10000
     * 
     * https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/
     */
    public class Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold
    {
        public int MaxSideLength(int[][] mat, int threshold)
        {
            // Binary search. Similar to "1283. Find the Smallest Divisor Given a Threshold".
            int m = mat.Length;
            int n = mat[0].Length;
            // Calculate "prefix sums".
            int[,] sums = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sums[i, j] = mat[i - 1][j - 1];
                    sums[i, j] += sums[i - 1, j] + sums[i, j - 1] - sums[i - 1, j - 1];
                }
            }

            // Possible range: [lo, hi)
            int lo = 0;
            int hi = Math.Min(m, n) + 1;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (Exists(mid)) lo = mid;
                else hi = mid;
            }

            return lo;

            bool Exists(int len)
            {
                for (int i = len; i <= m; i++)
                {
                    for (int j = len; j <= n; j++)
                    {
                        if (sums[i, j] - sums[i - len, j] - sums[i, j - len] + sums[i - len, j - len] <= threshold)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
