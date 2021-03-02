﻿using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 89. Gray Code
     * 
     * The gray code is a binary numeral system where two successive values differ in only one bit.
     * Given a non-negative integer n representing the total number of bits in the code, print the
     * sequence of gray code. A gray code sequence must begin with 0.
     * 
     * Example 1:
     * 
     * Input: 2
     * Output: [0,1,3,2]
     * Explanation:
     * 00 - 0
     * 01 - 1
     * 11 - 3
     * 10 - 2
     * 
     * For a given n, a gray code sequence may not be uniquely defined.
     * For example, [0,2,3,1] is also a valid gray code sequence.
     * 
     * 00 - 0
     * 10 - 2
     * 11 - 3
     * 01 - 1
     * 
     * Example 2:
     * 
     * Input: 0
     * Output: [0]
     * Explanation: We define the gray code sequence to begin with 0.
     *              A gray code sequence of n has size = 2n, which for n = 0 the size is 20 = 1.
     *              Therefore, for n = 0 the gray code sequence is [0].
     */
    public class GrayCodeSolution
    {
        public IList<int> GrayCode(int n)
        {
            // We can get GrayCode(n) from GrayCode(n-1)
            // For example: n = 2
            // 00
            // 01
            // 11
            // 10
            // If we want to get the result of n = 3, first we just add a "0" to each code above.
            // 000
            // 001
            // 011
            // 010
            // Then we add a "1" to the codes of n = 2, from bottom to the top.
            // 110
            // 111
            // 101
            // 100
            if (n == 0) return new int[] { 0 };
            var result = new List<int>() { 0, 1 };
            for (int i = 1; i < n; i++)
            {
                int mask = 1 << i;
                for (int j = result.Count - 1; j >= 0; j--)
                {
                    result.Add(result[j] | mask);
                }
            }
            return result;
        }
    }
}
