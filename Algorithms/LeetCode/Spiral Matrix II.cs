namespace Algorithms.LeetCode
{
    /* 59. Spiral Matrix II
     * 
     * Given a positive integer n, generate a square matrix filled with elements from 1 to n^2 in spiral order.
     * 
     * Example:
     * 
     * Input: 3
     * Output:
     * [
     *  [ 1, 2, 3 ],
     *  [ 8, 9, 4 ],
     *  [ 7, 6, 5 ]
     * ]
     */
    public class SpiralMatrixII
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }
            // Similar to "problem 54 Spiral Matrix".
            for (int j = 0, i = 1; i <= n * n; j++)
            {
                int maxIndex = n - j - 1;
                for (int k = j; k <= maxIndex; k++)
                {
                    result[j][k] = i++;
                }
                for (int k = j + 1; k <= maxIndex; k++)
                {
                    result[k][maxIndex] = i++;
                }
                for (int k = maxIndex - 1; k >= j; k--)
                {
                    result[maxIndex][k] = i++;
                }
                for (int k = maxIndex - 1; k > j; k--)
                {
                    result[k][j] = i++;
                }
            }
            return result;
        }
    }
}
