using System;

namespace Algorithms.LeetCode
{
    /* 1219. Path with Maximum Gold
     * 
     * In a gold mine grid of size m * n, each cell in this mine has an integer representing the
     * amount of gold in that cell, 0 if it is empty.
     * 
     * Return the maximum amount of gold you can collect under the conditions:
     * Every time you are located in a cell you will collect all the gold in that cell.
     * From your position you can walk one step to the left, right, up or down.
     * You can't visit the same cell more than once.
     * Never visit a cell with 0 gold.
     * You can start and stop collecting gold from any position in the grid that has some gold.
     * 
     * Example 1:
     * 
     * Input: grid = [[0,6,0],[5,8,7],[0,9,0]]
     * Output: 24
     * Explanation:
     * [[0,6,0],
     *  [5,8,7],
     *  [0,9,0]]
     * Path to get the maximum gold, 9 -> 8 -> 7.
     * 
     * Example 2:
     * 
     * Input: grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]]
     * Output: 28
     * Explanation:
     * [[1,0,7],
     *  [2,0,6],
     *  [3,4,5],
     *  [0,3,0],
     *  [9,0,20]]
     * Path to get the maximum gold, 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7.
     */
    public class Path_with_Maximum_Gold
    {
        public int GetMaximumGold(int[][] grid)
        {
            // DFS + Backtracking.
            // Search all possible paths (brute-force).
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] visited = new bool[m, n];
            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Dfs(i, j, 0);
                }
            }
            return result;

            void Dfs(int i, int j, int gold)
            {
                if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0 || visited[i, j])
                {
                    result = Math.Max(result, gold);
                    return;
                }

                visited[i, j] = true;
                gold += grid[i][j];
                foreach (int[] d in dirs)
                {
                    Dfs(i + d[0], j + d[1], gold);
                }
                visited[i, j] = false;
            }
        }

        private readonly int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    }
}
