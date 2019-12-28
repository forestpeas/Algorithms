using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1288. Remove Covered Intervals
     * 
     * Given a list of intervals, remove all intervals that are covered by another interval in the list.
     * Interval [a,b) is covered by interval [c,d) if and only if c <= a and b <= d.
     * 
     * After doing so, return the number of remaining intervals.
     * 
     * Example 1:
     * 
     * Input: intervals = [[1,4],[3,6],[2,8]]
     * Output: 2
     * Explanation: Interval [3,6] is covered by [2,8], therefore it is removed.
     */
    public class Remove_Covered_Intervals
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            // Be careful with this test case: [1,4], [1,6].
            Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]));
            int result = intervals.Length;
            int rightBound = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][1] <= rightBound) result--;
                else rightBound = intervals[i][1];
            }
            return result;
        }
    }
}
