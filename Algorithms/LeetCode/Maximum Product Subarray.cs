using System;

namespace Algorithms.LeetCode
{
    /* 152. Maximum Product Subarray
     * 
     * Given an integer array nums, find the contiguous subarray within an array
     * (containing at least one number) which has the largest product.
     * 
     * Example 1:
     * 
     * Input: [2,3,-2,4]
     * Output: 6
     * Explanation: [2,3] has the largest product 6.
     * 
     * Example 2:
     * 
     * Input: [-2,0,-1]
     * Output: 0
     * Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
     */
    public class MaximumProductSubarray
    {
        public int MaxProduct(int[] nums)
        {
            // Dynamic programming. Similar to "Problem 53. Maximum Subarray".
            // dp(i) contains the max product and min product of a subarray whose 
            // right boundary is fixed at index i.(But left boundary can move within [0...i])
            // dp(i + 1) can be calculated from nums[i] and dp(i) as the following.
            if (nums.Length == 0) return 0;
            int max = nums[0];
            int maxCurr = nums[0]; // The maximum product so far
            int minCurr = nums[0]; // The minimum product so far
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    int maxLast = maxCurr;
                    maxCurr = Math.Max(nums[i], nums[i] * minCurr);
                    minCurr = Math.Min(nums[i], nums[i] * maxLast);
                }
                else
                {
                    maxCurr = Math.Max(nums[i], nums[i] * maxCurr);
                    minCurr = Math.Min(nums[i], nums[i] * minCurr);
                }
                max = Math.Max(max, maxCurr);
            }
            return max;
        }
    }
}
