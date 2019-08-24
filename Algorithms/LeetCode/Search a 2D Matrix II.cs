﻿namespace Algorithms.LeetCode
{
    /* 240. Search a 2D Matrix II
     * 
     * Write an efficient algorithm that searches for a value in an m x n matrix.
     * This matrix has the following properties:
     * Integers in each row are sorted in ascending from left to right.
     * Integers in each column are sorted in ascending from top to bottom.
     * 
     * Example:
     * 
     * Consider the following matrix:
     * 
     * [
     *   [1,   4,  7, 11, 15],
     *   [2,   5,  8, 12, 19],
     *   [3,   6,  9, 16, 22],
     *   [10, 13, 14, 17, 24],
     *   [18, 21, 23, 26, 30]
     * ]
     * 
     * Given target = 5, return true.
     * Given target = 20, return false.
     */
    public class Search2DMatrixII
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            // Search from the bottom-left point, rule out one row or one column each time.
            int i = matrix.GetLength(0) - 1;
            int j = 0;
            while (i >= 0 && j < matrix.GetLength(1))
            {
                if (target < matrix[i, j])
                {
                    i--;
                }
                else if (target > matrix[i, j])
                {
                    j++;
                }
                else return true;
            }

            return false;
        }
    }
}
