using System;

namespace Algorithms.LeetCode
{
    /* 673. Number of Longest Increasing Subsequence
     * 
     * Given an integer array nums, return the number of longest increasing subsequences.
     * 
     * Notice that the sequence has to be strictly increasing.
     * 
     * Example 1:
     * 
     * Input: nums = [1,3,5,4,7]
     * Output: 2
     * Explanation: The two longest increasing subsequences are [1, 3, 4, 7] and [1, 3, 5, 7].
     * 
     * Example 2:
     * 
     * Input: nums = [2,2,2,2,2]
     * Output: 5
     * Explanation: The length of longest continuous increasing subsequence is 1, and there are
     * 5 subsequences' length is 1, so output 5.
     */
    public class Number_of_Longest_Increasing_Subsequence
    {
        public int FindNumberOfLIS(int[] nums)
        {
            int[] dpLength = new int[nums.Length];
            int[] dpRes = new int[nums.Length];
            int maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                dpLength[i] = 1;
                dpRes[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (dpLength[j] + 1 > dpLength[i])
                        {
                            dpLength[i] = dpLength[j] + 1;
                            dpRes[i] = dpRes[j];
                        }
                        else if (dpLength[j] + 1 == dpLength[i])
                        {
                            dpRes[i] += dpRes[j];
                        }
                    }
                }
                maxLength = Math.Max(maxLength, dpLength[i]);
            }

            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (dpLength[i] == maxLength) res += dpRes[i];
            }
            return res;
        }
    }
}
