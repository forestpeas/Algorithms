namespace Algorithms.LeetCode
{
    /* 52. N-Queens II
     * 
     * The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
     * Given an integer n, return the number of distinct solutions to the n-queens puzzle.
     * 
     * Example:
     * 
     * Input: 4
     * Output: 2
     * Explanation: There are two distinct solutions to the 4-queens puzzle as shown below.
     * [
     *  [".Q..",  // Solution 1
     *   "...Q",
     *   "Q...",
     *   "..Q."],
     * 
     *  ["..Q.",  // Solution 2
     *   "Q...",
     *   "...Q",
     *   ".Q.."]
     * ]
     */
    public class NQueensII
    {
        public int TotalNQueens(int n)
        {
            // Same as "51. N-Queens". Don't know the difference between these two problems.
            var chessBoard = new char[n][];
            for (int i = 0; i < n; i++)
            {
                chessBoard[i] = new char[n];
            }
            int result = 0;
            Solve(0);
            return result;

            void Solve(int i)
            {
                for (int j = 0; j < n; j++)
                {
                    if (FindQ(chessBoard, n, i, j)) continue;
                    chessBoard[i][j] = 'Q';

                    if (i + 1 == n)
                    {
                        result++;
                    }
                    else
                    {
                        Solve(i + 1);
                    }

                    chessBoard[i][j] = char.MinValue;
                }
            }
        }

        private bool FindQ(char[][] chessBoard, int n, int i, int j)
        {
            for (int k = 0; k < i; k++)
            {
                if (chessBoard[k][j] == 'Q') return true;
            }
            for (int x = i - 1, y = j - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (chessBoard[x][y] == 'Q') return true;
            }
            for (int x = i - 1, y = j + 1; x >= 0 && y < n; x--, y++)
            {
                if (chessBoard[x][y] == 'Q') return true;
            }
            return false;
        }
    }
}
