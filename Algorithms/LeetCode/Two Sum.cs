using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1. Two Sum
     * 
     * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * 
     * Example:
     * Given nums = [2, 7, 11, 15], target = 9,
     * Because nums[0] + nums[1] = 2 + 7 = 9,
     * return [0, 1].
     */
    public class TwoSumSolution
    {
        // Your runtime beats 84.08 % of csharp submissions.
        // Your memory usage beats 39.65 % of csharp submissions.
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>(nums.Length * 2);
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            throw new ArgumentException("No two sum solution");
        }
    }
}
