namespace Algorithms.LeetCode
{
    /* 887. Super Egg Drop
     * 
     * You are given K eggs, and you have access to a building with N floors from 1 to N. 
     * Each egg is identical in function, and if an egg breaks, you cannot drop it again.
     * You know that there exists a floor F with 0 <= F <= N such that any egg dropped at
     * a floor higher than F will break, and any egg dropped at or below floor F will not break.
     * Each move, you may take an egg (if you have an unbroken one) and drop it from any floor X (with 1 <= X <= N). 
     * Your goal is to know with certainty what the value of F is.
     * What is the minimum number of moves that you need to know with certainty what F is,
     * regardless of the initial value of F?
     * 
     * Example 1:
     * 
     * Input: K = 1, N = 2
     * Output: 2
     * Explanation: 
     * Drop the egg from floor 1.  If it breaks, we know with certainty that F = 0.
     * Otherwise, drop the egg from floor 2.  If it breaks, we know with certainty that F = 1.
     * If it didn't break, then we know with certainty F = 2.
     * Hence, we needed 2 moves in the worst case to know what F is with certainty.
     * 
     * Example 2:
     * 
     * Input: K = 2, N = 6
     * Output: 3
     * 
     * Example 3:
     * 
     * Input: K = 3, N = 14
     * Output: 4
     * 
     * Note:
     * 1 <= K <= 100
     * 1 <= N <= 10000
     */
    public class SuperEggDropSolution
    {
        public int SuperEggDrop(int K, int N)
        {
            // From Approach 3 of https://leetcode.com/articles/super-egg-drop/.
            // Given k eggs and m moves, dp(m,k) is the maximum floor that we can
            // know with certainty what F is. For example, dp(2,1) = 2 because
            // with 1 egg and 2 moves, we can only start from floor 1, if it doesn't
            // break, try floor 2, so if the critical point is floor 1 or floor 2,
            // we can be sure which floor it is, but if the critical point is on
            // the higher floor, then we need more eggs or more moves.
            //
            // dp(m, k) = dp(m - 1, k - 1) + dp(m - 1, k) + 1
            // Assume dp(m - 1, k - 1) = n0, dp(m - 1, k) = n1.
            // The first floor to check is n0 + 1.
            // If the egg breaks, the m-1 moves and k-1 eggs left is just enough to
            // check the lower n0 floors. If the egg doesn't break, we still have
            // m-1 moves and k eggs, we start from n0 + 2, and the highest floor
            // we can reach is dp(m-1, k) = n1. So dp(m,k) = n0 + 1 + n1.
            int[,] dp = new int[N + 1, K + 1]; // N + 1 is more than enough for m.
            int m = 0;
            while (dp[m, K] < N)
            {
                m++;
                for (int k = 1; k <= K; ++k)
                {
                    dp[m, k] = dp[m - 1, k - 1] + dp[m - 1, k] + 1;
                }
            }
            return m;
        }
    }
}
