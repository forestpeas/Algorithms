using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 523. Continuous Subarray Sum
     * 
     * Given a list of non-negative numbers and a target integer k, write a function to check if
     * the array has a continuous subarray of size at least 2 that sums up to a multiple of k,
     * that is, sums up to n*k where n is also an integer. 
     * 
     * Example 1:
     * 
     * Input: [23, 2, 4, 6, 7],  k=6
     * Output: True
     * Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
     * 
     * Example 2:
     * 
     * Input: [23, 2, 6, 4, 7],  k=6
     * Output: True
     * Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
     */
    public class Continuous_Subarray_Sum
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            // reference: https://leetcode.com/problems/continuous-subarray-sum/discuss/99499/Java-O(n)-time-O(k)-space/103585
            var seen = new Dictionary<int, int>() { [0] = -1 };
            int curr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                curr += nums[i];
                if (k != 0) curr %= k;
                if (seen.TryGetValue(curr, out int j))
                {
                    if (i - j > 1) return true;
                }
                else
                {
                    seen.Add(curr, i);
                }
            }
            return false;
        }
    }
}
