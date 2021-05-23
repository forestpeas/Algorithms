﻿using System;

namespace Algorithms.LeetCode
{
    /* 1793. Maximum Score of a Good Subarray
     * 
     * You are given an array of integers nums (0-indexed) and an integer k.
     * 
     * The score of a subarray (i, j) is defined as min(nums[i], nums[i+1], ..., nums[j]) * (j - i + 1).
     * A good subarray is a subarray where i <= k <= j.
     * 
     * Return the maximum possible score of a good subarray.
     * 
     * Example 1:
     * 
     * Input: nums = [1,4,3,7,4,5], k = 3
     * Output: 15
     * Explanation: The optimal subarray is (1, 5) with a score of min(4,3,7,4,5) * (5-1+1) = 3 * 5 = 15. 
     * 
     * Example 2:
     * 
     * Input: nums = [5,5,4,5,4,1,1,1], k = 0
     * Output: 20
     * Explanation: The optimal subarray is (0, 4) with a score of min(5,5,4,5,4) * (4-0+1) = 4 * 5 = 20.
     */
    public class Maximum_Score_of_a_Good_Subarray
    {
        public int MaximumScore(int[] nums, int k)
        {
            // each time we expand the length of the subarray, we can try to
            // maximize the minimum value in the subarray
            int res = nums[k], min = nums[k];
            int i = k, j = k;
            while (i > 0 || j < nums.Length - 1)
            {
                if (i == 0) j++;
                else if (j == nums.Length - 1) i--;
                else if (nums[i - 1] < nums[j + 1]) j++;
                else i--;
                min = Math.Min(min, Math.Min(nums[i], nums[j]));
                res = Math.Max(res, min * (j - i + 1));
            }
            return res;
        }
    }
}