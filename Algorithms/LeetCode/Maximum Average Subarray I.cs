using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 643. Maximum Average Subarray I
     * 
     * Given an array consisting of n integers, find the contiguous subarray of given length k that
     * has the maximum average value. And you need to output the maximum average value.
     * 
     * Example 1:
     * 
     * Input: [1,12,-5,-6,50,3], k = 4
     * Output: 12.75
     * Explanation: Maximum average is (12-5-6+50)/4 = 51/4 = 12.75
     * 
     * Note:
     * 1 <= k <= n <= 30,000.
     * Elements of the given array will be in the range [-10,000, 10,000].
     */
    public class Maximum_Average_Subarray_I
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            // sliding window
            int sum = nums.Take(k).Sum();
            int res = sum;
            for (int i = k; i < nums.Length; i++)
            {
                sum += nums[i];
                sum -= nums[i - k];
                res = Math.Max(res, sum);
            }
            return res / (double)k;
        }
    }
}
