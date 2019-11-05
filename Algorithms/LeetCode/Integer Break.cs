using System;

namespace Algorithms.LeetCode
{
    /* 343. Integer Break
     * 
     * Given a positive integer n, break it into the sum of at least two positive integers
     * and maximize the product of those integers. Return the maximum product you can get.
     * 
     * Example 1:
     * 
     * Input: 2
     * Output: 1
     * Explanation: 2 = 1 + 1, 1 × 1 = 1.
     * 
     * Example 2:
     * 
     * Input: 10
     * Output: 36
     * Explanation: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36.
     * 
     * Note: You may assume that n is not less than 2 and not larger than 58.
     */
    public class IntegerBreakSolution
    {
        public int IntegerBreak(int n)
        {
            // Inspired by https://leetcode.com/problems/integer-break/discuss/80721/Why-factor-2-or-3-The-math-behind-this-problem./85320
            // If an optimal product contains a factor f >= 4, then you can replace it
            // with factors 2 and f-2 without losing optimality, as 2*(f-2) = 2f-4 >= f.
            // So you never need a factor greater than or equal to 4, meaning you only
            // need factors 1, 2 and 3 (and 1 is of course wasteful and you'd only use
            // it for n=2 and n=3, where it's needed).
            // 3 * 3 is simply better than 2 * 2 * 2, so you'd never use 2 more than twice.
            // For example: 6 = 2 + 2 + 2 = 3 + 3. But 2 * 2 * 2 < 3 * 3.
            if (n == 2) return 1;
            if (n == 3) return 2;
            int product = 1;
            while (n >= 5)
            {
                product *= 3;
                n -= 3;
            }
            product *= n;

            return product;
        }

        public int IntegerBreak2(int n)
        {
            // DP.
            if (n == 2) return 1;
            if (n == 3) return 2;

            int[] dp = new int[n + 1];
            dp[2] = 2;
            dp[3] = 3;
            for (int i = 4; i <= n; i++)
            {
                for (int j = 2; j <= i / 2; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[j] * dp[i - j]);
                }
            }

            return dp[n];
        }
    }
}
