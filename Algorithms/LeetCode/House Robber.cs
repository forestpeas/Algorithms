using System;

namespace Algorithms.LeetCode
{
    /* 198. House Robber
     * 
     * You are a professional robber planning to rob houses along a street. Each house has a certain
     * amount of money stashed, the only constraint stopping you from robbing each of them is that
     * adjacent houses have security system connected and it will automatically contact the police
     * if two adjacent houses were broken into on the same night.
     * Given a list of non-negative integers representing the amount of money of each house, determine
     * the maximum amount of money you can rob tonight without alerting the police.
     * 
     * Example 1:
     * 
     * Input: [1,2,3,1]
     * Output: 4
     * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
     *              Total amount you can rob = 1 + 3 = 4.
     * 
     * Example 2:
     * 
     * Input: [2,7,9,3,1]
     * Output: 12
     * Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
     *              Total amount you can rob = 2 + 9 + 1 = 12.
     */
    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            // Dynamic programming:
            // dp(i) = max(dp(i - 1), nums[i] + dp(i - 2))
            // dp(i) means the result of nums[0...i].
            // If we choose to rob nums[i], we can't rob num[i-1], so we get (nums[i] + dp(i - 2)).
            // If we choose not to rob nums[i], we get dp(i-1), which may include num[i-1].
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            int lastLast = nums[0];
            int last = nums[1] > nums[0] ? nums[1] : nums[0];
            for (int i = 2; i < nums.Length; i++)
            {
                int curr = Math.Max(last, nums[i] + lastLast);
                lastLast = last;
                last = curr;
            }
            return last;
        }
    }
}
