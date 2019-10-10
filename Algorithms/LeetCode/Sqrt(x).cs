﻿namespace Algorithms.LeetCode
{
    /* 69. Sqrt(x)
     * 
     * Implement int sqrt(int x).
     * Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
     * Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
     * 
     * Example 1:
     * 
     * Input: 4
     * Output: 2
     * Example 2:
     * 
     * Input: 8
     * Output: 2
     * Explanation: The square root of 8 is 2.82842..., and since 
     *              the decimal part is truncated, 2 is returned.
     */
    public class SqrtX
    {
        public int MySqrt(int x)
        {
            int lo = 1;
            int hi = 46341; // Sqrt(int.MaxValue) + 1
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int square = mid * mid;
                if (square > x)
                {
                    hi = mid;
                }
                else if (square < x)
                {
                    lo = mid + 1;
                }
                else return mid;
            }
            return lo - 1;
        }
    }
}

