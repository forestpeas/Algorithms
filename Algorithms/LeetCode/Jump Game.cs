using System;

namespace Algorithms.LeetCode
{
    /* 55. Jump Game
     * 
     * Given an array of non-negative integers, you are initially positioned at the first index of the array.
     * Each element in the array represents your maximum jump length at that position.
     * Determine if you are able to reach the last index.
     * 
     * Example 1:
     * 
     * Input: [2,3,1,1,4]
     * Output: true
     * Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
     * 
     * Example 2:
     * 
     * Input: [3,2,1,0,4]
     * Output: false
     * Explanation: You will always arrive at index 3 no matter what. Its maximum
     * jump length is 0, which makes it impossible to reach the last index.
     */
    public class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            // Greedy. For each element nums[i], the farthest position it can reach is i + nums[i].
            // So we can maintain the farthest position we can reach so far and see if we reach the end.
            int max = 0; // The farthest position we can reach.
            for (int i = 0; i <= max; i++)
            {
                max = Math.Max(max, i + nums[i]);
                if (max >= nums.Length - 1) return true;
            }
            return false;
        }

        public bool CanJump2(int[] nums)
        {
            // My first attempt on this problem.
            return CanJumpCore(0, 0) >= nums.Length - 1;

            // Returns the farthest index that "start" can reach.
            // "end" is the farthest index we have reached.
            // For example: nums = [5, 4, 5, 2, 1, 0, 0, 0, 0]
            // When we reach nums[2] = 5, we will check nums[2 + 5], nums[2 + 4], nums[2 + 3]...
            // When we get to nums[2 + 3], we can stop, because nums[2 + 3] ~ nums[2 + 1] was already checked by nums[0 + 5], nums[0 + 4]...
            int CanJumpCore(int start, int end)
            {
                if (start >= nums.Length - 1)
                {
                    return start;
                }
                int farthest = start + nums[start];
                for (int jumpLength = nums[start]; jumpLength > 0; jumpLength--)
                {
                    int nextJumpPosition = start + jumpLength;
                    if (nextJumpPosition > end)
                    {
                        farthest = CanJumpCore(nextJumpPosition, farthest);
                        if (farthest >= nums.Length - 1)
                        {
                            return farthest;
                        }
                    }
                    else
                    {
                        return farthest;
                    }
                }

                return farthest;
            }
        }
    }
}
