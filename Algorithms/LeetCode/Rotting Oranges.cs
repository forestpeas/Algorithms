using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 994. Rotting Oranges
     * 
     * https://leetcode.com/problems/rotting-oranges/
     */
    public class Rotting_Oranges
    {
        private class Point
        {
            public int i;
            public int j;

            public Point(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

        public int OrangesRotting(int[][] grid)
        {
            if (grid.Length < 1 || grid[0].Length < 1) return 0;

            var queue = new Queue<Point>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(new Point(i, j));
                    }
                }
            }

            int result = BFS(grid, queue);

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }

            return result == -1 ? 0 : result;
        }

        private int BFS(int[][] grid, Queue<Point> queue)
        {
            int levels = -1;
            while (queue.Count != 0)
            {
                levels++;
                int count = queue.Count;
                while (count-- > 0)
                {
                    var point = queue.Dequeue();
                    if (point.i + 1 < grid.Length && grid[point.i + 1][point.j] == 1)
                    {
                        queue.Enqueue(new Point(point.i + 1, point.j));
                        grid[point.i + 1][point.j] = 3;
                    }
                    if (point.i - 1 >= 0 && grid[point.i - 1][point.j] == 1)
                    {
                        queue.Enqueue(new Point(point.i - 1, point.j));
                        grid[point.i - 1][point.j] = 3;
                    }
                    if (point.j + 1 < grid[0].Length && grid[point.i][point.j + 1] == 1)
                    {
                        queue.Enqueue(new Point(point.i, point.j + 1));
                        grid[point.i][point.j + 1] = 3;
                    }
                    if (point.j - 1 >= 0 && grid[point.i][point.j - 1] == 1)
                    {
                        queue.Enqueue(new Point(point.i, point.j - 1));
                        grid[point.i][point.j - 1] = 3;
                    }
                }
            }

            return levels;
        }
    }
}
