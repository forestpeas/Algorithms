using System;

namespace Algorithms.LeetCode
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
     * Follow up:
     * 
     * If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
     */
    public class MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxNegative = int.MinValue;
            int i = 0;
            for (; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    maxNegative = Math.Max(maxNegative, nums[i]);
                }
                else break;
            }
            if (i == nums.Length) return maxNegative;

            int result = 0;
            int sum = 0;
            int negatives = 0;
            for (; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    if (sum + negatives < 0)
                    {
                        sum = nums[i];
                    }
                    else
                    {
                        sum = sum + negatives + nums[i];
                    }
                    result = Math.Max(result, sum);
                    negatives = 0;
                }
                else
                {
                    negatives += nums[i];
                }
            }
            return result;
        }
    }
}
