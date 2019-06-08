﻿namespace Algorithms.LeetCode
{
    /* 53. Maximum Subarray
     * 
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
     * 
     * Example:
     * 
     * Input: [-2,1,-3,4,-1,2,1,-5,4],
     * Output: 6
     * Explanation: [4,-1,2,1] has the largest sum = 6.
     */
    public class MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            int max = nums[0]; // In case all numbers are negative.
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum < 0)
                {
                    sum = nums[i]; // Reset sum.
                }
                else
                {
                    sum += nums[i];
                }

                if (sum > max) max = sum;
            }

            return max;
        }
    }
}
