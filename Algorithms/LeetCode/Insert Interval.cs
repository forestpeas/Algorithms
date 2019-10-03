using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 57. Insert Interval
     * 
     * Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
     * You may assume that the intervals were initially sorted according to their start times.
     * 
     * Example 1:
     * 
     * Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
     * Output: [[1,5],[6,9]]
     * 
     * Example 2:
     * 
     * Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
     * Output: [[1,2],[3,10],[12,16]]
     * Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
     */
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                // Merge newInterval with intervals[i].
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }

            result.Add(newInterval);
            while (i < intervals.Length) result.Add(intervals[i++]);
            return result.ToArray();
        }
    }
}
