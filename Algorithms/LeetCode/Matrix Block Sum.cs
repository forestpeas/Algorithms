namespace Algorithms.LeetCode
{
    /* 1314. Matrix Block Sum
     * 
     * Given a m * n matrix mat and an integer K, return a matrix answer where each answer[i][j]
     * is the sum of all elements mat[r][c] for i - K <= r <= i + K, j - K <= c <= j + K,
     * and (r, c) is a valid position in the matrix.
     * 
     * Example 1:
     * 
     * Input: mat = [[1,2,3],[4,5,6],[7,8,9]], K = 1
     * Output: [[12,21,16],[27,45,33],[24,39,28]]
     * 
     * Example 2:
     * 
     * Input: mat = [[1,2,3],[4,5,6],[7,8,9]], K = 2
     * Output: [[45,45,45],[45,45,45],[45,45,45]]
     */
    public class Matrix_Block_Sum
    {
        public int[][] MatrixBlockSum(int[][] mat, int K)
        {
            // Use "prefix sum", similar to "304. Range Sum Query 2D - Immutable".
            int m = mat.Length;
            int n = mat[0].Length;
            for (int i = 1; i < m; i++) mat[i][0] += mat[i - 1][0];
            for (int j = 1; j < n; j++) mat[0][j] += mat[0][j - 1];
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    mat[i][j] += mat[i - 1][j] + mat[i][j - 1] - mat[i - 1][j - 1];
                }
            }

            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    int x1 = i + K;
                    int y1 = j + K;
                    int x2 = i - K - 1;
                    int y2 = j - K - 1;
                    result[i][j] = GetValue(x1, y1) - GetValue(x1, y2) - GetValue(x2, y1) + GetValue(x2, y2);
                }
            }
            return result;

            int GetValue(int i, int j)
            {
                if (i < 0 || j < 0) return 0;
                if (i >= m) i = m - 1;
                if (j >= n) j = n - 1;
                return mat[i][j];
            }
        }
    }
}
