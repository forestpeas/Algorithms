using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 200. Number of Islands
     * 
     * Given a 2d grid map of '1's (land) and '0's (water), count the number of islands.
     * An island is surrounded by water and is formed by connecting adjacent lands horizontally
     * or vertically. You may assume all four edges of the grid are all surrounded by water.
     * 
     * Example 1:
     * 
     * Input:
     * 11110
     * 11010
     * 11000
     * 00000
     * 
     * Output: 1
     * 
     * Example 2:
     * 
     * Input:
     * 11000
     * 11000
     * 00100
     * 00011
     * 
     * Output: 3
     */
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            // BFS, similar to "Problem 130. Surrounded Regions".
            // DFS version is in "1254. Number of Closed Islands".
            if (grid.Length < 1 || grid[0].Length < 1) return 0;
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        Bfs(i, j);
                    }
                }
            }

            return count;

            void Bfs(int i, int j)
            {
                var queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(new Tuple<int, int>(i, j));
                while (queue.Count != 0)
                {
                    var coordinate = queue.Dequeue();
                    i = coordinate.Item1;
                    j = coordinate.Item2;
                    if (i >= 0 && i < m && j >= 0 && j < n && grid[i][j] == '1')
                    {
                        grid[i][j] = '#';
                        queue.Enqueue(new Tuple<int, int>(i - 1, j));
                        queue.Enqueue(new Tuple<int, int>(i + 1, j));
                        queue.Enqueue(new Tuple<int, int>(i, j - 1));
                        queue.Enqueue(new Tuple<int, int>(i, j + 1));
                    }
                }
            }
        }
    }
}
