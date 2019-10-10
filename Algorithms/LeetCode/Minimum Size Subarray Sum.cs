using System;

namespace Algorithms.LeetCode
{
    /* 209. Minimum Size Subarray Sum
     * 
     * Given an array of n positive integers and a positive integer s, find the minimal length
     * of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.
     * 
     * Example: 
     * 
     * Input: s = 7, nums = [2,3,1,2,4,3]
     * Output: 2
     * Explanation: the subarray [4,3] has the minimal length under the problem constraint.
     */
    public class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            // Maintains a sliding window of [l,r] that satisfies the requirement.
            int minLength = int.MaxValue;
            int sum = 0;
            for (int l = 0, r = 0; r < nums.Length; r++)
            {
                sum += nums[r];
                if (sum < s) continue; // Wait until sum of [l,r] >= s.
                while (sum - nums[l] >= s)
                {
                    sum = sum - nums[l];
                    l++;
                }

                minLength = Math.Min(minLength, r - l + 1);
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
