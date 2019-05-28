using System;

namespace Algorithms.LeetCode
{
    /* 45. Jump Game II
     * 
     * Given an array of non-negative integers, you are initially positioned at the first index of the array.
     * Each element in the array represents your maximum jump length at that position.
     * Your goal is to reach the last index in the minimum number of jumps.
     * 
     * Example:
     * 
     * Input: [2,3,1,1,4]
     * Output: 2
     * Explanation: The minimum number of jumps to reach the last index is 2.
     *     Jump 1 step from index 0 to 1, then 3 steps to the last index.
     *     
     * Note:
     * You can assume that you can always reach the last index.
     */
    public class JumpGameII
    {
        public int Jump(int[] nums)
        {
            int[] mem = new int[nums.Length];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] >= nums.Length - i - 1)
                {
                    mem[i] = 1;
                }
                else
                {
                    int min = int.MaxValue - 1;
                    for (int j = i + 1; j <= i + nums[i]; j++)
                    {
                        min = Math.Min(min, mem[j]);
                    }
                    mem[i] = min + 1;
                }
            }
            return mem[0];
        }
    }
}
