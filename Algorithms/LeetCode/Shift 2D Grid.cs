using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1260. Shift 2D Grid
     * 
     * Given a 2D grid of size n * m and an integer k. You need to shift the grid k times.
     * 
     * In one shift operation:
     * Element at grid[i][j] becomes at grid[i][j + 1].
     * Element at grid[i][m - 1] becomes at grid[i + 1][0].
     * Element at grid[n - 1][m - 1] becomes at grid[0][0].
     * Return the 2D grid after applying shift operation k times.
     * 
     * https://leetcode.com/problems/shift-2d-grid/
     */
    public class Shift_2D_Grid
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            // "189. Rotate Array" with virtual index.
            int m = grid.Length;
            int n = grid[0].Length;
            int length = m * n;
            k = k % length;
            Reverse(0, length - 1);
            Reverse(0, k - 1);
            Reverse(k, length - 1);
            return grid;

            void Reverse(int start, int end)
            {
                while (start < end)
                {
                    int temp = grid[start / n][start % n];
                    grid[start / n][start % n] = grid[end / n][end % n];
                    grid[end / n][end % n] = temp;
                    start++;
                    end--;
                }
            }
        }

        public IList<IList<int>> ShiftGrid2(int[][] grid, int k)
        {
            while (k-- > 0)
            {
                int last = grid[grid.Length - 1][grid[0].Length - 1];
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[0].Length; j++)
                    {
                        int tmp = last;
                        last = grid[i][j];
                        grid[i][j] = tmp;
                    }
                }
            }
            return grid;
        }
    }
}
