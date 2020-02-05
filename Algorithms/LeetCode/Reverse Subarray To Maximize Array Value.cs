using System;

namespace Algorithms.LeetCode
{
    /* 1330. Reverse Subarray To Maximize Array Value
     * 
     * You are given an integer array nums. The value of this array is defined as the sum of
     * |nums[i]-nums[i+1]| for all 0 <= i < nums.length-1.
     * 
     * You are allowed to select any subarray of the given array and reverse it. You can perform
     * this operation only once.
     * 
     * Find maximum possible value of the final array.
     * 
     * Example 1:
     * 
     * Input: nums = [2,3,1,5,4]
     * Output: 10
     * Explanation: By reversing the subarray [3,1,5] the array becomes [2,5,1,3,4] whose value is 10.
     * 
     * Example 2:
     * 
     * Input: nums = [2,4,9,24,2,1,10]
     * Output: 68
     * 
     * Constraints:
     * 
     * 1 <= nums.length <= 3*10^4
     *  -10^5 <= nums[i] <= 10^5
     */
    public class Reverse_Subarray_To_Maximize_Array_Value
    {
        public int MaxValueAfterReverse(int[] nums)
        {
            // Inspired by https://leetcode.com/problems/reverse-subarray-to-maximize-array-value/discuss/489743/JavaC%2B%2BPython-One-Pass-O(1)-Space
            // First, reversing a subarray only affect its two edges.
            // Suppose we want to reverse a subarray [b...c]
            // ...a[b...c]d...
            // We can improve:
            // |a-c|+|b-d|-(|a-b|+|c-d|)
            // After trying to simplify this formula by listing all possible cases (e.g.
            // when a < b < c < d, swap is ok, but when a < c < b < d, no need to swap)
            // we can find that the result is always:
            // 2(y-x), where x is the second smallest value in [a,b,c,d] and y is the third,
            // a < b < c < d
            //     x   y
            // So our goal is to minimize x and maximize y.
            int total = 0, improvement = 0, x = 100001, y = -100001, n = nums.Length; // -10^5 <= nums[i] <= 10^5
            for (int i = 0; i < n - 1; i++)
            {
                int a = nums[i], b = nums[i + 1];
                total += Math.Abs(a - b);
                improvement = Math.Max(improvement, Math.Abs(nums[0] - b) - Math.Abs(a - b));
                improvement = Math.Max(improvement, Math.Abs(nums[n - 1] - a) - Math.Abs(a - b));
                x = Math.Min(x, Math.Max(a, b));
                y = Math.Max(y, Math.Min(a, b));
            }
            return total + Math.Max(improvement, 2 * (y - x));
        }
    }
}
