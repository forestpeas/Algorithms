using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 120. Triangle
     * 
     * Given a triangle, find the minimum path sum from top to bottom. Each step you may move to
     * adjacent numbers on the row below.
     * 
     * For example, given the following triangle
     * 
     * [
     *      [2],
     *     [3,4],
     *    [6,5,7],
     *   [4,1,8,3]
     * ]
     * The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
     * 
     * Note:
     * 
     * Bonus point if you are able to do this using only O(n) extra space, where n is the total
     * number of rows in the triangle.
     */
    public class Triangle
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            // "Top down" DP solution, from the first row to the last row.
            // row[i] is the minimum sum of a path that ends with triangle[row][i].
            if (triangle.Count < 1) return 0;
            int[] row = new int[] { triangle[0][0] };
            for (int i = 1; i < triangle.Count; i++)
            {
                int[] nextRow = new int[row.Length + 1];
                nextRow[0] = row[0] + triangle[i][0];
                nextRow[nextRow.Length - 1] = row[row.Length - 1] + triangle[i][nextRow.Length - 1];
                for (int j = 1; j < nextRow.Length - 1; j++)
                {
                    nextRow[j] = triangle[i][j] + Math.Min(row[j - 1], row[j]);
                }
                row = nextRow;
            }
            return row.Min();
        }

        public int MinimumTotal2(IList<IList<int>> triangle)
        {
            // "Bottom up" DP solution, from the last row to the first row.
            // Inspired by solutions from the discuss section.
            int[] results = new int[triangle.Count + 1];
            for (int i = triangle.Count - 1; i >= 0; i--)
            {
                var row = triangle[i];
                for (int j = 0; j < row.Count; j++)
                {
                    results[j] = Math.Min(results[j], results[j + 1]) + row[j];
                }
            }
            return results[0];
        }
    }
}
