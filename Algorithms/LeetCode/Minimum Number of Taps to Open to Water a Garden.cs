using System;

namespace Algorithms.LeetCode
{
    /* 1326. Minimum Number of Taps to Open to Water a Garden
     * 
     * There is a one-dimensional garden on the x-axis. The garden starts at the point 0 and ends at
     * the point n. (i.e The length of the garden is n).
     * 
     * There are n + 1 taps located at points [0, 1, ..., n] in the garden.
     * 
     * Given an integer n and an integer array ranges of length n + 1 where ranges[i] (0-indexed) means
     * the i-th tap can water the area [i - ranges[i], i + ranges[i]] if it was open.
     * 
     * Return the minimum number of taps that should be open to water the whole garden, If the garden
     * cannot be watered return -1.
     * 
     * https://leetcode.com/problems/minimum-number-of-taps-to-open-to-water-a-garden/
     */
    public class Minimum_Number_of_Taps_to_Open_to_Water_a_Garden
    {
        public int MinTaps(int n, int[] ranges)
        {
            // The problem is equivalent to "45. Jump Game II". (But I don't know how to prove it)
            int[] nums = new int[ranges.Length];
            for (int i = 0; i < ranges.Length; i++)
            {
                int left = Math.Max(0, i - ranges[i]);
                int right = Math.Min(n, i + ranges[i]);
                nums[left] = Math.Max(nums[left], right - left);
            }
            return Jump2(nums);
        }

        public int Jump2(int[] nums)
        {
            // Same as "45. Jump Game II".
            int jumps = 0, curEnd = 0, curFarthest = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                curFarthest = Math.Max(curFarthest, i + nums[i]);
                if (i == curEnd)
                {
                    if (curEnd == curFarthest) return -1;
                    jumps++;
                    curEnd = curFarthest;
                }
            }
            return jumps;
        }
    }
}
