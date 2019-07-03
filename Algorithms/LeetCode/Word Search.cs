using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 79. Word Search
     * 
     * Given a 2D board and a word, find if the word exists in the grid.
     * The word can be constructed from letters of sequentially adjacent cell, 
     * where "adjacent" cells are those horizontally or vertically neighboring.
     * The same letter cell may not be used more than once.
     * 
     * Example:
     * 
     * board =
     * [
     *   ['A','B','C','E'],
     *   ['S','F','C','S'],
     *   ['A','D','E','E']
     * ]
     * 
     * Given word = "ABCCED", return true.
     * Given word = "SEE", return true.
     * Given word = "ABCB", return false.
     */
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            // Backtracking
            if (board.Length < 1 || word.Length < 1) return false;
            int m = board.Length;
            int n = board[0].Length;
            var path = new HashSet<int>();
            for (int ii = 0; ii < m; ii++)
            {
                for (int jj = 0; jj < n; jj++)
                {
                    if (Exist(ii, jj, 0)) return true;
                    path.Clear();
                }
            }
            return false;

            bool Exist(int i, int j, int k)
            {
                if (i < 0 || j < 0 || i == m || j == n || board[i][j] != word[k]) return false;
                if (!path.Add(i * n + j)) return false; // Add a unique number of the combination of "i" and "j".
                if (k + 1 == word.Length) return true;
                if (Exist(i + 1, j, k + 1)) return true;
                if (Exist(i, j + 1, k + 1)) return true;
                if (Exist(i - 1, j, k + 1)) return true;
                if (Exist(i, j - 1, k + 1)) return true;
                path.Remove(i * n + j);
                return false;
            }
        }
    }
}
