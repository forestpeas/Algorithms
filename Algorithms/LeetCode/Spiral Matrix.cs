using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 54. Spiral Matrix
     * 
     * Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.
     * 
     * Example 1:
     * 
     * Input:
     * [
     *  [ 1, 2, 3 ],
     *  [ 4, 5, 6 ],
     *  [ 7, 8, 9 ]
     * ]
     * Output: [1,2,3,6,9,8,7,4,5]
     * 
     * Example 2:
     * 
     * Input:
     * [
     *   [1, 2, 3, 4],
     *   [5, 6, 7, 8],
     *   [9,10,11,12]
     * ]
     * Output: [1,2,3,4,8,12,11,10,9,5,6,7]
     */
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0) return new int[0];
            int[] result = new int[matrix.Length * matrix[0].Length];
            int i = 0;
            // Similar to "problem 48 Rotate Image".
            // We settle one "circle" each time from the outmost to the innermost.
            for (int j = 0; ; j++)
            {
                if (i == result.Length) break;

                int m = matrix[0].Length - j - 1; // max index of a row
                int n = matrix.Length - j - 1; // max index of a column
                for (int k = j; k <= m; k++)
                {
                    result[i++] = matrix[j][k];
                }
                for (int k = j + 1; k <= n; k++)
                {
                    result[i++] = matrix[k][m];
                }

                if (i == result.Length) break;

                for (int k = m - 1; k >= j; k--)
                {
                    result[i++] = matrix[n][k];
                }
                for (int k = n - 1; k > j; k--)
                {
                    result[i++] = matrix[k][j];
                }
            }
            return result;
        }
    }
}
