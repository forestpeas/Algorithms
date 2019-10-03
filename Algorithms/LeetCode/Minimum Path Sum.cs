using System;

namespace Algorithms.LeetCode
{
    /* 64. Minimum Path Sum
     * 
     * Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which
     * minimizes the sum of all numbers along its path.
     * 
     * Note: You can only move either down or right at any point in time.
     * 
     * Example:
     * 
     * Input:
     * [
     *   [1,3,1],
     *   [1,5,1],
     *   [4,2,1]
     * ]
     * Output: 7
     * Explanation: Because the path 1→3→1→1→1 minimizes the sum.
     */
    public class MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            // Similar to "Problem 63. Unique Paths II".
            // For example: if grid =
            // 1 3 1
            // 1 5 1
            // 4 2 1
            // Then "mem" should be:
            // 1 4 5
            // 2 7 6
            // 6 8 7
            if (grid.Length < 1 || grid[0].Length < 1) return 0;
            int[] mem = new int[grid[0].Length];

            mem[0] = grid[0][0];
            for (int j = 1; j < mem.Length; j++)
            {
                mem[j] = mem[j - 1] + grid[0][j];
            }
            for (int i = 1; i < grid.Length; i++)
            {
                mem[0] = mem[0] + grid[i][0];
                for (int j = 1; j < mem.Length; j++)
                {
                    mem[j] = Math.Min(mem[j], mem[j - 1]) + grid[i][j];
                }
            }
            return mem[mem.Length - 1];
        }
    }
}
