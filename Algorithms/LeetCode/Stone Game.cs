using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 877. Stone Game
     * 
     * Alex and Lee play a game with piles of stones.  There are an even number of piles arranged in
     * a row, and each pile has a positive integer number of stones piles[i].
     * 
     * The objective of the game is to end with the most stones.  The total number of stones is odd,
     * so there are no ties.
     * 
     * Alex and Lee take turns, with Alex starting first.  Each turn, a player takes the entire pile
     * of stones from either the beginning or the end of the row.  This continues until there are no
     * more piles left, at which point the person with the most stones wins.
     * 
     * Assuming Alex and Lee play optimally, return True if and only if Alex wins the game.
     * 
     * Example 1:
     * 
     * Input: [5,3,4,5]
     * Output: true
     * Explanation: 
     * Alex starts first, and can only take the first 5 or the last 5.
     * Say he takes the first 5, so that the row becomes [3, 4, 5].
     * If Lee takes 3, then the board is [4, 5], and Alex takes 5 to win with 10 points.
     * If Lee takes the last 5, then the board is [3, 4], and Alex takes 4 to win with 9 points.
     * This demonstrated that taking the first 5 was a winning move for Alex, so we return true.
     * 
     * Note:
     * 
     * 2 <= piles.length <= 500
     * piles.length is even.
     * 1 <= piles[i] <= 500
     * sum(piles) is odd.
     */
    public class Stone_Game
    {
        public bool StoneGame(int[] piles)
        {
            // Inspired by Approach 2 from https://leetcode.com/articles/stone-game/
            // Alex can choose whether to pick all even indexes or all odd indexes.
            return true;
        }

        public bool StoneGame2(int[] piles)
        {
            // DFS or DP. mem[l,r,p] is optimal score that Alex can get if it's player p's turn.
            // Alex is player 0 and Lee is player 1.
            var mem = new int[piles.Length, piles.Length, 2];
            int res = StoneGame(0, piles.Length - 1, 0);
            return res > piles.Sum() - res;

            int StoneGame(int l, int r, int player)
            {
                if (l == r) return player == 0 ? piles[l] : 0;
                if (mem[l, r, player] != 0) return mem[l, r, player];

                int max = Math.Max(piles[l] + StoneGame(l + 1, r, player ^ 1), piles[r] + StoneGame(l, r - 1, player ^ 1));
                int sl = piles[l] + StoneGame(l + 1, r, player ^ 1);
                int sr = piles[r] + StoneGame(l, r - 1, player ^ 1);
                if (sl > sr)
                {
                    mem[l, r, player] = player == 0 ? sl : sl - piles[l];
                }
                else
                {
                    mem[l, r, player] = player == 0 ? sr : sr - piles[r];
                }

                return mem[l, r, player];
            }
        }
    }
}
