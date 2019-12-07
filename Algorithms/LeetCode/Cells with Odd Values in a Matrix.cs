namespace Algorithms.LeetCode
{
    /* 1252. Cells with Odd Values in a Matrix
     * 
     * Given n and m which are the dimensions of a matrix initialized by zeros and given an array
     * indices where indices[i] = [ri, ci]. For each pair of [ri, ci] you have to increment all
     * cells in row ri and column ci by 1. Return the number of cells with odd values in the matrix
     * after applying the increment to all indices.
     * 
     * https://leetcode.com/problems/cells-with-odd-values-in-a-matrix/
     */
    public class Cells_with_Odd_Values_in_a_Matrix
    {
        public int OddCells(int n, int m, int[][] indices)
        {
            // Odd is true, even is false.
            bool[] rows = new bool[n];
            bool[] columns = new bool[m];
            foreach (var indice in indices)
            {
                rows[indice[0]] = !rows[indice[0]];
                columns[indice[1]] = !columns[indice[1]];
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // (odd + odd) and (even + even) are even.
                    // (odd + even) and (even + odd) are odd.
                    result += rows[i] ^ columns[j] ? 1 : 0;
                }
            }
            return result;
        }
    }
}
