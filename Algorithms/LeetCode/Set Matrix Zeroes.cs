namespace Algorithms.LeetCode
{
    /* 73. Set Matrix Zeroes
     * 
     * Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.
     * 
     * Follow up:
     * A straight forward solution using O(mn) space is probably a bad idea.
     * A simple improvement uses O(m + n) space, but still not the best solution.
     * Could you devise a constant space solution?
     * 
     * Example 1:
     * 
     * Input: 
     * [
     *   [1,1,1],
     *   [1,0,1],
     *   [1,1,1]
     * ]
     * Output: 
     * [
     *   [1,0,1],
     *   [0,0,0],
     *   [1,0,1]
     * ]
     * 
     * Example 2:
     * 
     * Input: 
     * [
     *   [0,1,2,0],
     *   [3,4,5,2],
     *   [1,3,1,5]
     * ]
     * Output: 
     * [
     *   [0,0,0,0],
     *   [0,4,5,0],
     *   [0,3,1,0]
     * ]
     */
    public class SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            if (matrix.Length < 1 || matrix[0].Length < 1) return;

            // If matrix[i][j] == 0, set matrix[0][j] and matrix[i][0] to zero as a mark
            // that "row i" and "column j" should be zero.
            // But matrix[0][0] is shared by "row 0" and "column 0", so we need some extra space.
            bool firstColumnZero = false;
            bool firstRowZero = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    firstColumnZero = true;
                    break;
                }
            }
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < matrix[0].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < matrix.Length; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            if (firstColumnZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }
            if (firstRowZero)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }
        }
    }
}
