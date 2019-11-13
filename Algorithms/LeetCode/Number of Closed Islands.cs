namespace Algorithms.LeetCode
{
    /* 1254. Number of Closed Islands
     * 
     * Given a 2D grid consists of 0s (land) and 1s (water).  An island is a maximal
     * 4-directionally connected group of 0s and a closed island is an island totally
     * (all left, top, right, bottom) surrounded by 1s.
     * Return the number of closed islands.
     * 
     * https://leetcode.com/problems/number-of-closed-islands/
     */
    public class Number_of_Closed_Islands
    {
        public int ClosedIsland(int[][] grid)
        {
            // Similar to "200. Number of Islands".
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        if (Dfs(grid, i, j)) result++;
                    }
                }
            }

            return result;
        }

        // Returns false if we reach the borders.
        private bool Dfs(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) return false;
            if (grid[i][j] == 1) return true;

            grid[i][j] = 1;
            bool inland = true;
            if (!Dfs(grid, i + 1, j)) inland = false;
            if (!Dfs(grid, i - 1, j)) inland = false;
            if (!Dfs(grid, i, j + 1)) inland = false;
            if (!Dfs(grid, i, j - 1)) inland = false;
            return inland;
        }
    }
}
