using System;

namespace Algorithms.LeetCode
{
    /* 312. Burst Balloons
     * 
     * Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it
     * represented by array nums. You are asked to burst all the balloons. If the you burst
     * balloon i you will get nums[left] * nums[i] * nums[right] coins. Here left and right
     * are adjacent indices of i. After the burst, the left and right then becomes adjacent.
     * 
     * Find the maximum coins you can collect by bursting the balloons wisely.
     * 
     * Note:
     * You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
     * 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100
     * 
     * Example:
     * 
     * Input: [3,1,5,8]
     * Output: 167 
     * Explanation: nums = [3,1,5,8] --> [3,5,8] -->   [3,8]   -->  [8]  --> []
     *              coins =  3*1*5      +  3*5*8    +  1*3*8      + 1*8*1   = 167
     */
    public class BurstBalloons
    {
        public int MaxCoins(int[] nums)
        {
            // Inspired by https://leetcode.com/problems/burst-balloons/discuss/76228/Share-some-analysis-and-explanations
            // First, in order to let nums[-1] = nums[n] = 1, we let nums[0] = nums[n + 1] = 1,
            // and the rest of nums are shifted to the right by 1.
            int[] newNums = new int[nums.Length + 2];
            int n = 1;
            foreach (int x in nums) newNums[n++] = x;
            newNums[0] = newNums[n++] = 1;
            nums = newNums;

            // dp(l, r) is the answer of bursting all the balloons between l and r, with l being the left boundary
            // and r being the right boundary(which means we can only burst balloons with index i, l < i < r).
            // If the balloon at index i is the last balloon to burst within (l,r) in the optimal case, the coins
            // we get by bursting balloon at i is simply (nums[l] * nums[i] * nums[r]). Before bursting balloon i,
            // we have collected the coins obtained from bursting balloons within (l,i) and (i,r).
            // dp(i, j) = max(nums[l] * nums[i] * nums[r] + dp[l, i] + dp[i, r]), l < i < r
            int[,] dp = new int[n, n];
            for (int k = 2; k < n; k++)
            {
                for (int l = 0; l < n - k; l++)
                {
                    int r = l + k;
                    for (int i = l + 1; i < r; i++)
                    {
                        dp[l, r] = Math.Max(dp[l, r], nums[l] * nums[i] * nums[r] + dp[l, i] + dp[i, r]);
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
