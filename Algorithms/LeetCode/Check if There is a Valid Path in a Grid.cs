using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1391. Check if There is a Valid Path in a Grid
     * 
     * https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/
     * 
     * Given a m x n grid. Each cell of the grid represents a street. The street of grid[i][j] can be:
     * 1 which means a street connecting the left cell and the right cell.
     * 2 which means a street connecting the upper cell and the lower cell.
     * 3 which means a street connecting the left cell and the lower cell.
     * 4 which means a street connecting the right cell and the lower cell.
     * 5 which means a street connecting the left cell and the upper cell.
     * 6 which means a street connecting the right cell and the upper cell.
     * 
     * You will initially start at the street of the upper-left cell (0,0). A valid path in the grid is
     * a path which starts from the upper left cell (0,0) and ends at the bottom-right cell (m - 1, n - 1).
     * The path should only follow the streets.
     * 
     * Notice that you are not allowed to change any street.
     * 
     * Return true if there is a valid path in the grid or false otherwise.
     * 
     * Example 1:
     * 
     * Input: grid = [[2,4,3],[6,5,2]]
     * Output: true
     * Explanation: As shown you can start at cell (0, 0) and visit all the cells of the grid to reach
     * (m - 1, n - 1).
     */
    public class Check_if_There_is_a_Valid_Path_in_a_Grid
    {
        public bool HasValidPath(int[][] grid)
        {
            // Just go down the one direction path.
            int m = grid.Length, n = grid[0].Length;
            if (m == 1 && n == 1) return true;
            int[] left = new int[] { 0, -1 };
            int[] right = new int[] { 0, 1 };
            int[] up = new int[] { -1, 0 };
            int[] down = new int[] { 1, 0 };
            var streets = new Dictionary<int, Street>()
            {
                [1] = new Street(left, right),
                [2] = new Street(up, down),
                [3] = new Street(left, down),
                [4] = new Street(down, right),
                [5] = new Street(left, up),
                [6] = new Street(up, right)
            };
            var start = streets[grid[0][0]];
            return Core(start.d1[0], start.d1[1], new int[] { -start.d1[0], -start.d1[1] })
                || Core(start.d2[0], start.d2[1], new int[] { -start.d2[0], -start.d2[1] });

            bool Core(int i, int j, int[] from)
            {
                while (true)
                {
                    if (i < 0 || i >= m || j < 0 || j >= n) return false;
                    var street = streets[grid[i][j]];
                    if (!street.TryGetAnotherDirection(from, out int[] nextDir)) return false;
                    if (i == m - 1 && j == n - 1) return true;
                    i += nextDir[0];
                    j += nextDir[1];
                    from[0] = -nextDir[0];
                    from[1] = -nextDir[1];
                }
            }
        }

        private class Street
        {
            public readonly int[] d1;
            public readonly int[] d2;

            public Street(int[] direction1, int[] direction2)
            {
                d1 = direction1;
                d2 = direction2;
            }

            public bool TryGetAnotherDirection(int[] direction, out int[] another)
            {
                if (d1[0] == direction[0] && d1[1] == direction[1])
                {
                    another = d2;
                    return true;
                }
                if (d2[0] == direction[0] && d2[1] == direction[1])
                {
                    another = d1;
                    return true;
                }

                another = null;
                return false;
            }
        }
    }
}
