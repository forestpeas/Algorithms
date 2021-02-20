using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 594. Longest Harmonious Subsequence
     * 
     * We define a harmonious array as an array where the difference between its maximum value and
     * its minimum value is exactly 1.
     * 
     * Given an integer array nums, return the length of its longest harmonious subsequence among
     * all its possible subsequences.  
     * 
     * Example 1:
     * 
     * Input: nums = [1,3,2,2,5,2,3,7]
     * Output: 5
     * Explanation: The longest harmonious subsequence is [3,2,2,2,3].
     * 
     * Example 2:
     * 
     * Input: nums = [1,2,3,4]
     * Output: 2
     * 
     * Example 3:
     * 
     * Input: nums = [1,1,1,1]
     * Output: 0
     */
    public class Longest_Harmonious_Subsequence
    {
        public int FindLHS(int[] nums)
        {
            var counts = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                counts[num] = counts.GetValueOrDefault(num) + 1;
            }

            int res = 0;
            foreach (var item in counts)
            {
                int num = item.Key;
                int count = item.Value;
                if (counts.ContainsKey(num + 1))
                {
                    res = Math.Max(res, count + counts[num + 1]);
                }
            }
            return res;
        }
    }
}
