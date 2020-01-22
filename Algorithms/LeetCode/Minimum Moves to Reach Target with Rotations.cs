using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1210. Minimum Moves to Reach Target with Rotations
     * 
     * https://leetcode.com/problems/minimum-moves-to-reach-target-with-rotations/
     */
    public class Minimum_Moves_to_Reach_Target_with_Rotations
    {
        public int MinimumMoves(int[][] grid)
        {
            // BFS. Search state is the snake's position.
            int n = grid.Length;
            int result = 0;
            var visited = new HashSet<Snake>();
            var queue = new Queue<Snake>();
            queue.Enqueue(new Snake(0, 0, 0, 1));
            while (queue.Count != 0)
            {
                int size = queue.Count;
                while (size-- > 0)
                {
                    var snake = queue.Dequeue();
                    if (snake.x1 == n - 1 && snake.y1 == n - 2 && snake.x2 == n - 1 && snake.y2 == n - 1) return result;
                    if (!visited.Add(snake)) continue;
                    if (snake.IsHorizontal)
                    {
                        if (snake.y2 + 1 < n && grid[snake.x2][snake.y2 + 1] == 0)
                        {
                            queue.Enqueue(new Snake(snake.x1, snake.y1 + 1, snake.x2, snake.y2 + 1)); // move right
                        }
                        if (snake.x1 + 1 < n && grid[snake.x1 + 1][snake.y1] == 0 && grid[snake.x2 + 1][snake.y2] == 0)
                        {
                            queue.Enqueue(new Snake(snake.x1 + 1, snake.y1, snake.x2 + 1, snake.y2)); // move down
                            queue.Enqueue(new Snake(snake.x1, snake.y1, snake.x1 + 1, snake.y1)); // rotate clockwise
                        }
                    }
                    else
                    {
                        if (snake.y1 + 1 < n && grid[snake.x1][snake.y1 + 1] == 0 && grid[snake.x2][snake.y2 + 1] == 0)
                        {
                            queue.Enqueue(new Snake(snake.x1, snake.y1 + 1, snake.x2, snake.y2 + 1)); // move right
                            queue.Enqueue(new Snake(snake.x1, snake.y1, snake.x1, snake.y1 + 1)); // rotate counterclockwise
                        }
                        if (snake.x2 + 1 < n && grid[snake.x2 + 1][snake.y2] == 0)
                        {
                            queue.Enqueue(new Snake(snake.x1 + 1, snake.y1, snake.x2 + 1, snake.y2)); // move down
                        }
                    }
                }
                result++;
            }

            return -1;
        }

        // the snake's position
        private class Snake
        {
            public readonly int x1;
            public readonly int y1;
            public readonly int x2;
            public readonly int y2;

            // Convention: x2 and y2 is the right cell if horizontal,
            // and the bottom cell if vertical.
            public Snake(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public bool IsHorizontal => x1 == x2;

            public override bool Equals(object obj)
            {
                return obj is Snake snake &&
                       x1 == snake.x1 &&
                       y1 == snake.y1 &&
                       x2 == snake.x2 &&
                       y2 == snake.y2;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(x1, y1, x2, y2);
            }
        }
    }
}
