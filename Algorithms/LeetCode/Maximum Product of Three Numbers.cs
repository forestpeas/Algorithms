using System;

namespace Algorithms.LeetCode
{
    /* 628. Maximum Product of Three Numbers
     * 
     * Given an integer array nums, find three numbers whose product is maximum and return the maximum product.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3]
     * Output: 6
     * 
     * Example 2:
     * 
     * Input: nums = [1,2,3,4]
     * Output: 24
     * 
     * Example 3:
     * 
     * Input: nums = [-1,-2,-3]
     * Output: -6
     */
    public class Maximum_Product_of_Three_Numbers
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            return Math.Max(nums[0] * nums[1] * nums[^1], nums[^1] * nums[^2] * nums[^3]);
        }
    }
}
