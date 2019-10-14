using System;

namespace Algorithms.LeetCode
{
    /* 188. Best Time to Buy and Sell Stock IV
     * 
     * Say you have an array for which the i-th element is the price of a given stock on day i.
     * 
     * Design an algorithm to find the maximum profit. You may complete at most k transactions.
     * 
     * Note:
     * You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
     * 
     * Example 1:
     * 
     * Input: [2,4,1], k = 2
     * Output: 2
     * Explanation: Buy on day 1 (price = 2) and sell on day 2 (price = 4), profit = 4-2 = 2.
     * 
     * Example 2:
     * 
     * Input: [3,2,6,5,0,3], k = 2
     * Output: 7
     * Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 6), profit = 6-2 = 4.
     *              Then buy on day 5 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
     */
    public class BestTimeToBuyAndSellStockIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices.Length < 2) return 0;
            // There is a test case that has very large k and prices.
            if (k >= prices.Length / 2) return new BestTimeToBuyAndSellStockII().MaxProfitAccumulative(prices);

            // dp[i, j] = the maximum profit from at most i transactions using prices[0..j]
            int[,] dp = new int[k + 1, prices.Length];

            for (int i = 1; i <= k; i++)
            {
                int maxProfit = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    // Either do nothing(not buy) or sell on day j.
                    // If we choose to sell on day j, assume the last time we bought is on day t.
                    // So the profit we can get is prices[j] - prices[t] + dp[i - 1, t - 1].
                    // We need to know what t makes the maximum profit. The variable "maxProfit"
                    // does this job.
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + maxProfit);

                    maxProfit = Math.Max(maxProfit, dp[i - 1, j - 1] - prices[j]);
                }
            }

            return dp[k, prices.Length - 1];
        }
    }
}
