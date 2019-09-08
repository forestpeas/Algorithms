using System;

namespace Algorithms.LeetCode
{
    /* 53. Maximum Subarray
     * 
     * Given an integer array nums, find the contiguous subarray (containing at least one number)
     * which has the largest sum and return its sum.
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
            // Dynamic programming.
            // dp(i) = max(nums[i], nums[i] + dp(i - 1))
            // dp(i) means the result when the right boundary of the subarray is fixed at index i.
            // (But the left boundary can move within [0...i])
            if (nums.Length == 0) return 0;
            int max = nums[0];
            int sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], nums[i] + sum);
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
}
