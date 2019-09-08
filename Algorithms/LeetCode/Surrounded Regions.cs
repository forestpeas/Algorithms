using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 130. Surrounded Regions
     * 
     * Given a 2D board containing 'X' and 'O' (the letter O), capture all regions surrounded by 'X'.
     * A region is captured by flipping all 'O's into 'X's in that surrounded region.
     * 
     * Example:
     * 
     * X X X X
     * X O O X
     * X X O X
     * X O X X
     * 
     * After running your function, the board should be:
     * 
     * X X X X
     * X X X X
     * X X X X
     * X O X X
     * 
     * Explanation:
     * 
     * Surrounded regions shouldn’t be on the border, which means that any 'O' on the border of the board
     * are not flipped to 'X'. Any 'O' that is not on the border and it is not connected to an 'O' on the
     * border will be flipped to 'X'. Two cells are connected if they are adjacent cells connected horizontally
     * or vertically.
     */
    public class SurroundedRegions
    {
        public void Solve(char[][] board)
        {
            // BFS starting from borders.
            // Use '#' to mark the 'O's connected to borders.
            if (board.Length < 3 || board[0].Length < 3) return;
            int m = board.Length;
            int n = board[0].Length;

            void Bfs(int i, int j)
            {
                var queue = new Queue<Tuple<int, int>>();
                queue.Enqueue(new Tuple<int, int>(i, j));
                while (queue.Count != 0)
                {
                    var grid = queue.Dequeue();
                    i = grid.Item1;
                    j = grid.Item2;
                    if (i >= 0 && i < m && j >= 0 && j < n && board[i][j] == 'O')
                    {
                        board[i][j] = '#';
                        queue.Enqueue(new Tuple<int, int>(i - 1, j));
                        queue.Enqueue(new Tuple<int, int>(i + 1, j));
                        queue.Enqueue(new Tuple<int, int>(i, j - 1));
                        queue.Enqueue(new Tuple<int, int>(i, j + 1));
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                if (board[i][0] == 'O')
                {
                    Bfs(i, 0);
                }

                if (board[i][n - 1] == 'O')
                {
                    Bfs(i, n - 1);
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (board[0][j] == 'O')
                {
                    Bfs(0, j);
                }

                if (board[m - 1][j] == 'O')
                {
                    Bfs(m - 1, j);
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    else if (board[i][j] == '#')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }
    }
}
