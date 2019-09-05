using System;

namespace Algorithms.LeetCode
{
    /* 213. House Robber II
     * 
     * You are a professional robber planning to rob houses along a street. Each house has
     * a certain amount of money stashed. All houses at this place are arranged in a circle.
     * That means the first house is the neighbor of the last one. Meanwhile, adjacent houses
     * have security system connected and it will automatically contact the police if two
     * adjacent houses were broken into on the same night.
     * 
     * Given a list of non-negative integers representing the amount of money of each house,
     * determine the maximum amount of money you can rob tonight without alerting the police.
     * 
     * Example 1:
     * 
     * Input: [2,3,2]
     * Output: 3
     * Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2),
     *              because they are adjacent houses.
     * 
     * Example 2:
     * 
     * Input: [1,2,3,1]
     * Output: 4
     * Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
     *              Total amount you can rob = 1 + 3 = 4.
     */
    public class HouseRobberII
    {
        public int Rob(int[] nums)
        {
            // Suppose nums = [1,2,3,4,5].
            // Then the answer is the max of the "House Robber I Problem" of [1,2,3,4] and [2,3,4,5].
            // This is because we cannot rob nums[0] and nums[length - 1] both.
            // If we choose to rob nums[0], we at most can get to nums[length - 2], then stop.
            // If we choose not to rob nums[0], we can start from nums[1] and get all the way to nums[length - 1].
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            return Math.Max(Rob(nums, 0, nums.Length - 1), Rob(nums, 1, nums.Length));
        }

        // Solution of House Robber I:
        public int Rob(int[] nums, int start, int end)
        {
            if (end - start == 1) return nums[start];
            int lastLast = nums[start];
            int last = nums[start + 1] > nums[start] ? nums[start + 1] : nums[start];
            for (int i = start + 2; i < end; i++)
            {
                int curr = Math.Max(last, nums[i] + lastLast);
                lastLast = last;
                last = curr;
            }
            return last;
        }
    }
}
