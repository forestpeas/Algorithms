namespace Algorithms.LeetCode
{
    /* 529. Minesweeper
     * 
     * Let's play the minesweeper game (Wikipedia, online game)!
     * 
     * You are given a 2D char matrix representing the game board. 'M' represents an unrevealed
     * mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square
     * that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1'
     * to '8') represents how many mines are adjacent to this revealed square, and finally 'X'
     * represents a revealed mine.
     * 
     * Now given the next click position (row and column indices) among all the unrevealed
     * squares ('M' or 'E'), return the board after revealing this position according to the
     * following rules:
     * 
     * 1. If a mine ('M') is revealed, then the game is over - change it to 'X'.
     * 2. If an empty square ('E') with no adjacent mines is revealed, then change it to revealed
     * blank ('B') and all of its adjacent unrevealed squares should be revealed recursively.
     * 3. If an empty square ('E') with at least one adjacent mine is revealed, then change it to
     * a digit ('1' to '8') representing the number of adjacent mines.
     * 4. Return the board when no more squares will be revealed.
     * 
     * Example 1:
     * https://leetcode.com/problems/minesweeper/
     * Input: 
     * 
     * [['E', 'E', 'E', 'E', 'E'],
     *  ['E', 'E', 'M', 'E', 'E'],
     *  ['E', 'E', 'E', 'E', 'E'],
     *  ['E', 'E', 'E', 'E', 'E']]
     * 
     * Click : [3,0]
     * 
     * Output: 
     * 
     * [['B', '1', 'E', '1', 'B'],
     *  ['B', '1', 'M', '1', 'B'],
     *  ['B', '1', '1', '1', 'B'],
     *  ['B', 'B', 'B', 'B', 'B']]
     */
    public class Minesweeper
    {
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            if (board[click[0]][click[1]] == 'M')
            {
                board[click[0]][click[1]] = 'X';
                return board;
            }
            Update(click[0], click[1]);
            return board;

            void Update(int i, int j)
            {
                if (board[i][j] != 'E') return;
                int count = 0;
                foreach (int[] d in dirs)
                {
                    int x = i + d[0], y = j + d[1];
                    if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length) continue;
                    if (board[x][y] == 'M') count++;
                }

                if (count == 0)
                {
                    board[i][j] = 'B';
                    foreach (int[] d in dirs)
                    {
                        int x = i + d[0], y = j + d[1];
                        if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length) continue;
                        Update(x, y);
                    }
                }
                else
                {
                    board[i][j] = (char)(count + '0');
                }
            }
        }

        private static readonly int[][] dirs = new int[][]
        {
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 1 },
            new int[] { 1, -1 },
            new int[] { -1, 1 },
            new int[] { -1, -1},
        };
    }
}
