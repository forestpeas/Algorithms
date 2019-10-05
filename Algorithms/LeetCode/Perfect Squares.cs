using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 279. Perfect Squares
     * 
     * Given a positive integer n, find the least number of perfect square numbers
     * (for example, 1, 4, 9, 16, ...) which sum to n.
     * 
     * Example 1:
     * 
     * Input: n = 12
     * Output: 3 
     * Explanation: 12 = 4 + 4 + 4.
     * 
     * Example 2:
     * 
     * Input: n = 13
     * Output: 2
     * Explanation: 13 = 4 + 9.
     */
    public class PerfectSquares
    {
        public int NumSquares(int n)
        {
            // Recursion + Memoization.
            // For example: n = 12. First we try to use as many "9" as possible:
            // 12 = 9 * 1 + 3, and we have a potential answer: 1 + NumSquares(3).
            // Then we try to use as many "4" as possible:
            // 12 = 4 * 3 + 0, and we have another potential answer: 3 + NumSquares(0).
            // I think we should try using more larger perfect square numbers, so that
            // the answer will be small. Maybe this is greedy.
            var mem = new Dictionary<int, int>();
            return NumSquaresCore(n);

            int NumSquaresCore(int num)
            {
                if (num <= 0) return 0;
                if (mem.TryGetValue(num, out int value)) return value;

                int result = int.MaxValue;
                for (int i = 1; i * i <= num; i++)
                {
                    int squareNum = i * i;
                    result = Math.Min(result, (num / squareNum) + NumSquaresCore(num % squareNum));
                }
                mem.Add(num, result);
                return result;
            }
        }
    }
}
