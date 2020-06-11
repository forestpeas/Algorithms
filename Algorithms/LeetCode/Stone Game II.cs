using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1140. Stone Game II
     * 
     * Alex and Lee continue their games with piles of stones.  There are a number of piles arranged
     * in a row, and each pile has a positive integer number of stones piles[i].  The objective of
     * the game is to end with the most stones. 
     * 
     * Alex and Lee take turns, with Alex starting first.  Initially, M = 1.
     * 
     * On each player's turn, that player can take all the stones in the first X remaining piles,
     * where 1 <= X <= 2M.  Then, we set M = max(M, X).
     * 
     * The game continues until all the stones have been taken.
     * 
     * Assuming Alex and Lee play optimally, return the maximum number of stones Alex can get.
     * 
     * Example 1:
     * 
     * Input: piles = [2,7,9,4,4]
     * Output: 10
     * Explanation:  If Alex takes one pile at the beginning, Lee takes two piles, then Alex takes
     * 2 piles again. Alex can get 2 + 4 + 4 = 10 piles in total. If Alex takes two piles at the
     * beginning, then Lee can take all three piles left. In this case, Alex get 2 + 7 = 9 piles
     * in total. So we return 10 since it's larger. 
     * 
     * Constraints:
     * 
     * 1 <= piles.length <= 100
     * 1 <= piles[i] <= 10 ^ 4
     */
    public class Stone_Game_II
    {
        public int StoneGameII(int[] piles)
        {
            int n = piles.Length;
            int[,] mem = new int[n, n];
            return F(0, 1, piles.Sum());

            // "sum" is the sum of [start...n-1].
            // Returns the optimal result of the first player when piles = [start...n-1] and m = m.
            int F(int start, int m, int sum)
            {
                if (start + 2 * m >= n) return sum; // Take all that is left.
                if (mem[start, m] != 0) return mem[start, m];
                int res = 0;
                int taken = 0;
                for (int x = 1; x <= 2 * m; x++)
                {
                    taken += piles[start + x - 1];
                    sum = sum - piles[start + x - 1];
                    // player1 takes "taken" this turn, in the next sub-problem, player2 takes
                    // F(start + x, Math.Max(m, x)), player 1 takes sum minus that.
                    int next = sum - F(start + x, Math.Max(m, x), sum);
                    res = Math.Max(res, taken + next);
                }

                mem[start, m] = res;
                return res;
            }
        }
    }
}
