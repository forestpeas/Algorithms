using System;

namespace Algorithms.LeetCode
{
    /* 123. Best Time to Buy and Sell Stock III
     * 
     * Say you have an array for which the ith element is the price of a given stock on day i.
     * Design an algorithm to find the maximum profit. You may complete at most two transactions.
     * 
     * Note: You may not engage in multiple transactions at the same time (i.e., you must sell
     * the stock before you buy again).
     * 
     * Example 1:
     * 
     * Input: [3,3,5,0,0,3,1,4]
     * Output: 6
     * Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
     *              Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
     * 
     * Example 2:
     * 
     * Input: [1,2,3,4,5]
     * Output: 4
     * Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
     *              Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
     *              engaging multiple transactions at the same time. You must sell before buying again.
     * 
     * Example 3:
     * 
     * Input: [7,6,4,3,1]
     * Output: 0
     * Explanation: In this case, no transaction is done, i.e. max profit = 0.
     */
    public class BestTimeToBuyAndSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            // Code is simple but not easy to understand. Let's take an exapmle:
            // prices = [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]
            int lowestBuyPrice1 = int.MaxValue;
            int lowestBuyPrice2 = int.MaxValue;
            int maxProfit1 = 0;
            int maxProfit2 = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                // The max profit so far of buying and selling only once.
                lowestBuyPrice1 = Math.Min(lowestBuyPrice1, prices[i]);
                maxProfit1 = Math.Max(maxProfit1, prices[i] - lowestBuyPrice1);

                // If this is the second time we buy(which means we've already finished our first trade
                // and gained some profits), and assume we buy at prices[i], we can consider the price
                // is only (prices[i] - maxProfit1). For example:
                // [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]
                //           ↑
                //           i
                // Since we've gained 4-1=3 profits from the first trade, and now we want to buy a stock
                // that costs 2, this can be considered as buying that stock at a price of "-1" (without
                // any initial funds), that is, buying a stock of 2 dollars with 3 dollers is equal to
                // buying a stock of "-1" dollars without any money. Now let's move i a step forward:
                // [1, 2, 4, 2, 5, 7, 2, 4, 9, 0]
                //           ↑  ↑
                //           ↑  i
                //           Buying point with the lowest price of -1.
                // Now, we want to sell that stock we bought at a price of -1, how much will we earn?
                // Apparently it's 5-(-1)= 6. This actually includes the profits of our first trade.
                // lowestBuyPrice2 is the lowest buy price so far.
                lowestBuyPrice2 = Math.Min(lowestBuyPrice2, prices[i] - maxProfit1);
                maxProfit2 = Math.Max(maxProfit2, prices[i] - lowestBuyPrice2);
            }

            return maxProfit2;
        }
    }
}
