using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 56. Merge Intervals
     * 
     * Given a collection of intervals, merge all overlapping intervals.
     * 
     * Example 1:
     * 
     * Input: [[1,3],[2,6],[8,10],[15,18]]
     * Output: [[1,6],[8,10],[15,18]]
     * Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
     * 
     * Example 2:
     * 
     * Input: [[1,4],[4,5]]
     * Output: [[1,5]]
     * Explanation: Intervals [1,4] and [4,5] are considered overlapping.
     */
    public class MergeIntervals
    {
        private class Comparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return x[0].CompareTo(y[0]);
            }
        }

        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, new Comparer());
            // "i" is the fast runner, and "j" is the slow runner.
            int j = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= intervals[j][1])
                {
                    intervals[j][1] = Math.Max(intervals[j][1], intervals[i][1]);
                }
                else
                {
                    intervals[++j] = intervals[i];
                }
            }
            return intervals.Take(j + 1).ToArray();
        }
    }
}
