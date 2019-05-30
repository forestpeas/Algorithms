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
        // A second solution. Refer to https://leetcode.com/problems/jump-game-ii/discuss/18014/Concise-O(n)-one-loop-JAVA-solution-based-on-Greedy
        public int Jump2(int[] nums)
        {
            // BFS
            int jumps = 0, curEnd = 0, curFarthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                curFarthest = Math.Max(curFarthest, i + nums[i]);
                if (i == curEnd)
                {
                    jumps++;
                    curEnd = curFarthest;
                }
            }
            return jumps;
        }

        public int Jump(int[] nums)
        {
            if (nums.Length < 1) return 0;

            // "mem[i]" is the pointer to the next node in the shortest "path".
            int[] mem = new int[nums.Length];
            mem[nums.Length - 1] = nums.Length;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int j = i + 1;
                // Skip the path that "i" can directly jump through.
                while (j < nums.Length && (mem[j] - i) <= nums[i])
                {
                    j = mem[j];
                }
                if (j == nums.Length) j = nums.Length - 1;
                mem[i] = j;
            }
            int result = 0;
            for (int i = 0; mem[i] < nums.Length;)
            {
                result++;
                i = mem[i];
            }
            return result;
        }
    }
}
