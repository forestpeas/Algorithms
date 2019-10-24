using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 354. Russian Doll Envelopes
     * 
     * You have a number of envelopes with widths and heights given as a pair of integers (w, h).
     * One envelope can fit into another if and only if both the width and height of one envelope
     * is greater than the width and height of the other envelope.
     * 
     * What is the maximum number of envelopes can you Russian doll? (put one inside other)
     * 
     * Note:
     * Rotation is not allowed.
     * 
     * Example:
     * 
     * Input: [[5,4],[6,4],[6,7],[2,3]]
     * Output: 3 
     * Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
     */
    public class RussianDollEnvelopes
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            // Sort by width, then find the longest increasing subsequence (Problem 300) of height.
            // Because envelopes with the same width cannot fit each other, we sort the height in
            // descending order if widths are equal.
            int[] heights = envelopes.OrderBy(e => e[0]).ThenByDescending(e => e[1]).Select(e => e[1]).ToArray();
            var piles = new List<int>();
            foreach (int h in heights)
            {
                int idx = piles.BinarySearch(h);
                if (idx < 0) idx = ~idx;
                if (idx == piles.Count) piles.Add(h);
                else piles[idx] = h;
            }
            return piles.Count;
        }

        public int MaxEnvelopes2(int[][] envelopes)
        {
            // First time DP attempt. O(N^2).
            Array.Sort(envelopes, Comparer<int[]>.Create((x, y) => x[0] * x[1] - y[0] * y[1]));
            int result = 0;
            int[] dp = new int[envelopes.Length]; // dp[i] is the length "starting" from envelopes[i].
            for (int i = envelopes.Length - 1; i >= 0; i--)
            {
                dp[i] = 1;
                for (int j = i + 1; j < envelopes.Length; j++)
                {
                    if (envelopes[j][0] > envelopes[i][0] && envelopes[j][1] > envelopes[i][1])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }

                result = Math.Max(result, dp[i]);
            }

            return result;
        }
    }
}
