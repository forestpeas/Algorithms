using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1253. Reconstruct a 2-Row Binary Matrix
     * 
     * Given the following details of a matrix with n columns and 2 rows :
     * The matrix is a binary matrix, which means each element in the matrix can be 0 or 1.
     * The sum of elements of the 0-th(upper) row is given as upper.
     * The sum of elements of the 1-st(lower) row is given as lower.
     * The sum of elements in the i-th column(0-indexed) is colsum[i], where colsum is given
     * as an integer array with length n.
     * 
     * Your task is to reconstruct the matrix with upper, lower and colsum.
     * Return it as a 2-D integer array.
     * If there are more than one valid solution, any of them will be accepted.
     * If no valid solution exists, return an empty 2-D array.
     * 
     * Example 1:
     * 
     * Input: upper = 2, lower = 1, colsum = [1,1,1]
     * Output: [[1,1,0],[0,0,1]]
     * Explanation: [[1,0,1],[0,1,0]], and [[0,1,1],[1,0,0]] are also correct answers.
     * 
     * Example 2:
     * 
     * Input: upper = 2, lower = 3, colsum = [2,2,1,1]
     * Output: []
     * 
     * Example 3:
     * 
     * Input: upper = 5, lower = 5, colsum = [2,1,2,0,1,0,1,2,0,1]
     * Output: [[1,1,1,0,1,0,0,1,0,0],[1,0,1,0,0,0,1,1,0,1]]
     * 
     * Constraints:
     * 1 <= colsum.length <= 10^5
     * 0 <= upper, lower <= colsum.length
     * 0 <= colsum[i] <= 2
     */
    public class Reconstruct_a_2_Row_Binary_Matrix
    {
        public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum)
        {
            int[][] result = new int[2][];
            result[0] = new int[colsum.Length];
            result[1] = new int[colsum.Length];
            for (int i = 0; i < colsum.Length; i++)
            {
                if (colsum[i] == 0)
                {
                    result[0][i] = 0;
                    result[1][i] = 0;
                }
                else if (colsum[i] == 2)
                {
                    result[0][i] = 1;
                    result[1][i] = 1;
                }
                else // colsum[i] == 1
                {
                    // Always add this "1" to the row with more "available seats",
                    // because if later the colsums are 0 or 2, upper and lower row
                    // will be increasing at equal speed.
                    if (upper > lower) result[0][i] = 1;
                    else result[1][i] = 1;
                }
                upper -= result[0][i];
                lower -= result[1][i];
            }

            if (upper == 0 && lower == 0) return result;
            return new int[0][];
        }
    }
}
