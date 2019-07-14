using System;

namespace Algorithms.LeetCode
{
    /* 85. Maximal Rectangle
     * 
     * Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
     * 
     * Example:
     * 
     * Input:
     * [
     *   ["1","0","1","0","0"],
     *   ["1","0","1","1","1"],
     *   ["1","1","1","1","1"],
     *   ["1","0","0","1","0"]
     * ]
     * Output: 6
     */
    public class MaximalRectangleSolution
    {
        public int MaximalRectangle(char[][] matrix)
        {
            // Transform the matrix into many sub-problems of "Problem 84. Largest Rectangle in Histogram".
            // Inspired by https://leetcode.com/problems/maximal-rectangle/discuss/29054/Share-my-DP-solution/27983
            if (matrix.Length < 1) return 0;
            int n = matrix[0].Length;
            int[] heights = new int[n];
            int largestArea = 0;
            foreach (char[] row in matrix)
            {
                for (int i = 0; i < n; i++)
                {
                    if (row[i] == '1')
                    {
                        heights[i] += 1;
                    }
                    else
                    {
                        heights[i] = 0;
                    }
                }
                largestArea = Math.Max(largestArea, new LargestRectangleInHistogram().LargestRectangleArea(heights));
            }
            return largestArea;

            // The DP solution is hard to come up with, and harder to prove.
            // https://leetcode.com/problems/maximal-rectangle/discuss/29054/Share-my-DP-solution/28029
        }
    }
}
