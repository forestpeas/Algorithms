using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 417. Pacific Atlantic Water Flow
     * 
     * Given an m x n matrix of non-negative integers representing the height of each unit cell in a
     * continent, the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic
     * ocean" touches the right and bottom edges.
     * 
     * Water can only flow in four directions (up, down, left, or right) from a cell to another one
     * with height equal or lower.
     * 
     * Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.
     * 
     * Note:
     * The order of returned grid coordinates does not matter.
     * Both m and n are less than 150.
     * 
     * Example:
     * 
     * Given the following 5x5 matrix:
     * 
     *   Pacific ~   ~   ~   ~   ~ 
     *        ~  1   2   2   3  (5) *
     *        ~  3   2   3  (4) (4) *
     *        ~  2   4  (5)  3   1  *
     *        ~ (6) (7)  1   4   5  *
     *        ~ (5)  1   1   2   4  *
     *           *   *   *   *   * Atlantic
     * 
     * Return:
     * 
     * [[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).
     */
    public class Pacific_Atlantic_Water_Flow
    {
        private static int[][] _dir = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };

        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            // Similar to "130. Surrounded Regions". We need to search from borders, and
            // we need to "go against the current" (逆流而上).
            var result = new List<IList<int>>();
            if (matrix.Length == 0 || matrix[0].Length == 0) return result;

            int m = matrix.Length;
            int n = matrix[0].Length;

            bool[,] pac = new bool[m, n];
            bool[,] atl = new bool[m, n];
            for (int i = 0; i < m; i++)
            {
                Dfs(i, 0, pac);
                Dfs(i, n - 1, atl);
            }
            for (int j = 0; j < n; j++)
            {
                Dfs(0, j, pac);
                Dfs(m - 1, j, atl);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (pac[i, j] && atl[i, j]) result.Add(new int[] { i, j });
                }
            }
            return result;

            void Dfs(int i, int j, bool[,] marked)
            {
                if (marked[i, j]) return;
                marked[i, j] = true;
                foreach (var d in _dir)
                {
                    int x = i + d[0];
                    int y = j + d[1];
                    if (x >= 0 && x < m && y >= 0 && y < n && matrix[x][y] >= matrix[i][j])
                    {
                        Dfs(x, y, marked);
                    }
                }
            }
        }
    }
}
