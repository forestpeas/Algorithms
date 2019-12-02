using System;

namespace Algorithms.LeetCode
{
    /* 174. Dungeon Game
     * 
     * https://leetcode.com/problems/dungeon-game/
     */
    public class Dungeon_Game
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            // If we iterate from top-left to bottom-right, we need 1. the current HP(the path sum
            // from top-left to the current grid); and 2. the minimum HP that we have experienced.
            // We can't tell whether there will be enough power-ups for us to currently choose the
            // path with greater minimum HP or there will be more demons so that we'd better choose
            // the path with greater current HP. So we might as well reverse our thoughts. If we 
            // iterate from bottom-right to top-left, the path sum from the current grid to bottom-
            // right is no longer our concern, because even a very large sum path is no difference
            // than a smaller one as they all lead to the destination.
            int m = dungeon.Length;
            int n = dungeon[0].Length;
            // dp[i,j] is the minimum initial IF we start from dungeon[i,j] to reach the bottom-right.
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++) dp[i, n] = int.MaxValue;
            for (int j = 0; j < n; j++) dp[m, j] = int.MaxValue;
            dp[m - 1, n] = 1; // Or dp[m, n - 1] = 1

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    int needed = Math.Min(dp[i + 1, j], dp[i, j + 1]);
                    if (dungeon[i][j] >= needed) dp[i, j] = 1;
                    else dp[i, j] = needed - dungeon[i][j];
                }
            }

            return dp[0, 0];
        }
    }
}
