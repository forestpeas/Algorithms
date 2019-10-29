using System.Linq;

namespace Algorithms.LeetCode
{
    /* 494. Target Sum
     * 
     * You are given a list of non-negative integers, a1, a2, ..., an, and a target, S.
     * Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol.
     * 
     * Find out how many ways to assign symbols to make sum of integers equal to target S.
     * 
     * Example 1:
     * Input: nums is [1, 1, 1, 1, 1], S is 3. 
     * Output: 5
     * Explanation: 
     * 
     * -1+1+1+1+1 = 3
     * +1-1+1+1+1 = 3
     * +1+1-1+1+1 = 3
     * +1+1+1-1+1 = 3
     * +1+1+1+1-1 = 3
     * 
     * There are 5 ways to assign symbols to make the sum of nums be target 3.
     * 
     * Note:
     * The length of the given array is positive and will not exceed 20.
     * The sum of elements in the given array will not exceed 1000.
     * Your output answer is guaranteed to be fitted in a 32-bit integer.
     */
    public class TargetSum
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            // Possible range for S is [-sum, sum]. We examine each number in this range as a sum.
            // dp[i, j] means the ways to achieve a sum j using only nums[0...i].
            // For each element nums[i], we can give it a '+' or '-'.
            // (Similar to the knapsack problem, choose it or not.)
            // dp[i, j] = dp[i - 1, j - nums[i]] + dp[i - 1, j + nums[i]]
            // But we need to map [-sum, sum] to [0, 2 * sum] because indexes cannot be negative.
            // It is worth mentioning another brilliant solution from https://leetcode.com/problems/target-sum/discuss/97334/Java-(15-ms)-C%2B%2B-(3-ms)-O(ns)-iterative-DP-solution-using-subset-sum-with-explanation
            // which converts this problem to a subset sum problem: 
            // Find a subset P of nums such that sum(P) = (S + sum(nums)) / 2
            // which is very similar to 416. Partition Equal Subset Sum.
            int sum = nums.Sum();
            if (S < -sum || S > sum) return 0;
            int[,] dp = new int[nums.Length, 2 * sum + 2];
            int offset = sum;

            dp[0, nums[0] + offset] = 1;
            dp[0, -nums[0] + offset] += 1;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = -sum; j <= sum; j++)
                {
                    if (j - nums[i] >= -sum && j - nums[i] <= sum)
                    {
                        dp[i, j + offset] = dp[i - 1, j - nums[i] + offset];
                    }

                    if (j + nums[i] >= -sum && j + nums[i] <= sum)
                    {
                        dp[i, j + offset] += dp[i - 1, j + nums[i] + offset];
                    }
                }
            }

            return dp[nums.Length - 1, S + offset];
        }
    }
}
