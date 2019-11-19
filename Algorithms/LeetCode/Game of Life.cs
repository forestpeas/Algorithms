namespace Algorithms.LeetCode
{
    /* 289. Game of Life
     * 
     * According to the Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular
     * automaton devised by the British mathematician John Horton Conway in 1970."
     * 
     * Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell
     * interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules
     * (taken from the above Wikipedia article):
     * Any live cell with fewer than two live neighbors dies, as if caused by under-population.
     * Any live cell with two or three live neighbors lives on to the next generation.
     * Any live cell with more than three live neighbors dies, as if by over-population..
     * Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
     * 
     * Write a function to compute the next state (after one update) of the board given its current state.
     * The next state is created by applying the above rules simultaneously to every cell in the current
     * state, where births and deaths occur simultaneously.
     * 
     * Example:
     * 
     * Input: 
     * [
     *   [0,1,0],
     *   [0,0,1],
     *   [1,1,1],
     *   [0,0,0]
     * ]
     * Output: 
     * [
     *   [0,0,0],
     *   [1,0,1],
     *   [0,1,1],
     *   [0,1,0]
     * ]
     * 
     * Follow up:
     * Could you solve it in-place? Remember that the board needs to be updated at the same time: You
     * cannot update some cells first and then use their updated values to update other cells.
     * In this question, we represent the board using a 2D array. In principle, the board is infinite,
     * which would cause problems when the active area encroaches the border of the array. How would 
     * you address these problems?
     */
    public class Game_of_Life
    {
        public void GameOfLife(int[][] board)
        {
            // In order to solve it in-place, mark a cell as 2 to represent that it is now alive, but
            // will be dead in the next state, and mark a cell as -1 to represent that it is now dead,
            // but will be alive in the next state. So positive cells are alive.
            if (board.Length < 1 || board[0].Length < 1) return;

            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 1)
                    {
                        int liveNeighbors = GetLiveNeighbors(i, j);
                        if (liveNeighbors < 2 || liveNeighbors > 3) board[i][j] = 2;
                    }
                    else
                    {
                        if (GetLiveNeighbors(i, j) == 3) board[i][j] = -1;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] == 2) board[i][j] = 0;
                    else if (board[i][j] == -1) board[i][j] = 1;
                }
            }

            int GetLiveNeighbors(int i, int j)
            {
                int liveNeighbors = 0;
                liveNeighbors += GetValue(i - 1, j - 1);
                liveNeighbors += GetValue(i - 1, j);
                liveNeighbors += GetValue(i - 1, j + 1);
                liveNeighbors += GetValue(i, j + 1);
                liveNeighbors += GetValue(i + 1, j + 1);
                liveNeighbors += GetValue(i + 1, j);
                liveNeighbors += GetValue(i + 1, j - 1);
                liveNeighbors += GetValue(i, j - 1);
                return liveNeighbors;
            }

            int GetValue(int i, int j)
            {
                // Out-of-boundary cells won't be counted as living cells.
                if (i < 0 || i >= m || j < 0 || j >= n) return 0;
                return board[i][j] > 0 ? 1 : 0;
            }
        }
    }
}
