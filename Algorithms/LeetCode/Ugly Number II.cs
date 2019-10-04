using System;

namespace Algorithms.LeetCode
{
    /* 264. Ugly Number II
     * 
     * Write a program to find the n-th ugly number.
     * Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
     * 
     * Example:
     * 
     * Input: n = 10
     * Output: 12
     * Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
     * 
     * Note:  
     * 
     * 1 is typically treated as an ugly number.
     * n does not exceed 1690.
     */
    public class UglyNumberII
    {
        public int NthUglyNumber(int n)
        {
            // Observe the ugly number sequence:
            // 1, 2, 3, 4, 5, 6, 8, 9, 10, 12,...
            // We can see that a number can be always derived from another previous number,
            // that is, num = prev * 2 or prev * 3 or prev * 5.
            // From another perspective, every number can produce a new number, that is,
            // newNum = num * 2 or num * 3 or num * 5.
            // But we don't know which one is the minimum, so we maintain 3 pointers for 2, 3 and 5.
            // Each number from left to right will at some point be multiplied by 2, 3 and 5.
            // Be careful of cases such as:
            // 1, 2, 3, 4, 5, 6, 8, 9, 10, 12,...
            //    ↑  ↑
            //    p3 p2
            //
            // min = 2 * 3 = 3 * 2, so we need to forward both p2 and p3.
            int[] mem = new int[n];
            mem[0] = 1;
            int p2 = 0, p3 = 0, p5 = 0;
            for (int i = 1; i < n; i++)
            {
                mem[i] = Math.Min(mem[p2] * 2, Math.Min(mem[p3] * 3, mem[p5] * 5));
                if (mem[i] == mem[p2] * 2) p2++;
                if (mem[i] == mem[p3] * 3) p3++;
                if (mem[i] == mem[p5] * 5) p5++;
            }
            return mem[n - 1];
        }
    }
}
