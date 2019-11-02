using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 909. Snakes and Ladders
     * 
     * https://leetcode.com/problems/snakes-and-ladders/
     */
    public class SnakesAndLaddersSolution
    {
        public int SnakesAndLadders(int[][] board)
        {
            // BFS.
            int n = board.Length;
            bool[] visited = new bool[n * n + 1];
            int result = 0;
            var queue = new Queue<int>();
            queue.Enqueue(1);
            while (queue.Count != 0)
            {
                result++;
                int length = queue.Count;
                while (length-- > 0)
                {
                    int square = queue.Dequeue();
                    for (int i = 1; i <= 6; i++)
                    {
                        int nextSquare = square + i;
                        if (nextSquare > n * n) continue;
                        int value = GetBoardValue(nextSquare);
                        if (value != -1) nextSquare = value;
                        if (visited[nextSquare]) continue;
                        if (nextSquare == n * n) return result;
                        queue.Enqueue(nextSquare);
                        visited[nextSquare] = true;
                    }
                }
            }

            return -1;

            // Maps a number from [1...n^2] to a cell.
            int GetBoardValue(int square)
            {
                square--;
                int row = (n - 1) - square / n;
                int col = square % n;
                if ((square / n) % 2 == 1) col = (n - 1) - col;
                return board[row][col];
            }
        }
    }
}
