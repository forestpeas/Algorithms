using System;

namespace Algorithms.LeetCode
{
    /* 674. Longest Continuous Increasing Subsequence
     * 
     * Given an unsorted array of integers nums, return the length of the longest continuous
     * increasing subsequence (i.e. subarray). The subsequence must be strictly increasing.  
     * 
     * Example 1:
     * 
     * Input: nums = [1,3,5,4,7]
     * Output: 3
     * Explanation: The longest continuous increasing subsequence is [1,3,5] with length 3.
     * Even though [1,3,5,7] is an increasing subsequence, it is not continuous as elements 5
     * and 7 are separated by element
     * 4.
     * 
     * Example 2:
     * 
     * Input: nums = [2,2,2,2,2]
     * Output: 1
     * Explanation: The longest continuous increasing subsequence is [2] with length 1. Note
     * that it must be strictly increasing.
     */
    public class Longest_Continuous_Increasing_Subsequence
    {
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            int res = 1, length = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    length++;
                }
                else
                {
                    length = 1;
                }
                res = Math.Max(res, length);
            }
            return res;
        }
    }
}
