namespace Algorithms.LeetCode
{
    /* 1329. Sort the Matrix Diagonally
     * 
     * https://leetcode.com/problems/sort-the-matrix-diagonally/
     * 
     * Example 1:
     * 
     * Input: mat = [[3,3,1,1],[2,2,1,2],[1,1,1,2]]
     * Output: [[1,1,1,1],[1,2,2,2],[1,2,3,3]]
     */
    public class Sort_the_Matrix_Diagonally
    {
        public int[][] DiagonalSort(int[][] mat)
        {
            // Sort each diagonal, which can be mapped to a 1-D array.
            int m = mat.Length;
            int n = mat[0].Length;
            for (int x = 0; x < m; x++)
            {
                Sort(x, 0);
            }
            for (int y = 0; y < n; y++)
            {
                Sort(0, y);
            }
            return mat;

            // Insertion sort.
            void Sort(int x, int y)
            {
                // (x,y) is the starting point, i and j are offsets.
                for (int i = 1; x + i < m && y + i < n; i++)
                {
                    for (int j = i; j > 0 && mat[x + j][y + j] < mat[x + j - 1][y + j - 1]; j--)
                    {
                        int tmp = mat[x + j][y + j];
                        mat[x + j][y + j] = mat[x + j - 1][y + j - 1];
                        mat[x + j - 1][y + j - 1] = tmp;
                    }
                }
            }
        }

        public int[][] DiagonalSort2(int[][] mat)
        {
            // Bubble sort each diagonal.
            int m = mat.Length;
            int n = mat[0].Length;
            for (int k = m; k > 0; k--)
            {
                for (int i = 0; i + 1 < k; i++)
                {
                    for (int j = 0; j + 1 < n; j++)
                    {
                        if (mat[i][j] > mat[i + 1][j + 1])
                        {
                            int tmp = mat[i][j];
                            mat[i][j] = mat[i + 1][j + 1];
                            mat[i + 1][j + 1] = tmp;
                        }
                    }
                }
            }

            return mat;
        }
    }
}
