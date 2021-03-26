using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1801. Number of Orders in the Backlog
     * 
     * https://leetcode.com/problems/number-of-orders-in-the-backlog/
     */
    public class Number_of_Orders_in_the_Backlog
    {
        public int GetNumberOfBacklogOrders(int[][] orders)
        {
            var buyLogs = new PriorityQueue<int[]>(Comparer<int[]>.Create((x, y) => x[0] - y[0]));
            var sellLogs = new PriorityQueue<int[]>(Comparer<int[]>.Create((x, y) => y[0] - x[0]));
            foreach (var order in orders)
            {
                if (order[2] == 0)
                {
                    Execute(order, sellLogs, (logAmount, orderAmount) => logAmount <= orderAmount);
                    if (order[1] > 0) buyLogs.Add(order);
                }
                else
                {
                    Execute(order, buyLogs, (logAmount, orderAmount) => logAmount >= orderAmount);
                    if (order[1] > 0) sellLogs.Add(order);
                }
            }
            return buyLogs.Concat(sellLogs).Select(o => o[1]).Aggregate((a, b) => (a + b) % 1000000007);
        }

        private void Execute(int[] order, PriorityQueue<int[]> logs, Func<int, int, bool> compare)
        {
            while (order[1] > 0 && logs.Count != 0 && compare(logs.PeekTop()[0], order[0]))
            {
                if (logs.PeekTop()[1] > order[1])
                {
                    logs.PeekTop()[1] -= order[1];
                    order[1] = 0;
                }
                else
                {
                    order[1] -= logs.DeleteTop()[1];
                }
            }
        }
    }
}
