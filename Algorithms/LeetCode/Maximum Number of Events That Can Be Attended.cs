using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1353. Maximum Number of Events That Can Be Attended
     * 
     * Given an array of events where events[i] = [startDayi, endDayi]. Every event i starts at startDayi
     * and ends at endDayi.
     * 
     * You can attend an event i at any day d where startTimei <= d <= endTimei. Notice that you can only
     * attend one event at any time d.
     * 
     * Return the maximum number of events you can attend.
     * 
     * Example 1:
     * https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/
     * Input: events = [[1,2],[2,3],[3,4]]
     * Output: 3
     * Explanation: You can attend all the three events.
     * One way to attend them all is as shown.
     * Attend the first event on day 1.
     * Attend the second event on day 2.
     * Attend the third event on day 3.
     * 
     * Example 2:
     * 
     * Input: events= [[1,2],[2,3],[3,4],[1,2]]
     * Output: 4
     * 
     * Example 3:
     * 
     * Input: events = [[1,4],[4,4],[2,2],[3,4],[1,1]]
     * Output: 4
     * 
     * Example 4:
     * 
     * Input: events = [[1,100000]]
     * Output: 1
     * 
     * Example 5:
     * 
     * Input: events = [[1,1],[1,2],[1,3],[1,4],[1,5],[1,6],[1,7]]
     * Output: 7
     * 
     * Constraints:
     * 1 <= events.length <= 10^5
     * events[i].length == 2
     * 1 <= events[i][0] <= events[i][1] <= 10^5
     */
    public class Maximum_Number_of_Events_That_Can_Be_Attended
    {
        public int MaxEvents(int[][] events)
        {
            // Greedy, still needs to be proved.
            var pq = new PriorityQueue<int>(Comparer<int>.Create((x, y) => y - x));
            Array.Sort(events, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
            int result = 0, i = 0;
            for (int d = 1; d <= 100000; d++)
            {
                // Add all the events that starts at this day.
                while (i < events.Length && events[i][0] == d) pq.Add(events[i++][1]);

                // Delete all the events that ends before this day (and we can't attend
                // them because our schedule was full).
                while (pq.Count > 0 && pq.PeekTop() < d) pq.DeleteTop();

                // On this day, let's attend the event that has the minimum ending day.
                // For those events that have greater ending day, we might still have
                // chance to attend them in future days.
                if (pq.Count > 0)
                {
                    pq.DeleteTop();
                    result++;
                }
            }
            return result;
        }
    }
}
