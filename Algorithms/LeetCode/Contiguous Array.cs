using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 525. Contiguous Array
     * 
     * Given a binary array, find the maximum length of a contiguous subarray with equal number of 0
     * and 1.
     * 
     * Example 1:
     * Input: [0,1]
     * Output: 2
     * Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
     * 
     * Example 2:
     * Input: [0,1,0]
     * Output: 2
     * Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
     */
    public class Contiguous_Array
    {
        public int FindMaxLength(int[] nums)
        {
            var seen = new Dictionary<int, int>() { [0] = -1 };
            int curr = 0, res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                curr += nums[i] == 1 ? 1 : -1;
                if (seen.TryGetValue(curr, out int j))
                {
                    res = Math.Max(res, i - j);
                }
                else
                {
                    seen.Add(curr, i);
                }
            }
            return res;
        }
    }
}
