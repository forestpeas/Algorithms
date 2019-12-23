using System;

namespace Algorithms.LeetCode
{
    /* 1277. Count Square Submatrices with All Ones
     * 
     * Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.
     * 
     * Example 1:
     * 
     * Input: matrix =
     * [
     *   [0,1,1,1],
     *   [1,1,1,1],
     *   [0,1,1,1]
     * ]
     * Output: 15
     * Explanation: 
     * There are 10 squares of side 1.
     * There are 4 squares of side 2.
     * There is  1 square of side 3.
     * Total number of squares = 10 + 4 + 1 = 15.
     * 
     * Example 2:
     * 
     * Input: matrix = 
     * [
     *   [1,0,1],
     *   [1,1,0],
     *   [1,1,0]
     * ]
     * Output: 7
     * Explanation: 
     * There are 6 squares of side 1.  
     * There is 1 square of side 2. 
     * Total number of squares = 6 + 1 = 7.
     */
    public class Count_Square_Submatrices_with_All_Ones
    {
        public int CountSquares(int[][] matrix)
        {
            // dp[i,j] is the side length of the maximum square whose bottom right corner is matrix[i,j]. 
            // Similar to "221. Maximal Square".
            int[,] dp = new int[matrix.Length, matrix[0].Length];
            int result = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0) continue;
                    int t1 = (i - 1 < 0 || j - 1 < 0) ? 0 : dp[i - 1, j - 1];
                    int t2 = i - 1 < 0 ? 0 : dp[i - 1, j];
                    int t3 = j - 1 < 0 ? 0 : dp[i, j - 1];
                    dp[i, j] = Math.Min(t1, Math.Min(t2, t3)) + 1;
                    result += dp[i, j];
                }
            }
            return result;
        }
    }
}
