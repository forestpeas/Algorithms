using System;

namespace Algorithms.LeetCode
{
    /* 485. Max Consecutive Ones
     * 
     * Given a binary array, find the maximum number of consecutive 1s in this array.
     * 
     * Example 1:
     * Input: [1,1,0,1,1,1]
     * Output: 3
     * Explanation: The first two digits or the last three digits are consecutive 1s.
     *     The maximum number of consecutive 1s is 3.
     */
    public class Max_Consecutive_Ones
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int res = 0;
            int count = 0;
            foreach (int num in nums)
            {
                if (num == 0)
                {
                    res = Math.Max(res, count);
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            return Math.Max(res, count);
        }
    }
}
