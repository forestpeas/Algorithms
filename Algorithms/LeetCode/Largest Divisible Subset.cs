using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 368. Largest Divisible Subset
     * 
     * Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj)
     * of elements in this subset satisfies:
     * 
     * Si % Sj = 0 or Sj % Si = 0.
     * 
     * If there are multiple solutions, return any subset is fine.
     * 
     * Example 1:
     * 
     * Input: [1,2,3]
     * Output: [1,2] (of course, [1,3] will also be ok)
     * 
     * Example 2:
     * 
     * Input: [1,2,4,8]
     * Output: [1,2,4,8]
     */
    public class LargestDivisibleSubsetSolution
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            // For example, 4 % 2 = 0, so we have [2, 4]. If the next number is 8, and
            // 8 % 4 = 0, we know 8 is definitely divisible by 2, thus getting [2, 4, 8].
            // So we can sort the array first.
            Array.Sort(nums);

            // For each nums[i], if we find a nums[j] such that
            // nums[i] % nums[j] == 0, j < i
            // we can link nums[i] to nums[j], i. e. links[i] = j.
            // dp[i] means the maximum number of links that "ends" with nums[i].
            // For example, [2, 3, 4], link 4 to 2, and 4 has 2 links (including itself).
            int maxSubsetLength = 0; // The maximum dp[i] so far.
            int maxSubsetIdx = -1; // The corresponding i to maxSubsetLength.
            int[] links = new int[nums.Length];
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
                links[i] = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        links[i] = j;
                    }
                }

                if (dp[i] > maxSubsetLength)
                {
                    maxSubsetLength = dp[i];
                    maxSubsetIdx = i;
                }
            }

            var result = new List<int>();
            for (int i = maxSubsetIdx; i != -1; i = links[i])
            {
                result.Add(nums[i]);
            }

            return result;
        }
    }
}
