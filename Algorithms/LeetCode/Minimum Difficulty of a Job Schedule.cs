using System;

namespace Algorithms.LeetCode
{
    /* 1335. Minimum Difficulty of a Job Schedule
     * 
     * Cut the array into d non-empty sub-arrays. Find the minimum sum of the maximum
     * values from each sub-array.
     * 
     * https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
     */
    public class Minimum_Difficulty_of_a_Job_Schedule
    {
        public int MinDifficulty(int[] arr, int d)
        {
            // dp[j,i] is the answer to scheduling arr[0...i] in j days.
            int n = arr.Length;
            if (d > n) return -1;

            int[,] dp = new int[d + 1, n];
            dp[1, 0] = arr[0];
            for (int i = 1; i < n; i++)
            {
                dp[1, i] = Math.Max(dp[1, i - 1], arr[i]);
            }

            for (int j = 2; j < d + 1; j++)
            {
                for (int i = j - 1; i < n; i++)
                {
                    int maxd = 0;
                    dp[j, i] = int.MaxValue;
                    // Split arr[0...i] into arr[0...k-1] amd arr[k...i].
                    // And make sure there are enough jobs for j-1 days.
                    for (int k = i; k > 0 && k >= j - 1; k--)
                    {
                        maxd = Math.Max(maxd, arr[k]);
                        dp[j, i] = Math.Min(dp[j, i], dp[j - 1, k - 1] + maxd);
                    }
                }
            }

            return dp[d, n - 1];
        }
    }
}
