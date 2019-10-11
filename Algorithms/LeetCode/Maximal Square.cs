using System;

namespace Algorithms.LeetCode
{
    /* 221. Maximal Square
     * 
     * Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's
     * and return its area.
     * 
     * Example:
     * 
     * Input: 
     * 
     * 1 0 1 0 0
     * 1 0 1 1 1
     * 1 1 1 1 1
     * 1 0 0 1 0
     * 
     * Output: 4
     */
    public class MaximalSquareSolution
    {
        public int MaximalSquare(char[][] matrix)
        {
            // dp(i,j) represents the side length of the maximum square whose bottom right corner
            // is the cell with index (i,j) in the original matrix.
            // dp(i, j) = min(dp(i − 1, j - 1), dp(i, j − 1), dp(i, j − 1)) + 1.
            if (matrix.Length < 1 || matrix[0].Length < 1) return 0;

            int maxLength = 0;
            int[,] dp = new int[matrix.Length + 1, matrix[0].Length + 1];

            for (int i = 1; i <= matrix.Length; i++)
            {
                for (int j = 1; j <= matrix[0].Length; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j]));
                        maxLength = Math.Max(maxLength, dp[i, j]);
                    }
                }
            }

            return maxLength * maxLength;
        }
    }
}
