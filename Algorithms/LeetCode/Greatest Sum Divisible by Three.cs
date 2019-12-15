﻿using System;

namespace Algorithms.LeetCode
{
    /* 1262. Greatest Sum Divisible by Three
     * 
     * Given an array nums of integers, we need to find the maximum possible sum of elements
     * of the array such that it is divisible by three.
     * 
     * Example 1:
     * 
     * Input: nums = [3,6,5,1,8]
     * Output: 18
     * Explanation: Pick numbers 3, 6, 1 and 8 their sum is 18 (maximum sum divisible by 3).
     * 
     * Example 2:
     * 
     * Input: nums = [4]
     * Output: 0
     * Explanation: Since 4 is not divisible by 3, do not pick any number.
     * 
     * Example 3:
     * 
     * Input: nums = [1,2,3,4,4]
     * Output: 12
     * Explanation: Pick numbers 1, 3, 4 and 4 their sum is 12 (maximum sum divisible by 3).
     *  
     * Constraints:
     * 1 <= nums.length <= 4 * 10^4
     * 1 <= nums[i] <= 10^4
     */
    public class Greatest_Sum_Divisible_by_Three
    {
        public int MaxSumDivThree(int[] nums)
        {
            // dp[i] is the maximum possible sum so far such that dp[i] % 3 == i
            int[] dp = new int[3];
            foreach (int num in nums)
            {
                int[] next = new int[3]; // Next possible candidates for dp[0~2].
                foreach (int sum in dp)
                {
                    int mod = (sum + num) % 3;
                    next[mod] = Math.Max(next[mod], sum + num);
                }

                for (int i = 0; i < 3; i++) dp[i] = Math.Max(dp[i], next[i]);
            }
            return dp[0];
        }
    }
}
