using System;

namespace Algorithms.LeetCode
{
    /* 322. Coin Change
     * 
     * You are given coins of different denominations and a total amount of money amount.
     * Write a function to compute the fewest number of coins that you need to make up
     * that amount. If that amount of money cannot be made up by any combination of the
     * coins, return -1.
     * 
     * Example 1:
     * 
     * Input: coins = [1, 2, 5], amount = 11
     * Output: 3 
     * 
     * Explanation: 11 = 5 + 5 + 1
     * Example 2:
     * 
     * Input: coins = [2], amount = 3
     * Output: -1
     * 
     * Note:
     * You may assume that you have an infinite number of each kind of coin.
     */
    public class CoinChangeSolution
    {
        public int CoinChange(int[] coins, int amount)
        {
            // S is the amount, dp(S) is the problem answer to S.
            // dp(S) = min(dp(S - coins[i]) + 1, 0 <= i < coins.Length, S - coins[i] >= 0
            // coins[i] is the last coin's denomination to make up S.
            // For example, coins = [1, 2, 5], amount = 11
            // dp(11) = min(dp(10), dp(9), dp(6)) + 1
            int[] dp = new int[amount + 1];
            dp[0] = 0;

            for (int i = 1; i < dp.Length; i++)
            {
                int minCoins = int.MaxValue;
                foreach (int coin in coins)
                {
                    if (i - coin >= 0 && dp[i - coin] != -1)
                    {
                        minCoins = Math.Min(minCoins, dp[i - coin] + 1);
                    }
                }

                dp[i] = minCoins == int.MaxValue ? -1 : minCoins;
            }

            return dp[amount];
        }
    }
}
