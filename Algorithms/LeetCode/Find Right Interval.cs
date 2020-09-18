using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 436. Find Right Interval
     * 
     * You are given an array of intervals, where intervals[i] = [starti, endi] and each starti is unique.
     * 
     * The right interval for an interval i is an interval j such that startj >= endi and startj is minimized.
     * 
     * Return an array of right interval indices for each interval i. If no right interval exists for interval i,
     * then put -1 at index i.
     * 
     * Example 1:
     * 
     * Input: intervals = [[1,2]]
     * Output: [-1]
     * Explanation: There is only one interval in the collection, so it outputs -1.
     * Example 2:
     * 
     * Input: intervals = [[3,4],[2,3],[1,2]]
     * Output: [-1,0,1]
     * Explanation: There is no right interval for [3,4].
     * The right interval for [2,3] is [3,4] since start0 = 3 is the smallest start that is >= end1 = 3.
     * The right interval for [1,2] is [2,3] since start1 = 2 is the smallest start that is >= end2 = 2.
     * Example 3:
     * 
     * Input: intervals = [[1,4],[2,3],[3,4]]
     * Output: [-1,2,-1]
     * Explanation: There is no right interval for [1,4] and [3,4].
     * The right interval for [2,3] is [3,4] since start2 = 3 is the smallest start that is >= end1 = 3.
     */
    public class Find_Right_Interval
    {
        public int[] FindRightInterval(int[][] intervals)
        {
            var originalIdx = new Dictionary<int, int>();
            for (int i = 0; i < intervals.Length; i++)
                originalIdx.Add(intervals[i][0], i);

            int[] starts = intervals.Select(interval => interval[0]).OrderBy(s => s).ToArray();
            int[] res = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                int idx = Array.BinarySearch(starts, intervals[i][1]);
                if (idx < 0) idx = ~idx;
                res[i] = idx == starts.Length ? -1 : originalIdx[starts[idx]];
            }
            return res;
        }
    }
}
