namespace Algorithms.LeetCode
{
    /* 518. Coin Change 2
     * 
     * You are given coins of different denominations and a total amount of money.
     * Write a function to compute the number of combinations that make up that amount.
     * You may assume that you have infinite number of each kind of coin.
     * 
     * Example 1:
     * 
     * Input: amount = 5, coins = [1, 2, 5]
     * Output: 4
     * Explanation: there are four ways to make up the amount:
     * 5=5
     * 5=2+2+1
     * 5=2+1+1+1
     * 5=1+1+1+1+1
     * 
     * Example 2:
     * 
     * Input: amount = 3, coins = [2]
     * Output: 0
     * Explanation: the amount of 3 cannot be made up just with coins of 2.
     * Example 3:
     * 
     * Input: amount = 10, coins = [10] 
     * Output: 1
     *  
     * Note:
     * You can assume that
     * 0 <= amount <= 5000
     * 1 <= coin <= 5000
     * the number of coins is less than 500
     * the answer is guaranteed to fit into signed 32-bit integer
     */
    public class CoinChange2
    {
        public int Change(int amount, int[] coins)
        {
            // dp[i, j] means how many combinations there are when amount = j and we can only use coins[0...i].
            // Consider how we can get dp[i, j].
            // 1. Not using coins[i], we have dp[i - 1, j] combinations.
            // 2. Use one coins[i] first, we have dp[i, j - coins[i]] combinations.
            // These two events do not overlap with each other, so we can just add them.
            // All possibilities are inluded in these two events.
            int[,] dp = new int[coins.Length + 1, amount + 1];

            for (int i = 0; i <= coins.Length; i++) dp[i, 0] = 1;

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    int tmp = j - coins[i - 1] < 0 ? 0 : dp[i, j - coins[i - 1]];
                    dp[i, j] = dp[i - 1, j] + tmp;
                }
            }

            return dp[coins.Length, amount];
        }

        public int Change1(int amount, int[] coins)
        {
            // The above solution can be optimized to O(amount) space.
            int[] dp = new int[amount + 1];

            dp[0] = 1;

            foreach (int coin in coins)
            {
                for (int j = coin; j <= amount; j++)
                {
                    dp[j] = dp[j] + dp[j - coin];
                }
            }

            return dp[amount];
        }
    }
}
