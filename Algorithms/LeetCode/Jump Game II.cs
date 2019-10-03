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
        public int Jump2(int[] nums)
        {
            // Greedy solution Inpired by https://leetcode.com/problems/jump-game-ii/discuss/18014/Concise-O(n)-one-loop-JAVA-solution-based-on-Greedy
            // We can think it this way, for example, nums = [2,3,1,1,4].
            // Starting from nums[0], what are the elements that only need 1 jump from nums[0]?
            // Apparently they are nums[1] and nums[2]. We can draw these two elements on the second level:
            // 2
            // 3 1
            // Then, we can draw the elements that only need 1 jump from the elements on the second level:
            // 2
            // 3 1
            // 1 4
            // Now it is clear that we need 2 jumps from nums[0] to reach the end.
            // curEnd is the index of the last element on the current level.
            // curFarthest is the index of the last element on the next level.
            // So this is implicit BFS.
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
    }
}
