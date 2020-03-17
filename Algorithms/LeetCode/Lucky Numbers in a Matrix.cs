using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1380. Lucky Numbers in a Matrix
     * 
     * Given a m * n matrix of distinct numbers, return all lucky numbers in the matrix in any order.
     * 
     * A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column.
     * 
     * Example 1:
     * 
     * Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
     * Output: [15]
     * Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column
     * 
     * Example 2:
     * 
     * Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
     * Output: [12]
     * Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
     * 
     * Example 3:
     * 
     * Input: matrix = [[7,8],[1,2]]
     * Output: [7]
     */
    public class Lucky_Numbers_in_a_Matrix
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] mins = new int[m]; // The minimum value of each row.
            int[] maxs = new int[n]; // The maximum value of each column.
            Array.Fill(mins, int.MaxValue);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mins[i] = Math.Min(mins[i], matrix[i][j]);
                    maxs[j] = Math.Max(maxs[j], matrix[i][j]);
                }
            }

            var result = new List<int>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mins[i] == maxs[j]) result.Add(matrix[i][j]);
                }
            }
            return result;
        }
    }
}
