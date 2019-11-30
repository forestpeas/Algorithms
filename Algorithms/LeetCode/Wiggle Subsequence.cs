using System;

namespace Algorithms.LeetCode
{
    /* 376. Wiggle Subsequence
     * 
     * A sequence of numbers is called a wiggle sequence if the differences between successive
     * numbers strictly alternate between positive and negative. The first difference (if one
     * exists) may be either positive or negative. A sequence with fewer than two elements is
     * trivially a wiggle sequence.
     * 
     * For example, [1,7,4,9,2,5] is a wiggle sequence because the differences (6,-3,5,-7,3) are
     * alternately positive and negative. In contrast, [1,4,7,2,5] and [1,7,4,5,5] are not wiggle
     * sequences, the first because its first two differences are positive and the second because
     * its last difference is zero.
     * 
     * Given a sequence of integers, return the length of the longest subsequence that is a wiggle
     * sequence. A subsequence is obtained by deleting some number of elements (eventually, also
     * zero) from the original sequence, leaving the remaining elements in their original order.
     * 
     * Example 1:
     * 
     * Input: [1,7,4,9,2,5]
     * Output: 6
     * Explanation: The entire sequence is a wiggle sequence.
     * 
     * Example 2:
     * 
     * Input: [1,17,5,10,13,15,10,5,16,8]
     * Output: 7
     * Explanation: There are several subsequences that achieve this length. One is [1,17,10,13,10,16,8].
     * 
     * Example 3:
     * 
     * Input: [1,2,3,4,5,6,7,8,9]
     * Output: 2
     * 
     * Follow up:
     * Can you do it in O(n) time?
     */
    public class Wiggle_Subsequence
    {
        public int WiggleMaxLength(int[] nums)
        {
            // Inspired by Approach #5 from https://leetcode.com/articles/wiggle-subsequence/
            // The peaks and valleys in the array can form the longest wiggle sequence.
            // Any other points instead of peaks and valleys could result in shorter sequence.
            // So just count the number of peaks and valleys.
            if (nums.Length < 1) return 0;
            int result = 1;
            int sign = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1] && sign != 1)
                {
                    sign = 1;
                    result++;
                }
                else if (nums[i] < nums[i - 1] && sign != -1)
                {
                    sign = -1;
                    result++;
                }
            }
            return result;
        }

        public int WiggleMaxLength2(int[] nums)
        {
            // This solution is essentially the same in idea to the solution above.
            // up[i] gets incremented when nums[i] turns from falling to rising (i.e. found a valley).
            // up[i] can be considered as the number of peaks and valleys in [0,i], with the last one
            // as a peak. down[i] is similar.
            if (nums.Length < 1) return 0;

            int[] up = new int[nums.Length];
            int[] down = new int[nums.Length];
            up[0] = down[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    up[i] = down[i - 1] + 1;
                    down[i] = down[i - 1];
                }
                else if (nums[i] < nums[i - 1])
                {
                    down[i] = up[i - 1] + 1;
                    up[i] = up[i - 1];
                }
                else
                {
                    down[i] = down[i - 1];
                    up[i] = up[i - 1];
                }
            }
            return Math.Max(down[nums.Length - 1], up[nums.Length - 1]);
        }
    }
}
