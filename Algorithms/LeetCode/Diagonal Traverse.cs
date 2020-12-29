using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 498. Diagonal Traverse
     * 
     * Given a matrix of M x N elements (M rows, N columns), return all elements of the
     * matrix in diagonal order as shown in the below image.
     * https://leetcode.com/problems/diagonal-traverse/
     * 
     * Example:
     * 
     * Input:
     * [
     *  [ 1, 2, 3 ],
     *  [ 4, 5, 6 ],
     *  [ 7, 8, 9 ]
     * ]
     * 
     * Output:  [1,2,4,7,5,3,6,8,9]
     */
    public class Diagonal_Traverse
    {
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            //     1,2,3,x,x
            //   x,4,5,6,x
            // x,x,7,8,9
            //     ↑...    ↑
            //     k       k
            if (matrix.Length == 0 || matrix[0].Length == 0) return new int[0];
            int m = matrix.Length, n = matrix[0].Length;
            var res = new List<int>();
            bool toggle = true;
            int k = 0;
            while (k < n + m - 1)
            {
                if (toggle)
                {
                    int i = m - 1, j = -m + 1 + k;
                    while (i >= 0)
                    {
                        Add(i--, j++);
                    }
                }
                else
                {
                    int i = 0, j = k;
                    while (i < m)
                    {
                        Add(i++, j--);
                    }
                }
                toggle = !toggle;
                k++;
            }
            return res.ToArray();

            void Add(int i, int j)
            {
                if (i >= 0 && i < m && j >= 0 && j < n)
                {
                    res.Add(matrix[i][j]);
                }
            }
        }
    }
}
