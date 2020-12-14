using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 410. Split Array Largest Sum
     * 
     * Given an array nums which consists of non-negative integers and an integer m,
     * you can split the array into m non-empty continuous subarrays.
     * 
     * Write an algorithm to minimize the largest sum among these m subarrays.
     * 
     * Example 1:
     * 
     * Input: nums = [7,2,5,10,8], m = 2
     * Output: 18
     * Explanation:
     * There are four ways to split nums into two subarrays.
     * The best way is to split it into [7,2,5] and [10,8],
     * where the largest sum among the two subarrays is only 18.
     * 
     * Example 2:
     * 
     * Input: nums = [1,2,3,4,5], m = 2
     * Output: 9
     * 
     * Example 3:
     * 
     * Input: nums = [1,4,4], m = 3
     * Output: 4
     */
    public class Split_Array_Largest_Sum
    {
        public int SplitArray(int[] nums, int m)
        {
            // mem[i,m] is the answer to subarray nums[i...] with m groups.
            var mem = new int[nums.Length, m + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    mem[i, j] = -1;
                }
            }
            return Helper(0, m);

            int Helper(int start, int m)
            {
                if (mem[start, m] >= 0) return mem[start, m];
                if (m == 1)
                {
                    mem[start, m] = nums.Skip(start).Sum();
                    return mem[start, m];
                }

                int sum = 0, min = int.MaxValue;
                for (int i = start; i < nums.Length - m + 1; i++)
                {
                    sum += nums[i];
                    if (sum > min) break;
                    min = Math.Min(min, Math.Max(sum, Helper(i + 1, m - 1)));
                }
                mem[start, m] = min;
                return mem[start, m];
            }
        }
    }
}
