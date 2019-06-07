using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 51. N-Queens
     * 
     * The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
     * Given an integer n, return all distinct solutions to the n-queens puzzle.
     * Each solution contains a distinct board configuration of the n-queens' placement, 
     * where 'Q' and '.' both indicate a queen and an empty space respectively.
     * 
     * Example:
     * 
     * Input: 4
     * Output: [
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
     * Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above.
     */
    public class NQueens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            // Backtracking and DFS.
            var chessBoard = new char[n][];
            for (int i = 0; i < n; i++)
            {
                chessBoard[i] = Enumerable.Repeat('.', n).ToArray();
            }
            var results = new List<IList<string>>();
            Solve(0);
            return results;

            void Solve(int i)
            {
                for (int j = 0; j < n; j++)
                {
                    if (FindQ(chessBoard, n, i, j)) continue;
                    chessBoard[i][j] = 'Q';

                    if (i + 1 == n)
                    {
                        results.Add(chessBoard.Select(chars => new string(chars)).ToArray());
                    }
                    else
                    {
                        Solve(i + 1);
                    }

                    chessBoard[i][j] = '.';
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
