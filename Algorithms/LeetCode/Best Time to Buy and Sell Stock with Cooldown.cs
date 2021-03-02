using System;

namespace Algorithms.LeetCode
{
    /* 309. Best Time to Buy and Sell Stock with Cooldown
     * 
     * Say you have an array for which the ith element is the price of a given stock on day i.
     * 
     * Design an algorithm to find the maximum profit. You may complete as many transactions as
     * you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
     * 
     * You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
     * After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
     * 
     * Example:
     * 
     * Input: [1,2,3,0,2]
     * Output: 3 
     * Explanation: transactions = [buy, sell, cooldown, buy, sell]
     */
    public class BestTimeToBuyAndSellStockWithCooldown
    {
        public int MaxProfit(int[] prices)
        {
            // I think this is greedy rather than DP. Hard to prove but it seems to be the case.
            // buy[i] means the max profit that ends with buying on a day from range [0-i].
            // sell[i] means the max profit that ends with selling on a day from range [0-i].
            if (prices.Length < 1) return 0;
            int[] buy = new int[prices.Length];
            int[] sell = new int[prices.Length];
            buy[0] = -prices[0];
            sell[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                // Do not buy at i, or do buy at i and include the profit that we gained from sell[i - 2].
                // (Not sell[i-1] because of cooldown)
                int lastSell = i < 2 ? 0 : sell[i - 2];
                buy[i] = Math.Max(buy[i - 1], lastSell - prices[i]);
                // Do not sell at i, or do sell at i and include the profit that we gained from buy[i - 1].
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }
            return sell[sell.Length - 1];
        }
    }
}
