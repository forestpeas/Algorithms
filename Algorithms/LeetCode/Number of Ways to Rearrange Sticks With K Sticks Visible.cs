﻿namespace Algorithms.LeetCode
{
    /* 1866. Number of Ways to Rearrange Sticks With K Sticks Visible
     * 
     * There are n uniquely-sized sticks whose lengths are integers from 1 to n. You want to arrange
     * the sticks such that exactly k sticks are visible from the left. A stick is visible from the
     * left if there are no longer sticks to the left of it.
     * 
     * For example, if the sticks are arranged [1,3,2,5,4], then the sticks with lengths 1, 3, and 5
     * are visible from the left.
     * 
     * Given n and k, return the number of such arrangements. Since the answer may be large, return
     * it modulo 10^9 + 7. 
     * 
     * Example 1:
     * 
     * Input: n = 3, k = 2
     * Output: 3
     * Explanation: [1,3,2], [2,3,1], and [2,1,3] are the only arrangements such that exactly 2 sticks are visible.
     * The visible sticks are underlined.
     * 
     * Example 2:
     * 
     * Input: n = 5, k = 5
     * Output: 1
     * Explanation: [1,2,3,4,5] is the only arrangement such that all 5 sticks are visible.
     * The visible sticks are underlined.
     * 
     * Example 3:
     * 
     * Input: n = 20, k = 11
     * Output: 647427950
     * Explanation: There are 647427950 (mod 109 + 7) ways to rearrange the sticks such that exactly 11 sticks are visible.
     * 
     * Constraints:
     * 1 <= n <= 1000
     * 1 <= k <= n
     */
    public class Number_of_Ways_to_Rearrange_Sticks_With_K_Sticks_Visible
    {
        private readonly int[,] mem = new int[1001, 1001];
        private readonly int mod = 1000000007;

        public int RearrangeSticks(int n, int k)
        {
            // from https://leetcode.com/problems/number-of-ways-to-rearrange-sticks-with-k-sticks-visible/discuss/1211169/JavaC%2B%2BPython-Concise-DP-Solution
            if (n == k) return 1;
            if (k == 0) return 0;
            if (mem[n, k] != 0) return mem[n, k];
            mem[n, k] = (int)((RearrangeSticks(n - 1, k - 1) + (long)RearrangeSticks(n - 1, k) * (n - 1)) % mod);
            return mem[n, k];
        }
    }
}
