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
            // DFS + Backtracking.
            // Search all possible paths (brute-force).
            if (board.Length < 1 || word.Length < 1) return false;
            int m = board.Length;
            int n = board[0].Length;
            var visited = new bool[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Dfs(i, j, 0)) return true;
                }
            }
            return false;

            bool Dfs(int i, int j, int k)
            {
                if (i < 0 || j < 0 || i == m || j == n || visited[i, j] || board[i][j] != word[k]) return false;
                if (k == word.Length - 1) return true;
                visited[i, j] = true;
                foreach (int[] d in dirs)
                {
                    if (Dfs(i + d[0], j + d[1], k + 1)) return true;
                }
                visited[i, j] = false;
                return false;
            }
        }

        private readonly int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    }
}
