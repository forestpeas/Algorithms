﻿namespace Algorithms.LeetCode
{
    /* 463. Island Perimeter
     * 
     * You are given row x col grid representing a map where grid[i][j] = 1 represents land and
     * grid[i][j] = 0 represents water.
     * 
     * Grid cells are connected horizontally/vertically (not diagonally). The grid is completely
     * surrounded by water, and there is exactly one island (i.e., one or more connected land cells).
     * 
     * The island doesn't have "lakes", meaning the water inside isn't connected to the water around
     * the island. One cell is a square with side length 1. The grid is rectangular, width and height
     * don't exceed 100. Determine the perimeter of the island. 
     * 
     * Example 1:
     * https://leetcode.com/problems/island-perimeter/
     * Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
     * Output: 16
     * Explanation: The perimeter is the 16 yellow stripes in the image above.
     * 
     * Example 2:
     * 
     * Input: grid = [[1]]
     * Output: 4
     * 
     * Example 3:
     * 
     * Input: grid = [[1,0]]
     * Output: 4
     */
    public class Island_Perimeter
    {
        public int IslandPerimeter(int[][] grid)
        {
            int res = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        res += 4;
                        if (i - 1 >= 0 && grid[i - 1][j] == 1) res -= 2;
                        if (j - 1 >= 0 && grid[i][j - 1] == 1) res -= 2;
                    }
                }
            }
            return res;
        }
    }
}
