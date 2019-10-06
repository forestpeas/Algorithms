using System;

namespace Algorithms.LeetCode
{
    /* 329. Longest Increasing Path in a Matrix
     * 
     * Given an integer matrix, find the length of the longest increasing path.
     * 
     * From each cell, you can either move to four directions: left, right, up or down.
     * You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).
     * 
     * Example 1:
     * 
     * Input: nums = 
     * [
     *   [9,9,4],
     *   [6,6,8],
     *   [2,1,1]
     * ] 
     * Output: 4 
     * Explanation: The longest increasing path is [1, 2, 6, 9].
     * 
     * Example 2:
     * 
     * Input: nums = 
     * [
     *   [3,4,5],
     *   [3,2,6],
     *   [2,2,1]
     * ] 
     * Output: 4 
     * Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
     */
    public class LongestIncreasingPathInMatrix
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            // Dfs with memoization.
            // Second approach: treat the matrix as a directed graph, with edges pointing from smaller value
            // to larger value. Use BFS topological sort based on in-degree counting. Count the number of levels.
            if (matrix.Length < 1) return 0;
            int m = matrix.Length;
            int n = matrix[0].Length;
            var mem = new int[m][];
            for (int i = 0; i < m; i++) mem[i] = new int[n];

            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result = Math.Max(result, Dfs(i, j));
                }
            }
            return result;

            int Dfs(int i, int j)
            {
                if (mem[i][j] != 0) return mem[i][j];
                int max = 1;
                if (i - 1 >= 0 && matrix[i - 1][j] > matrix[i][j])
                {
                    max = Math.Max(max, 1 + Dfs(i - 1, j));
                }
                if (i + 1 < m && matrix[i + 1][j] > matrix[i][j])
                {
                    max = Math.Max(max, 1 + Dfs(i + 1, j));
                }
                if (j - 1 >= 0 && matrix[i][j - 1] > matrix[i][j])
                {
                    max = Math.Max(max, 1 + Dfs(i, j - 1));
                }
                if (j + 1 < n && matrix[i][j + 1] > matrix[i][j])
                {
                    max = Math.Max(max, 1 + Dfs(i, j + 1));
                }
                mem[i][j] = max;
                return max;
            }
        }
    }
}
